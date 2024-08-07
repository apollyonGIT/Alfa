using Foundation;
using UnityEngine;

namespace Battle.Battle_Fields
{
    public class Battle_Field : Model<Battle_Field, IBattle_FieldView>
    {
        public Hexagon id;
        public Vector2 view_pos => Hexagon.hex_2_pos(id, 0.5f);
        public Vector2 xy_pos => Hexagon.hex_2_xy(id);

        public Battle_FieldMgr mgr;

        public bool is_obs; //是否为障碍物

        //==================================================================================================

        public Battle_Field(Battle_FieldMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            id = (Hexagon)args[0];
            
        }
    }
}

