using CalcExpr;
using Common;
using Common.Graph_Module;
using GraphNode;
using GraphNode.Editor;

namespace Editor.GraphEditors
{
    [PropertyEditor(typeof(Common.Graph_Module.Expression))]
    public class ExpressionEditor : ExpressionEditor<Common.Graph_Module.Expression>
    {

        //================================================================================================

        public override ExpressionBase create_expression()
        {
            return new Common.Graph_Module.Expression();
        }


        protected override bool get_external(string str, out ValueType ty, out IExpressionExternal external)
        {
            Common_DS.instance.try_get_value("expression_continue", out bool need_complete);

            external = new EE(str, target.ctx_type, need_complete);
            ty = external.ret_type;

            var content = target.content;
            int startIndex = content.IndexOf(str);
            int endIndex = startIndex + str.Length;

            string head = content[..startIndex];
            string tail = content[endIndex..];

            target.content = $"{head}{(external as EE).complete_content}{tail}";

            return (ty != ValueType.Unknown);
        }


        protected override void notify_changed(bool by_user)
        {
            Common_DS.instance.add("expression_continue", false);

            var content = target.content;
            if (content.Contains("@"))
            {
                target.content = content.Split("@")[0];
                Common_DS.instance.add("expression_continue", true);
            }

            base.notify_changed(by_user);
        }
    }
}

