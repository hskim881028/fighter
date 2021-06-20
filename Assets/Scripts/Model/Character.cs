using UnityEngine;

namespace Fighter.Model {
    public class Character : Model {
        public Character(int id, Vector3 startPosition, float speed, int hp) : base(id, startPosition, speed, hp) {
        }

        public Character(Vector3 startPosition, float speed, int hp) : base(startPosition, speed, hp) {
        }
    }
}