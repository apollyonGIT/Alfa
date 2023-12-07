using Foundation;
using UnityEngine;

namespace Battle.Battle_Ctrls
{
    public class Battle_Ctrl : Model<Battle_Ctrl, IBattle_CtrlView>
    {
        public VID vid;

        public Vector2 view_pos => VID.convert(vid);

        //==================================================================================================

    }
}

