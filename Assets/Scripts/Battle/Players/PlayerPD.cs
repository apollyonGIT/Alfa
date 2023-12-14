using Common;
using TMPro;

namespace Battle.Players
{
    public class PlayerPD : Producer
    {
        public TextMeshProUGUI energy;

        public override IMgr imgr => null;

        //==================================================================================================

        public override void init()
        {
            BattleContext.instance.energy = 3;
        }


        public override void tick()
        {
            BattleContext.instance.energy = 3;
        }


        public override void fini()
        {
        }


        void Update()
        {
            energy.text = BattleContext.instance.energy.ToString();
        }
    }
}

