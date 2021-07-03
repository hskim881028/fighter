using Fighter.Data;
using UnityEngine;

namespace Fighter.Model {
    public class Character : Model {
        public float Avoid { get; private set; }

        public override void Initialize(int id, IData data, Vector3 position, Vector3 direction) {
            base.Initialize(id, data, position, direction);
            if (data is CharacterData characterData) {
                Avoid = characterData.Avoid;
            }
        }
    }
}