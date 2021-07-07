using Fighter.Data;
using UnityEngine;
using UniRx;

namespace Fighter.Model {
    public class Model {
        public int ID { get; private set; }
        public ReactiveProperty<bool> Active { get; } = new ReactiveProperty<bool>();

        public ReactiveProperty<Vector3> Position { get; } = new ReactiveProperty<Vector3>();
        public ReactiveProperty<Vector3> Direction { get; } = new ReactiveProperty<Vector3>();
        public ReactiveProperty<Vector3> Look { get; } = new ReactiveProperty<Vector3>();
        public ReactiveProperty<float> Speed { get; } = new ReactiveProperty<float>();
        public ReactiveProperty<int> Damage { get; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> HP { get; } = new ReactiveProperty<int>();

        public virtual void Initialize(int id, IData data, Vector3 position, Vector3 direction) {
            ID = id;
            
            if (data is BaseData baseData) {
                Look.Value = baseData.Look;
                Speed.Value = baseData.Speed;
                Damage.Value = baseData.Damage;
                HP.Value = baseData.Hp;
            }

            Position.Value = position;
            Direction.Value = direction;
        }
    }
}