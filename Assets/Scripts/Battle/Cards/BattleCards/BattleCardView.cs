using Foundation;
using UnityEngine;
using Common;

namespace Cards.BattleCards
{
    public class BattleCardView : MonoBehaviour, IBattleCardView
    {
        BattleCard cell;

        //==================================================================================================

        void IModelView<BattleCard>.attach(BattleCard cell)
        {
            this.cell = cell;
        }


        void IModelView<BattleCard>.detach(BattleCard cell)
        {
            this.cell = null;
        }
    }
}

