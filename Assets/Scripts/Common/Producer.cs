using UnityEngine;

namespace Common
{
    public abstract class Producer : MonoBehaviour
    {
        public abstract IMgr imgr { get; }

        //==================================================================================================

        public abstract void init(int priority);

        public abstract void call();
    }
}

