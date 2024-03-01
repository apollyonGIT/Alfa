using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Skills
{
    public class SkillPD : Producer
    {
        public RectTransform rect;

        public int count = 6;
        public SkillView model_view;

        public override IMgr imgr => mgr;
        SkillMgr mgr;

        public float selected_scale_offset = 1.3f;
        public float selected_height_offset = 30f;

        public Transform selecting_area;
        public Transform standing;

        public Texture2D cursor;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("SkillMgr", priority);

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


        IEnumerable<Skill> cells(SkillMgr mgr)
        {
            for (int pos = 0; pos < count; pos++)
            {
                yield return new(mgr, pos);
            }
        }
    }
}

