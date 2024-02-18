using System.Reflection;

namespace Battle.Players
{
    public abstract class Player_AC
    {
        public static void load_ac(Player cell)
        {
            var ac_name = $"Player_AC_{cell._desc.f_race.value}";
            cell.ac = (Player_AC)Assembly.Load("Battle").CreateInstance($"Battle.Players.{ac_name}");
        }


        public abstract bool move_condition(float f, string s);
    }
}

