using UnityEngine;

namespace Battle
{
    public class Camera_Helper : Common.Camera_Helper<Camera_Helper>
    {
        public override Camera camera => BattleSceneRoot.instance.mainCamera;
    }
}

