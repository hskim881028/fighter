using UnityEngine;

namespace Fighter.View {
    public class PlayerView : View {
        [SerializeField] private Transform eye;
        private const float interval = 0.2f;

        protected override void Initialize() {
            if (Camera.main is { })
                Camera.main.transform.SetParent(transform);
        }

        public void UpdateLookAt(Vector3 value) {
            eye.transform.localPosition = value.normalized * interval;
        }
    }
}