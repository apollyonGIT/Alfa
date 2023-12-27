using UnityEngine;

namespace Common
{
    public abstract class Producer : MonoBehaviour
    {
        public abstract IMgr imgr { get; }

        //==================================================================================================

        public abstract void init();

        public abstract void tick();

        public abstract void fini();
    }
}

