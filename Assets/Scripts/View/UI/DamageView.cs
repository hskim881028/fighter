using System.Globalization;
using DG.Tweening;
using Fighter.UI.ValueObject;
using TMPro;
using UnityEngine;

namespace Fighter.View.UI {
    public class DamageView : UIView {
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