using UnityEngine;

namespace Fighter.Model {
    public class Player : Character {
        
        public Player(Vector3 startPosition, float speed) {
            Speed.Value = speed;
        }
    }
}
