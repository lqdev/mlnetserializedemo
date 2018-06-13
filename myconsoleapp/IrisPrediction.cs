using Microsoft.ML.Runtime.Api;

namespace myconsoleapp
{
    public class IrisPrediction
    {
        [ColumnName("Score")]
        public float[] Score;
    }
}