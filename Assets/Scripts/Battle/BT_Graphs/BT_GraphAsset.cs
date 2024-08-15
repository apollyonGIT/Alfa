using GraphNode;
using UnityEngine;

namespace Battle.BT_Graphs
{
    [CreateAssetMenu(fileName = "bt_graph", menuName = "DIY_Graph/BT_Graph")]
    public class BT_GraphAsset : GraphAsset<BT_Graph>
    {
        //==================================================================================================

        public override Graph new_graph()
        {
            BT_Graph graph = new()
            {
                nodes = new Node[] { }
            };

            return graph;
        }
    }
}

