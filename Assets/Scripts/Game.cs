using Fighter.Action;
using Fighter.Enum;
using Fighter.Manager;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.View;
using UnityEngine;

namespace Fighter {
    public class Game : MonoBehaviour {
        public static Game Instance;

        [SerializeField] private InputManager inputManager;
        private readonly ActionHandler _actionHandler = new ActionHandler();

        public InputManager InputManager => inputManager;

        private void Awake() {
            Instance = this;
            GameManager.Initialize();
            UIManager.Initialize();
            CloneManager.Initialize(_actionHandler);
            CloneManager.Clone<Character, PlayerView, PlayerPresenter>(CloneType.Player, Vector3.zero, Vector3.zero);
            for (int i = 0; i < 5; i++) {
                CloneManager.Clone<Enemy, EnemyView, EnemyPresenter>(CloneType.Enemy, new Vector3(i + 1, 0, 0),
                                                                     Vector3.zero);
            }
        }

        private void Update() {
            CloneManager.UpdateAll();
        }

        private void LateUpdate() {
            _actionHandler.ExecuteAll();
        }
    }
}