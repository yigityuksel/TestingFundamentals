using System;

namespace TestingFundamentals.UnitTests.TestDoubles
{
    public static class Solve
    {
        public static Tuple<double, double> Quadratic(double a, double b, double c)
        {
            var discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
                throw new Exception("Cannot not solve with complex roots");
            else
            {
                var root = Math.Sqrt(discriminant);
                return Tuple.Create(
                    (-b + root) / 2 / a,
                    (-b - root) / 2 / a
                    );
            }
        }
    }
}