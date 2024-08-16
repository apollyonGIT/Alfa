using GraphNode;
using System;
using UnityEngine;

namespace Battle.BT_Graphs
{
    [Serializable]
    [Graph(typeof(BT_Graph))]
    public class MainStateNode : BT_Node
    {

        //==================================================================================================

        #region Input
        #endregion


        #region Output
        [Output]
        [Display("out")]
        public System.Action<BT_Context> _o { get; set; }
        #endregion


        public void @do(BT_Context bctx)
        {
            _o?.Invoke(bctx);
        }
    }
}

