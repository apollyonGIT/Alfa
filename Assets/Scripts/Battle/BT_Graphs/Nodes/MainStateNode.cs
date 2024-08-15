using GraphNode;
using System;
using UnityEngine;

namespace Battle.BT_Graphs
{
    [Serializable]
    [Graph(typeof(BT_Graph))]
    public class MainStateNode : BT_Node
    {
        public override Type cpn_type => typeof(MainState);

        //==================================================================================================

        #region Input
        #endregion


        #region Output
        [Output]
        [Display("out")]
        public System.Action<BT_Context> _o { get; set; }
        #endregion
    }


    public class MainState : BT_CPN
    {

        //==================================================================================================

        public override void @do(BT_Context ctx)
        {
            node.do_method("_o");
        }

    }
}

