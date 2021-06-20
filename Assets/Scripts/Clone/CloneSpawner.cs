using Fighter.Action;
using Fighter.Manager;
using UnityEngine;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.View;

namespace Fighter.Clone {
    public class CloneSpawner : MonoBehaviour {
        public void SpawnPlayer(ActionHandler actionHandler, out Character model) {
            if (CloneManager.TryGetClone(CloneType.Player, out var clone)) {
                model = new Character(clone.Key, Vector3.zero, 5.0f, 10);
                clone.Value.Respawn(model);
            }
            else {
                var prefab = ResourceManager.GetPlayer(0);
                var player = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                var view = player.GetComponent<PlayerView>();
                var id = CloneManager.Count;
                model = new Character(id, Vector3.zero, 5.0f, 10);
                var presenter = new PlayerPresenter(model, view, actionHandler);
                var newClone = new Clone(CloneType.Player, model, presenter, view);
                CloneManager.Add(id, newClone);
            }
        }

        public void SpawnProjectile(ActionHandler actionHandler,
                                    Vector3 startPosition,
                                    Vector3 direction,
                                    float speed,
                                    float range) {
            if (CloneManager.TryGetClone(CloneType.Projectile, out var clone)) {
                var model = new Projectile(clone.Key, startPosition, direction, speed, range);
                clone.Value.Respawn(model);
            }
            else {
                var prefab = ResourceManager.GetProjectile(0);
                var projectile = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                var view = projectile.GetComponent<ProjectileView>();
                var id = CloneManager.Count;
                var model = new Projectile(id, startPosition, direction, speed, range);
                var presenter = new ProjectilePresenter(model, view, actionHandler);
                var newClone = new Clone(CloneType.Projectile, model, presenter, view);
                CloneManager.Add(id, newClone);
            }
        }
    }
}