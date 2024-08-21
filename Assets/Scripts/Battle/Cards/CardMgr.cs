using Common;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace Battle.Cards
{
    public enum EN_Card_Type
    {
        none,
        left,
        right,
        enemy
    }


    public interface ICardView : IModelView<Card>
    { 
    }


    public class CardMgr : IMgr
    {
        public Dictionary<EN_Card_Type, LinkedList<Card>> cells = new();

        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        //==================================================================================================

        public CardMgr(string name, int priority, params object[] args)
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


        public void add_cell(Card cell)
        {
            cells.TryGetValue(cell.type, out var list);
            if (list == null)
            {
                list = new();
                cells.Add(cell.type, list);
            }

            list.AddLast(cell);
        }


        public int calc_seq(Card cell)
        {
            cells.TryGetValue(cell.type, out var list);

            return list.Select((value, index) => (value, index)).Where(t => t.value == cell).First().index;
        }
    }
}

