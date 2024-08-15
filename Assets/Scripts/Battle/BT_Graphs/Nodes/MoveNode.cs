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
            var e = new Move(bctx, this);
            e.@do(bctx, move_type, step);
        }
        #endregion


        #region Output
        [Output]
        [Display("out")]
        public System.Action<BT_Context> _o { get; set; }
        #endregion
    }


    public class Move : BT_CPN
    {

        //==================================================================================================

        public Move(BT_Context bctx, BT_Node node) : base(bctx, node)
        {
        }


        public override void @do(BT_Context bctx, params object[] args)
        {
            var move_type = (EN_Move_Type)args[0];
            var step = (int)args[1];

            var owner = bctx.owner;
            var pi = owner.GetType().GetProperty("pos_ref");

            var pos = (Vector2)pi.GetValue(owner);
            Move_Helper.move(move_type, ref pos, step);
            pi.SetValue(owner, pos);

            node.do_out("_o", bctx);
        }

    }
}

