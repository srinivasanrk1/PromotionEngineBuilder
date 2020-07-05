using PromotionEngine.DTO;
using PromotionEngine.Rules.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.RuleCalculator.Conditions
{
    class CountPromo : BaseRule
    {
        private readonly int _actual;
        private readonly PromotionRules _promotionRules;



        public CountPromo(int actual, PromotionRules promotionRules)
        {
            _actual = actual;
            _promotionRules = promotionRules;
            SKUid = _promotionRules.SKUids;

        }

        public override bool CondnPassed()
        {
            bool valid = false;
            if (_actual >= _promotionRules.Count)
            {
                int totalDisc = _actual / _promotionRules.Count;
                if (totalDisc > 0)
                {
                    DiscountPrice = totalDisc * _promotionRules.PromotionValue;
                    valid =  true;
                }
            }
            return valid;
        }
    }

}
