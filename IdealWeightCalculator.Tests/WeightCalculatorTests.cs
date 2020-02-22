using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace IdealWeightCalculator.Tests
{
    [TestClass]
    public class WeightCalculatorTests
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            context.WriteLine("In Class Initializer");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("In Test Initialize");
        }

        [TestCleanup]
        public void TestCleanup()
        {

        }
        // Given_When_Then
        [TestMethod]
        [Description("This test is about checking if the ideal body weight " +
                     " of a man with 180 CM in height is equals to 72.5")]
        [Owner("KhalidEssaadani")]
        [Priority(1)]
        [TestCategory("WeightCategory")]
        public void GetIdealBodyWeight_WithSex_M_And_Height_180_Return_72_5()
        {
            // Arrange
            WeightCalculator sut = new WeightCalculator
            {
                Sex = 'm',
                Height  = 180
            };

            // Act
            double actual = sut.GetIdealBodyWeight();
            double expected = 72.5;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("This test is about checking if the ideal body weight " +
                     " of a women with 180 CM in height is equals to 65")]
        [Owner("KhalidEssaadani")]
        [Priority(1)]
        [TestCategory("WeightCategory")]
        public void GetIdealBodyWeight_WithSex_W_And_Height_180_Return_65()
        {
            // Arrange
            WeightCalculator sut = new WeightCalculator
            {
                Sex = 'w',
                Height = 180
            };

            // Act
            double actual = sut.GetIdealBodyWeight();
            double expected = 65;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("This test is about checking if the sex argument " +
                     " is not valid by throwing an exception.")]
        [Owner("KhalidEssaadani")]
        [Priority(1)]
        [TestCategory("WeightCategory")]
        public void GetIdealBodyWeight_WithBadSex_And_Height_180_Throw_Exception()
        {
            // Arrange
            WeightCalculator sut = new WeightCalculator
            {
                Sex = 'r',
                Height = 180
            };

            // Act
            double actual = sut.GetIdealBodyWeight();
            double expected = 0;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [Description("This test is about using some Assert methods")]
        [Owner("KhalidEssaadani")]
        [Priority(2)]
        [TestCategory("AssertCategory")]
        public void Assert_Tests()
        {
            // Assert.AreNotEqual(100, 90);

            //WeightCalculator calc1 = new WeightCalculator();
            //WeightCalculator calc2 = new WeightCalculator();

            //Assert.AreNotSame(calc1, calc2);

            //WeightCalculator calculator = new WeightCalculator();

            //Assert.IsInstanceOfType(calculator, typeof(WeightCalculator));

            ////calculator = null;

            //Assert.IsNotNull(calculator);

            Assert.IsFalse(100 == 9);
        }

        [TestMethod]
        [Description("This test is about using some StringAssert methods")]
        [Owner("KhalidEssaadani")]
        [Priority(2)]
        [TestCategory("AssertCategory")]
        public void StringAssert_Tests()
        {
            string name = "Khalid";

            StringAssert.Contains(name, "lid");
            name.Should().Contain("lid");

            StringAssert.EndsWith(name, "id");
            StringAssert.StartsWith(name, "Kh");
        }

        [TestMethod]
        [Description("This test is about using some CollectionAssert methods")]
        [Owner("KhalidEssaadani")]
        [Priority(2)]
        [TestCategory("AssertCategory")]
        [Ignore]
        public void CollectionAssert_Tests()
        {
            List<string> names = new List<string>() { "Hamid", "Said", "Khalid", "Kamal" };

            CollectionAssert.AllItemsAreNotNull(names);
            CollectionAssert.Contains(names, "Said");
            CollectionAssert.AllItemsAreInstancesOfType(names, typeof(string));
        }

        [TestMethod]
        [Description("This test is about using some FluentAssertions methods")]
        [Owner("KhalidEssaadani")]
        [Priority(3)]
        [TestCategory("AssertCategory")]
        [Timeout(3000)]
        public void FluentAssertions_Tests()
        {
            //string name = "Hamid";
            //name.Should().StartWith("H").And.EndWith("id");

            //int number = 10;

            //number.Should().BeGreaterThan(8);
            //number.Should().BeLessOrEqualTo(10);

            List<string> names = new List<string>() { "Ahmed", "Yassin" };

            names.Should().HaveCount(2);

            names.Should().NotBeEmpty();
        }

        [TestMethod]
        public void GetIdealBodyWeightFromDataSource_WithGoodInputs_Returns_Correct_Results()
        {
            WeightCalculator weightCalculator = new WeightCalculator(new FakeWeightRepository());

            List<double> actual = weightCalculator.GetIdealBodyWeightFromDataSource();
            double[] expected = { 62.5, 62.75, 74};

            actual.Should().BeEquivalentTo(expected);

        }

        [TestMethod]
        public void GetIdealBodyWeightFromDataSource_Using_Moq()
        {
            List<WeightCalculator> weights = new List<WeightCalculator>()
            {
                new WeightCalculator { Height = 175, Sex ='w' }, // 62.5
                new WeightCalculator { Height = 167, Sex ='m' }, // 62.75
            };

            Mock<IDataRepository> repo = new Mock<IDataRepository>();

            repo.Setup(w => w.GetWeights()).Returns(weights);

            WeightCalculator calculator = new WeightCalculator(repo.Object);

            var actual = calculator.GetIdealBodyWeightFromDataSource();

            double[] expected = { 62.5 , 62.75 };

            actual.Should().Equal(expected);
        }
    }
}
