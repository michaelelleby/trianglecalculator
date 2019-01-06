using Domain;
using FunctionTestHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;
using System.Collections.Generic;

namespace AzureCalculator.Test
{
    public class CalculateTests : FunctionTest
    {
        [Test]
        [TestCase(10, 10, 10, TriangleType.Equilateral)]
        [TestCase(10, 10, 5, TriangleType.Isosceles)]
        [TestCase(10, 5, 1, TriangleType.Scalene)]
        public void ShouldReturnCorrectType(int first, int second, int third, TriangleType expectedType)
        {
            var query = new Dictionary<string, StringValues>();
            var body = "";

            var result = Calculate.Run(req: HttpRequestSetup(query, body), first: first, second: second, third: third, log: log);
            var resultObject = (OkObjectResult)result;

            Assert.AreEqual(expectedType.ToString(), resultObject.Value.ToString());
        }
    }
}