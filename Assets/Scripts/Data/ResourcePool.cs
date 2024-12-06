using System;
using System.Collections.Generic;
using DefaultNamespace;
using Enums;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class ResourcePool
    {
        public ColorTypes colorType;
        public Ball ballPrefab;
        public Color color;
        public int countToCreate;
        public Transform parent;
        [HideInInspector] public Queue<Ball> PoolQueue;
    }
}