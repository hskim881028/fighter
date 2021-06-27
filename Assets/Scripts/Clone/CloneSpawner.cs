using Fighter.Action;
using Fighter.Manager;
using UnityEngine;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.Type;
using Fighter.View;

namespace Fighter.Clone {
    public class CloneSpawner : MonoBehaviour {
        public static void SpawnPlayer(ActionHandler actionHandler, out Character model) {
            model = new Character(CloneManager.Count, Vector3.zero, 5.0f, 10);
            Spawn<Character, PlayerView, PlayerPresenter>(ResourceType.Player, actionHandler, model, 0);
        }

        public static void SpawnProjectile(ActionHandler actionHandler,
                                           Vector3 startPosition,
                                           Vector3 direction,
                                           float speed,
                                           float range) {
            var model = new Projectile(CloneManager.Count, startPosition, direction, speed, range);
            Spawn<Projectile, ProjectileView, ProjectilePresenter>(ResourceType.Projectile, actionHandler, model, 0);
        }

        private static void Spawn<T1, T2, T3>(ResourceType resourceType,
                                              ActionHandler actionHandler,
                                              Model.Model model,
                                              int resourceId = 0) where T1 : Model.Model
                                                                  where T2 : View.View
                                                                  where T3 : Presenter<T1, T2> {
            if (CloneManager.TryGetClone(resourceType, out var clone)) {
                clone.Value.Respawn(clone.Key, model);
            }
            else {
                var prefab = ResourceManager.GetPrefab(resourceType, resourceId);
                var instantiate = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                var view = instantiate.GetComponent<T2>();
                var presenter = PresenterFactory.Create<T1, T2, T3>(actionHandler, model, view);
                presenter.Initialize();
                CloneManager.Add(model.ID, new Clone(resourceType, model, presenter, view));
            }
        }
    }
}