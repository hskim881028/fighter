using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Fighter.Action;
using Fighter.Enum;
using Fighter.Factory;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.View;
using UnityEngine;

namespace Fighter.Manager {
    public static class CloneManager {
        private static ActionHandler _actionHandler;
        private static readonly Dictionary<int, Clone.Clone> _clones = new Dictionary<int, Clone.Clone>();
        private static Transform _pool;

        public static void Initialize(ActionHandler actionHandler) {
            _pool = new GameObject("ObjectPool").transform;
            _actionHandler = actionHandler;
        }

        public static void UpdateAll() {
            foreach (var clone in _clones) {
                clone.Value.Update();
            }
        }

        public static void Destroy(int id) {
            if (_clones.ContainsKey(id)) {
                _clones[id].Destroy();
            }
        }

        public static (Model.Model, Model.Model) GetModels((int, int) ids) {
            var (attackerId, defenderId) = ids;
            var attacker = _clones[attackerId].Model;
            var defender = _clones[defenderId].Model;
            return (attacker, defender);
        }

        public static Character GetPlayerModel() {
            return _clones.FirstOrDefault(x => x.Value.Type.Equals(CloneType.Player)).Value.Model as Character;
        }

        public static void ClonePlayer(Vector3 position, Vector3 direction) {
            Spawn<Character, PlayerView, PlayerPresenter>(CloneType.Player, _actionHandler, position, direction, 0);
        }

        public static void CloneEnemy(Vector3 position, Vector3 direction) {
            Spawn<Character, EnemyView, EnemyPresenter>(CloneType.Enemy, _actionHandler, position, direction, 0);
        }

        public static void CloneProjectile(Vector3 position, Vector3 direction) {
            Spawn<Projectile, ProjectileView, ProjectilePresenter>(CloneType.Projectile, _actionHandler, position,
                                                                   direction, 0);
        }

        private static void Spawn<T1, T2, T3>(CloneType type,
                                              ActionHandler actionHandler,
                                              Vector3 position,
                                              Vector3 direction,
                                              int cloneId = 0) where T1 : Model.Model, new()
                                                               where T2 : View.View
                                                               where T3 : Presenter<T1, T2> {
            if (!System.Enum.IsDefined(typeof(CloneType), type))
                throw new InvalidEnumArgumentException(nameof(type), (int) type, typeof(CloneType));
            if (!System.Enum.IsDefined(typeof(CloneType), type))
                throw new InvalidEnumArgumentException(nameof(type), (int) type, typeof(CloneType));
            var data = GameManager.GetData(type, cloneId);
            if (TryGetClone(type, out var clone)) {
                clone.Respawn(data, position, direction);
            }
            else {
                var model = new T1();
                var prefab = GameManager.GetClone(type, cloneId);
                var instantiate = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity, _pool);
                var instanceID = instantiate.GetInstanceID();
                var view = instantiate.GetComponent<T2>();
                var presenter = PresenterFactory.Create<T1, T2, T3>(actionHandler, model, view);
                _clones.Add(instanceID, new Clone.Clone(type, presenter, instanceID, data, position, direction));
            }
        }

        private static bool TryGetClone(CloneType type, out Clone.Clone clone) {
            clone = _clones.FirstOrDefault(x => x.Value.Type.Equals(type) && !x.Value.IsActive.Value).Value;
            return clone != null;
        }
    }
}