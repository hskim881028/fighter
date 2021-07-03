using System.Collections.Generic;
using System.Linq;
using Fighter.Clone;
using Fighter.Data;
using Fighter.ScriptableObject;

namespace Fighter.Factory {
    public static class DataFactory {
        public static List<IData> Create(DataScriptableObject data) {
            switch (data.CloneType) {
                case CloneType.Player:
                    var player = data as CharacterDataScriptableObject;
                    var pl = player.Data.Cast<IData>().ToList();
                    return pl;
                case CloneType.Projectile:
                    var projectile = data as ProjectileDataScriptableObject;
                    var test = projectile.Data.Cast<IData>().ToList();
                    return test;
            }
            return null;
        }
    }
}