﻿using UnityEngine;

namespace Battle.Players
{
    public class Player_AC_i_Human : Player_AC
    {
        public override bool move_condition(float f, string s)
        {
            Debug.Log(f);
            return false;
        }
    }
}
