using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.MapLands
{
    public interface IMapLandView : IModelView<MapLand>
    { 
    }


    public class MapLandMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;

        Dictionary<int, MapLand> cells = new();

        //==================================================================================================

        public MapLandMgr(string name, params object[] objs)
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

