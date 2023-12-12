using UnityEditor;
using UnityEngine;

namespace Editor.DIY_Editor.Tools
{
    public class Brush : DIY_EditorTool
    {
        public string m_win_title;

        //==================================================================================================

        public override void init(Component root, string icon_image_path, string icon_text)
        {
            base.init(root, icon_image_path, icon_text);

            m_win_title = GetType().Name;
        }


        public override void OnToolGUI(EditorWindow window)
        {
            create_win(window);
            mouse_left_down();
        }


        /// <summary>
        /// 创建窗体
        /// </summary>
        void create_win(EditorWindow window)
        {
            Handles.BeginGUI();
            var size = window.position.size;
            var panel_size = new Vector2(200, 70);
            var pos = size - panel_size - new Vector2(16, 36);

            GUILayout.BeginArea(new Rect(pos, panel_size), m_win_title, GUI.skin.window);
            EditorGUIUtility.labelWidth = 40;

            draw_win_content();

            GUILayout.EndArea();
            Handles.EndGUI();
        }


        protected virtual void draw_win_content()
        { 
        }


        void mouse_left_down()
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

            var ev = Event.current;
            if (ev.type != EventType.MouseDown) return;
            if (ev.button != 0) return;
            if (!Common.EX_Utility.try_get_mouse_point(ev, root, out var point)) return;

            root.GetType().GetMethod("do_brush")?.Invoke(root, new object[] { point });
            ev.Use();
        }

    }
}

