using Common;
using UnityEngine;

namespace Battle.Intentions
{
    public class IntentionPD : Producer
    {
        public IntentionView model_view;

        public override IMgr imgr => mgr;
        IntentionMgr mgr;

        public float selected_scale_offset = 1.3f;
        public float selected_height_offset = 30f;

        public Texture2D cursor;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("IntentionMgr", priority);

            Intention cell = new(mgr);
            mgr.add_cell(cell);

            var view = Instantiate(model_view, transform);
            cell.add_view(view);
            view.pd = this;
        }


        public override void call()
        {
        }
    }
}

