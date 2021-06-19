using Fighter.Model;
using UnityEngine;

namespace Fighter.Action {
    public class LookAtAction : IAction {
        private readonly Character _character;
        private readonly Vector3 _direction;
        public LookAtAction(Character character, Vector3 direction) {
            _character = character;
            _direction = direction;
        }

        public void Execute() {
            _character.Direction.Value = _direction;
            var position = _character.Position.Value;
            var speed = _character.Speed.Value;
            _character.Position.Value = position + _direction * (speed * Time.deltaTime);
        }
    }                                                                                       
}
