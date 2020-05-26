using System;
using System.Collections.Generic;

namespace AE_ClusterCrackLib.AeDbscanClustering
{
    public class AeDbscanBasePoint : AePointBase
    {
        private readonly List<int> _pointCount; 
        private readonly List<AeDbscanCluster> _clusterReference;
        private List<AeDbscanBasePoint> _closePoints;
        public int PointId { get; private set; }

        public bool IsCore { get; private set; }

        public AeDbscanBasePoint(double x, double y, int id) : base(x, y)
        {
            X = x;
            Y = y;
            IsCore = false;

            PointId = id;
            _pointCount = new List<int>();
            _clusterReference = new List<AeDbscanCluster>();
            _closePoints = new List<AeDbscanBasePoint>();
        }

        public List<AeDbscanBasePoint> GetClosePoints()
        {
            return _closePoints;
        }

        public int AddClosePoint(AeDbscanBasePoint inputPoint)
        {
            if (IsCore)
                return -1;

            _closePoints.Add(inputPoint);
            return _closePoints.Count;
        }

        public void MakeCore()
        {
            IsCore = true;
            _closePoints = null;
        }

        public void MoveToCluster(int pointCount, AeDbscanCluster cluster)
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

        public AeDbscanCluster GetCurrentCluster()
        {
            return _clusterReference.Count == 0 ? null : _clusterReference[_clusterReference.Count - 1];
        }

        public AeDbscanCluster GetCluster(int pointCount)
        {
            if (_pointCount == null /*|| _clusterReference == null*/)
                return null;

            if (_pointCount.Count == 0 || _pointCount[0] > pointCount)
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
