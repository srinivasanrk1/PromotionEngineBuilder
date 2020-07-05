using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Rules.Interfaces
{
    public interface IRule<T>
    {
        void ClearConditions();
        void Initialize(T obj);
        bool IsValid();
        T Apply(T obj);
    }
}
