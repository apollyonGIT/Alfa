using Common;
using Foundation;

namespace Battle.Lands
{
    public class LandView : View, ILandView
    {
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
    }
}

