using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.Res_Cards
{
    public interface IRes_CardView : IModelView<Res_Card>
    {
    }


    public class Res_CardMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        LinkedList<Res_Card> m_cells = new();

        //==================================================================================================

        public Res_CardMgr(string name, int priority, params object[] args)
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


        public void add_cells(Res_Card cell)
        {
            m_cells.AddLast(cell);
        }
    }
}

