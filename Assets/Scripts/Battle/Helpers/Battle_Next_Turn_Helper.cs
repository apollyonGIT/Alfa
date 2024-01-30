using Common;

namespace Battle
{
    public class Battle_Next_Turn_Helper : Singleton<Battle_Next_Turn_Helper>
    {
        public void next_turn(BattleContext ctx)
        {
            var mission = Mission.instance;
            {
                mission.try_get_mgr("Res_CardMgr", out Res_Cards.Res_CardMgr res_card_mgr);
                mission.try_get_mgr("EnemyMgr", out Enemys.EnemyMgr enemy_mgr);

                //规则：怪物向下移动一格
                enemy_mgr.be_call();

                //规则：重新抽牌至上限
                res_card_mgr.remove_cells();
                res_card_mgr.add_cells();
            }
        }
    }
}

