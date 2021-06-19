using UnityEngine;
using UniRx;

namespace Fighter.Model {
    public abstract class Model {
        public int ID { get; }

        public ReactiveProperty<int> HP { get; } = new ReactiveProperty<int>();
        public ReactiveProperty<bool> Active { get; } = new ReactiveProperty<bool>();
        public ReactiveProperty<Vector3> Position { get; } = new ReactiveProperty<Vector3>();
        public ReactiveProperty<float> Speed { get; } = new ReactiveProperty<float>();
        public ReactiveProperty<Vector3> Direction { get; } = new ReactiveProperty<Vector3>();
        public ReactiveProperty<Vector3> Look { get; } = new ReactiveProperty<Vector3>();

        protected Model(int id, Vector3 startPosition, float speed, int hp) {
            Active.Value = true;
            ID = id;
            Position.Value = startPosition;
            Speed.Value = speed;
            HP.Value = hp;
        }

        protected Model(Vector3 startPosition, float speed, int hp) {
            Active.Value = true;
            Position.Value = startPosition;
            Speed.Value = speed;
            HP.Value = hp;
        }
    }
}