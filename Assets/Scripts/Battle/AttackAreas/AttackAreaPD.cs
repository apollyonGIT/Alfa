using Battle.Helpers;
using Common;
using System.Collections.Generic;

namespace Battle.AttackAreas
{
    public class AttackAreaPD : Producer
    {
        public AttackAreaView temp_view;

        public override IMgr imgr => mgr;
        AttackAreaMgr mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new(Config.AttackAreaMgr_Name);

            //foreach (var cell in cells())
            //{
            //    mgr.add_cell(cell);

            //    var view = Instantiate(temp_view, transform);
            //    cell.add_view(view);
            //}
        }


        public override void tick()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        //IEnumerable<int> vids(MapLandMgr ml_mgr)
        //{
        //    foreach (var (vid, _) in ml_mgr.cells)
        //    {
        //        yield return vid;
        //    }
        //}


        //IEnumerable<AttackArea> cells()
        //{
        //    Mission.instance.try_get_mgr(Config.MapLandMgr_Name, out MapLandMgr ml_mgr);
        //    foreach (var vid in vids(ml_mgr))
        //    {
        //        yield return new(vid);
        //    }
        //}
    }
}

