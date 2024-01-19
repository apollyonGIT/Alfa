﻿using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.Interactives
{
    public interface IInteractiveView : IModelView<Interactive>
    { 
    }


    public class InteractiveMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        Dictionary<VID, Interactive> m_cells = new();

        //==================================================================================================

        public InteractiveMgr(string name, int priority, params object[] args)
        {
            m_mgr_name = name;
            m_mgr_priority = priority;

            (this as IMgr).init(args);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);
        }


        void IMgr.init(object[] objs)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);
        }


        bool IMgr.try_get_cell(out object cell, params object[] args)
        {
            throw new System.NotImplementedException();
        }


        public void add_cell(Interactive cell)
        {
            m_cells.Add(cell.pos, cell);
        }


        public void do_on_click(Interactive cell)
        {
            var pos = cell.pos;

            var mission = Mission.instance;
            {
                if (mission.try_get_mgr("ArrivalMgr", out var arrival_mgr))
                {
                    arrival_mgr.GetType().GetMethod("active_cell")?.Invoke(arrival_mgr, new object[] { new VID[] { pos } });
                }
            }
            

        }
    }
}

