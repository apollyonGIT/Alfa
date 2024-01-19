using Battle.Interactives;
using Common;
using System.Collections.Generic;

namespace Battle.Arrivals
{
    public class ArrivalPD : Producer
    {
        public ArrivalView model_view;

        public override IMgr imgr => mgr;
        ArrivalMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("ArrivalMgr", priority);

            foreach (var cell in cells(mgr))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model_view, transform);
                cell.add_view(view);
            }
        }


        public override void call()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<Arrival> cells(ArrivalMgr mgr)
        {
            Common_DS.instance.try_get_value(Config.land_area, out (int x, int y) land_area);

            for (int y = 0; y < land_area.y; y++)
            {
                for (int x = 0; x < land_area.x; x++)
                {
                    VID pos = (x, y);

                    yield return new(mgr, pos);
                }
            }
        }
    }
}

