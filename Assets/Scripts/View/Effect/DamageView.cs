using System.Globalization;
using DG.Tweening;
using Fighter.Effect.ValueObject;
using TMPro;
using UnityEngine;

namespace Fighter.View.Effect {
    public class DamageView : EffectView {
        [SerializeField] private TextMeshPro damage;
        
        private const float _move = 0.5f;
        private const float _duration = 0.5f;

        public override void Initialize(ValueObject vo, System.Action destroy) {
            base.Initialize(vo, destroy);
            transform.DOMoveY(vo.Position.y + _move, _duration).SetEase(Ease.OutQuart)
                     .OnComplete(() => { destroy?.Invoke(); });
            if (vo is DamageVO damageVo) {
                damage.text = damageVo.Damage.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}