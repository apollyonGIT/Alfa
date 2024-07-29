using Foundation;
using UnityEngine;
using Common;

namespace Battle.Battle_Fields
{
    public class Battle_FieldView : View, IBattle_FieldView
    {
        public TextMesh q, r, s;

        Battle_Field cell;

        public override object vmgr => cell.mgr;
        public override object vcell => cell;

        //==================================================================================================

        void IModelView<Battle_Field>.attach(Battle_Field cell)
        {
            this.cell = cell;

            var id = cell.id;
            q.text = $"{id.q}";
            r.text = $"{id.r}";
            s.text = $"{id.s}";

            transform.localPosition = cell.view_pos;
        }


        void IModelView<Battle_Field>.detach(Battle_Field cell)
        {
            this.cell = null;

            DestroyImmediate(gameObject);
        }
    }
}

