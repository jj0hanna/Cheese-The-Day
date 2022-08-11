using UnityEngine;

namespace Animation
{
    public class SpinningObjectAnimation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 50;

        void Update() 
        {
            transform.Rotate(0,0 , rotationSpeed * Time.deltaTime);
        }
    }
}