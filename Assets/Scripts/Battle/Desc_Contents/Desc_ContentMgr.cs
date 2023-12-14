using Common;
using Foundation;

namespace Battle.Desc_Contents
{
    public interface IDesc_ContentView : IModelView<Desc_Content>
    {
        void notify_on_enable(bool is_enable);
    }


    public class Desc_ContentMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;

        public Desc_Content cell;

        //==================================================================================================

        public Desc_ContentMgr(string name, params object[] objs)
        {
            m_mgr_name = name;
            (this as IMgr).init(objs);
        }


        void IMgr.fini()
        {
            Mission.instance.detach_mgr(m_mgr_name);
        }


        void IMgr.init(object[] objs)
        {
            Mission.instance.attach_mgr(m_mgr_name, this);
        }


        bool IMgr.try_get_cell(out object cell, params object[] prms)
        {
            cell = this.cell;
            return true;
        }


        public void enable_cell(bool is_enable)
        {
            cell.enable(is_enable);
        }
    }
}

