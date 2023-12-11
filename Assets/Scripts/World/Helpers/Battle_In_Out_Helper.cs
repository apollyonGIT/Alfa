using Common;
using System.Reflection;

namespace World.Helpers
{
    public class Battle_In_Out_Helper : Singleton<Battle_In_Out_Helper>
    {
        public void enter_battle(WorldContext ctx)
        {
            ctx.battle_ret = new();

            EX_Utility.load_scene_async("scenes", "Battle");

            ctx.is_battle = true;
        }


        public void end_battle(WorldContext ctx)
        {
            var bctx_type = Assembly.Load(Config.current.battle_assembly_name).GetType(Config.current.battle_ctx_name);
            bctx_type.GetMethod("end_battle")?.Invoke(null, new object[] { ctx });

            EX_Utility.unload_scene_async("Battle");

            ctx.is_battle = false;
        }
    }
}

