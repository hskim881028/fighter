using UnityEngine;

namespace Fighter.View {
    public class View : MonoBehaviour, IView {
        public void UpdatePosition(Vector3 position) {
            transform.position = position;
        }

        public void UpdateActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}