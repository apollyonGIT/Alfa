using UnityEngine;

namespace Common
{
    public class Camera_Helper<T> : Singleton<T> where T : Camera_Helper<T>, new()
    {
        public virtual Camera camera { get; }
        public virtual float default_size { get; } = 5f;

        //==================================================================================================

        public void change_size(float v)
        {
            camera.orthographicSize += v;
        }


        public void reset_size()
        {
            camera.orthographicSize = default_size;
        }


        public void add_pos(Vector2 v)
        {
            var pos = camera.transform.localPosition;
            pos += (Vector3)v;
            camera.transform.localPosition = pos;
        }


        public void move_to_pos(Vector2 v)
        {
            var pos = camera.transform.localPosition;
            pos = new Vector3(v.x, v.y, pos.z);
            camera.transform.localPosition = pos;
        }
    }
}

