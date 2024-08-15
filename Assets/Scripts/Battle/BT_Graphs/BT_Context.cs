using Common;
using GraphNode;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle.BT_Graphs
{
    public class BT_Context : IContext
    {
        public string main_state;

        public object owner;
        public BT_GraphAsset asset;

        Type IContext.context_type => typeof(BT_Context);

        Dictionary<string, BT_CPN> m_cpns = new();

        //================================================================================================

        public BT_Context(object owner, (string, string) asset_path)
        {
            this.owner = owner;

            EX_Utility.try_load_asset(asset_path, out asset);
            init_graph();

            main_state = "idle";
        }


        public void init_graph()
        {
            foreach (var node in asset.graph.nodes.Where(t => t is BT_Node bn && bn.cpn_type != null).Cast<BT_Node>())
            {
                m_cpns.Add(node.module_name, node.init_cpn(this));
            }
        }


        public void tick()
        {
            m_cpns.TryGetValue(main_state, out var start);
            start.@do(this);
        }
    }
}

