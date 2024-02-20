using Common;
using UnityEngine;

namespace World
{
    public class World_Camera_Helper : Camera_Helper<World_Camera_Helper>
    {
        public override Camera camera => WorldSceneRoot.instance.mainCamera;
    }
}

