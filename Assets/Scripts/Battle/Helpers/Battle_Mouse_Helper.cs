using Common;
using UnityEngine;

namespace Battle
{
    public class Battle_Mouse_Helper : Mouse_Helper<Battle_Mouse_Helper>
    {
        public override Camera camera => BattleSceneRoot.instance.mainCamera;

        //==================================================================================================
    }
}

