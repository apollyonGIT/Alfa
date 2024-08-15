using GraphNode;
using System;

namespace Battle.BT_Graphs
{
    [Serializable]
    public class BT_Graph : Graph
    {
        public override Type context_type => typeof(BT_Context);
    }
}

