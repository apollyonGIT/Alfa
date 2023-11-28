using Common;
using Foundation;

namespace Battle.Chesses
{
    public interface IChessView : IModelView<Chess>
    { 
    }


    public class ChessMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;

        //==================================================================================================

        public ChessMgr(string name, params object[] objs)
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
    }
}

