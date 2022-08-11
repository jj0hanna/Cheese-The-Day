using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianMove : MonoBehaviour
{
    public Transform path;
    public float speed;
    public float requiredDistance;
    public bool reverse;

    private Transform _firstPos;
    private Transform _currentGoal;
    private int _currentIndex;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (path.childCount < 1)
        {
            Debug.LogError("Path of " + transform.name + " is Invalid!");
        }
        else
        {
            _currentGoal = path.GetChild(0);
            _currentIndex = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _currentGoal.position) < requiredDistance)
        {
            if (path.childCount > _currentIndex +1)
            {
                _currentGoal = path.GetChild(_currentIndex + 1);
                _currentIndex = _currentIndex + 1;
            }
            else
            {
                _currentGoal = path.GetChild(0);
                _currentIndex = 0;
            }
        }
        else
        {
            Vector3 adjustedPos = new Vector3(_currentGoal.position.x, transform.position.y, _currentGoal.position.z);
            transform.LookAt(adjustedPos);
            _rigidbody.velocity = transform.forward * speed;
        }
    }
}
