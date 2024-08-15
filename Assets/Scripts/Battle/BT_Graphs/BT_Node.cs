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

        public BT_CPN init_cpn(BT_Context ctx)
        {
            var cpn = (BT_CPN)Activator.CreateInstance(cpn_type);
            cpn.init(ctx, this);

            return cpn;
        }


        public void do_method(string method_name, params object[] args)
        {
            GetType().GetMethod(method_name)?.Invoke(this, args);
        }
    }
}

