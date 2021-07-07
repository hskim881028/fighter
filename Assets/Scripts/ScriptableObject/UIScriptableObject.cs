using System.Collections.Generic;
using Fighter.UI;
using UnityEngine;

namespace Fighter.ScriptableObject {
    [CreateAssetMenu(fileName = "UI", menuName = "ScriptableObject/UI", order = 2)]
    public class UIScriptableObject : UnityEngine.ScriptableObject {
        public UIType UIType;
        public List<GameObject> Data;
    }
}