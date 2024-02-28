using Common;
using Common.Ticker_Module;
using Foundation;
using System.Collections.Generic;

namespace Battle.Trigrams
{
    public interface ITrigramView : IModelView<Trigram>
    {
        void notify_on_tick1();
    }


    public class TrigramMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        Dictionary<int, Trigram> m_cells = new();

        //==================================================================================================

        public TrigramMgr(string name, int priority, params object[] args)
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

        }


        void tick1()
        {
            foreach (var (_, cell) in m_cells)
            {
                cell.tick1();
            }
        }


        public void add_cell(Trigram cell)
        {
            m_cells.Add(cell.id, cell);
        }


        public void random_select(int i, int max_cell_count)
        {
            reset_cell();

            List<int> unfull_list = new();
            for (int x = 1; x <= 8; x++)
            {
                unfull_list.Add(x);
            }

            while (i > 0)
            {
                var rnd = EX_Utility.rnd_int(0, unfull_list.Count - 1);
                var id = unfull_list[rnd];
                m_cells.TryGetValue(id, out var cell);

                ref var cell_count = ref cell.count;
                cell_count++;
                i--;

                if (cell_count == max_cell_count)
                    unfull_list.Remove(cell.id);
            }
        }


        void reset_cell()
        {
            foreach (var (_,cell) in m_cells)
            {
                cell.count = 0;
            }
        }
    }
}

