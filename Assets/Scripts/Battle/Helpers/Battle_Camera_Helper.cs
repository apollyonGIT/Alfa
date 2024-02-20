using Common;
using UnityEngine;

namespace Battle
{
    public class Battle_Camera_Helper : Camera_Helper<Battle_Camera_Helper>
    {
        protected sealed override Camera camera => World.WorldSceneRoot.instance.mainCamera;
        protected sealed override float default_size => 7.5f; 
    }
}

