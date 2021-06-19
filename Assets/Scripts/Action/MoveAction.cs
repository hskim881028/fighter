using Fighter.Model;
using UnityEngine;

namespace Fighter.Action {
    public class MoveAction : IAction {
        private readonly Character _character;
        public MoveAction(Character character) {
            _character = character;
        }

        public void Execute() {
            var speed = _character.Speed.Value;
            var direction = _character.Direction.Value;
            var position = _character.Position.Value;
            _character.Position.Value = position + direction * (speed * Time.deltaTime);
        }
    }
}
