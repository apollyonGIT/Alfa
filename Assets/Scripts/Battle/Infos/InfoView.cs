using TMPro;
using UnityEngine;

namespace Battle
{
    public class InfoView : MonoBehaviour
    {
        public TextMeshProUGUI res;

        //==================================================================================================

        // Update is called once per frame
        void Update()
        {
            var bctx = BattleContext.instance;
            {
                res.text = $"{bctx.reiki},{bctx.reiki_type}";
            }
        }
    }
}

