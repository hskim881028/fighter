using UniRx;
using UnityEngine;

namespace Fighter.View {
    public class ProjectileView : View {
        public Subject<(int attacker , int defender)> TriggerEnter { get; } = new Subject<(int, int)>();

        protected override void Initialize() {
        }

        private void OnTriggerEnter2D(Collider2D other) {
            TriggerEnter.OnNext((gameObject.GetInstanceID(), other.gameObject.GetInstanceID()));
        }
    }
}