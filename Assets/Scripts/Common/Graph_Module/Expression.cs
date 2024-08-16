using CalcExpr;
using GraphNode;
using System;
using System.Linq;

namespace Common.Graph_Module
{
    [Serializable]
    public class Expression : Expression<Expression>
    {
        public virtual Type ctx_type => null;

        //================================================================================================

        public int do_calc_int<T>(T ctx) where T : IContext
        {
            if (constant.HasValue)
            {
                return (int)constant.Value;
            }

            var cx = ExpressionCalculator.instance;
            cx.attach(code);

            //获取ee的值
            if (externals != null)
            {
                foreach (var (ee, index) in externals.Select((value, i) => (value, i)))
                {
                    ee.get_value(ctx, default, out var value);
                    EE.set_external(cx, ee, index, value);
                }
            }

            //加载函数
            if (functions != null)
            {
                foreach (var function in functions)
                {
                    function.initialize(ctx.GetType());
                }
            }

            //运行计算器，并返回结果
            ExpressionFunction.fns = functions;
            ExpressionFunction.obj = ctx;
            cx.run(ExpressionFunction.entry);
            ExpressionFunction.fns = null;
            ExpressionFunction.obj = null;

            cx.get_result(out int ret);
            return ret;
        }


        public float do_calc_float<T>(T ctx) where T : IContext
        {
            if (constant.HasValue)
            {
                return Utility.convert_float_from(constant.Value);
            }

            var cx = ExpressionCalculator.instance;
            cx.attach(code);

            //获取ee的值
            if (externals != null)
            {
                foreach (var (ee, index) in externals.Select((value, i) => (value, i)))
                {
                    ee.get_value(ctx, default, out var value);
                    EE.set_external(cx, ee, index, value);
                }
            }

            //加载函数
            if (functions != null)
            {
                foreach (var function in functions)
                {
                    function.initialize(ctx.GetType());
                }
            }

            //运行计算器，并返回结果
            ExpressionFunction.fns = functions;
            ExpressionFunction.obj = ctx;
            cx.run(ExpressionFunction.entry);
            ExpressionFunction.fns = null;
            ExpressionFunction.obj = null;

            cx.get_result(out float ret);
            return ret;
        }


        public bool do_calc_bool<T>(T ctx) where T : IContext
        {
            if (constant.HasValue)
            {
                return constant.Value != 0;
            }

            var cx = ExpressionCalculator.instance;
            cx.attach(code);

            //获取ee的值
            if (externals != null)
            {
                foreach (var (ee, index) in externals.Select((value, i) => (value, i)))
                {
                    ee.get_value(ctx, default, out var value);
                    EE.set_external(cx, ee, index, value);
                }
            }

            //加载函数
            if (functions != null)
            {
                foreach (var function in functions)
                {
                    function.initialize(ctx.GetType());
                }
            }

            //运行计算器，并返回结果
            ExpressionFunction.fns = functions;
            ExpressionFunction.obj = ctx;
            cx.run(ExpressionFunction.entry);
            ExpressionFunction.fns = null;
            ExpressionFunction.obj = null;

            cx.get_result(out bool ret);
            return ret;
        }
    }
}

