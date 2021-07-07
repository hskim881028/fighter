using System.Collections.Generic;
using System.Linq;
using Fighter.UI;
using Fighter.View.UI;
using UnityEngine;

namespace Fighter.Manager {
    public static class UIManager {
        private static readonly Dictionary<int, UI.UI> _uis = new Dictionary<int, UI.UI>();
        private static Transform _pool;

        public static void Initialize() {
            _pool = new GameObject("UIPool").transform;
        }

        public static void CloneDamage(Vector3 position) {
            Spawn<DamageView>(UIType.Damage, position);
        }

        private static void Spawn<T>(UIType type, Vector3 position, int uiId = 0) where T : View.UIView {
            if (TryGetClone(type, out var ui)) {
                ui.Respawn(position);
            }
            else {
                var prefab = GameManager.GetUI(type, uiId);
                var instantiate = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity, _pool);
                var instanceID = instantiate.GetInstanceID();
                var view = instantiate.GetComponent<T>();
                _uis.Add(instanceID, new UI.UI(type, view, position));
            }
        }

        private static bool TryGetClone(UIType type, out UI.UI ui) {
            ui = _uis.FirstOrDefault(x => x.Value.Type.Equals(type) && !x.Value.IsActive).Value;
            return ui != null;
        }
    }
}