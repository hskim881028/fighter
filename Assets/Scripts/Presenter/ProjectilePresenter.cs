using Fighter.Action;
using Fighter.Data;
using Fighter.Manager;
using Fighter.Model;
using Fighter.View;
using UniRx;
using UnityEngine;

namespace Fighter.Presenter {
    public class ProjectilePresenter : Presenter<Projectile, ProjectileView> {
        private Vector3 startPosition;

        public ProjectilePresenter(ActionHandler actionHandler, Model.Model model, View.View view)
            : base(actionHandler, model, view) {
        }

        public override void Initialize() {
            base.Initialize();
            _view.TriggerEnter.Subscribe(x => {
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

        public override void Update() {
            Destroy();
            Movement();
        }

        private void Movement() {
            _actionHandler.Enqueue(new MoveAction(_model));
        }

        private void Destroy() {
            var dist = Vector3.SqrMagnitude(startPosition - _model.Position.Value);
            if (dist > _model.Range * _model.Range) {
                _actionHandler.Enqueue(new DestroyAction(_model));
            }
        }
    }
}