using UnityEngine;

namespace Fighter.View {
    public class UIView : MonoBehaviour, IView {
        private System.Action _destroy;

        public virtual void Initialize(System.Action destroy, Vector3 position) {
            _destroy = destroy;
            transform.position = position;
        }

        public virtual void UpdatePosition(Vector3 position) {
        }

        public void UpdateActive(bool value) {
        }
    }
}