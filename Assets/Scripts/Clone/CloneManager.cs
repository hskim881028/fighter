using System.Collections.Generic;
using System.Linq;
using Fighter.Action;
using Fighter.Clone;
using Fighter.Model;
using UnityEngine;

namespace Fighter.Manager {
    public static class CloneManager {
        private static CloneSpawner _cloneSpawner;
        private static ActionHandler _actionHandler;

        private static readonly Dictionary<int, Clone.Clone> _clones = new Dictionary<int, Clone.Clone>();
        public static int Count => _clones.Count;

        public static void Initialize(CloneSpawner cloneSpawner, ActionHandler actionHandler) {
            _cloneSpawner = cloneSpawner;
            _actionHandler = actionHandler;
        }

        public static void UpdateAll() {
            foreach (var clone in _clones) {
                clone.Value.Update();
            }
        }

        public static void Add(int id, Clone.Clone clone) {
            _clones.Add(id, clone);
        }

        public static void Destroy(int id) {
            if (_clones.ContainsKey(id)) {
                _clones[id].Destroy();
            }
        }

        public static bool TryGetClone(CloneType type, out KeyValuePair<int, Clone.Clone> pair) {
            pair = _clones.FirstOrDefault(x => x.Value.Type.Equals(type) && !x.Value.IsActive);
            return pair.Value != null;
        }

        public static Character SpawnPlayer() {
            _cloneSpawner.SpawnPlayer(_actionHandler, out var model);
            return model;
        }

        public static void SpawnProjectile(Vector3 startPosition, Vector3 direction, float speed, float range) {
            _cloneSpawner.SpawnProjectile(_actionHandler, startPosition, direction, speed, range);
        }
    }
}