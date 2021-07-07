using DG.Tweening;
using UnityEngine;

namespace Fighter.View.UI {
    public class DamageView : UIView {
        private const float _move = 0.5f;
        private const float _duration = 0.5f;

        public override void Initialize(System.Action destroy, Vector3 position) {
            base.Initialize(destroy, position);
            transform.DOMoveY(position.y + _move, _duration).SetEase(Ease.OutQuart)
                     .OnComplete(() => { destroy?.Invoke(); });
        }
    }
}