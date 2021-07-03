using Fighter.Data;
using UnityEngine;

namespace Fighter.Model {
    public class Projectile : Model {
        public float Range { get; private set; }
        public override void Initialize(int id, IData data, Vector3 position, Vector3 direction) {
            base.Initialize(id, data, position, direction);
            if (data is ProjectileData projectileData) {
                Range = projectileData.Range;
            }
        }
    }
}