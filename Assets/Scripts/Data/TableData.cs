using System;

namespace Data
{
    [Serializable]
    public struct TableData
    {
        public int RowCount;
        public int GateScaleCoefficient;
        public float GateHeightOffset;
    }
}