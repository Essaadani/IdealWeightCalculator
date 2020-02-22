using System.Collections.Generic;

namespace IdealWeightCalculator
{
    public interface IDataRepository
    {
        IEnumerable<WeightCalculator> GetWeights();
    }
}
