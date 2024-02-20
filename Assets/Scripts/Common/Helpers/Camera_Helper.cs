using UnityEngine;

namespace Common
{
    public class Camera_Helper<T> : Singleton<T> where T : Camera_Helper<T>, new()
    {
        public Vector3 pos => camera.transform.localPosition;

        protected virtual Camera camera { get; }
        protected virtual float default_size { get; } = 5f;
        protected virtual float max_size { get; } = 10f;
        protected virtual float min_size { get; } = 4f;

        //==================================================================================================

        public void change_size(float v)
        {
            var size = camera.orthographicSize + v;
            size = Mathf.Clamp(size, min_size, max_size);

            camera.orthographicSize = size;
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

