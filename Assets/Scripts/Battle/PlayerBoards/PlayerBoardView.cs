using TMPro;
using UnityEngine;

namespace Battle.PlayerBoards
{
    public class PlayerBoardView : MonoBehaviour
    {
        public TextMeshProUGUI hp;
        public TextMeshProUGUI reiki;

        //==================================================================================================

        // Update is called once per frame
        void Update()
        {
            var ctx = BattleContext.instance;
            {
                hp.text = $"{ctx.hp}/{ctx.max_hp}";
                reiki.text = $"{ctx.reiki}/{ctx.max_reiki}";
            }
        }
    }
}

