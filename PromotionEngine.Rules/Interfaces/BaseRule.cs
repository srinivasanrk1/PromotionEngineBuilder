using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Rules.Interfaces
{

    public abstract class BaseRule
    {
        public decimal DiscountPrice = 0M;
        public string SKUid = string.Empty;
        public abstract bool CondnPassed();
    }

}
