using Common;
using GraphNode;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle.BT_Graphs
{
    public class BT_Context : IContext
    {
        public string main_state;

        public Vector2 pos;
        public Dictionary<Vector2, object> sight => calc_sight();

        public object owner;
        BT_GraphAsset m_asset;

        Type IContext.context_type => typeof(BT_Context);

        public Dictionary<string, BT_Node> nodes = new();

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
            nodes.Clear();

            foreach (var node in asset.graph.nodes.Where(t => t is BT_Node bn && bn.module_name != null).Cast<BT_Node>())
            {
                nodes.Add(node.module_name, node);
            }
        }


        public void detach()
        {
            m_asset.notify_on_save -= attach;
        }


        public void call()
        {
            do_node_method(main_state);
        }


        public void do_node_method(string module_name)
        {
            nodes.TryGetValue(module_name, out var node);
            node.GetType().GetMethod("do")?.Invoke(node, new object[] { this });
        }


        Dictionary<Vector2, object> calc_sight()
        {
            Mission.instance.try_get_mgr("BFMgr", out BFs.BFMgr bf_mgr);
            var ret = bf_mgr.cells.Where(t => t.Value.is_access).ToDictionary(t => t.Key, t => (object)t.Value);

            return ret;
        }
    }
}

