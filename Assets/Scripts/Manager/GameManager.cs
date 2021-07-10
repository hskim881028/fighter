using System;
using System.Collections.Generic;
using Fighter.ScriptableObject;
using UnityEngine;
using System.Linq;
using Fighter.Data;
using Fighter.Enum;
using Fighter.Factory;
using Fighter.UI;

namespace Fighter.Manager {
    public static class GameManager {
        private static readonly Dictionary<CloneType, List<GameObject>> Clones =
            new Dictionary<CloneType, List<GameObject>>();
        
        private static readonly Dictionary<UIType, List<GameObject>> UIs =
            new Dictionary<UIType, List<GameObject>>();

        private static readonly Dictionary<CloneType, List<IData>> Datas = new Dictionary<CloneType, List<IData>>();

        public static void Initialize() {
            var scriptableObjects = UnityEngine.Resources.LoadAll<UnityEngine.ScriptableObject>("ScriptableObjects/");
            var prefabs = scriptableObjects.OfType<PrefabScriptableObject>();
            foreach (var prefab in prefabs) {
                Clones.Add(prefab.CloneType, prefab.Data);
            }
            
            var uis = scriptableObjects.OfType<UIScriptableObject>();
            foreach (var ui in uis) {
                UIs.Add(ui.UIType, ui.Data);
            }

            var datas = scriptableObjects.OfType<DataScriptableObject>();
            foreach (var data in datas) {
                var processedData = DataFactory.Create(data);
                Datas.Add(data.CloneType, processedData);
            }
        }

        public static GameObject GetClone(CloneType type, int id) {
            try {
                return Clones[type][id];
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public static GameObject GetUI(UIType type, int id) {
            try {
                return UIs[type][id];
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        public static IData GetData(CloneType type, int id) {
            try {
                return Datas[type][id];
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}