﻿using Common;
using UnityEngine;

namespace Battle.HandCards.Funcs
{
    public class Test_Func : IFunc
    {
        int i;

        //==================================================================================================

        public Test_Func(int i)
        {
            this.i = i;
        }


        bool IExprFunc.@do()
        {
            Debug.Log(i);
            return true;
        }
    }
}
