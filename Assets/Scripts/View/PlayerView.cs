using UnityEngine;

namespace Fighter.View {
    public class PlayerView : View {
        public void UpdateLookAt(Vector3 direction) {
            if (direction.sqrMagnitude > 0) {
                transform.right = direction;
            }
        }
    }
}