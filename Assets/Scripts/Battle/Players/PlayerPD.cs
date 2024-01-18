﻿using Common;
using System.Collections.Generic;

namespace Battle.Players
{
    public class PlayerPD : Producer
    {
        public PlayerView model_view;

        public override IMgr imgr => mgr;
        PlayerMgr mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new("PlayerMgr");

            foreach (var cell in cells(mgr))
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


        IEnumerable<Player> cells(PlayerMgr mgr)
        {
            VID pos = (2, 3);

            yield return new(mgr, pos);
        }
    }
}
