using Fighter.Enum;
using Fighter.Manager;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.View;
using UniRx;
using UnityEngine;

namespace Fighter {
    public class Stage {
        private StageState _state;

        private ReactiveProperty<int> Gauge = new ReactiveProperty<int>(0);

        public void Initialize() {
            _state = StageState.Start;
        }

        public void Update() {
            UpdateState();
            Execute();
        }

        private void UpdateState() {
            if (Gauge.Value >= 100) {
                _state = StageState.BossAppears;
            }
        }

        private void Execute() {
            switch (_state) {
                case StageState.Start:
                    Gauge.Value = 0;
                    ClonePlayer();
                    CloneEnemy();
                    _state = StageState.Battle;
                    break;
                case StageState.Battle:
                    break;
                case StageState.BossAppears:
                    CloneBoss();
                    _state = StageState.BossBattle;
                    break;
                case StageState.BossBattle:
                    break;
                case StageState.End:
                    break;
            }
        }

        private void ClonePlayer() {
            CloneManager.Clone<Character, PlayerView, PlayerPresenter>(CloneType.Player, Vector3.zero, Vector3.zero);
        }

        private void CloneEnemy() {
            for (int i = 0; i < 5; i++) {
                CloneManager.Clone<Enemy, EnemyView, EnemyPresenter>(CloneType.Enemy, new Vector3(i + 1, 0, 0),
                                                                     Vector3.zero);
            }
        }

        private void CloneBoss() {
        }
    }
}