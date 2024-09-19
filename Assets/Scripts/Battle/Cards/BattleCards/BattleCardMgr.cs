using Common;
using Foundation;
using System.Collections.Generic;

namespace Cards.BattleCards
{
    public interface IBattleCardView : IModelView<BattleCard>
    { 
    }


    public class BattleCardMgr : IMgr
    {
        public BattleCardPD pd;

        public Dictionary<int, BattleCard> cells = new();

        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        //==================================================================================================

        public BattleCardMgr(string name, int priority, params object[] args)
        {
            m_mgr_name = name;
            m_mgr_priority = priority;

            (this as IMgr).init(args);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);
        }


        void IMgr.init(object[] args)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);
        }


        public void add_cell(BattleCard cell, int slot_id)
        {
            cells.Add(slot_id, cell);
        }


        public void remove_cell(int slot_id)
        {
            cells.Remove(slot_id);
        }
    }
}

