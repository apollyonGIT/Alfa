using UnityEngine;

namespace Common
{
    public class Camera_Helper<T> : Singleton<T> where T : Camera_Helper<T>, new()
    {
        public virtual Camera camera { get; }

        //==================================================================================================

        public void change_size(float v)
        {
            camera.orthographicSize += v;
        }


        public void add_pos(Vector2 v)
        {
            var pos = camera.transform.localPosition;
            pos += (Vector3)v;
            camera.transform.localPosition = pos;
        }


        public void goto_pos(Vector2 v)
        {
            var pos = camera.transform.localPosition;
            pos = new Vector3(v.x, v.y, pos.z);
            camera.transform.localPosition = pos;
        }
    }
}

