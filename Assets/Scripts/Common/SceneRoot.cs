using Foundation;
using System.Linq;
using UnityEngine;

namespace Common
{
    public class SceneRoot<T> : MonoBehaviourSingleton<T> where T : SceneRoot<T>
    {
        public Camera mainCamera;
        public Camera uiCamera;
        public Canvas uiRoot;
        public Transform monoRoot;

        public Trigger[] triggers;

        //==================================================================================================

        protected void init_triggers()
        {
            if (triggers == null) return;

            foreach (var t in triggers)
            {
                t.@do(true);
            }
        }
    }
}

