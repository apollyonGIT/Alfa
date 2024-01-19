using Foundation;
using UnityEngine;

namespace Battle.Interactives
{
    public class Interactive : Model<Interactive, IInteractiveView>
    {
        public VID pos;

        public Vector2 view_pos => (Vector2)pos;

        public InteractiveMgr mgr;

        //==================================================================================================

        public Interactive(InteractiveMgr mgr,  params object[] args)
        {
            pos = (VID)args[0];

            this.mgr = mgr;
        }
    }
}

