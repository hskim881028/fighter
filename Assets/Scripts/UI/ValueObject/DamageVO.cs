using UnityEngine;

namespace Fighter.UI.ValueObject {
    public readonly struct DamageVO : ValueObject {
        public Vector3 Position { get; }
        public float Damage { get; }

        public DamageVO(Vector3 position, float damage) {
            Position = position;
            Damage = damage;
        }
    }
}
