using Foundation;
using UnityEngine;

namespace Battle.Battle_Fields
{
    public class Battle_Field : Model<Battle_Field, IBattle_FieldView>
    {
        public Hexagon id;
        public Vector2 view_pos => id.hex_2_unity_pos(0.5f);

        public Battle_FieldMgr mgr;

        //==================================================================================================

        public Battle_Field(Battle_FieldMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            id = (Hexagon)args[0];
            
        }
    }
}

