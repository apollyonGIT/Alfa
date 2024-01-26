using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Ticker_Module
{
    public class Ticker_Mono : MonoBehaviour
    {
        Ticker ticker;

        //==================================================================================================

        private void Start()
        {
            ticker = Ticker._init();
            ticker.init();

            ticker.can_start_tick = true;
        }


        private void Update()
        {
            ticker.update();
        }
    }
}

