using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle.Cards
{
    public class Win_Draw : MonoBehaviour
    {
        public Show_Card_View model;

        public Transform content;

        //==================================================================================================

        public void init()
        {
            Mission.instance.try_get_mgr("DeckMgr", out DeckMgr deck_mgr);

            foreach (var card in deck_mgr.drawcards)
            {
                var show_card = Instantiate(model, content);
                show_card.init(card);
            }
        }
    }
}

