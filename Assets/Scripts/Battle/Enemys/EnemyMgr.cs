using Common;
using Common.Ticker_Module;
using Foundation;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Enemys
{
    public interface IEnemyView : IModelView<Enemy>
    { 
    }


    public class EnemyMgr : IMgr
    {
        public List<Enemy> cells = new();

        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        //==================================================================================================

        public EnemyMgr(string name, int priority, params object[] args)
        {
            m_mgr_name = name;
            m_mgr_priority = priority;

            (this as IMgr).init(args);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);

            Ticker.instance.remove_tick(m_mgr_name);
        }


        void IMgr.init(object[] args)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);

            Ticker.instance.add_tick(m_mgr_priority, m_mgr_name, tick);
        }


        void tick()
        {
            foreach (var cell in cells)
            {
                cell.bctx?.tick();
            }
        }


        public void add_cell(Enemy cell)
        {
            cells.Add(cell);
        }
    }
}

