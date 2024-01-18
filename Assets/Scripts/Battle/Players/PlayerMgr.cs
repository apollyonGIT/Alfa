using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.Players
{
    public interface IPlayerView : IModelView<Player>
    { 
    }


    public class PlayerMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;

        Dictionary<VID ,Player> m_cells = new();

        //==================================================================================================

        public PlayerMgr(string name, params object[] objs)
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


        bool IMgr.try_get_cell(out object cell, params object[] args)
        {
            cell = default;

            var pos = (VID)args[0];
            if (!m_cells.TryGetValue(pos, out var _cell)) return false;

            cell = _cell;
            return true;
        }


        public void add_cell(Player cell)
        {
            m_cells.Add(cell.pos, cell);
        }


        public void remove_cell(VID pos)
        {
            m_cells.Remove(pos);
        }
    }
}

