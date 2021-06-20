using Fighter.Action;
using Fighter.Model;
using UniRx;
using UnityEngine;

namespace Fighter.Presenter {
    public class ProjectilePresenter : IPresenter {
        private readonly Projectile _model;
        private readonly ActionHandler _actionHandler;

        private Vector3 startPosition;

        public ProjectilePresenter(Projectile model, View.View view, ActionHandler actionHandler) {
            _model = model;
            _model.Position.Subscribe(x => {
                if (view.isActiveAndEnabled) {
                    view.UpdatePosition(x);
                }
            });
            
            _model.Active.Subscribe(x => {
                if (view.isActiveAndEnabled) {
                    view.UpdateActive(x);
                }
            });

            _actionHandler = actionHandler;
            startPosition = _model.Position.Value;
        }
        
        public void Respawn(Model.Model model) {
            startPosition = model.Position.Value;
            _model.Initialize(model);
        }

        public void Update() {
            Destroy();
            Movement();
        }

        private void Movement() {
            _actionHandler.Enqueue(new MoveAction(_model));
        }

        private void Destroy() {
            if (Vector3.Distance(startPosition, _model.Position.Value) > _model.Range) {
                _actionHandler.Enqueue(new DestroyAction(_model));
            }
        }
    }
}