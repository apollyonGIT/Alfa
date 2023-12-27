using Common;
using UnityEngine;
using World;

namespace Battle
{
    public class BattleContext : Singleton<BattleContext>
    {
        #region outter
        #endregion

        //==================================================================================================

        public static void init()
        {
            var wctx = WorldContext.instance;
            Debug.Log("init");
        }


        public static void fini()
        {
            var wctx = WorldContext.instance;
            Debug.Log("fini");
        }
    }
}

