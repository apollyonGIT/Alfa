using GraphNode;

namespace Battle.BT_Graphs
{
    [System.Serializable]
    public class BT_NodePort : NodeDynamicNodePort<BT_Node>
    {
        public override IO io => IO.Output;
        public override string name => index.ToString();

        [System.NonSerialized]
        public int index;
    }
}

