using Fighter.Action;
using Fighter.Presenter;

namespace Fighter.Factory {
    public static class PresenterFactory {
        public static Presenter<T1, T2> Create<T1, T2, T3>(ActionHandler actionHandler,
                                                           Model.Model model,
                                                           View.View view) where T1 : Model.Model
                                                                           where T2 : View.View
                                                                           where T3 : Presenter<T1, T2> {
            var presenterType = typeof(T3);
            switch (true) {
                case var _ when presenterType.IsAssignableFrom(typeof(ProjectilePresenter)):
                    var projectile = new ProjectilePresenter(actionHandler, model, view);
                    return projectile as Presenter<T1, T2>;

                case var _ when presenterType.IsAssignableFrom(typeof(PlayerPresenter)):
                    var player = new PlayerPresenter(actionHandler, model, view);
                    return player as Presenter<T1, T2>;
                default:
                    return null;
            }
        }
    }
}