using Common;

namespace Battle.Decks
{
    public class DeckPD : Producer
    {
        public override IMgr imgr => mgr;
        DeckMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("DeckMgr", priority);
        }


        public override void call()
        {
        }
    }
}

