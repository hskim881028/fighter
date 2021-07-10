using Fighter.Action;
using Fighter.Model;
using Fighter.View;

namespace Fighter.Presenter {
    public class EnemyPresenter : Presenter<Character, EnemyView> {
        public EnemyPresenter(ActionHandler actionHandler, Model.Model model, View.View view)
            : base(actionHandler, model, view) {
            
        }

        public override void Update() {
        }
    }
}
