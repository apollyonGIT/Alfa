using GraphNode;
using System;
using UnityEngine;

namespace Battle.BT_Graphs
{
    [CreateAssetMenu(fileName = "bt_graph", menuName = "DIY_Graph/BT_Graph")]
    public class BT_GraphAsset : GraphAsset<BT_Graph>
    {
        public System.Action<BT_GraphAsset> notify_on_save;

        //==================================================================================================

        public override Graph new_graph()
        {
            BT_Graph graph = new()
            {
                nodes = new Node[] { }
            };

            return graph;
        }


        public override bool save_graph(Graph graph)
        {
            var ret = base.save_graph(graph);
            notify_on_save?.Invoke(this);

            return ret;
        }
    }
}

