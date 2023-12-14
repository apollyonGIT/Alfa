using Common;
using System.Collections.Generic;

namespace Battle.Store_Checks
{
    public class Store_CheckPD : Producer
    {
        public int count;
        public Store_CheckView model_view;        

        public override IMgr imgr => mgr;
        Store_CheckMgr mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new(Config.StoreCheckMgr_Name);

            foreach (var cell in cells())
            {
                mgr.add_cell(cell);

                var view = Instantiate(model_view, transform);
                cell.add_view(view);
            }
        }


        public override void tick()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<Store_Check> cells()
        {
            var col_count = count / 2;

            for (int i = 0; i < count; i++)
            {
                VID vid = new()
                {
                    x = i % col_count,
                    y = i / col_count,
                };

                yield return new(vid);
            }
        }
    }
}

