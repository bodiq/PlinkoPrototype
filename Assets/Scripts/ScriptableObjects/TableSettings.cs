using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TableSettings", menuName = "ScriptableObjects/Table Settings")]
    public class TableSettings : ScriptableObject
    {
        [SerializeField] private GameObject pinPrefab;
        [SerializeField] private Gate gatePrefab;
        
        [SerializeField] private List<TableData> tables;
        
        public readonly Dictionary<int, float[][]> MultiplierTables = new Dictionary<int, float[][]>
        {
            {
                12, new float[][]
                {
                    new float[] { 11f, 3.2f, 1.6f, 1.2f, 1.1f, 1f, 0.5f, 1f, 1.1f, 1.2f, 1.6f, 3.2f, 11f },
                    new float[] { 25f, 8f, 3.1f, 1.7f, 1.2f, 0.7f, 0.3f, 0.7f, 1.2f, 1.7f, 3.1f, 8f, 25f },
                    new float[] { 141f, 25f, 8.1f, 2.3f, 0.7f, 0.2f, 0f, 0.2f, 0.7f, 2.3f, 8.1f, 25f, 141f }
                }
            },
            {
                14, new float[][]
                {
                    new float[] { 18f, 3.2f, 1.6f, 1.3f, 1.2f, 1.1f, 1f, 0.5f, 1f, 1.1f, 1.2f, 1.3f, 1.6f, 3.2f, 18f },
                    new float[] { 55f, 12f, 5.6f, 3.2f, 1.6f, 1f, 0.7f, 0.2f, 0.7f, 1f, 1.6f, 3.2f, 5.6f, 12f, 55f },
                    new float[] { 353f, 49f, 14f, 5.3f, 2.1f, 0.5f, 0.2f, 0f, 0.2f, 0.5f, 2.1f, 5.3f, 14f, 49f, 353f }
                }
            },
            {
                16, new float[][]
                {
                    new float[] { 35f, 7.7f, 2.5f, 1.6f, 1.3f, 1.2f, 1.1f, 1f, 0.4f, 1f, 1.1f, 1.2f, 1.3f, 1.6f, 2.5f, 7.7f, 35f },
                    new float[] { 118f, 61f, 12f, 4.5f, 2.3f, 1.2f, 1f, 0.7f, 0.2f, 0.7f, 1f, 1.2f, 2.3f, 4.5f, 12f, 61f, 118f },
                    new float[] { 555f, 122f, 26f, 8.5f, 3.5f, 2f, 0.5f, 0.2f, 0f, 0.2f, 0.5f, 2f, 3.5f, 8.5f, 26f, 122f, 555f }
                }
            }
        };

        

        public List<TableData> Tables => tables;
        public GameObject PinPrefab => pinPrefab;
        public Gate GatePrefab => gatePrefab;
    }
}