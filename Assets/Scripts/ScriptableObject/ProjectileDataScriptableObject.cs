using System.Collections.Generic;
using Fighter.Data;
using UnityEngine;

namespace Fighter.ScriptableObject {
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "ScriptableObject/Data/Projectile", order = 3)]
    public class ProjectileDataScriptableObject : DataScriptableObject {
        public List<ProjectileData> Data;
    }
}