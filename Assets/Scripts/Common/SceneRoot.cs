using Foundation;
using UnityEngine;

namespace Common
{
    public class SceneRoot<T> : MonoBehaviourSingleton<T> where T : SceneRoot<T>
    {
        public Camera mainCamera;
        public Camera uiCamera;
        public Canvas uiRoot;
        public Transform monoRoot;

        public Producer[] producers;

        //==================================================================================================

        protected void init_triggers()
        {
            if (producers == null) return;

            foreach (var t in producers)
            {
                t.@do(true);
            }
        }
    }
}

