using System.Collections.Generic;
using Fighter.Data;
using UnityEngine;

namespace Fighter.ScriptableObject {
    [CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/Data/Character", order = 2)]
    public class CharacterDataScriptableObject : DataScriptableObject {
        public List<CharacterData> Data;
    }
}