using Battle.BT_Graphs;
using GraphNode;
using GraphNode.Editor;

namespace Editor.GraphEditors
{
    [PropertyEditor(typeof(BT_Expression))]
    public class BT_ExpressionEditor : ExpressionEditor
    {

        //================================================================================================

        public override ExpressionBase create_expression()
        {
            return new BT_Expression();
        }


    }
}

