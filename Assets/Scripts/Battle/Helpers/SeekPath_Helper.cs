using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Foundation.Net.TcpStream;

namespace Battle
{
    public class SeekPath_Helper : Singleton<SeekPath_Helper>
    {
        public static void show_path()
        {
            Mission.instance.try_get_mgr("EnemyMgr", out Enemys.EnemyMgr enemy_mgr);
            Mission.instance.try_get_mgr("LandMgr", out Lands.LandMgr land_mgr);

            var start = enemy_mgr.temp_cell_pos_for_test;
            var end = Vector2.zero;

            var obstacles = new LinkedList<Vector2>();
            obstacles.AddLast(new Vector2(1, 0));

            foreach (var pos in obstacles)
            {
                land_mgr.set_cell_color(pos, Color.red);
            }

            if (!Common.SeekPath_Module.SeekPath_Utility.try_seek_path(start, end, obstacles.ToArray(), VID.valid_in_area, out var paths))
                return;

            foreach (var pos in paths)
            {
                land_mgr.set_cell_color(pos, Color.gray);
            }
        }


        public static bool try_seek_path(VID start, VID end, List<VID> obstacles, Func<Vector2, bool> valid_in_area_func, out LinkedList<Vector2> ret)
        {
            List<Vector2> obs = new();
            foreach (var t in obstacles)
            {
                obs.Add((Vector2)t);
            }

            return Common.SeekPath_Module.SeekPath_Utility.try_seek_path((Vector2)start, (Vector2)end, obs.ToArray(), valid_in_area_func, out ret);
        }
    }
}

