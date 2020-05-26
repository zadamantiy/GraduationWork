using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AE_ClusterCrackLib.AeDbscanClustering
{
    public class AeDbscanClusterField
    {
        private readonly Dictionary<AePointBase, List<AeDbscanBasePoint>> _cells = new Dictionary<AePointBase, List<AeDbscanBasePoint>>();

        public Point TopLeftPoint;
        public Point BotRightPoint;

        public int PointCount { get; private set; }
        public int ClusterCount { get; private set; }
        public int MaxClusterCount { get; private set; }
        public int CurrentClusterId { get; private set; }

        public double R;


        private readonly double _density;
        public double Density => _density - 1;

        private readonly int _cellSize;

        private readonly int[] _dx = { -1, -1, -1,  0, 0,  1, 1, 1 };
        private readonly int[] _dy = { -1,  0,  1, -1, 1, -1, 0, 1 };

        private AePointBase FindCell(AePointBase point)
        {
            return new AePointBase(Math.Floor(point.X / _cellSize) * _cellSize, Math.Floor(point.Y / _cellSize) * _cellSize);
        }

        private AePointBase FindCell(double x, double y)
        {
            return new AePointBase(Math.Floor(x / _cellSize) * _cellSize, Math.Floor(y / _cellSize) * _cellSize);
        }

        private AeDbscanCluster UnionClusters(AeDbscanCluster first, AeDbscanCluster second)
        {
            if (first == null || second == null)
                throw new NullReferenceException();

            if (ReferenceEquals(first, second))
                return first;
            
            ClusterCount--;
            if (first.Count <= second.Count)
            {
                foreach (var point in first)
                {
                    point.MoveToCluster(PointCount, second);
                }
                return second;
            }

            foreach (var point in second)
            {
                point.MoveToCluster(PointCount, first);
            }
            return first;
        }

        private void UnionClosePoints(AeDbscanBasePoint inputPoint)
        {
            var closePoints = inputPoint.GetClosePoints();

            var inputPointCluster = inputPoint.GetCurrentCluster();
            if (inputPointCluster == null)
            {
                inputPointCluster = new AeDbscanCluster(++CurrentClusterId);
                inputPoint.MoveToCluster(PointCount, inputPointCluster);
            }

            foreach (var point in closePoints)
            {
                var pointCluster = point.GetCurrentCluster();
                if (pointCluster == null)
                    point.MoveToCluster(PointCount, inputPointCluster);
                else
                    inputPointCluster = UnionClusters(pointCluster, inputPointCluster);
            }

            inputPoint.MakeCore();
        }

        private void ClusterPoint(AeDbscanBasePoint inputPoint)
        {
            //AddPoint(inputPoint);
            //var newCluster = new AeDbscanCluster();
            //inputPoint.MoveToCluster(PointCount, newCluster);
            ClusterCount++;

            var cells = GetNearestCells(inputPoint);

            if (_density == 0)
                inputPoint.MoveToCluster(PointCount, new AeDbscanCluster(++CurrentClusterId));

            foreach (var cellPointer in cells)
            {
                foreach (var anotherPoint in _cells[cellPointer])
                {
                    if (!(inputPoint.GetDistanceTo(anotherPoint) <= R)) 
                        continue;

                    if (!inputPoint.IsCore && !anotherPoint.IsCore)
                    { 
                        var inputCloseCount = inputPoint.AddClosePoint(anotherPoint);
                        var anotherCloseCount = anotherPoint.AddClosePoint(inputPoint);

                        if (anotherCloseCount >= _density)
                        {
                            UnionClosePoints(anotherPoint);
                        }

                        if (inputCloseCount >= _density)
                        {
                            UnionClosePoints(inputPoint);
                        }
                    }
                    else if (!inputPoint.IsCore && anotherPoint.IsCore)
                    {
                        var anotherPointCluster = anotherPoint.GetCurrentCluster();
                        var inputPointCluster = inputPoint.GetCurrentCluster();
                        if (inputPointCluster == null)
                            inputPoint.MoveToCluster(PointCount, anotherPointCluster);
                        else
                        {
                            UnionClusters(inputPointCluster, anotherPointCluster);
                        }
                    }
                    else if (inputPoint.IsCore && !anotherPoint.IsCore)
                    {
                        var inputPointCluster = inputPoint.GetCurrentCluster();
                        var anotherPointCluster = anotherPoint.GetCurrentCluster();
                        if (anotherPointCluster == null)
                            anotherPoint.MoveToCluster(PointCount, inputPointCluster);
                        else
                        {
                            UnionClusters(inputPointCluster, anotherPointCluster);
                        }
                    }
                    else
                    {
                        UnionClusters(inputPoint.GetCurrentCluster(), anotherPoint.GetCurrentCluster());
                    }
                }
            }

            MaxClusterCount = Math.Max(MaxClusterCount, ClusterCount);
        }

        public List<AeDbscanCluster> GetClustersByPointCount(int pointCount, out List<AeDbscanBasePoint> Unclusterized)
        {
            var dic = new Dictionary<AeDbscanCluster, AeDbscanCluster>();
            Unclusterized = new List<AeDbscanBasePoint>();

            foreach (var pointList in _cells.Values)
            {
                foreach (var point in pointList)
                {
                    var cluster = point.GetCluster(pointCount);

                    if (cluster == null)
                    {
                        if (point.PointId <= pointCount)
                        { 
                            Unclusterized.Add(point);
                        }
                        continue;
                    }

                    if (dic.ContainsKey(cluster))
                    {
                        dic[cluster].Add(point);
                    }
                    else
                    {
                        dic[cluster] = new AeDbscanCluster{point};
                        dic[cluster].ClusterId = cluster.ClusterId;
                    }
                }
            }

            return dic.Values.ToList();
        }

        private IEnumerable<AePointBase> GetNearestCells(AePointBase point)
        {
            var res = new List<AePointBase>();

            var mid = FindCell(point);
            res.Add(mid);

            //TODO: maybe rework
            for (var i = 0; i < 8; i++)
            {
                var tmp = new AePointBase(mid.X + _dx[i], mid.Y + _dy[i]);
                if (_cells.ContainsKey(tmp))
                    res.Add(tmp);
            }

            return res;
        }

        public void AddPoints(List<AeDbscanBasePoint> pointList)
        {
            foreach (var point in pointList)
                AddPoint(point);
        }

        public void AddPoint(AeDbscanBasePoint point)
        {
            var pt = FindCell(point);
            if (!_cells.ContainsKey(pt))
                _cells.Add(pt, new List<AeDbscanBasePoint>());

            PointCount++;

            var ptFloorX = (int) Math.Floor(point.X) - 1;
            var ptFloorY = (int) Math.Floor(point.Y) - 1;
            var ptCeilX = (int)Math.Ceiling(point.X) + 1;
            var ptCeilY = (int)Math.Ceiling(point.Y) + 1;

            if (PointCount == 1)
            {
                TopLeftPoint.X = ptFloorX;
                TopLeftPoint.Y = ptFloorY;
                BotRightPoint.X = ptCeilX;
                BotRightPoint.Y = ptCeilY;
            }
            else
            {
                if (ptFloorX < TopLeftPoint.X)
                    TopLeftPoint.X = ptFloorX;
                if (ptFloorY < TopLeftPoint.Y)
                    TopLeftPoint.Y = ptFloorY;

                if (ptCeilX > BotRightPoint.X)
                    BotRightPoint.X = ptCeilX;
                if (ptCeilY > BotRightPoint.Y)
                    BotRightPoint.Y = ptCeilY;
            }

            ClusterPoint(point);
            _cells[pt].Add(point);
        }

        public AeDbscanClusterField(double r, double density)
        {
            PointCount = 0;
            ClusterCount = 0;
            CurrentClusterId = -1;

            _cellSize = (int) Math.Ceiling(r);
            R = r;
            _density = density - 1;

            for (var i = 0; i < 8; i++)
            {
                _dx[i] *= _cellSize;
                _dy[i] *= _cellSize;
            }
        }
    }
}
