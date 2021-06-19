using Fighter.Model;
using UnityEngine;

namespace Fighter.Action {
    public class LookAtAction : IAction {
        private readonly CharacterModel _characterModel;
        private readonly Vector3 _direction;

        public LookAtAction(CharacterModel characterModel, Vector3 direction) {
            _characterModel = characterModel;
            _direction = direction;
        }

        public void Execute() {
            _characterModel.Direction.Value = _direction;
            var position = _characterModel.Position.Value;
            var speed = _characterModel.Speed.Value;
            _characterModel.Position.Value = position + _direction * (speed * Time.deltaTime);

            if (_direction.sqrMagnitude > 0) {
                _characterModel.Look.Value = _direction;
            }
        }
    }
}