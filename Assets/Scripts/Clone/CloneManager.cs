using System.Collections.Generic;
using System.Linq;
using Clone;
using Fighter.Action;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.View;
using UnityEngine;

namespace Fighter.Manager {
    public class CloneManager : MonoBehaviour {
        private readonly Dictionary<int, Clone.Clone> _clones = new Dictionary<int, Clone.Clone>();

        public CharacterModel SpawnPlayer(ActionHandler actionHandler) {
            var model = new CharacterModel(Vector3.zero, 5.0f, 10);

            if (TryGetClone(CloneType.Player, out var clone)) {
                clone.OnInitialize(model);
            }
            else {
                var prefab = ResourceManager.GetPlayer(0);
                var player = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                var view = player.GetComponent<PlayerView>();
                var id = _clones.Count;
                model = new CharacterModel(id, Vector3.zero, 5.0f, 10);
                var presenter = new PlayerPresenter(model, view, actionHandler);
                var newClone = new Clone.Clone(CloneType.Player, model, presenter, view);
                _clones.Add(id, newClone);
            }

            return model;
        }

        public void UpdateAll() {
            foreach (var clone in _clones) {
                clone.Value.Update();
            }
        }

        public void Destroy(int id) {
            if (_clones.ContainsKey(id)) {
                _clones[id].Destroy();
            }
        }

        private bool TryGetClone(CloneType type, out Clone.Clone clone) {
            clone = _clones.FirstOrDefault(x => x.Value.Type.Equals(type) && !x.Value.IsActive).Value;
            return clone != null;
        }
    }
}