using System.Collections.Generic;

namespace Fighter.Action {
    public class ActionHandler {
        private readonly Queue<IAction> _Actions = new Queue<IAction>();

        public void Enqueue(IAction action) {
            _Actions.Enqueue(action);
        }
        
        public void ExecuteAll() {
            while (_Actions.Count > 0) {
                var action = _Actions.Dequeue();
                action.Execute();
            }
        }
    }
}
