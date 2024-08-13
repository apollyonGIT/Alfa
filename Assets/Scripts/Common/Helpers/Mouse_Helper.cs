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
    }


    public class Mouse_Helper : Mouse_Helper<Mouse_Helper>
    {
        public static Vector2 calc_mouse_pos(Camera _camera)
        {
            return _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }
    }
}

