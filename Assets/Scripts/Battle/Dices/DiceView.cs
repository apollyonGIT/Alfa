using Foundation;
using UnityEngine;
using TMPro;

namespace Battle.Dices
{
    public class DiceView : MonoBehaviour, IDiceView
    {
        public TextMeshProUGUI value;

        Dice cell;

        //==================================================================================================

        void IModelView<Dice>.attach(Dice cell)
        {
            this.cell = cell;

            fresh();
        }


        void IModelView<Dice>.detach(Dice cell)
        {
            this.cell = null;

            DestroyImmediate(gameObject);
        }


        public void fresh()
        {
            value.text = $"{cell.value}";
        }



    }
}

