using Common;

namespace Battle.HandCards.Funcs
{
    public interface IFunc : IExprFunc
    {
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

        bool IExprFunc.@do()
        {
            return f1.@do() && f2.@do();
        }
    }
}

