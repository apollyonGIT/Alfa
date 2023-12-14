using Foundation;

namespace Battle.Store_Checks
{
    public class Store_Check : Model<Store_Check, IStore_CheckView>
    {
        public VID vid;

        //==================================================================================================

        public Store_Check(VID vid)
        {
            this.vid = vid;
        }
    }
}

