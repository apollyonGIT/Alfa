using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.Trigrams
{
    public interface ITrigramView : IModelView<Trigram>
    { 
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
        }


        void IMgr.init(object[] args)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);
        }


        bool IMgr.try_get_cell(out object cell, params object[] args)
        {
            throw new System.NotImplementedException();
        }


        public void add_cell(Trigram cell)
        {
            m_cells.Add(cell.id, cell);
        }
    }
}

