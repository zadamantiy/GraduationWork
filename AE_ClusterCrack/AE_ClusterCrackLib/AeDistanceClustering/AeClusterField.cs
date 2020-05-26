using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AE_ClusterCrackLib.AeDistanceClustering
{
    public class AeClusterField
    {
        private readonly Dictionary<AePointBase, List<AePoint>> _cells = new Dictionary<AePointBase, List<AePoint>>();

        public Point TopLeftPoint;
        public Point BotRightPoint;

        public int PointCount { get; private set; }
        public int ClusterCount { get; private set; }
        public int MaxClusterCount { get; private set; }
        public int CurrentClusterId { get; private set; }

        public double R;
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

        private void ClusterPoint(AePoint inputPoint)
        {
            //AddPoint(inputPoint);
            var newCluster = new AeCluster();
            inputPoint.MoveToCluster(PointCount, newCluster);
            ClusterCount++;

            var cells = GetNearestCells(inputPoint);
            var inputCluster = inputPoint.GetCurrentCluster();
            foreach (var cellPointer in cells)
            {
                foreach (var anotherPoint in _cells[cellPointer])
                {
                    if (!(inputPoint.GetDistanceTo(anotherPoint) <= R)) 
                        continue;

                    var anotherCluster = anotherPoint.GetCurrentCluster();
                    if (ReferenceEquals(inputCluster, anotherCluster))
                        continue;

                    ClusterCount--;
                    if (inputCluster.Count <= anotherCluster.Count)
                    {
                        foreach (var point in inputCluster)
                        {
                            point.MoveToCluster(PointCount, anotherCluster);
                        }
                        inputCluster = anotherPoint.GetCurrentCluster();
                    }
                    else
                    {
                        foreach (var point in anotherCluster)
                        {
                            point.MoveToCluster(PointCount, inputCluster);
                        }
                    }
                }
            }

            if (inputPoint.GetCurrentCluster() == newCluster)
            {
                CurrentClusterId++;
                newCluster.ClusterId = CurrentClusterId;
            }

            MaxClusterCount = Math.Max(MaxClusterCount, ClusterCount);
        }

        public List<AeCluster> GetClustersByPointCount(int pointCount)
        {
            var dic = new Dictionary<AeCluster, AeCluster>();

            foreach (var pointList in _cells.Values)
            {
                foreach (var point in pointList)
                {
                    var cluster = point.GetCluster(pointCount);

                    if (cluster == null)
                        continue;

                    if (dic.ContainsKey(cluster))
                    {
                        dic[cluster].Add(point);
                    }
                    else
                    {
                        dic[cluster] = new AeCluster{point};
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

        public void AddPoints(List<AePoint> pointList)
        {
            foreach (var point in pointList)
                AddPoint(point);
        }

        public void AddPoint(AePoint point)
        {
            var pt = FindCell(point);
            if (!_cells.ContainsKey(pt))
                _cells.Add(pt, new List<AePoint>());

            PointCount++;

            var ptFloorX = (int) Math.Floor(point.X) - 1;
            var ptFloorY = (int) Math.Floor(point.Y) - 1;
            var ptCeilX = (int) Math.Ceiling(point.X) + 1;
            var ptCeilY = (int) Math.Ceiling(point.Y) + 1;

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

        public AeClusterField(double r)
        {
            PointCount = 0;
            ClusterCount = 0;
            CurrentClusterId = -1;

            _cellSize = (int) Math.Ceiling(r);
            R = r;

            for (var i = 0; i < 8; i++)
            {
                _dx[i] *= _cellSize;
                _dy[i] *= _cellSize;
            }
        }
    }
}
