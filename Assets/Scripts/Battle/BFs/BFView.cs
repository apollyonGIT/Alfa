using Foundation;
using UnityEngine;

namespace Battle.BFs
{
    public class BFView : MonoBehaviour, IBFView
    {
        public GameObject show_obs_bg;
        public GameObject show_path_bg;

        BF cell;

        //==================================================================================================

        void IModelView<BF>.attach(BF cell)
        {
            this.cell = cell;

            transform.localPosition = cell.view_pos;
        }


        void IModelView<BF>.detach(BF cell)
        {
            this.cell = null;
        }


        void IBFView.notify_on_show_path(bool is_enable)
        {
            show_path_bg.SetActive(is_enable);
        }


        public void notify_on_right_click()
        {
            ref var is_obs = ref cell.is_obs;
            is_obs = !is_obs;

            show_obs_bg.SetActive(is_obs);
        }
    }
}

