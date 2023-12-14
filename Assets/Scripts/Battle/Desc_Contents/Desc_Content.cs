using Foundation;

namespace Battle.Desc_Contents
{
    public class Desc_Content : Model<Desc_Content, IDesc_ContentView>
    {

        //==================================================================================================

        public void enable(bool is_enable)
        {
            foreach (var view in views)
            {
                view.notify_on_enable(is_enable);
            }
        }
    }
}

