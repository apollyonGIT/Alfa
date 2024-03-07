﻿using Common;
using System.Collections.Generic;

namespace Battle.Players
{
    public class PlayerPD : Producer
    {
        public int max_hp;
        public int max_reiki;

        public PlayerView model_view;

        public override IMgr imgr => mgr;
        PlayerMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("PlayerMgr", priority);

            foreach (var cell in cells(mgr))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model_view, transform);
                cell.add_view(view);
            }

            var ctx = BattleContext.instance;
            {
                ctx.max_hp = max_hp;
                ctx.hp = max_hp;
                ctx.max_reiki = max_reiki;
                ctx.reiki = max_reiki;
            }
        }


        public override void call()
        {
        }


        IEnumerable<Player> cells(PlayerMgr mgr)
        {
            VID pos = (2, 3);

            yield return new(mgr, 400000201u, pos);
        }
    }
}

