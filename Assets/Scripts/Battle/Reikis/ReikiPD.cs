using Common;

namespace Battle.Reikis
{
    public class ReikiPD : Producer
    {
        public int reiki_each_turn;

        public ReikiView model_view;

        public override IMgr imgr => mgr;
        ReikiMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("ReikiMgr", priority);
            
            var view = Instantiate(model_view, transform);
            mgr.add_view(view);

            BattleContext.instance.reiki_each_turn = reiki_each_turn;

            call();
        }


        public override void call()
        {
            mgr.calc_reiki();
        }
    }
}

