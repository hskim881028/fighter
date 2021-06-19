using UniRx;
using UnityEngine;

namespace Fighter.Model {
    public class Character : ICharacter {
        public ReactiveProperty<float> Speed { get; } = new ReactiveProperty<float>();
        public ReactiveProperty<Vector3> Direction { get; } = new ReactiveProperty<Vector3>();
        public ReactiveProperty<Vector3> Look { get; } = new ReactiveProperty<Vector3>();
        public ReactiveProperty<Vector3> Position { get; } = new ReactiveProperty<Vector3>();
    }
}