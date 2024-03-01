﻿using Common;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Battle.Behaviour_Options
{
    public class Behaviour_OptionPD : Producer
    {
        public override IMgr imgr => mgr;
        Behaviour_OptionMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("Behaviour_OptionMgr", priority);

            foreach (var cell in cells(mgr))
            {
                mgr.add_cell(cell);

                EX_Utility.try_load_asset(cell._desc.f_view_path, out Behaviour_OptionView view_asset);
                var view = Instantiate(view_asset, transform);
                cell.add_view(view);
                cell.init();
            }
        }


        public override void call()
        {
        }


        IEnumerable<Behaviour_Option> cells(Behaviour_OptionMgr mgr)
        {
            var rs = Battle_DB.instance.behaviour_option.records;

            for (int i = 0; i < rs.Count; i++)
            {
                var type = Assembly.Load("Battle").GetType($"Battle.Behaviour_Options.Behaviour_Option_{rs[i].f_name}");

                yield return (Behaviour_Option)Activator.CreateInstance(type, new object[] { mgr, rs[i].f_id });
            }
        }
    }
}

