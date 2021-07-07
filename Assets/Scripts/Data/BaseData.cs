﻿using System;
using UnityEngine;

namespace Fighter.Data {
    [Serializable]
    public class BaseData : IData
    {
        public Vector3 Look;
        public float Speed;
        public int Damage;
        public int Hp;
    }
}