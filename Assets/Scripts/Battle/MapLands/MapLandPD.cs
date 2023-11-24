using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.MapLands
{
    public class MapLandPD : Producer
    {
        MapLandMgr mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new(Config.MapLandMgr_Name);


        }


        public override void tick()
        {
        }


        public override void fini()
        {
        }
    }
}

