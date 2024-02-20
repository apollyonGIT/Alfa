using Common;
using UnityEngine;

namespace World
{
    public class WorldContext : Singleton<WorldContext>
    {
        public Vector3 mainCamera_pos => WorldSceneRoot.instance.mainCamera.transform.localPosition;

        #region outter
        public bool is_battle;
        #endregion

        //==================================================================================================

        public static void attach()
        {
            World_Camera_Helper.instance.reset_size();
        }


        public static void detach()
        {
            
        }
    }

}

