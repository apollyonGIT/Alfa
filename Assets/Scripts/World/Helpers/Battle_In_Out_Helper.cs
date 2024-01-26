﻿using Common;
using System.Reflection;

namespace World
{
    public class Battle_In_Out_Helper : Singleton<Battle_In_Out_Helper>
    {
        public void in_battle(WorldContext ctx)
        {
            Assembly.Load(Config.current.battle_assembly).GetType(Config.current.battle_context_path).GetMethod("attach").Invoke(null, new object[] { ctx });

            EX_Utility.load_scene_async("scenes", "Battle");
            ctx.is_battle = true;
        }


        public void out_battle(WorldContext ctx)
        {
            Assembly.Load(Config.current.battle_assembly).GetType(Config.current.battle_context_path).GetMethod("detach").Invoke(null, new object[] { ctx });

            EX_Utility.unload_scene_async("Battle");
            ctx.is_battle = false;
        }
    }
}

