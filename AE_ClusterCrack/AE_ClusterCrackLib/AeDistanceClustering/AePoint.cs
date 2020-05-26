using System.Collections.Generic;

namespace AE_ClusterCrackLib.AeDistanceClustering
{
    public class AePoint : AePointBase
    {
        private readonly List<int> _pointCount; 
        private readonly List<AeCluster> _clusterReference;

        public AePoint(double x, double y) : base(x, y)
        {
            X = x;
            Y = y;

            _pointCount = new List<int>();
            _clusterReference = new List<AeCluster>();
        }

        public void MoveToCluster(int pointCount, AeCluster cluster)
        {
            if (_pointCount.Count > 0 && _pointCount[_pointCount.Count - 1] == pointCount)
            {
                _clusterReference[_pointCount.Count - 1] = cluster;
            }
            else
            {
                _pointCount.Add(pointCount);
                _clusterReference.Add(cluster);
            }

            cluster.Add(this);
        }

        public AeCluster GetCurrentCluster()
        {
            return _clusterReference.Count == 0 ? null : _clusterReference[_clusterReference.Count - 1];
        }

        public AeCluster GetCluster(int pointCount)
        {
            if (_pointCount == null /*|| _clusterReference == null*/)
                return null;

            if (_pointCount[0] > pointCount)
                return null;

            var l = 0;
            var r = _clusterReference.Count - 1;

            while (r - l > 1)
            {
                var m = (l + r) / 2;
                if (_pointCount[m] < pointCount)
                { 
                    l = m;
                }
                else if (_pointCount[m] > pointCount)
                {
                    r = m - 1;
                }
                else
                {
                    return _clusterReference[m];
                }
            }

            return _pointCount[r] <= pointCount ? _clusterReference[r] : _clusterReference[l];
        }
    }
}
