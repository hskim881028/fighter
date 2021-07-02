using UniRx;
using UnityEngine;

namespace Fighter.Model {
    public class Character : Model {
        public ReactiveProperty<float> Avoid { get; } = new ReactiveProperty<float>();

        public Character(int id, Vector3 startPosition, float speed, float avoid, int hp)
            : base(id, startPosition, speed, hp) {
            Look.Value = Vector3.right;
            Avoid.Value = avoid;
        }
    }
}