using Common;
using Common.Ticker_Module;
using Foundation;
using System.Collections.Generic;

namespace Battle.Behaviour_Options
{
    public interface ISelectorView : IModelView<Behaviour_Option>
    {
        void notify_on_tick1();
    }


    public class Behaviour_OptionMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        Dictionary<string, Behaviour_Option> m_cells = new();

        //==================================================================================================

        public Behaviour_OptionMgr(string name, int priority, params object[] args)
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
                ticker.remove_tick1(m_mgr_name);
            }
        }


        void IMgr.init(object[] args)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);

            var ticker = Ticker.instance;
            {
                ticker.add_tick(m_mgr_priority, m_mgr_name, tick);
                ticker.add_tick1(m_mgr_priority, m_mgr_name, tick1);
            }
        }


        bool IMgr.try_get_cell(out object cell, params object[] args)
        {
            throw new System.NotImplementedException();
        }


        void tick()
        {
            foreach (var (_, cell) in m_cells)
            {
                cell.tick();
            }
        }


        void tick1()
        {
            foreach (var (_, cell) in m_cells)
            {
                cell.tick1();
            }
        }


        public void add_cell(Behaviour_Option cell)
        {
            m_cells.Add(cell.id, cell);
        }
    }
}

