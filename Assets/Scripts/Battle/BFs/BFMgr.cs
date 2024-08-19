using Common;
using Foundation;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle.BFs
{
    public interface IBFView : IModelView<BF>
    {
        void notify_on_show_path(bool is_enable = false);
    }


    public class BFMgr : IMgr
    {
        public Dictionary<Vector2, BF> cells = new();

        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        //==================================================================================================

        public BFMgr(string name, int priority, params object[] args)
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


        public void add_cell(BF cell)
        {
            cells.Add(cell.pos, cell);
        }


        public void show_path(Vector2[] path)
        {
            foreach (var (_, cell) in cells)
            {
                foreach (var view in cell.views)
                {
                    view.notify_on_show_path();
                }
            }

            foreach (var pos in path)
            {
                cells.TryGetValue(pos, out var cell);
                foreach (var view in cell.views)
                {
                    view.notify_on_show_path(true);
                }
            }
        }
    }
}

