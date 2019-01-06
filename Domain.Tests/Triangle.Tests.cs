using NUnit.Framework;
using System;

namespace Domain.Test
{
    [TestFixture]
    public class TriangleTest
    {
        [Test]
        [TestCase(0, 10, 15)]
        [TestCase(15, 0, 15)]
        [TestCase(15, 10, 0)]
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
        [TestCase(10, 10, 10, TriangleType.Equilateral)]
        [TestCase(10, 10, 5, TriangleType.Isosceles)]
        [TestCase(10, 5, 1, TriangleType.Scalene)]
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
