using Fighter.Data;
using UnityEngine;

namespace Fighter.Model {
    public class Enemy : Character {
        public float SearchRange { get; private set; }
        
        public override void Initialize(int id, IData data, Vector3 position, Vector3 direction) {
            base.Initialize(id, data, position, direction);
            if (data is EnemyData enemyData) {
                SearchRange = enemyData.SearchRange;
            }
        }
    }
}