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

        //==================================================================================================

        #region Input
        [Input]
        [Display("input")]
        public void _i(BT_Context bctx)
        {
            Move e = new();
            e.init(bctx, this);
            e.@do(bctx, move_type);
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

        public override void @do(BT_Context bctx, params object[] args)
        {
            var move_type = (EN_Move_Type)args[0];
            var pos = (Vector2)bctx.owner.GetType().GetProperty("pos_ref").GetValue(bctx.owner);

            Move_Helper.move(move_type, ref pos);
            bctx.owner.GetType().GetProperty("pos_ref").SetValue(bctx.owner, pos);

            node.do_out("_o", bctx);
        }

    }
}

