using Fighter.UI.ValueObject;
using UnityEngine;

namespace Fighter.View {
    public class UIView : MonoBehaviour, IView {
        private System.Action _destroy;

        public virtual void Initialize(ValueObject vo, System.Action destroy) {
            transform.position = vo.Position;
            _destroy = destroy;
        }

        public virtual void UpdatePosition(Vector3 position) {
        }

        public void UpdateActive(bool value) {
        }
    }
}