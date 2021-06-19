using UnityEngine;

namespace Fighter.View {
    public class PlayerView : View {
        public void UpdatePosition(Vector3 position) {
            transform.position = position;
        }

        public void UpdateLookAt(Vector3 direction) {
            if (direction.sqrMagnitude > 0) {
                transform.right = direction;
            }
        }

        public void UpdateActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}