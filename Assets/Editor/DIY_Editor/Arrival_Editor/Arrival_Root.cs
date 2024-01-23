using Battle;
using Battle.Arrivals;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.DIY_Editor.Arrival_Editor
{
    public class Arrival_Root : Root<Arrival_Asset>
    {
        public GameObject model_view;

        Dictionary<VID, GameObject> m_cells = new();

        //==================================================================================================

        public override void clean()
        {
            foreach (var (_, go) in m_cells)
            {
                DestroyImmediate(go);
            }

            m_cells.Clear();
        }


        public override void load_asset()
        {
            clean();

            foreach (var pos in asset.pos_array)
            {
                do_brush(pos);
            }
        }


        protected override void save_asset(Arrival_Asset asset)
        {
            var list = new List<Vector2>();
            foreach (var (pos, _) in m_cells)
            {
                list.Add((Vector2)pos);
            }

            asset.pos_array = list.ToArray();
        }


        public void do_brush(Vector2 pos)
        {
            VID _pos = pos;
            if (m_cells.TryGetValue(_pos, out var _)) return;

            var view = Instantiate(model_view, transform);
            view.transform.localPosition = (Vector2)_pos;

            var cell = view.gameObject;
            m_cells.Add(_pos, cell);
        }


        public void do_erase(Vector2 pos)
        {
            VID _pos = pos;
            if (!m_cells.TryGetValue(_pos, out var cell)) return;

            m_cells.Remove(_pos);
            DestroyImmediate(cell);
        }
    }
}

