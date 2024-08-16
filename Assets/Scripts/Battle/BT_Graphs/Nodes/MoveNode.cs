using GraphNode;
using System;
using UnityEngine;

namespace Battle.BT_Graphs
{
    [Serializable]
    [Graph(typeof(BT_Graph))]
    public class MoveNode : BT_Node
    {
        [ShowInBody(format = "move_type -> {0}")]
        public EN_Move_Type move_type;

        [ShowInBody(format = "step -> {0}")]
        public int step;

        //==================================================================================================

        #region Input
        [Input]
        [Display("input")]
        public void _i(BT_Context bctx)
        {
            var pos = Move_Helper.move(move_type, bctx.pos, step);

            if (bctx.sight.ContainsKey(pos))
                bctx.pos = pos;

            _o?.Invoke(bctx);
        }
        #endregion


        #region Output
        [Output]
        [Display("out")]
        public System.Action<BT_Context> _o { get; set; }
        #endregion
    }
}

