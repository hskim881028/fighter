﻿using Fighter.Action;
using UnityEngine;
using UniRx;

namespace Fighter.Presenter {
    public class Presenter<T1, T2> : IPresenter where T1 : Model.Model where T2 : View.View {
        protected readonly ActionHandler _actionHandler;
        protected readonly T1 _model;
        protected readonly T2 _view;

        public Presenter(ActionHandler actionHandler, Model.Model model, View.View view) {
            _actionHandler = actionHandler;
            _model = (T1) model;
            _view = (T2) view;
        }

        protected Presenter() {
            Debug.Log("Call default");
        }

        public virtual void Initialize() {
            _model.Position.Subscribe(x => {
                if (_view.isActiveAndEnabled) {
                    _view.UpdatePosition(x);
                }
            });

            _model.Active.Subscribe(x => {
                if (_view.isActiveAndEnabled) {
                    _view.UpdateActive(x);
                }
            });
        }

        public virtual void Respawn(int id, Model.Model model) {
        }

        public virtual void Update() {
        }
    }
}