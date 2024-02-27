using Common;
using Foundation;
using UnityEngine;

namespace Battle.Trigrams
{
    public class Trigram : Model<Trigram, ITrigramView>
    {
        public int id;
        

        public Vector2 pos;
        public Quaternion dir;

        public TrigramMgr mgr;

        //==================================================================================================

        public Trigram(TrigramMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            id = (int)args[0];
            pos = (Vector2)args[1];
            dir = EX_Utility.quick_look_rotation_from_left((Vector2)args[2]);
        }
    }
}

