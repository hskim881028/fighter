using Fighter.Action;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.View;
using UnityEngine;

namespace Fighter.Manager {
    public class ObjectManager : MonoBehaviour {
        public (IPresenter, Character) SpawnPlayer(ActionHandler actionHandler) {
            var prefab = ResourceManager.GetPlayer(0);
            var clone = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            var view = clone.GetComponent<PlayerView>();
            var model = new Player(Vector3.zero, 5.0f);
            var presenter = new PlayerPresenter(model, view, actionHandler);
            return (presenter, model);
        }
    }
}