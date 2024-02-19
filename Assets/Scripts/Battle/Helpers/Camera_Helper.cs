using UnityEngine;
using World;

namespace Battle
{
    public class Camera_Helper
    {

        //==================================================================================================

        public static void change_camera_projection_size(float v)
        {
            var root = WorldSceneRoot.instance;
            {
                root.mainCamera.orthographicSize += v;
                root.uiCamera.orthographicSize += v;
            }
        }


        public static void change_camera_pos(Vector2 v)
        {
            var mainCamera = WorldSceneRoot.instance.mainCamera;
            {
                var pos = mainCamera.transform.localPosition;
                pos += (Vector3)v;
                mainCamera.transform.localPosition = pos;
            }
        }
    }
}

