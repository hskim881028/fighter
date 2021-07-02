using Fighter.Action;
using Fighter.Model;
using Fighter.View;
using UniRx;
using UnityEngine;

namespace Fighter.Presenter {
    public class ProjectilePresenter : Presenter<Projectile, ProjectileView> {
        private Projectile _projectile;
        private Vector3 startPosition;

        public ProjectilePresenter(ActionHandler actionHandler, Model.Model model, View.View view)
            : base(actionHandler, model, view) {
        }

        public override void Initialize() {
            base.Initialize();
            _view.TriggerEnter.Subscribe( x=> {
                var (attacker, defender) = x;
                Debug.Log($"attacker : {attacker} ------ defender : {defender}");
                _actionHandler.Enqueue(new DestroyAction(_projectile));
            });
            _projectile = _model as Projectile;
            startPosition = _projectile.Position.Value;
        }

        public override void Respawn(Model.Model model) {
            startPosition = model.Position.Value;
            _projectile.Initialize(model);
        }

        public override void Update() {
            Destroy();
            Movement();
        }

        private void Movement() {
            _actionHandler.Enqueue(new MoveAction(_projectile));
        }

        private void Destroy() {
            if (Vector3.Distance(startPosition, _projectile.Position.Value) > _projectile.Range) {
                _actionHandler.Enqueue(new DestroyAction(_projectile));
            }
        }
    }
}