using System;
using System.Collections.Generic;
using System.Linq;
using Fighter.Data;
using Fighter.Enum;
using Fighter.ScriptableObject;

namespace Fighter.Factory {
    public static class DataFactory {
        public static List<IData> Create(DataScriptableObject data) {
            switch (data.CloneType) {
                case CloneType.Player:
                    var player = data as CharacterDataScriptableObject;
                    return player.Data.Cast<IData>().ToList();
                case CloneType.Enemy:
                    var enemy = data as CharacterDataScriptableObject;
                    return enemy.Data.Cast<IData>().ToList();
                case CloneType.Projectile:
                    var projectile = data as ProjectileDataScriptableObject;
                    return projectile.Data.Cast<IData>().ToList();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}