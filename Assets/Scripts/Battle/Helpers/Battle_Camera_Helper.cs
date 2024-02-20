using Common;
using UnityEngine;

namespace Battle
{
    public class Battle_Camera_Helper : Camera_Helper<Battle_Camera_Helper>
    {
        public override Camera camera => World.WorldSceneRoot.instance.mainCamera;
        public override float default_size => 7.5f; 
    }
}

