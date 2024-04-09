using Common;
using Foundation;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Lands
{
    public interface ILandView : IModelView<Land>
    {
        void notify_on_change_color(Color color);
        void notify_on_enable_color(bool is_enable);
    }


    public class LandMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        Dictionary<VID, Land> m_cells = new();

        //==================================================================================================

        public LandMgr(string name, int priority, params object[] args)
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


        bool IMgr.try_get_cell(out object cell, params object[] prms)
        {
            var pos = (VID)prms[0];
            var ret = m_cells.TryGetValue(pos, out var _cell);
            cell = _cell;

            return ret;
        }


        public void add_cell(Land cell)
        {
            m_cells.Add(cell.pos ,cell);
        }


        public void set_cell_color(VID pos, Color color)
        {
            if (!m_cells.TryGetValue(pos, out var cell)) return;
            foreach (var view in cell.views)
            {
                view.notify_on_change_color(color);
            }
        }


        public void enable_cell_color(VID pos, bool is_enable)
        {
            if (!m_cells.TryGetValue(pos, out var cell)) return;
            foreach (var view in cell.views)
            {
                view.notify_on_enable_color(is_enable);
            }
        }


        public void clear_cells_color()
        {
            foreach (var (_, cell) in m_cells)
            {
                foreach (var view in cell.views)
                {
                    view.notify_on_enable_color(false);
                }
            }
        }


        public void notify_on_left_click(Land cell)
        {
            Mission.instance.try_get_mgr("PlayerMgr", out Players.PlayerMgr mgr);
            
        }
    }
}

