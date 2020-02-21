using System;
using System.Collections.Generic;
using System.Text;

namespace IdealWeightCalculator
{
    public class WeightCalculator
    {
        public double Height { get; set; }
        public char Sex { get; set; }

        public double GetIdealBodyWeight()
        {
            switch (Sex)
            {
                case 'm':
                    return (Height - 100) - ((Height - 150) / 4);
                case 'w':
                    return (Height - 100) - ((Height - 150) / 2);
                default:
                    throw new ArgumentException("The Sex argument is not valid"); ;
            }
        }
    }
}
