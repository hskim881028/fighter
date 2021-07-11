using System.Collections.Generic;
using System.Linq;
using Fighter.UI;
using Fighter.UI.ValueObject;
using Fighter.View.UI;
using UnityEngine;

namespace Fighter.Manager {
    public static class UIManager {
        private static readonly Dictionary<int, UI.UI> _uis = new Dictionary<int, UI.UI>();
        private static Transform _pool;

        public static void Initialize() {
            _pool = new GameObject("UIPool").transform;
        }

        public static void CloneDamage(DamageVO valueObject) {
            Spawn<DamageView>(UIType.Damage, valueObject);
        }

        private static void Spawn<T>(UIType type, ValueObject valueObject, int uiId = 0) where T : View.UIView {
            if (TryGetClone(type, out var ui)) {
                ui.Respawn(valueObject);
            }
            else {
                var prefab = GameManager.GetUI(type, uiId);
                var instantiate = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity, _pool);
                var instanceID = instantiate.GetInstanceID();
                var view = instantiate.GetComponent<T>();
                _uis.Add(instanceID, new UI.UI(type, view, valueObject));
            }
        }

        private static bool TryGetClone(UIType type, out UI.UI ui) {
            ui = _uis.FirstOrDefault(x => x.Value.Type.Equals(type) && !x.Value.IsActive).Value;
            return ui != null;
        }
    }
}