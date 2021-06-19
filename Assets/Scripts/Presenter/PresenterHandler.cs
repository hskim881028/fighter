using System.Collections.Generic;

namespace Fighter.Presenter {
    public class PresenterHandler {
        private readonly List<IPresenter> _presenters = new List<IPresenter>();

        public void Add(IPresenter presenter) {
            _presenters.Add(presenter);
        }
        public void UpdateAll() {
            foreach (var presenter in _presenters) {
                presenter.Update();
            }
        }
    }
}
