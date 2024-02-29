using Common;
using Foundation;
using UnityEngine;
using static AutoCode.Tables.Monster;

namespace Battle.Enemys
{
    public class Enemy : Model<Enemy, IEnemyView>
    {
        public VID pos;
        public Vector2 view_pos => (Vector2)pos;

        public int hp;

        Record _desc;
        public EnemyMgr mgr;

        //==================================================================================================

        public Enemy(EnemyMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            var id = (uint)args[0];
            Battle_DB.instance.monster.try_get(id, out _desc);
            hp = _desc.f_hp;

            pos = (VID)args[1];
        }


        public void tick1()
        {
            foreach (var view in views)
            {
                view.notify_on_tick1();
            }
        }


        public void hurt(int dmg)
        {
            hp = EX_Utility.floor_int(0, hp - dmg);
            Debug.Log($"怪物受到攻击，剩余hp：{hp}");
        }
    }
}

