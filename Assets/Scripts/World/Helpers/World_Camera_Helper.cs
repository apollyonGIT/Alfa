using Common;
using UnityEngine;

namespace World
{
    public class World_Camera_Helper : Camera_Helper<World_Camera_Helper>
    {
        protected sealed override Camera camera => WorldSceneRoot.instance.mainCamera;
        protected sealed override float default_size => Config.current.camera_size_world;
    }
}

