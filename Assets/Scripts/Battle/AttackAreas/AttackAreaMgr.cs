using Battle.Helpers;
using Common;
using Foundation;
using System.Collections.Generic;

namespace Battle.AttackAreas
{
    public interface IAttackAreaView : IModelView<AttackArea>
    {
        void notify_on_show(bool is_enable);
    }


    public class AttackAreaMgr : IMgr
    {
        string IMgr.name => m_mgr_name;
        readonly string m_mgr_name;

        Dictionary<int, AttackArea> m_cells = new();

        //==================================================================================================

        public AttackAreaMgr(string name, params object[] objs)
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


        public void add_cell(AttackArea cell)
        {
            m_cells.Add(cell.vid ,cell);
        }


        public void @enable(int self_vid, (string, string) asset_paths)
        {
            @disable();

            EX_Utility.try_load_asset(asset_paths, out AttackArea_Asset asset);
            foreach (var pos in asset.pos_array)
            {
                SquareMap_Helper.decode_vid(self_vid, out var self_x, out var self_y);
                SquareMap_Helper.encode_vid(pos.x + self_x, pos.y + self_y, out var vid);

                if (!m_cells.TryGetValue(vid, out var cell)) continue;
                foreach (var view in cell.views)
                {
                    view.notify_on_show(true);
                }
            }
        }


        public void @disable()
        {
            foreach (var (_, cell) in m_cells)
            {
                foreach (var view in cell.views)
                {
                    view.notify_on_show(false);
                }
            }
        }

    }
}

