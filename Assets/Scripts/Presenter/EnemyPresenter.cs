using System;
using Fighter.Action;
using Fighter.Enum;
using Fighter.Manager;
using Fighter.Model;
using Fighter.View;
using UnityEngine;

namespace Fighter.Presenter {
    public class EnemyPresenter : Presenter<Enemy, EnemyView> {
        private EnemyState _state;
        private readonly Character _target;
        private Vector3 _direction;

        public EnemyPresenter(ActionHandler actionHandler, Model.Model model, View.View view)
            : base(actionHandler, model, view) {
            _target = CloneManager.GetPlayerModel();
        }

        protected override void UpdateState() {
            Search();
        }

        protected override void ExecuteAction() {
            switch (_state) {
                case EnemyState.Idle:
                    break;
                case EnemyState.Search:
                    break;
                case EnemyState.Move:
                    _actionHandler.Enqueue(new LookAtAction(_model, _direction));
                    _actionHandler.Enqueue(new MoveAction(_model));
                    break;
                case EnemyState.Attack:
                    break;
                case EnemyState.Destroy:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Search() {
            var distance = Vector3.SqrMagnitude(_target.Position.Value - _model.Position.Value);
            if (distance < _model.SearchRange * _model.SearchRange) {
                _state = EnemyState.Move;
                _direction = (_target.Position.Value - _model.Position.Value).normalized;
            }
            else {
                _state = EnemyState.Search;
                _direction = Vector3.zero;
            }
        }
    }
}