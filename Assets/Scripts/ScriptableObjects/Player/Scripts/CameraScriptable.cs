using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Player.Scripts
{
    [CreateAssetMenu(fileName = "new Default CameraScriptable", menuName = "")]
    public class CameraScriptable : ScriptableObject
    {
        public float sensitivityMultiplier;
    }
}
