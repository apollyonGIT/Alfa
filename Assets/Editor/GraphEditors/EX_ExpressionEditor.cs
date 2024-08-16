using Battle.Graph_Module;
using CalcExpr;
using Common;
using GraphNode;
using GraphNode.Editor;
using System.Linq;

namespace Editor.GraphEditors
{
    [PropertyEditor(typeof(EX_Expression))]
    public class EX_ExpressionEditor : ExpressionEditor<EX_Expression>
    {
        public override ExpressionBase create_expression()
        {
            return new EX_Expression();
        }


        protected override bool get_external(string str, out ValueType ty, out IExpressionExternal external)
        {
            //if (!EX_Data.datas.Any())
            //    EX_Data.reset();

            Common_DS.instance.try_get_value("tl_content_need_complete", out bool need_complete);

            external = new EE(str, EX_Data.owner_type, need_complete);
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
            Common_DS.instance.add("tl_content_need_complete", false);

            var content = target.content;
            if (content.Contains("@"))
            {
                target.content = content.Split("@")[0];
                Common_DS.instance.add("tl_content_need_complete", true);
            }

            base.notify_changed(by_user);
        }
    }
}

