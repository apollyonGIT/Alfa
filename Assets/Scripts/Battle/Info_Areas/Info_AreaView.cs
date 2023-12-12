using Foundation;
using UnityEngine;

namespace Battle.Info_Areas
{
    public class Info_AreaView : MonoBehaviour, IInfo_AreaView
    {
        public SpriteRenderer area;

        Info_Area cell;

        //==================================================================================================

        void IModelView<Info_Area>.attach(Info_Area cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<Info_Area>.detach(Info_Area cell)
        {
            this.cell = null;
        }

        
        void IModelView<Info_Area>.shift(Info_Area old_cell, Info_Area new_cell)
        {
        }


        void IInfo_AreaView.notify_on_change()
        {
            
        }


        void IInfo_AreaView.notify_on_enable(bool is_enable)
        {
            if (is_enable)
                area.color = cell.view_color;

            area.enabled = is_enable;
        }
    }
}

