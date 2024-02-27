using Common;
using Foundation;
using UnityEngine;
using static AutoCode.Tables.Trigram;

namespace Battle.Trigrams
{
    public class Trigram : Model<Trigram, ITrigramView>
    {
        public int id;
        public Record _desc;

        public Vector2 pos;
        public Quaternion dir;

        public TrigramMgr mgr;

        //==================================================================================================

        public Trigram(TrigramMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            id = (int)args[0];
            Battle_DB.instance.trigram.try_get((e_trigramType)id, out _desc);

            pos = (Vector2)args[1];
            dir = EX_Utility.quick_look_rotation_from_left((Vector2)args[2]);
        }
    }
}

