using Audio;
using ScriptableObjects.Player.Scripts;
using UnityEngine;
public class player_movement : MonoBehaviour
{
    public PlayerScriptable playerScriptable;
    public Camera mainCamera;
    
    private Vector3 _moveInput;
    private float _currentAngle;
    private float _goalAngle;
    [SerializeField] private Upgrade boost;
    [SerializeField] private Upgrade doubleJump;
    [SerializeField] private Upgrade moveSpeed;
    [SerializeField] private ParticleSystem dust;
    
    private float _timeBetweenJumps;
    private float _timeBetweenDash;
    private float _timeLeftDisabled;
    private float _smoothedAnimBlend;
    private bool _hasDoubleJumped;
    
    private player_controls_script _playerControls;
    private Rigidbody _playerRigidbody;
    private CapsuleCollider _playerCollider;
    private Animator _animator;
    private RandomSoundPlayer _randomJumpSound;

    private void Awake()
    {
        _playerControls = new player_controls_script();
        _playerRigidbody = GetComponent<Rigidbody>();
        _playerCollider = GetComponent<CapsuleCollider>();
        _animator = GetComponent<Animator>();
        _randomJumpSound = GetComponent<RandomSoundPlayer>();
        
        playerScriptable.doubleJump = !doubleJump.GetCurrentLevelValue().Equals(0);
        playerScriptable.dash = !boost.GetCurrentLevelValue().Equals(0);
        playerScriptable.jumpForce = playerScriptable.jumpForceBaseline;
        
        if (!moveSpeed.GetCurrentLevelValue().Equals( 0))
        {
            playerScriptable.moveSpeed = moveSpeed.GetCurrentLevelValue();
        }
        else 
        { 
            playerScriptable.moveSpeed = playerScriptable.moveSpeedBaseline;
        }
    }
 
    private void OnEnable()
    {
        _playerControls.player_map.Enable();
    }
    private void OnDisable()
    {
        _playerControls.player_map.Disable();
    }
 
    private void Update() // uses Update due to WasPressedThisFrame seemingly not working in FixedUpdate
    {
        _moveInput = _playerControls.player_map.movement.ReadValue<Vector3>();
        if (!(_timeLeftDisabled < 0)) return;
        if (_playerControls.player_map.Jump.WasPressedThisFrame())
        {
            if (IsGrounded() && _timeBetweenJumps > playerScriptable.jumpCooldown) // checks if player can jump normally
            {
                _hasDoubleJumped = false;
                _playerRigidbody.AddForce(0f, playerScriptable.jumpForce, 0f, ForceMode.VelocityChange);
                _groundSnapTimer = 0.3f;
                _animator.SetTrigger(Jump);
                _timeBetweenJumps = 0;
                AudioManager.PlaySound("JumpSound"); // jumpsound
                _randomJumpSound.PlayRandomSound();
            }
            else if (playerScriptable.doubleJump && !_hasDoubleJumped) // otherwise checks doublejump
            {
                var velocity = _playerRigidbody.velocity;
                if (_playerRigidbody.velocity.y <= 0)
                {
                    velocity = new Vector3(velocity.x, 0f, velocity.z);
                }
                else
                {
                    velocity = new Vector3(velocity.x, velocity.y * 0.5f, velocity.z);
                }
                _playerRigidbody.velocity = velocity;
                _playerRigidbody.AddForce(0f, playerScriptable.jumpForce, 0f, ForceMode.VelocityChange);
                _animator.SetTrigger(DoubleJump);
                _hasDoubleJumped = true;
                AudioManager.PlaySound("JumpSound");  // jumpsound
                _randomJumpSound.PlayRandomSound();
            }
        } 
        Vector3 movement = mainCamera.transform.right * _moveInput.x + mainCamera.transform.forward * _moveInput.z;
        if (_playerControls.player_map.boost.WasPressedThisFrame() && _timeBetweenDash > playerScriptable.dashCooldown && playerScriptable.dash) // dash
        {
            var velocity = _playerRigidbody.velocity;
            velocity = new Vector3(velocity.x, 0f, velocity.z);
            _playerRigidbody.velocity = velocity;
            _timeLeftDisabled = playerScriptable.dashCooldown / 2; // could be a part of playerscriptable
            _timeBetweenDash = 0;
            movement.y = 0;
            _playerRigidbody.velocity = movement.normalized * playerScriptable.dashForce * playerScriptable.moveSpeed + Vector3.up * _playerRigidbody.velocity.y;
        }
        if (_timeBetweenJumps <= playerScriptable.jumpCooldown)
        {
                _timeBetweenJumps += Time.deltaTime;
        }
        if (_timeBetweenDash <= playerScriptable.dashCooldown)
        {
                 _timeBetweenDash += Time.deltaTime;
        }

        if (movement.x != 0 || movement.z != 0)
        {
            _goalAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        }

        _currentAngle = Mathf.MoveTowardsAngle(_currentAngle, CustomClasses.DampAngle(_currentAngle, _goalAngle, 7f, Time.deltaTime), 700f * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, _currentAngle, 0f);

        HandleAnimator();
    }

    void HandleAnimator()
    {
        bool isSprinting = true;

        float moveBlend = 0f;
        if (_moveInput.magnitude > 0)
        {
            moveBlend = 1f;
        }

        _smoothedAnimBlend = Mathf.MoveTowards(_smoothedAnimBlend, moveBlend, Time.deltaTime * 5f);

        _animator.SetFloat("Movement Blend", _smoothedAnimBlend);

        _animator.SetFloat("Movement Speed", Mathf.Lerp(1f, isSprinting ? playerScriptable.moveSpeed : playerScriptable.moveSpeed * 0.5f, _smoothedAnimBlend * 2f));

        _animator.SetBool("IsGrounded", IsGroundedAnim());

        _animator.SetBool("IsMoving", _moveInput.magnitude > 0);
    }
 
    private void FixedUpdate() // Regular movement here
    {
        UpdateGrounded(); 

        if (_timeLeftDisabled < 0)
        {
            Vector3 movement = mainCamera.transform.right * _moveInput.x + mainCamera.transform.forward * _moveInput.z;
            movement.y = 0;
            if (IsGrounded())
            {
                _playerRigidbody.velocity = movement.normalized * playerScriptable.moveSpeed + Vector3.up * _playerRigidbody.velocity.y;
                if (Mathf.Abs(_playerRigidbody.velocity.x) > 0.2 || Mathf.Abs(_playerRigidbody.velocity.z) > 0.2)
                {
                    CreateDust();
                }
            }
            else if (playerScriptable.floatyAirMovement)
            {
                _playerRigidbody.velocity += movement.normalized * playerScriptable.moveSpeed * playerScriptable.airSpeedModifier * 0.1f;
            }
            else
            {
                _playerRigidbody.velocity = movement.normalized * playerScriptable.moveSpeed * playerScriptable.airSpeedModifier + Vector3.up * _playerRigidbody.velocity.y;;
            }
        }
        else
        {
            _timeLeftDisabled -= Time.deltaTime;
        }
    }

    private float _groundedTimer;
    private float _groundSnapTimer;
    private static readonly int DoubleJump = Animator.StringToHash("DoubleJump");
    private static readonly int Jump = Animator.StringToHash("Jump");

    private void UpdateGrounded()
    {
        _groundedTimer -= Time.fixedDeltaTime;

        _groundSnapTimer -= Time.fixedDeltaTime;

        if (Physics.SphereCast(transform.position + Vector3.up * (_playerCollider.radius + 0.1f), _playerCollider.radius * 0.95f, Vector3.down, out RaycastHit hit, 0.4f))
        {
            if (hit.collider.isTrigger)
            {
                return;
            }
            _groundedTimer = 0.1f;

            if (_groundSnapTimer <= 0f)
            {
                _hasDoubleJumped = false;
                _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, 0f, _playerRigidbody.velocity.z);
            }
        }
    }
    private bool IsGrounded()
    {
        return _groundedTimer > 0f;
    }

    private bool IsGroundedAnim()
    {
        return _groundSnapTimer <= 0f && _groundedTimer == 0.1f;
    }
    public void DisableControls(float disableTime)
    {
        if (_timeLeftDisabled < disableTime)
        {
            _timeLeftDisabled = disableTime;
        }
    }

    void CreateDust()
    {
        if (!dust.isPlaying)
        {
            dust.Play();
        }
    }
}
