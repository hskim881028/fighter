using System.Collections.Generic;
using Fighter.Enum;
using UnityEngine;

namespace Fighter.ScriptableObject {
    [CreateAssetMenu(fileName = "Prefab", menuName = "ScriptableObject/Prefab", order = 1)]
    public class PrefabScriptableObject : UnityEngine.ScriptableObject {
        public CloneType CloneType;
        public List<GameObject> Data;
    }
}