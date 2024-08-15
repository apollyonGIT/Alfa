using GraphNode;
using System;

namespace Battle.BT_Graphs
{
    [Serializable]
    public class BT_Node : Node
    {
        [ShowInBody(format = "[{0}]")]
        public string module_name;

        public virtual Type cpn_type => null;

        //==================================================================================================

        public BT_CPN init_cpn(BT_Context bctx)
        {
            return (BT_CPN)Activator.CreateInstance(cpn_type, bctx, this);
        }


        public void do_out(string method_name, BT_Context bctx)
        {
            var _out = (System.Action<BT_Context>)GetType().GetProperty(method_name).GetValue(this);
            _out?.Invoke(bctx);
        }
    }
}

