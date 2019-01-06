using NUnit.Framework;
using System;

namespace Domain.Tests
{
    [TestFixture]
    public class TriangleTest
    {
        [Test]
        [TestCase((int)0, (int)10, (int)15)]
        [TestCase((int)15, (int)0, (int)15)]
        [TestCase((int)15, (int)10, (int)0)]
        public void ShouldThrowAnyLengthIsZero(int first, int second, int third)
        {
            // Arrange
            object result;

            // Act
            result = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(first, second, third));

            // Assert
            Assert.That(result, Is.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ShouldInstantiateForValidLengths()
        {
            // Arrange
            Triangle result;

            // Act
            result = new Triangle(10, 15, 10);

            // Assert
            Assert.That(result, Is.InstanceOf<Triangle>());
        }

        [Test]
        [TestCase((int)10, (int)10, (int)10, TriangleType.Equilateral)]
        [TestCase((int)10, (int)10, (int)5, TriangleType.Isosceles)]
        [TestCase((int)10, (int)5, (int)1, TriangleType.Scalene)]
        public void ShouldSetTypeBasedOnSidesLengths(int first, int second, int third, TriangleType expectedType)
        {
            // Arrange
            Triangle triangle = new Triangle(first, second, third);

            // Act
            TriangleType result = triangle.Type;

            // Assert
            Assert.That(result, Is.EqualTo(expectedType));
        }
    }
}
