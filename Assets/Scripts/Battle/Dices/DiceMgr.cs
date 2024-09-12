using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.Dices
{
    public interface IDiceView : IModelView<Dice>
    {
    }


    public class DiceMgr : IMgr
    {
        LinkedList<Dice> cells = new();

        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        //==================================================================================================

        public DiceMgr(string name, int priority, params object[] args)
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


        public static int roll()
        {
            return EX_Utility.rnd_int(1, 6);
        }


        public void add_cell(Dice cell)
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
    }
}

