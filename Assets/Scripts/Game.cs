using Fighter.Controller;
using Fighter.Manager;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.View;
using UnityEngine;

namespace Fighter {
    public class Game : MonoBehaviour {
        [SerializeField] private InputController inputController;

        private void Awake() {
            ResourceManager.Initialize();
            SpawnPlayer();
        }

        private void SpawnPlayer() {
            var prefab = ResourceManager.GetPlayer(0);
            var clone = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            var view = clone.GetComponent<PlayerView>();
            var model = new Player();
            var presenter = new PlayerPresenter(inputController, model, view);
        }
    }
}