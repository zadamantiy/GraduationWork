using System;

namespace AE_ClusterCrackLib
{
    public class AePointBase
    {
        public double X;
        public double Y;

        public AePointBase(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Вычисляет расстояние от текущей точки до другой
        /// </summary>
        /// <param name="point">Точка до которой вычисляется расстояние</param>
        /// <returns>Расстояние до точки</returns>
        public double GetDistanceTo(AePointBase point)
        {
            var tmp1 = X - point.X;
            var tmp2 = Y - point.Y;
            return Math.Sqrt(tmp1 * tmp1 + tmp2 * tmp2);
        }

        public override bool Equals(object obj)
        {
            return obj is AePointBase point && point.X == X && point.Y == Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }
    }
}
