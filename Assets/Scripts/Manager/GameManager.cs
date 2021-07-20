using System;
using System.Collections.Generic;
using Fighter.ScriptableObject;
using UnityEngine;
using System.Linq;
using Fighter.Data;
using Fighter.Enum;
using Fighter.Factory;
using Fighter.Effect;

namespace Fighter.Manager {
    public static class GameManager {
        private static readonly Dictionary<CloneType, List<GameObject>> Clones =
            new Dictionary<CloneType, List<GameObject>>();
        
        private static readonly Dictionary<EffectType, List<GameObject>> Effects =
            new Dictionary<EffectType, List<GameObject>>();

        private static readonly Dictionary<CloneType, List<IData>> Datas = new Dictionary<CloneType, List<IData>>();

        public static void Initialize() {
            var scriptableObjects = UnityEngine.Resources.LoadAll<UnityEngine.ScriptableObject>("ScriptableObjects/");
            var prefabs = scriptableObjects.OfType<PrefabScriptableObject>();
            foreach (var prefab in prefabs) {
                Clones.Add(prefab.CloneType, prefab.Data);
            }
            
            var effects = scriptableObjects.OfType<EffectScriptableObject>();
            foreach (var effect in effects) {
                Effects.Add(effect.effectType, effect.Data);
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
        
        public static GameObject GetEffect(EffectType type, int id) {
            try {
                return Effects[type][id];
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