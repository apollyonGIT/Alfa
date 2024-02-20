using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common
{
    public class Mouse_Helper
    {
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


        /// <summary>
        /// 计算鼠标位置
        /// </summary>
        public static Vector2 calc_mouse_pos(Camera camera)
        {
            var raw = Mouse.current.position.ReadValue();
            return camera.ScreenToWorldPoint(raw);
        }
    }
}

