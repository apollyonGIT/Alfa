using Foundation;
using UnityEngine;
using Common;
using TMPro;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;

namespace Battle.HandCards
{
    public class HandCardView : MonoBehaviour, IHandCardView
    {
        public TextMeshProUGUI title;

        HandCard cell;

        //==================================================================================================

        void IModelView<HandCard>.attach(HandCard cell)
        {
            this.cell = cell;

            fresh();
        }


        void IModelView<HandCard>.detach(HandCard cell)
        {
            this.cell = null;

            DestroyImmediate(gameObject);
        }


        public void fresh()
        {
            title.text = $"{cell.title}";
        }
    }
}

