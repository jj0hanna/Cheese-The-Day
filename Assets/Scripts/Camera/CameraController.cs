using ScriptableObjects.Player.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class CameraController : MonoBehaviour
{
    public Transform player;
    [RangeAttribute(5, 90)] public float maxAngle = 30;
    [RangeAttribute(0, 90)] public float minAngle = 15;

    public float maxDistance;
    public float minDistance;
    [SerializeField] private CameraScriptable cameraScriptable;
    private float _distance;
    private bool _paused;
    private Vector2 _cameraRot; 
    
    // Update is called once per frame
    private void Start()
    {
        _cameraRot = new Vector2(180,0);
        _cameraRot.y = Mathf.Clamp(_cameraRot.y, -minAngle, maxAngle);
    }

    void Update() 
    {
        if (!_paused)
        {
            _cameraRot += Pointer.current.delta.ReadValue() * cameraScriptable.sensitivityMultiplier;
            _cameraRot.y = Mathf.Clamp(_cameraRot.y, -minAngle, maxAngle);
        }
    }
    
    void LateUpdate() 
    {
        if (!_paused)
        {
            var cameraTransform = transform;
            cameraTransform.eulerAngles = new Vector3(-_cameraRot.y, _cameraRot.x, 0f);
            Vector3 desiredCameraPos = player.position + cameraTransform.up - cameraTransform.forward * maxDistance;
            if (Physics.Linecast(player.position + player.up, desiredCameraPos, out RaycastHit hit))
            {
                _distance = Mathf.Clamp((hit.distance * 0.87f), minDistance, maxDistance);
            }
            else
            {
                _distance = maxDistance;
            }

            cameraTransform.position =
                player.position + cameraTransform.up - cameraTransform.forward * _distance;
        }
    }

    public void pauseCam() // incorrect naming scheme, hard to change
    {
        _paused = true;
    }

    public void resumeCam()
    {
        _paused = false;
    }
}
