using System.Threading.Tasks;
using UnityEngine;

public class TableGeneration : MonoBehaviour
{
    [SerializeField] private Transform firstTable;
    [SerializeField] private Transform secondTable;
    [SerializeField] private Transform thirdTable;

    [SerializeField] private float pyramidWidth = 7f;
    [SerializeField] private float pyramidHeight = 7f;

    [SerializeField] private GameObject pinPrefab;
    [SerializeField] private Gate gatePrefab;

    private int baseCountRows = 12;

    private void Start()
    {
        GeneratePins(12, firstTable);
        GeneratePins(14, secondTable);
        GeneratePins(16, thirdTable);
    }

    private void GeneratePins(int rows, Transform parent)
    {
        var rowSpacing = pyramidHeight / (rows - 1); 
        var pinSpacing = pyramidWidth / (rows - 1);

        var dominator = rows - baseCountRows;

        Vector3 scaleGate;

        if (dominator <= 0)
        {
            scaleGate = gatePrefab.transform.localScale;
        }
        else
        {
            scaleGate = gatePrefab.transform.localScale - gatePrefab.transform.localScale / (baseCountRows / dominator);
        }

        var startY = pyramidHeight / 2f; 
        
        var firstRowOffsetX = -pinSpacing; 
        for (int col = 0; col < 3; col++)
        {
            var xPosition = firstRowOffsetX + col * pinSpacing;
            var yPosition = startY;
            var position = new Vector2(xPosition, yPosition);
            Instantiate(pinPrefab, position, Quaternion.identity, parent);
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
                Instantiate(pinPrefab, position, Quaternion.identity, parent);

                if (row == rows - 1 && col < pinsInRow - 1)
                {
                    var gatePos = new Vector2(position.x + pinSpacing / 2, position.y - 0.4f);
                    var gate = Instantiate(gatePrefab, gatePos, Quaternion.identity, parent);
                    
                    gate.transform.localScale = scaleGate;
                }
            }
        }
    }
}