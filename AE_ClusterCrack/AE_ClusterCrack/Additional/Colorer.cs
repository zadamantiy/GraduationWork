using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE_ClusterCrack.Additional
{
    internal static class Colorer
    {
        private const double MinHueLimit = 0.0;
        private const double MaxHueLimit = 240.0 / 360;
        private const double MinLightnessLimit = 0.0;
        private const double MaxLightnessLimit = 0.5;
        private const double MaxDanger = 1000;

        public static Color GetColorByClass(int cluster, int clusterAmount)
        {
            if (cluster == -1)
                return Color.Black;

            if (clusterAmount == 0)
                clusterAmount = 1;

            if (cluster > clusterAmount)
                cluster = clusterAmount;

            cluster = clusterAmount - cluster;

            return Hsl2Rgb(
                MinHueLimit + (double)cluster / clusterAmount * (MaxHueLimit - MinHueLimit),
                0.5,
                0.5
            );
        }

        public static Color Hsl2Rgb(double h, double sl, double l)
        {
            var r = l;
            var g = l;
            var b = l;
            var v = l <= 0.5 ? l * (1.0 + sl) : l + sl - l * sl;
            if (v > 0)
            {
                var m = l + l - v;
                var sv = (v - m) / v;
                h *= 6.0;
                var sextant = (int)h;
                var fract = h - sextant;
                var vsf = v * sv * fract;
                var mid1 = m + vsf;
                var mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            var rgb = Color.FromArgb(Convert.ToByte(r * 255.0f), Convert.ToByte(g * 255.0f), Convert.ToByte(b * 255.0f));
            return rgb;
        }
    }
}
