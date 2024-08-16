using GraphNode;
using System;
using System.Linq;
using UnityEngine;

namespace Battle.BT_Graphs
{
    [Serializable]
    [Graph(typeof(BT_Graph))]
    public class MoveToTargetNode : BT_Node
    {
        [ShowInBody(format = "step -> {0}")]
        public int step;

        [ShowInBody(format = "target_x -> {0}")]
        [ExpressionType(CalcExpr.ValueType.Floating)]
        public BT_Expression target_x;

        [ShowInBody(format = "target_y -> {0}")]
        [ExpressionType(CalcExpr.ValueType.Floating)]
        public BT_Expression target_y;

        //==================================================================================================

        #region Input
        [Input]
        [Display("input")]
        public void _i(BT_Context bctx)
        {
            var e = new Move_To_Target(bctx, this);
            e.@do(bctx, new Vector2(target_x.do_calc_float(bctx), target_y.do_calc_float(bctx)) ,step);
        }
        #endregion


        #region Output
        [Output]
        [Display("out")]
        public System.Action<BT_Context> _o { get; set; }
        #endregion
    }


    public class Move_To_Target : BT_CPN
    {

        //==================================================================================================

        public Move_To_Target(BT_Context bctx, BT_Node node) : base(bctx, node)
        {
        }


        public override void @do(BT_Context bctx, params object[] args)
        {
            ref var pos = ref bctx.pos;
            var target_pos = (Vector2)args[0];
            var step = (int)args[1];

            if (step > 0 && SeekPath_Helper.try_seek_path(bctx.pos, target_pos, bctx.sight, out var path))
            {
                if (step > path.Length)
                    pos = path.Last();
                else
                    pos = path[step - 1];
            }

            node.do_out("_o", bctx);
        }

    }
}

