using UniRx;
using UnityEngine;

namespace Fighter.Model {
    public class Player {
        public ReactiveProperty<Vector3> Position { get; } = new ReactiveProperty<Vector3>();
    }
}
