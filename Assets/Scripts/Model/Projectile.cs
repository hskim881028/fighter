using UnityEngine;

namespace Fighter.Model {
    public class Projectile : Model {
        public float Range { get; }
        private new const int HP = 999;

        public Projectile(int id, Vector3 startPosition, Vector3 direction, float speed, float range)
            : base(id, startPosition, speed, HP) {
            Direction.Value = direction;
            Range = range;
        }
    }
}