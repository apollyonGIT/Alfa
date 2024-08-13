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
            if (!try_get_mouse_point(ev, root, out var point)) return;

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


        /// <summary>
        /// 获取鼠标在scene中的点击位置
        /// 以组件所在的gameobject为参照物
        /// </summary>
        public static bool try_get_mouse_point(Event ev, Component target, out Vector3 point)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(ev.mousePosition);

            point = new();
            if (target == null) return false;

            var transform = target.transform;
            var plane = new Plane(transform.forward, -Vector3.Dot(transform.position, transform.forward));

            if (!plane.Raycast(ray, out var distance)) return false;

            point = ray.GetPoint(distance);
            point = transform.InverseTransformPoint(point); //获取点的位置
            return true;
        }
    }
}

