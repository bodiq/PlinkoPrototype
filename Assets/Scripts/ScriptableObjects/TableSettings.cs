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

        public List<TableData> Tables => tables;
        public GameObject PinPrefab => pinPrefab;
        public Gate GatePrefab => gatePrefab;
    }
}