using Common;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace Battle.Decks
{
    public interface IDeckView : IModelView<Deck>
    { 
    }


    public class DeckMgr : IMgr
    {
        public LinkedList<Deck> cells = new();
        public IEnumerable<Deck> discards => cells.Where(t => t.status == ENUM.Card_Status.discard);
        public IEnumerable<Deck> drawcards => cells.Where(t => t.status == ENUM.Card_Status.drawcard);
        public IEnumerable<Deck> holds => cells.Where(t => t.status == ENUM.Card_Status.hold);

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


        public void add_cell(Deck cell)
        {
            cells.AddLast(cell);
        }


        public void remove_cells()
        {
            foreach (var cell in cells)
            {
                cell.clear_views();
            }

            cells.Clear();
        }


        public void remove_cell(Deck cell)
        {
            cell.clear_views();

            cells.Remove(cell);
        }


        public uint draw_random_cell()
        {
            var index = EX_Utility.rnd_int(1, drawcards.Count());

            var e = drawcards.GetEnumerator();
            for (int i = 0; i < index; i++)
            {
                e.MoveNext();
            }

            var cell = e.Current;

            return cell._desc.f_id;
        }
    }
}

