using Common;

namespace Battle
{
    public class Battle_Next_Turn_Helper : Singleton<Battle_Next_Turn_Helper>
    {
        public void next_turn(BattleContext ctx)
        {
            var mission = Mission.instance;
            {
                mission.try_get_mgr("Res_CardMgr", out var res_card_mgr);

                //规则：重新抽牌至上限
                res_card_mgr.GetType().GetMethod("remove_cells")?.Invoke(res_card_mgr, null);
                res_card_mgr.GetType().GetMethod("add_cells")?.Invoke(res_card_mgr, null);
            }
        }
    }
}

