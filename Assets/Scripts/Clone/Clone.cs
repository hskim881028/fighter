using Fighter.Data;
using Fighter.Enum;
using Fighter.Presenter;
using UniRx;
using UnityEngine;

namespace Fighter.Clone {
    public class Clone {
        public CloneType Type { get; }
        private readonly IPresenter _presenter;
        public Model.Model Model => _presenter.Model;
        
        public ReactiveProperty<bool> IsActive { get; } = new ReactiveProperty<bool>();

        public Clone(CloneType type, IPresenter presenter, int instanceID, IData data, Vector3 position, Vector3 direction) {
            IsActive.Value = true;
            Type = type;
            _presenter = presenter;
            _presenter.Initialize(instanceID, data, position, direction);
            IsActive.Subscribe(x => {
                Model.Active.Value = x;
            });
        }

        public void Respawn(IData data, Vector3 position, Vector3 direction) {
            _presenter.Respawn(data, position, direction);
            IsActive.Value = true;
        }

        public void Update() {
            if (IsActive.Value) {
                _presenter.Update();
            }
        }

        public void Destroy() {
            IsActive.Value = false;
        }
    }
}