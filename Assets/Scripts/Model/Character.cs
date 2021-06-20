using UnityEngine;

namespace Fighter.Model {
    public class Character : Model {
        public Character(int id, Vector3 startPosition, float speed, int hp)
            : base(id, startPosition, speed, hp) {
            Look.Value = Vector3.right;
        }
    }
}