using Foundation;

namespace Battle.Res_Cards
{
    public class Res_Card : Model<Res_Card, IRes_CardView>
    {
        public bool is_selected;

        public Res_CardMgr mgr;

        //==================================================================================================

        public Res_Card(Res_CardMgr mgr,  params object[] args)
        {
            this.mgr = mgr;
        }


        public void destroy()
        {
            foreach (var view in views)
            {
                view.detach(this);
            }
        }


        public void select()
        {
            is_selected = !is_selected;
            mgr.change_selected_cells(this);
        }
    }
}

