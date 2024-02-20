using UnityEngine;

namespace Battle
{
    public class Camera_Helper
    {

        //==================================================================================================

        public static void change_camera_projection_size(float v)
        {
            var root = BattleSceneRoot.instance;
            {
                root.mainCamera.orthographicSize += v;
                root.uiCamera.orthographicSize += v;
            }
        }


        public static void change_camera_pos(Vector2 v)
        {
            var mainCamera = BattleSceneRoot.instance.mainCamera;
            {
                var pos = mainCamera.transform.localPosition;
                pos += (Vector3)v;
                mainCamera.transform.localPosition = pos;
            }
        }


        public static void move_camera_to_pos(Vector2 v)
        {
            var mainCamera = BattleSceneRoot.instance.mainCamera;
            {
                var pos = mainCamera.transform.localPosition;
                pos = new Vector3(v.x, v.y, pos.z);
                mainCamera.transform.localPosition = pos;
            }
        }
    }
}

