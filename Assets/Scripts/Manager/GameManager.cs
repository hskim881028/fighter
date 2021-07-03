using System;
using System.Collections.Generic;
using Fighter.ScriptableObject;
using UnityEngine;
using System.Linq;
using Fighter.Clone;
using Fighter.Data;
using Fighter.Factory;

namespace Fighter.Manager {
    public static class GameManager {
        private static readonly Dictionary<CloneType, List<GameObject>> Resources =
            new Dictionary<CloneType, List<GameObject>>();

        private static readonly Dictionary<CloneType, List<IData>> Datas = new Dictionary<CloneType, List<IData>>();

        public static void Initialize() {
            var scriptableObjects = UnityEngine.Resources.LoadAll<UnityEngine.ScriptableObject>("ScriptableObjects/");
            var prefabs = scriptableObjects.OfType<PrefabScriptableObject>();
            foreach (var prefab in prefabs) {
                Resources.Add(prefab.cloneType, prefab.Data);
            }

            var datas = scriptableObjects.OfType<DataScriptableObject>();
            foreach (var data in datas) {
                var processedData = DataFactory.Create(data);
                Datas.Add(data.CloneType, processedData);
            }
        }

        public static GameObject GetPrefab(CloneType type, int id) {
            try {
                return Resources[type][id];
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