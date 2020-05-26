using System.Collections.Generic;

namespace AE_ClusterCrackLib.AeDbscanClustering
{
    public class AeDbscanCluster : List<AeDbscanBasePoint>
    {
        public int ClusterId;

        public AeDbscanCluster()
        {
            ClusterId = 0;
        }

        public AeDbscanCluster(int clusterId)
        {
            ClusterId = clusterId;
        }
    }
}