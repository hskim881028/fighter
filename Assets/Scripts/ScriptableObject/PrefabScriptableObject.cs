using System.Collections.Generic;
using Fighter.Clone;
using UnityEngine;

namespace Fighter.ScriptableObject {
    [CreateAssetMenu(fileName = "Prefab", menuName = "ScriptableObject/Prefab", order = 1)]
    public class PrefabScriptableObject : UnityEngine.ScriptableObject {
        public CloneType cloneType;
        public List<GameObject> Data;
    }
}