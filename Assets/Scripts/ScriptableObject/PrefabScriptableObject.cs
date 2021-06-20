using System.Collections.Generic;
using UnityEngine;

namespace Fighter.ScriptableObject {
    [CreateAssetMenu(fileName = "Prefabs", menuName = "ScriptableObject/Prefabs", order = 1)]
    public class PrefabScriptableObject : UnityEngine.ScriptableObject {
        public List<GameObject> players;
        public List<GameObject> projectiles;
    }
}