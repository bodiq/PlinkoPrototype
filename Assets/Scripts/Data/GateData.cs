using System;
using Enums;
using TMPro;
using UnityEngine;

namespace Data
{
    [Serializable]
    public struct GateData
    {
        public ColorTypes colorType;
        public Transform boxObject;
        public TextMeshPro textObject;

        public float multiplier;
    }
}