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
        BT_GraphAsset m_asset;

        Type IContext.context_type => typeof(BT_Context);

        Dictionary<string, BT_CPN> m_cpns = new();

        //================================================================================================

        public BT_Context(object owner, (string, string) asset_path)
        {
            this.owner = owner;

            EX_Utility.try_load_asset(asset_path, out m_asset);
            attach(m_asset);

            m_asset.notify_on_save += attach;

            main_state = "idle";
        }


        public void attach(BT_GraphAsset asset)
        {
            m_cpns.Clear();

            foreach (var node in asset.graph.nodes.Where(t => t is BT_Node bn && bn.module_name != null && bn.cpn_type != null).Cast<BT_Node>())
            {
                m_cpns.Add(node.module_name, node.init_cpn(this));
            }
        }


        public void detach()
        {
            m_asset.notify_on_save -= attach;
        }


        public void tick()
        {
            try_do_cpn(main_state);
        }


        public bool try_do_cpn(string module_name, params object[] args)
        {
            if (!m_cpns.TryGetValue(module_name, out var cpn)) return false;

            cpn.@do(this, args);
            return true;
        }
    }
}

