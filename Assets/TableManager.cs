using Configs;
using Enums;
using Managers;
using UnityEngine;

public class TableManager : MonoSingleton<TableManager>
{
    [SerializeField] private BallSpawnZone ballSpawnZone;
    [SerializeField] private TableGeneration tableGeneration;
    public BallSpawnZone BallSpawnZone => ballSpawnZone;

    public void TurnOnFirstTable()
    {
        tableGeneration.TurnOnTable(TablesEnum.First);
    }

    public void TurnOnSecondTable()
    {
        tableGeneration.TurnOnTable(TablesEnum.Second);
    }

    public void TurnOnThirdTable()
    {
        tableGeneration.TurnOnTable(TablesEnum.Third);
    }
}
