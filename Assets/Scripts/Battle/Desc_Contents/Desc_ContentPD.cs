using Common;
using UnityEngine;

namespace Battle.Desc_Contents
{
    public class Desc_ContentPD : Producer
    {
        public Desc_ContentView content;

        public override IMgr imgr => mgr;
        Desc_ContentMgr mgr;

        //==================================================================================================

        public override void init()
        {
            mgr = new(Config.Desc_ContentMgr_Name);
            Desc_Content cell = new();

            mgr.cell = cell;

            var view = Instantiate(content, transform);
            cell.add_view(view);
        }


        public override void tick()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }
    }
}

