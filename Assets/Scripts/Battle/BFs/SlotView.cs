using Common;
using UnityEngine;
using World;

namespace Battle.BFs
{
    public class SlotView : MonoBehaviour
    {
        public int id;

        //==================================================================================================

        public void notify_on_UseCardInSlot()
        {
            Common_DS.instance.add("slot_view", this);
        }
    }
}

