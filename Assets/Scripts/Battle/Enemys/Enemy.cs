using Foundation;
using UnityEngine;

namespace Battle.Enemys
{
    public class Enemy : Model<Enemy, IEnemyView>
    {
        public VID pos;
        public Vector2 view_pos => (Vector2)pos;

        public EnemyMgr mgr;

        //==================================================================================================

        public Enemy(EnemyMgr mgr,  params object[] args)
        {
            this.mgr = mgr;

            pos = (VID)args[0];
        }


        public void tick1()
        {
            foreach (var view in views)
            {
                view.notify_on_tick1();
            }
        }


        public void notify_on_call()
        {
            mgr.move(ref pos, new(0, -1));
        }
    }
}

