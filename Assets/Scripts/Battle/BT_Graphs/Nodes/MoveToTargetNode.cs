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
            ref var pos = ref bctx.pos;
            Vector2 target_pos = new(target_x.do_calc_float(bctx), target_y.do_calc_float(bctx));

            if (step > 0 && SeekPath_Helper.try_seek_path(bctx.pos, target_pos, bctx.sight, out var path))
            {
                if (step > path.Length)
                    pos = path.Last();
                else
                    pos = path[step - 1];
            }

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

