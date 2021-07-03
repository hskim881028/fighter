using System.Collections.Generic;
using System.Linq;
using Fighter.Action;
using Fighter.Clone;
using Fighter.Factory;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.View;
using UnityEngine;

namespace Fighter.Manager {
    public static class CloneManager {
        private static ActionHandler _actionHandler;
        private static readonly Dictionary<int, Clone.Clone> _clones = new Dictionary<int, Clone.Clone>();

        public static void Initialize(ActionHandler actionHandler) {
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

        public static Character ClonePlayer(Vector3 position, Vector3 direction) {
            var model = Spawn<Character, PlayerView, PlayerPresenter>(CloneType.Player, _actionHandler, position,
                                                                      direction, 0);
            return model as Character;
        }

        public static void CloneEnemy(Vector3 position, Vector3 direction) {
            var model = Spawn<Character, EnemyView, EnemyPresenter>(CloneType.Enemy, _actionHandler, position,
                                                                    direction, 0);
        }

        public static void CloneProjectile(Vector3 position, Vector3 direction) {
            Spawn<Projectile, ProjectileView, ProjectilePresenter>(CloneType.Projectile, _actionHandler, position,
                                                                   direction, 0);
        }

        private static Model.Model Spawn<T1, T2, T3>(CloneType cloneType,
                                                     ActionHandler actionHandler,
                                                     Vector3 position,
                                                     Vector3 direction,
                                                     int cloneId = 0) where T1 : Model.Model, new()
                                                                      where T2 : View.View
                                                                      where T3 : Presenter<T1, T2> {
            var model = new T1();
            var data = GameManager.GetData(cloneType, cloneId);
            if (TryGetClone(cloneType, out var clone)) {
                clone.Respawn(data, position, direction);
            }
            else {
                var prefab = GameManager.GetPrefab(cloneType, cloneId);
                var instantiate = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);

                var instanceID = instantiate.GetInstanceID();
                model.Initialize(instanceID, data, position, direction);
                var view = instantiate.GetComponent<T2>();
                var presenter = PresenterFactory.Create<T1, T2, T3>(actionHandler, model, view);
                presenter.Initialize();
                _clones.Add(instanceID, new Clone.Clone(cloneType, model, presenter, view));
            }

            return model;
        }

        private static bool TryGetClone(CloneType type, out Clone.Clone clone) {
            clone = _clones.FirstOrDefault(x => x.Value.Type.Equals(type) && !x.Value.IsActive).Value;
            return clone != null;
        }
    }
}