using Battle.BT_Graphs;
using GraphNode.Editor;

namespace Editor.GraphEditors
{
    [NodeEditor(typeof(BT_Node))]
    public class BT_NodeEditor : GenericNodeEditor
    {
        protected BT_NodePort m_incoming_port;
        public new BT_Node node => base.node as BT_Node;

        //==================================================================================================

        public override void on_output_connected(ConnectionView connection)
        {
            if (view.graph.undo.operating)
            {
                return;
            }

            //if (connection.output.port == m_incoming_port)
            //{
            //    var cmd = new AddPort
            //    {
            //        editor = this,
            //    };
            //    cmd.port = m_incoming_port;
            //    cmd.incoming_port = new BT_NodePort { index = 2 };
            //    cmd.incoming_port_view = new OutputPortView(view, cmd.incoming_port, view.graph.editor.query_node_port_color(m_incoming_port));
            //    cmd.redo();
            //    view.graph.undo.record(cmd);
            //}

            var cmd = new AddPort
            {
                editor = this,
            };

            cmd.incoming_port = new BT_NodePort { index = 0 };
            cmd.incoming_port_view = new OutputPortView(view, cmd.incoming_port, view.graph.editor.query_node_port_color(m_incoming_port));
            cmd.redo();

            view.graph.undo.record(cmd);
        }


        private class AddPort : GraphUndo.ICommand
        {
            public BT_NodeEditor editor;
            public BT_NodePort port;
            public BT_NodePort incoming_port;
            public OutputPortView incoming_port_view;

            public int dirty_count => 1;

            public void redo()
            {
                editor.m_incoming_port = incoming_port;
                editor.view.dynamic_output_ports.Add(incoming_port_view);
                editor.view.size_changed = true;
            }

            public void undo()
            {
                editor.m_incoming_port = port;
                editor.view.dynamic_output_ports.RemoveAt(incoming_port.index);
                editor.view.size_changed = true;
            }
        }

        private class RemovePort : GraphUndo.ICommand
        {
            public BT_NodeEditor editor;
            public BT_NodePort port;
            public OutputPortView port_view;

            public int dirty_count => 1;

            public void redo()
            {
                var index = port.index;
                editor.view.dynamic_output_ports.RemoveAt(index);
                editor.view.size_changed = true;
            }

            public void undo()
            {
                var index = port.index;
                editor.view.dynamic_output_ports.Insert(index, port_view);
                editor.view.size_changed = true;
            }
        }
    }


}
