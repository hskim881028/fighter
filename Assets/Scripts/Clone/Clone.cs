using Fighter.Presenter;

namespace Fighter.Clone {
    public class Clone {
        private readonly Model.Model _model;
        private readonly View.View _view;
        private readonly IPresenter _presenter;

        public Clone(CloneType type, Model.Model model, IPresenter presenter, View.View view) {
            IsActive = true;
            Type = type;
            _model = model;
            _presenter = presenter;
            _view = view;
        }

        public bool IsActive { get; private set; }
        public CloneType Type { get; }

        public void Respawn(int id, Model.Model model) {
            _view.gameObject.SetActive(true);
            _presenter.Respawn(id, model);
            IsActive = true;
        }

        public void Update() {
            if (IsActive) {
                _presenter.Update();
            }
        }

        public void Destroy() {
            IsActive = false;
            _view.gameObject.SetActive(false);
        }
    }
}