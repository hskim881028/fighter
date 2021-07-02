using System.Collections.Generic;
using System.Linq;
using Fighter.Action;
using Fighter.Clone;
using Fighter.Model;
using Fighter.Type;
using UnityEngine;

namespace Fighter.Manager {
    public static class CloneManager {
        private static ActionHandler _actionHandler;
        private static CloneSpawner _cloneSpawner;

        private static readonly Dictionary<int, Clone.Clone> _clones = new Dictionary<int, Clone.Clone>();
        public static int Count => _clones.Count;

        public static Clone.Clone GetModel(int id) {
            return _clones[id];
        }

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

        public static bool TryGetClone(ResourceType type, out Clone.Clone clone) {
            clone = _clones.FirstOrDefault(x => x.Value.Type.Equals(type) && !x.Value.IsActive).Value;
            return clone != null;
        }

        public static Character ClonePlayer() {
            return _cloneSpawner.SpawnPlayer(_actionHandler);
        }

        public static void CloneProjectile(Vector3 startPosition, Vector3 direction, float speed, float range) {
            _cloneSpawner.SpawnProjectile(_actionHandler, startPosition, direction, speed, range);
        }
    }
}