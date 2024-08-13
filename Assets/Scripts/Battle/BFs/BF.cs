using Foundation;
using UnityEngine;

namespace Battle.BFs
{
    public class BF : Model<BF, IBFView>
    {
        public Vector2 pos;
        public Vector2 view_pos => pos * 2f;

        public BFMgr mgr;

        //==================================================================================================

        public BF(BFMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            pos = (Vector2)args[0];
        }
    }
}

