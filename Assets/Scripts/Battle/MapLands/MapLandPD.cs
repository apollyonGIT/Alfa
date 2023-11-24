using Common;

namespace Battle.MapLands
{
    public class MapLandPD : Producer
    {
        public override IMgr imgr => mgr;
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
            imgr.fini();
        }
    }
}

