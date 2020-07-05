using PromotionEngine.Rules.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Rules
{
    public static class RuleBuilder
    {
        public static T ApplyRule<T>(this T obj, IRule<T> rule) where T : class
        {
            rule.ClearConditions();
            rule.Initialize(obj);
            if (rule.IsValid())
            {
                rule.Apply(obj);
            }
            return obj;
        }
        
    }
}
