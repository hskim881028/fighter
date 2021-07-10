using Fighter.Action;
using Fighter.Data;
using UnityEngine;
using UniRx;

namespace Fighter.Presenter {
    public abstract class Presenter<T1, T2> : IPresenter where T1 : Model.Model where T2 : View.View {
        protected readonly ActionHandler _actionHandler;
        protected readonly T1 _model;
        protected readonly T2 _view;

        protected Presenter(ActionHandler actionHandler, Model.Model model, View.View view) {
            _actionHandler = actionHandler;
            _model = (T1) model;
            _view = (T2) view;
        }

        public virtual void Initialize(int id, IData data, Vector3 position, Vector3 direction) {
            _model.Initialize(id, data, position, direction);
            _model.Position.Subscribe(x => {
                _view.UpdatePosition(x);
            });

            _model.Active.Subscribe(x => {
                _view.UpdateActive(x);
            });
        }

        public virtual void Respawn(IData data, Vector3 position, Vector3 direction) {
            _model.Initialize(_model.ID, data, position, direction);
        }

        public abstract void Update();

        public Model.Model GetModel() {
            return _model;
        }
    }
}