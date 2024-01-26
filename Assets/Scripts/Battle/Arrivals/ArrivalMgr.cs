using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.Arrivals
{
    public interface IArrivalView : IModelView<Arrival>
    {
        void notify_on_change_active();
    }


    public class ArrivalMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        Dictionary<VID, Arrival> m_cells = new();

        //==================================================================================================

        public ArrivalMgr(string name, int priority, params object[] args)
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


        bool IMgr.try_get_cell(out object cell, params object[] args)
        {
            cell = default;

            var pos = (VID)args[0];
            if (!m_cells.TryGetValue(pos, out var _cell)) return false;

            //条件：是否过滤非激活的cell
            if ((bool)args[1] &&!_cell.is_active) return false;

            cell = _cell;
            return true;
        }


        public void add_cell(Arrival cell)
        {
            m_cells.Add(cell.pos, cell);
        }


        public void active_cell(VID[] pos_array)
        {
            unactive_cells();

            foreach (var pos in pos_array)
            {
                if (!m_cells.TryGetValue(pos, out var cell)) continue;
                cell.change_active(true);
            }
        }


        public void unactive_cells()
        {
            foreach (var (_, cell) in m_cells)
            {
                cell.change_active(false);
            }
        }
    }
}

