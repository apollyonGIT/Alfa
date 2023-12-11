using Common;
using System.Reflection;
using System;

namespace World.Helpers
{
    public class Battle_In_Out_Helper : Singleton<Battle_In_Out_Helper>
    {
        public void enter_battle(WorldContext ctx)
        {
            var type = Assembly.Load(Config.current.battle_assembly_name).GetType(Config.current.battle_ctx_name);
            ctx.bctx = Activator.CreateInstance(type);

            EX_Utility.load_scene_async("scenes", "Battle");

            ctx.is_battle = true;
        }


        public void end_battle(WorldContext ctx)
        {
            var bctx = ctx.bctx;
            var mi = bctx.GetType().GetMethod("end_battle");
            mi?.Invoke(bctx, new object[] { });

            EX_Utility.unload_scene_async("Battle");

            ctx.is_battle = false;
        }
    }
}

