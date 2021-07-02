using Fighter.Action;
using Fighter.Manager;
using UnityEngine;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.Type;
using Fighter.View;

namespace Fighter.Clone {
    public class CloneSpawner : MonoBehaviour {
        public Character SpawnPlayer(ActionHandler actionHandler) {
            var model = new Character(Vector3.zero, 5.0f, 1.0f, 10);
            Spawn<Character, PlayerView, PlayerPresenter>(ResourceType.Player, actionHandler, model, 0);
            return model;
        }

        public void SpawnProjectile(ActionHandler actionHandler,
                                    Vector3 startPosition,
                                    Vector3 direction,
                                    float speed,
                                    float range) {
            var model = new Projectile(startPosition, direction, speed, range);
            Spawn<Projectile, ProjectileView, ProjectilePresenter>(ResourceType.Projectile, actionHandler, model, 0);
        }

        private void Spawn<T1, T2, T3>(ResourceType resourceType,
                                       ActionHandler actionHandler,
                                       Model.Model model,
                                       int resourceId = 0) where T1 : Model.Model
                                                           where T2 : View.View
                                                           where T3 : Presenter<T1, T2> {
            if (CloneManager.TryGetClone(resourceType, out var clone)) {
                clone.Respawn(model);
            }
            else {
                var prefab = ResourceManager.GetPrefab(resourceType, resourceId);
                var instantiate = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                var view = instantiate.GetComponent<T2>();
                model.ID = instantiate.GetInstanceID();
                var presenter = PresenterFactory.Create<T1, T2, T3>(actionHandler, model, view);
                presenter.Initialize();
                CloneManager.Add(model.ID, new Clone(resourceType, model, presenter, view));
            }
        }
    }
}