using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Enums;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private List<GateData> boxesInfo;

    public Dictionary<ColorTypes, GateData> ColoredGates = new();
    
    public void Initialize(float[] multipliers)
    {
        for (var i = 0; i < boxesInfo.Count; i++)
        {
            var box = boxesInfo[i];
            var multiplier = multipliers[i];

            box.multiplier = multiplier;
            box.textObject.text = multiplier.ToString();
            
            ColoredGates.Add(box.colorType, box);
        }
    }
}
