using Battle.BT_Graphs;
using Foundation;
using UnityEngine;

namespace Battle.Enemys
{
    public class Enemy : Model<Enemy, IEnemyView>
    {
        public AutoCode.Tables.Enemy.Record _desc;

        public Vector2 pos;
        public Vector2 view_pos => pos * 2f;

        public BT_Context bctx;
        public EnemyMgr mgr;

        //==================================================================================================

        public Enemy(EnemyMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            var id = (uint)args[0];
            Battle_DB.instance.enemy.try_get(id, out _desc);

            pos = (Vector2)args[1];

            bctx = new(this, _desc.f_behaviour_tree);
        }


        public Vector2 pos_ref 
        {
            get { return pos; }
            set { pos = value; }
        }
    }
}

