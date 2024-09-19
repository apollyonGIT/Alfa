using Battle.BFs;
using Battle.Cards;
using Common;
using UnityEngine;

namespace Cards.BattleCards
{
    public class BattleCardPD : Producer
    {
        public BattleCardView model;
        public SlotView[] slot_views;

        public override IMgr imgr => mgr;
        BattleCardMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("BattleCardMgr", priority);
            mgr.pd = this;
        }


        public override void call()
        {
        }


        public void create_cells(params object[] args)
        {
            var slot_id = (int)args[0];
            var slot_view = slot_views[slot_id - 1];

            var card = (Card)args[1];
            BattleCard cell = new(mgr, card);

            mgr.add_cell(cell, slot_id);

            var view = Instantiate(model, slot_view.transform);
            view.transform.localScale = Vector3.one;

            cell.add_view(view);
        }
    }
}

