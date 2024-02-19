﻿using Foundation;

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
            mgr = null;

            foreach (var view in views)
            {
                view.detach(this);
            }
        }
    }
}

