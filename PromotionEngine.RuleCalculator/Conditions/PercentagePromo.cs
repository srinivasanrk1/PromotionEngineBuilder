using PromotionEngine.DTO;
using PromotionEngine.Rules.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.RuleCalculator.Conditions
{

    class PercentagePromo : BaseRule
    {
        private readonly int _actual;
        private readonly decimal _price;
        private readonly PromotionRules _promotionRules;
        public PercentagePromo(int actual, decimal price, PromotionRules promotionRules)
        {
            _actual = actual;
            _price = price;
            _promotionRules = promotionRules;
            SKUid = _promotionRules.SKUids;

        }

        public override bool CondnPassed()
        {
            if (_actual == _promotionRules.Count)
            {
                DiscountPrice = decimal.Negate(((decimal)_price *  _promotionRules.PromotionValue) / 100);
                SKUid = _promotionRules.SKUids;
                return true;
            }
            return false;
        }
    }

}
