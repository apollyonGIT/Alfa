using Foundation;

namespace Battle.Battle_Fields
{
    public class Battle_Field : Model<Battle_Field, IBattle_FieldView>
    {
        public Hexagon_ID id;

        public Battle_FieldMgr mgr;

        //==================================================================================================

        public Battle_Field(Battle_FieldMgr mgr,  params object[] args)
        {
            this.mgr = mgr;
        }
    }
}

