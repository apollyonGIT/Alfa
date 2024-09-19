using Cards.BattleCards;
using UnityEngine;

namespace Battle.BFs
{
    public class BFView : MonoBehaviour
    {
        public BattleCardPD battle_card_PD;

        //==================================================================================================

        public void init()
        {
            battle_card_PD.init(999);
        }
    }
}

