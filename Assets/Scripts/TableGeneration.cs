using System.Threading.Tasks;
using Data;
using ScriptableObjects;
using UnityEngine;

public class TableGeneration : MonoBehaviour
{
    [SerializeField] private Transform[] tablesParents;

    [SerializeField] private float pyramidWidth = 7f;
    [SerializeField] private float pyramidHeight = 7f;

    [SerializeField] private TableSettings tableSettings;

    private int baseCountRows = 12;

    private void Start()
    {
        for (var i = 0; i < tableSettings.Tables.Count; i++)
        {
            var table = tableSettings.Tables[i];
            
            GeneratePins(table, tablesParents[i]);
        }
    }

    private void GeneratePins(TableData tableData, Transform parent)
    {
        var rows = tableData.RowCount;
        
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
                    
                    gate.transform.localScale = scaleGate;
                }
            }
        }
    }
}