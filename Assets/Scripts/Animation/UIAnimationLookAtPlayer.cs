using System;
using UnityEngine;

namespace Animation
{
    public class UIAnimationLookAtPlayer : MonoBehaviour
    {
        public Camera mainCamera;
        [SerializeField] private Transform target;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void LateUpdate()
        {
            transform.LookAt(target.position);
        }
    }
}