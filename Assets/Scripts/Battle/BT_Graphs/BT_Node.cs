using GraphNode;
using System;

namespace Battle.BT_Graphs
{
    [Serializable]
    public class BT_Node : Node
    {
        [ShowInBody(format = "[{0}]")]
        public string module_name;

        //==================================================================================================

    }
}

