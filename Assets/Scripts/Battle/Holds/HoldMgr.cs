using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.Holds
{
    public interface IHoldView : IModelView<Hold>
    { 
    }


    public class HoldMgr : IMgr
    {
        public int hold_count => cells.Count;

        LinkedList<Hold> cells = new();

        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        //==================================================================================================

        public HoldMgr(string name, int priority, params object[] args)
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


        public void add_cell(Hold cell)
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


        public void remove_cell(Hold cell)
        {
            cell.clear_views();

            cells.Remove(cell);
        }
    }
}

