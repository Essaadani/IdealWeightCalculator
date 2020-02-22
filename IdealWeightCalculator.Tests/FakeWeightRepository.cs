﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IdealWeightCalculator.Tests
{
    class FakeWeightRepository :  IDataRepository
    {
        IEnumerable<WeightCalculator> weights;

        public FakeWeightRepository()
        {
            weights = new List<WeightCalculator>()
            {
                new WeightCalculator { Height = 175, Sex ='w' }, // 62.5
                new WeightCalculator { Height = 167, Sex ='m' }, // 62.75
                new WeightCalculator { Height = 182, Sex ='m' } // 74
            };
        }

        public IEnumerable<WeightCalculator> GetWeights()
        {
            return weights;
        }

    }
}
