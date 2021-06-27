using UnityEngine;
using UniRx;

namespace Fighter.Model {
    public class Model {
        public int ID { get; private set; }

        public ReactiveProperty<int> HP { get; } = new ReactiveProperty<int>();
        public ReactiveProperty<bool> Active { get; } = new ReactiveProperty<bool>();
        public ReactiveProperty<Vector3> Position { get; } = new ReactiveProperty<Vector3>();
        public ReactiveProperty<float> Speed { get; } = new ReactiveProperty<float>();
        public ReactiveProperty<Vector3> Direction { get; } = new ReactiveProperty<Vector3>();
        public ReactiveProperty<Vector3> Look { get; } = new ReactiveProperty<Vector3>();

        protected Model(int id, Vector3 startPosition, float speed, int hp) {
            ID = id;
            Active.Value = true;
            Position.Value = startPosition;
            Speed.Value = speed;
            HP.Value = hp;
        }
        
        public void Initialize(int id, Model model) {
            ID = id;
            Position.Value = model.Position.Value;
            Active.Value = model.Active.Value;
            Direction.Value = model.Direction.Value;
            Speed.Value = Speed.Value;
        }
    }
}