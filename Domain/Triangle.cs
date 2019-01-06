using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Triangle
    {
        public IReadOnlyCollection<Side> Sides { get; }

        public TriangleType Type { get; }

        public Triangle(int first, int second, int third)
        {
            if (first <= 0 || second <= 0 || third <= 0) throw new ArgumentOutOfRangeException("All side lengths must be greater than 0.");

            Sides = new List<Side>
            {
                new Side(first),
                new Side(second),
                new Side(third)
            };

            Type = GetTriangleType();
        }

        private TriangleType GetTriangleType()
        {
            var lengths = Sides.GroupBy(x => x.Length);
            switch (lengths.Count())
            {
                case 1:
                    return TriangleType.Equilateral;
                case 2:
                    return TriangleType.Isosceles;
                case 3:
                    return TriangleType.Scalene;
                default:
                    throw new InvalidOperationException("This code should not be reached, as a triangle must always have 3 sides.");
            }
        }
    }
}