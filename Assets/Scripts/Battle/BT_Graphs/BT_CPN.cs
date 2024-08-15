namespace Battle.BT_Graphs
{
    public class BT_CPN
    {
        public BT_Node node;

        //==================================================================================================

        public virtual void @init(BT_Context ctx, BT_Node node)
        {
            this.node = node;
        }


        public virtual void @do(BT_Context ctx)
        {

        }
    }
}

