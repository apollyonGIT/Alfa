using TMPro;
using UnityEngine;

namespace Battle.Cards
{
    public class Show_Card_View : MonoBehaviour
    {
        public TextMeshProUGUI title;

        internal Card card;

        //==================================================================================================

        public void init(Card card)
        {
            this.card = card;

            title.text = card._desc.f_name;
        }
    }
}

