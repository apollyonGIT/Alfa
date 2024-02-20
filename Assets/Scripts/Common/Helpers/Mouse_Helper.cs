using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common
{
    public class Mouse_Helper<T> : Singleton<T> where T : Mouse_Helper<T>, new()
    {
        public virtual Camera camera { get; }

        //==================================================================================================

        /// <summary>
        /// 计算鼠标位置
        /// </summary>
        public void calc_mouse_pos(out Vector3 ret)
        {
            ret = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            ret.z = 0;
        }


        public Vector2 calc_mouse_pos()
        {
            return camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }
    }


    public class Mouse_Helper : Mouse_Helper<Mouse_Helper>
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


        public static Vector2 calc_mouse_pos(Camera _camera)
        {
            return _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }
    }
}

