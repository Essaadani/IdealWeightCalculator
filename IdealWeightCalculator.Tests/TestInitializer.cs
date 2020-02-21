using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdealWeightCalculator.Tests
{
    [TestClass]
    public class TestInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            context.WriteLine("In Assembly Initialize");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }
    }
}
