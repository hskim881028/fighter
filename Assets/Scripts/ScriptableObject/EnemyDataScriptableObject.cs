using System.Collections.Generic;
using Fighter.Data;
using UnityEngine;

namespace Fighter.ScriptableObject {
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/Data/Enemy", order = 11)]
    public class EnemyDataScriptableObject : DataScriptableObject{
        public List<EnemyData> Data;
    }
}
