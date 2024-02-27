using Common;
using Foundation;

namespace Battle.Miracles
{
    public interface IMiracleView : IModelView<Miracle>
    { 
    }


    public class MiracleMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;
        int IMgr.priority => m_mgr_priority;
        readonly int m_mgr_priority;

        public bool is_casting;

        Miracle m_cell;

        //==================================================================================================

        public MiracleMgr(string name, int priority, params object[] args)
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


        public void add_cell(Miracle cell)
        {
            m_cell = cell;
        }

    }
}

