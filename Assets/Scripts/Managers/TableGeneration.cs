using System;
using Data;
using Enums;
using ScriptableObjects;
using UnityEngine;

namespace Managers
{
    public class TableGeneration : MonoBehaviour
    {
        [SerializeField] private Transform[] tablesParents;

        [SerializeField] private float pyramidWidth = 7f;
        [SerializeField] private float pyramidHeight = 7f;

        [SerializeField] private TableSettings tableSettings;

        private GameObject _activeTable;

        private void Start()
        {
            for (var i = 0; i < tableSettings.Tables.Count; i++)
            {
                var table = tableSettings.Tables[i];
            
                GeneratePins(table, tablesParents[i]);
            }

            _activeTable = tablesParents[0].gameObject;
        }

        public void TurnOnTable(TablesEnum tablesEnum)
        {
            switch (tablesEnum)
            {
                case TablesEnum.First:
                    _activeTable.SetActive(false);
                    _activeTable = tablesParents[0].gameObject;
                    _activeTable.SetActive(true);
                    break;
                case TablesEnum.Second:
                    _activeTable.SetActive(false);
                    _activeTable = tablesParents[1].gameObject;
                    _activeTable.SetActive(true);
                    break;
                case TablesEnum.Third:
                    _activeTable.SetActive(false);
                    _activeTable = tablesParents[2].gameObject;
                    _activeTable.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tablesEnum), tablesEnum, null);
            }
        }

        private void GeneratePins(TableData tableData, Transform parent)
        {
            var rows = tableData.RowCount;

            tableSettings.MultiplierTables.TryGetValue(rows, out var multipliersArray);

            var rowSpacing = pyramidHeight / (rows - 1); 
            var pinSpacing = pyramidWidth / (rows - 1);

            Vector3 scaleGate;

            if (tableData.GateScaleCoefficient <= 0)
            {
                scaleGate = tableSettings.GatePrefab.transform.localScale;
            }
            else
            {
                scaleGate = tableSettings.GatePrefab.transform.localScale - tableSettings.GatePrefab.transform.localScale / tableData.GateScaleCoefficient;
            }

            var startY = pyramidHeight / 2f; 
        
            var firstRowOffsetX = -pinSpacing; 
            for (int col = 0; col < 3; col++)
            {
                var xPosition = firstRowOffsetX + col * pinSpacing;
                var yPosition = startY;
                var position = new Vector2(xPosition, yPosition);
                Instantiate(tableSettings.PinPrefab, position, Quaternion.identity, parent);
            }
        
            for (var row = 1; row < rows; row++)
            {
                var pinsInRow = row + 3;
            
                var offsetX = -(pinsInRow - 1) * pinSpacing / 2f;

                for (var col = 0; col < pinsInRow; col++)
                {
                    var xPosition = offsetX + col * pinSpacing;
                    var yPosition = startY - row * rowSpacing;
                    var position = new Vector2(xPosition, yPosition);
                    Instantiate(tableSettings.PinPrefab, position, Quaternion.identity, parent);

                    if (row == rows - 1 && col < pinsInRow - 1)
                    {
                        var gatePos = new Vector2(position.x + pinSpacing / 2, position.y - tableData.GateHeightOffset);
                        var gate = Instantiate(tableSettings.GatePrefab, gatePos, Quaternion.identity, parent);

                        if (multipliersArray != null)
                        {
                            var multipliers = new float[]
                            {
                                multipliersArray[0][col],
                                multipliersArray[1][col],
                                multipliersArray[2][col]
                            };
                        
                            gate.Initialize(multipliers);
                        }

                        gate.transform.localScale = scaleGate;
                    }
                }
            }
        }
    }
}