using Foundation;
using UnityEngine;

namespace Battle.Battle_Fields
{
    public class Battle_FieldView : MonoBehaviour, IBattle_FieldView
    {
        public TextMesh q, r, s;

        Battle_Field cell;

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


        public void notify_on_left_click()
        {
            var dis = Hexagon.distance(Hexagon.xy_2_hex(new(1, 1)), cell.id);
            Debug.Log(dis);
        }
    }
}

