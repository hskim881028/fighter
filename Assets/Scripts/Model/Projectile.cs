using UnityEngine;

namespace Fighter.Model {
    public class Projectile : Model {
        public float Range { get; }
        private new const int HP = 999;

        public Projectile(Vector3 startPosition, Vector3 direction, float speed, float range)
            : base(startPosition, speed, HP) {
            Direction.Value = direction;
            Range = range;
        }
    }
}