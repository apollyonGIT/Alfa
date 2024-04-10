using Common;
using Foundation;
using UnityEngine;

namespace Battle.Lands
{
    public class LandView : View, ILandView
    {
        public SpriteRenderer area;
        public SpriteRenderer mask;

        Land cell;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Land>.attach(Land cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<Land>.detach(Land cell)
        {
            this.cell = null;
        }


        void ILandView.notify_on_change_color(Color color)
        {
            mask.color = color;
        }
    }
}

