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

        protected void init_producers()
        {
            if (producers == null) return;

            for (int i = 0; i < producers.Length; i++)
            {
                producers[i].init(i);
            }
        }


        protected void fini_producers()
        {
            if (producers == null) return;

            foreach (var t in producers)
            {
                t.fini();
            }
        }
    }
}

