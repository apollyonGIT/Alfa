using Foundation;

namespace Battle.Dices
{
    public class Dice : Model<Dice, IDiceView>
    {

        public DiceMgr mgr;

        public int value;

        //==================================================================================================

        public Dice(DiceMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            value = (int)args[0];
        }
    }
}

