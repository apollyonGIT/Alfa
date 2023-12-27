using Common;
using System.Collections.Generic;

namespace Battle.BF_Lands
{
    public class BF_LandPD : Producer
    {
        public int count_x;
        public int count_y;

        public BF_LandView model_view;

        public override IMgr imgr => mgr;
        BF_LandMgr mgr;

        //==================================================================================================

        public override void init()
        {
            Common_DS.instance.add(Config.bf_land_area, (count_x, count_y));

            mgr = new("BF_LandMgr");

            foreach (var cell in cells())
            {
                var view = Instantiate(model_view, transform);
                cell.add_view(view);
            }

            //位置调整，使其居中
            transform.localPosition = new(-count_x / 2, -count_y / 2);
        }


        public override void tick()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<BF_Land> cells()
        {
            for (int y = 0; y < count_y; y++)
            {
                for (int x = 0; x < count_x; x++)
                {
                    var vid = VID.init(x, y);

                    yield return new(vid);
                }
            }
        }
    }
}

