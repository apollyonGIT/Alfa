using Common;
using System.Collections.Generic;
using System.Linq;

namespace Battle.Cards
{
    public class DeckMgr : IMgr
    {
        public LinkedList<Card> cells = new();
        public IEnumerable<Card> discards => cells.Where(t => t.status == ENUM.Card_Status.discard);
        public IEnumerable<Card> drawcards => cells.Where(t => t.status == ENUM.Card_Status.drawcard);
        public IEnumerable<Card> holds => cells.Where(t => t.status == ENUM.Card_Status.hold);

        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        //==================================================================================================

        public DeckMgr(string name, int priority, params object[] args)
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
            cells.AddLast(cell);
        }


        public void remove_cells()
        {
            cells.Clear();
        }


        public void remove_cell(Card cell)
        {
            cells.Remove(cell);
        }


        public Card draw()
        {
            var index = EX_Utility.rnd_int(1, drawcards.Count());

            var e = drawcards.GetEnumerator();
            for (int i = 0; i < index; i++)
            {
                e.MoveNext();
            }

            return e.Current;
        }
    }
}

