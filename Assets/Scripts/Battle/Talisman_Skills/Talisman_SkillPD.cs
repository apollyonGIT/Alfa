using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Talisman_Skills
{
    public class Talisman_SkillPD : Producer
    {
        public RectTransform rect;

        public int count = 6;
        public Talisman_SkillView model_view;

        public override IMgr imgr => mgr;
        Talisman_SkillMgr mgr;

        public int cells_distance = 130;
        public float selected_scale_offset = 1.3f;
        public float selected_height_offset = 30f;

        public Transform selecting_area;
        public Transform standing;

        public Texture2D cursor;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("Talisman_SkillMgr", priority);

            foreach (var cell in cells(mgr))
            {
                mgr.add_cell(cell);

                var view = Instantiate(model_view, transform);
                cell.add_view(view);
                view.pd = this;
            }
        }


        public override void call()
        {
        }


        public override void fini()
        {
            imgr.fini();
        }


        IEnumerable<Talisman_Skill> cells(Talisman_SkillMgr mgr)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new(mgr);
            }
        }


        private void Update()
        {
            if (mgr == null) return;

            rect.sizeDelta = Vector2.right * count * cells_distance;
        }
    }
}

