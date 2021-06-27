using Fighter.Action;
using Fighter.Manager;
using UnityEngine;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.View;

namespace Fighter.Clone {
    public class CloneSpawner : MonoBehaviour {
        public void SpawnPlayer(ActionHandler actionHandler, out Character model) {
            model = new Character(CloneManager.Count, Vector3.zero, 5.0f, 10);
            var prefab = ResourceManager.GetPlayer(0);
            Spawn<Character, PlayerView, PlayerPresenter>(CloneType.Player, actionHandler, model, prefab);
        }

        public void SpawnProjectile(ActionHandler actionHandler,
                                    Vector3 startPosition,
                                    Vector3 direction,
                                    float speed,
                                    float range) {
            var model = new Projectile(CloneManager.Count, startPosition, direction, speed, range);
            var prefab = ResourceManager.GetProjectile(0);
            Spawn<Projectile, ProjectileView, ProjectilePresenter>(CloneType.Projectile, actionHandler, model, prefab);
        }

        private static void Spawn<T1, T2, T3>(CloneType cloneType,
                                              ActionHandler actionHandler,
                                              Model.Model model,
                                              GameObject prefab) where T1 : Model.Model
                                                                 where T2 : View.View
                                                                 where T3 : Presenter<T1, T2> {
            if (CloneManager.TryGetClone(cloneType, out var clone)) {
                clone.Value.Respawn(clone.Key, model);
            }
            else {
                var instantiate = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                var view = instantiate.GetComponent<T2>();
                var presenter = PresenterFactory.Create<T1, T2, T3>(actionHandler, model, view);
                presenter.Initialize();
                CloneManager.Add(model.ID, new Clone(cloneType, model, presenter, view));
            }
        }
    }
}