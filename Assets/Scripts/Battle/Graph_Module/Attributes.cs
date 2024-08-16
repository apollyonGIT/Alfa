using System;

namespace Battle.Graph_Module
{
    public class Attributes
    {
        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
        public class ExprConstAttribute : Attribute
        {
            public string name { get; }
            public ExprConstAttribute() { }
            public ExprConstAttribute(string name) { this.name = name; }
        }
    }
}

