using UnityEngine;

namespace Fighter.View {
    public interface IView {
        public void UpdatePosition(Vector3 position);
        public void UpdateActive(bool value);
    }
}