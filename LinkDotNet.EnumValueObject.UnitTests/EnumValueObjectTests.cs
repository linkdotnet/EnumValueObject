using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LinkDotNet.EnumValueObject.UnitTests
{
    [TestClass]
    public class EnumValueObjectTests
    {
        [TestMethod]
        public void GivenEnumValueObject_WhenCallingToString_ThenKeyIsReturned()
        {
            // Arrange
            var testEnum = TestEnumValueObject.One;

            // Act
            var display = testEnum.ToString();

            // Assert
            display.ShouldBe(testEnum.Key);
        }

        [TestMethod]
        public void GivenEnumValueObject_WhenCallingAll_ThenAllPartsAreReturned()
        {
            // Act
            var all = TestEnumValueObject.All;

            // Assert
            all.ShouldContain(TestEnumValueObject.One);
            all.ShouldContain(TestEnumValueObject.Two);
        }

        [TestMethod]
        public void GivenEnumValueObject_WhenComparingEqualOnes_ThenEqual()
        {
            // Arrange
            var enum1 = TestEnumValueObject.One;
            var alsoEnum1 = TestEnumValueObject.Create("One").Value;

            // Act
            var isEqual = enum1 == alsoEnum1;

            isEqual.ShouldBeTrue();
        }

        [TestMethod]
        public void GivenEnumValueObject_WhenComparingWithStringKey_ThenEqual()
        {
            // Arrange
            var enum1 = TestEnumValueObject.One;
            const string enum1Key = "One";

            // Act
            var isEqual = enum1 == enum1Key;

            // Assert
            isEqual.ShouldBeTrue();
        }

        [TestMethod]
        public void GivenInvalidKey_WhenCreatingEnumValueObject_ThenErrorResult()
        {
            // Act
            var result = TestEnumValueObject.Create("InvalidKey");

            // Assert
            result.IsFailure.ShouldBeTrue();
            result.Error.ShouldBe("The type 'InvalidKey' is not a valid TestEnumValueObject.");
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("  ")]
        public void GivenNullOrEmptyKey_WhenCreating_ThenException(string key)
        {
            // Assert
            Assert.ThrowsException<ArgumentException>(() => new TestEnumValueObject(key));
        }

        [DataTestMethod]
        [DataRow(null, false)]
        [DataRow("Four", false)]
        [DataRow(nameof(TestEnumValueObject.Two), true)]
        [DataRow(nameof(TestEnumValueObject.One), true)]
        public void GivenPossibleKey_WhenCheckingIfKeyIsEnumValueObject_ThenShouldReturnTrueIfKeyRecognized(string possibleKey, bool isIn)
        {
            // Act
            var isEnumValueObject = TestEnumValueObject.Is(possibleKey);

            // Assert
            isEnumValueObject.ShouldBe(isIn);
        }
    }
}
