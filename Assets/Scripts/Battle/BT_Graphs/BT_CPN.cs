namespace Battle.BT_Graphs
{
    public class BT_CPN
    {
        public BT_Node node;

        //==================================================================================================

        public BT_CPN(BT_Context bctx, BT_Node node)
        {
            this.node = node;
        }


        public virtual void @do(BT_Context bctx, params object[] args)
        {

        }
    }
}

