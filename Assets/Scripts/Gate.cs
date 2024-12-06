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
    
    public void Initialize()
    {
        foreach (var box in boxesInfo)
        {
            ColoredGates.Add(box.colorType, box);
        }
    }
}
