using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Player.Scripts
{
    [CreateAssetMenu(fileName = "new Default PlayerScriptable", menuName = "")]
    public class PlayerScriptable : ScriptableObject
    { 
        public float moveSpeed;
        public float moveSpeedBaseline;
        public float jumpForce;
        public float jumpForceBaseline;
        public float jumpCooldown;
        public float dashForce;
        public float dashCooldown;
        [Range(0,1)]
        public float airSpeedModifier;
        public bool doubleJump;
        public bool dash;
        public bool floatyAirMovement;
    }
}
