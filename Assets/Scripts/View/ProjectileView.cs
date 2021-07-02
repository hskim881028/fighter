﻿using UniRx;
using UnityEngine;

namespace Fighter.View {
    public class ProjectileView : View {
        public Subject<(int attacker , int defender)> TriggerEnter { get; } = new Subject<(int, int)>();
        
        private void OnTriggerEnter2D(Collider2D other) {
            TriggerEnter.OnNext((transform.GetInstanceID(), other.GetInstanceID()));
            // var model = CloneManager.GetModel(id);
        }
    }
}