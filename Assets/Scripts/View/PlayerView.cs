using UnityEngine;

namespace Fighter.View {
    public class PlayerView : MonoBehaviour {
        public void UpdatePosition(Vector3 position) {
            transform.position = position;
        }
    }
}