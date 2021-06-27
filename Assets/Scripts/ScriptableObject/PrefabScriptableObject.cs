using System.Collections.Generic;
using UnityEngine;

namespace Fighter.ScriptableObject {
    [CreateAssetMenu(fileName = "Prefabs", menuName = "ScriptableObject/Player Prefabs", order = 1)]
    public class PrefabScriptableObject : UnityEngine.ScriptableObject {
        public List<GameObject> data;
    }
}