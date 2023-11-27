using Foundation.Tables;

namespace Battle.HandCards.Funcs
{
    public interface IFunc
    {
        bool @do();
    }


    public class Func_Utility
    {
        public static ExprTreeConverter converter = new("Battle.HandCards.Funcs.", ", Battle", "Battle.HandCards.Funcs.", ", Battle");

        //==================================================================================================
        
    }


    public class And : IFunc
    {
        IFunc f1;
        IFunc f2;

        public And(IFunc f1, IFunc f2)
        {
            this.f1 = f1;
            this.f2 = f2;
        }

        bool IFunc.@do()
        {
            return f1.@do() && f2.@do();
        }
    }
}

