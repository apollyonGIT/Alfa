using Common;
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


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<Behaviour_Option> cells(Behaviour_OptionMgr mgr)
        {
            var rs = Battle_DB.instance.behaviour_option.records;

            for (int i = 0; i < rs.Count; i++)
            {
                var id = rs[i].f_id;
                var type = Assembly.Load("Battle").GetType($"Battle.Behaviour_Options.Behaviour_Option_{id}");

                yield return (Behaviour_Option)Activator.CreateInstance(type, new object[] { mgr, id });
            }
        }
    }
}

