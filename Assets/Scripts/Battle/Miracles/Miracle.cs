using Foundation;

namespace Battle.Miracles
{
    public class Miracle : Model<Miracle, IMiracleView>
    {
        public MiracleMgr mgr;

        //==================================================================================================

        public Miracle(MiracleMgr mgr,  params object[] args)
        {
            this.mgr = mgr;
        }
    }
}

