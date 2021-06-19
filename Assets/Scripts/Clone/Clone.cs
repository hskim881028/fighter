using Clone;
using Fighter.Presenter;

namespace Fighter.Clone {
    public class Clone {
        private Model.Model _model;
        private readonly IPresenter _presenter;
        private View.View _view;

        public Clone(CloneType type, Model.Model model, IPresenter presenter, View.View view) {
            IsActive = true;
            Type = type;
            _model = model;
            _presenter = presenter;
            _view = view;
        }

        public bool IsActive { get; private set; }
        public CloneType Type { get; }

        public void OnInitialize(Model.Model model) {
            IsActive = true;
            _model = model;
        }

        public void Update() {
            _presenter.Update();
        }

        public void Destroy() {
            IsActive = false;
        }
    }
}