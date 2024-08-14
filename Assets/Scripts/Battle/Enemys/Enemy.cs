using Foundation;
using UnityEngine;

namespace Battle.Enemys
{
    public class Enemy : Model<Enemy, IEnemyView>
    {
        public AutoCode.Tables.Enemy.Record _desc;

        public Vector2 pos;
        public Vector2 view_pos => pos * 2f;

        public EnemyMgr mgr;

        //==================================================================================================

        public Enemy(EnemyMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            var id = (uint)args[0];
            Battle_DB.instance.enemy.try_get(id, out _desc);

            pos = (Vector2)args[1];
        }
    }
}

