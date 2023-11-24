using UnityEngine;

namespace Common
{
    public abstract class Producer : MonoBehaviour
    {
        public abstract void @do(bool is_init = false);
    }
}

