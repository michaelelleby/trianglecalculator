using Domain;
using System;

namespace CloudeonTriangleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Triangle with sides 10x10x10 is an {new Triangle(10, 10, 10).Type.ToString().ToLower()} triangle");

            Console.WriteLine($"Triangle with sides 10x10x5 is an {new Triangle(10, 10, 5).Type.ToString().ToLower()} triangle");

            Console.WriteLine($"Triangle with sides 10x5x1 is a {new Triangle(10, 5, 1).Type.ToString().ToLower()} triangle");
        }
    }
}