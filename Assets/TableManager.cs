using System.Collections;
using System.Collections.Generic;
using Configs;
using UnityEngine;

public class TableManager : MonoSingleton<TableManager>
{
    [SerializeField] private BallSpawnZone ballSpawnZone;
    
    public BallSpawnZone BallSpawnZone => ballSpawnZone;
}
