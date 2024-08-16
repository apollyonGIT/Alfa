using Common.Graph_Module;
using System;
using System.Collections;

namespace Battle.BT_Graphs
{
    [Serializable]
    public class BT_Expression : Expression
    {
        public override Type ctx_type => typeof(BT_Context);
    }
}

