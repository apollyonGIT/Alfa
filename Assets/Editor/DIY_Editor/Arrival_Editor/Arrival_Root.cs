using UnityEngine;

namespace Editor.DIY_Editor.Arrival_Editor
{
    public class Arrival_Root : Root<Arrival_Asset>
    {

        //==================================================================================================

        public override void clean()
        {
            
        }


        public override void load_asset()
        {
            clean();
        }


        protected override void save_asset(Arrival_Asset asset)
        {
            
        }


        public void do_brush(Vector3 pos)
        {
            Debug.Log("bbbbb");
        }


        public void do_erase(Vector3 pos)
        {
            Debug.Log("eeee");
        }
    }
}

