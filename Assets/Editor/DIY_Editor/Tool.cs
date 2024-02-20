using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace Editor.DIY_Editor
{
    public class Tool : EditorTool
    {
        protected GUIContent m_icon;
        public override GUIContent toolbarIcon => m_icon;

        public Component root;

        //==================================================================================================

        public virtual void init(Component root, string icon_image_path, string icon_text)
        {
            m_icon = new()
            {
                image = EditorGUIUtility.IconContent(icon_image_path).image,
                text = icon_text,
                tooltip = icon_text,
            };

            this.root = root;
        }


        public override void OnToolGUI(EditorWindow window)
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

            var ev = Event.current;
            if (ev.type != EventType.MouseDown && ev.type != EventType.MouseDrag) return;
            if (!Common.Mouse_Helper.try_get_mouse_point(ev, root, out var point)) return;

            var args = new object[] { (Vector2)point };
            if (ev.button == 0)
                left_click(args);
            if (ev.button == 1)
                right_click(args);

            ev.Use();
        }


        protected virtual void left_click(object[] args)
        { 
        }


        protected virtual void right_click(object[] args)
        {
        }
    }
}

