using UnityEngine;

namespace Fighter.Model {
    public class CharacterModel : Model {
        public CharacterModel(int id, Vector3 startPosition, float speed, int hp) : base(id, startPosition, speed, hp) {
        }

        public CharacterModel(Vector3 startPosition, float speed, int hp) : base(startPosition, speed, hp) {
        }
    }
}