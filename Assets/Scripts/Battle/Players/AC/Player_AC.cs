using System.Reflection;

namespace Battle.Players
{
    public interface IPlayer_AC
    { 
        
    }


    public class Player_AC
    {
        public static void load_ac(Player cell)
        {
            var ac_name = $"Player_AC_{cell._desc.f_race.value}";
            cell.ac = (IPlayer_AC)Assembly.Load("Battle").CreateInstance($"Battle.Players.{ac_name}");
        }
    }
}

