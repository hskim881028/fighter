using System.Collections.Generic;
using UnityEngine;

namespace Fighter.ScriptableObject {
    [CreateAssetMenu(fileName = "Players", menuName = "ScriptableObject/Player", order = 1)]
    public class PlayerScriptableObject : UnityEngine.ScriptableObject {
        public List<GameObject> players;
    }
}