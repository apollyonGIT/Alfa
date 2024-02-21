using Common;
using Common.Ticker_Module;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battle.Talisman_Skills
{
    public interface ITalisman_SkillView : IModelView<Talisman_Skill>
    {
    }


    public class Talisman_SkillMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        LinkedList<Talisman_Skill> m_cells = new();

        public Action add_cells_ac;

        //==================================================================================================

        public Talisman_SkillMgr(string name, int priority, params object[] args)
        {
            m_mgr_name = name;
            m_mgr_priority = priority;

            (this as IMgr).init(args);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);

            var ticker = Ticker.instance;
            {
                ticker.remove_tick(m_mgr_name);
            }
        }


        void IMgr.init(object[] args)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);

            var ticker = Ticker.instance;
            {
                ticker.add_tick(m_mgr_priority, m_mgr_name, tick);
            }
        }


        void tick()
        {
            
        }


        bool IMgr.try_get_cell(out object cell, params object[] args)
        {
            throw new System.NotImplementedException();
        }


        public void add_cell(Talisman_Skill cell)
        {
            m_cells.AddLast(cell);
        }


        public void remove_cell(Talisman_Skill cell)
        {
            m_cells.Remove(cell);

            cell.destroy();
        }


        public void remove_cells()
        {
            foreach (var cell in m_cells)
            {
                cell.destroy();
            }

            m_cells.Clear();
        }


        public void play()
        {
            
        }


        public void add_cells()
        {
            add_cells_ac?.Invoke();
        }
    }
}

