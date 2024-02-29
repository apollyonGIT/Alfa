using Common;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Battle.Behaviour_Options
{
    public class Behaviour_OptionPD : Producer
    {
        public Behaviour_OptionView[] model_views;

        public override IMgr imgr => mgr;
        Behaviour_OptionMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("Behaviour_OptionMgr", priority);

            var i = 0;
            foreach (var cell in cells(mgr))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model_views[i++], transform);
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


        IEnumerable<Behaviour_Option> cells(Behaviour_OptionMgr mgr)
        {
            for (int i = 0; i < model_views.Length; i++)
            {
                var name = model_views[i].name;
                var type = Assembly.Load("Battle").GetType($"Battle.Behaviour_Options.Behaviour_Option_{name}");

                yield return (Behaviour_Option)Activator.CreateInstance(type, new object[] { mgr, name });
            }
        }
    }
}

