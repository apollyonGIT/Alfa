using Common;
using System.Collections.Generic;

namespace Battle.Lands
{
    public class LandPD : Producer
    {
        public int count_x;
        public int count_y;

        public LandView model_view;

        public override IMgr imgr => mgr;
        LandMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            Common_DS.instance.add(Config.land_area, (count_x, count_y));

            mgr = new("LandMgr", priority);

            foreach (var cell in cells(mgr))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model_view, transform);
                cell.add_view(view);
            }

            //调整镜头，使其居中
            Battle_Camera_Helper.instance.move_to_pos(new(count_x / 2, count_y / 2));
        }


        public override void call()
        {
        }


        IEnumerable<Land> cells(LandMgr mgr)
        {
            for (int y = 0; y < count_y; y++)
            {
                for (int x = 0; x < count_x; x++)
                {
                    VID pos = (x, y);

                    yield return new(mgr, pos);
                }
            }
        }
    }
}

