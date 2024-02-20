using UnityEngine;

namespace Battle
{
    public class Camera_Helper
    {

        //==================================================================================================

        public static void change_size(float v)
        {
            BattleSceneRoot.instance.mainCamera.orthographicSize += v;
        }


        public static void add_pos(Vector2 v)
        {
            var mainCamera = BattleSceneRoot.instance.mainCamera;
            {
                var pos = mainCamera.transform.localPosition;
                pos += (Vector3)v;
                mainCamera.transform.localPosition = pos;
            }
        }


        public static void goto_pos(Vector2 v)
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

