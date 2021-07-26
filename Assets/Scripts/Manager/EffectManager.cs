using System.Collections.Generic;
using System.Linq;
using Fighter.Effect;
using Fighter.Effect.ValueObject;
using Fighter.View.Effect;
using UnityEngine;

namespace Fighter.Manager {
    public static class EffectManager {
        private static readonly Dictionary<int, Effect.Effect> _effects = new Dictionary<int, Effect.Effect>();
        private static Transform _pool;

        public static void Initialize() {
            _pool = new GameObject("EffectPool").transform;
        }
        
        public static void CloneGauge(DamageVO valueObject) {
            Spawn<DamageView>(EffectType.Damage, valueObject);
        }

        public static void CloneDamage(DamageVO valueObject) {
            Spawn<DamageView>(EffectType.Damage, valueObject);
        }

        private static void Spawn<T>(EffectType type, ValueObject valueObject, int effectId = 0) where T : View.EffectView {
            if (TryGetClone(type, out var effect)) {
                effect.Respawn(valueObject);
            }
            else {
                var prefab = GameManager.GetEffect(type, effectId);
                var instantiate = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity, _pool);
                var instanceID = instantiate.GetInstanceID();
                var view = instantiate.GetComponent<T>();
                _effects.Add(instanceID, new Effect.Effect(type, view, valueObject));
            }
        }

        private static bool TryGetClone(EffectType type, out Effect.Effect effect) {
            effect = _effects.FirstOrDefault(x => x.Value.Type.Equals(type) && !x.Value.IsActive).Value;
            return effect != null;
        }
    }
}