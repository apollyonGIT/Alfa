using Common;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Battle.Selectors
{
    public class SelectorPD : Producer
    {
        public SelectorView[] model_views;

        public override IMgr imgr => mgr;
        SelectorMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("SelectorMgr", priority);

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


        IEnumerable<Selector> cells(SelectorMgr mgr)
        {
            for (int i = 0; i < model_views.Length; i++)
            {
                var name = model_views[i].name;
                var type = Assembly.Load("Battle").GetType($"Battle.Selectors.Selector_{name}");

                yield return (Selector)Activator.CreateInstance(type, new object[] { mgr, name });
            }
        }
    }
}

