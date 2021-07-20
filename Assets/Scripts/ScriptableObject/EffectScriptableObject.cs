using System.Collections.Generic;
using Fighter.Effect;
using UnityEngine;

namespace Fighter.ScriptableObject {
    [CreateAssetMenu(fileName = "Effect", menuName = "ScriptableObject/Effect", order = 2)]
    public class EffectScriptableObject : UnityEngine.ScriptableObject {
        public EffectType effectType;
        public List<GameObject> Data;
    }
}