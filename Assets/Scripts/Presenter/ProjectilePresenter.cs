using System;
using Fighter.Action;
using Fighter.Data;
using Fighter.Enum;
using Fighter.Manager;
using Fighter.Model;
using Fighter.View;
using UniRx;
using UnityEngine;

namespace Fighter.Presenter {
    public class ProjectilePresenter : Presenter<Projectile, ProjectileView> {
        private ProjectileState _state;
        private Vector3 startPosition;

        public ProjectilePresenter(ActionHandler actionHandler, Model.Model model, View.View view)
            : base(actionHandler, model, view) {
        }

        public override void Initialize(int id, IData data, Vector3 position, Vector3 direction) {
            base.Initialize(id, data, position, direction);
            _view.TriggerEnter.Subscribe(x => {
                _state = ProjectileState.Attack;
                var (attacker, defender) = x;
                var models = CloneManager.GetModels(x);
                _actionHandler.Enqueue(new HitAction(models));
                _actionHandler.Enqueue(new DestroyAction(_model));
            });
            startPosition = _model.Position.Value;
        }

        public override void Respawn(IData data, Vector3 position, Vector3 direction) {
            base.Respawn(data, position, direction);
            startPosition = position;
        }

        protected override void UpdateState() {
            CheckLife();
        }
        
        protected override void ExecuteAction() {
            switch (_state) {
                case ProjectileState.Move:
                    _actionHandler.Enqueue(new MoveAction(_model));
                    break;
                case ProjectileState.Destroy:
                    _actionHandler.Enqueue(new DestroyAction(_model));
                    break;
                case ProjectileState.Attack:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void CheckLife() {
            var dist = Vector3.SqrMagnitude(startPosition - _model.Position.Value);
            _state = dist < _model.Range * _model.Range ? ProjectileState.Move : ProjectileState.Destroy;
        }
    }
}