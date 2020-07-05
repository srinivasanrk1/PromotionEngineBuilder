using PromotionEngine.DTO;
using PromotionEngine.Rules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.RuleCalculator.Conditions
{
    class ComboPromo : BaseRule
    {

        private readonly string[] _comboStr;
        private readonly PromotionRules _promotionRules;
        public ComboPromo(string[] comboStr, PromotionRules promotionRules)
        {
            _comboStr = comboStr;
            _promotionRules = promotionRules;
            SKUid = _promotionRules.SKUids;

        }


        public override bool CondnPassed()
        {
            decimal totalPairs = 0M;
            var splitValue = _promotionRules.SKUids.Split(',').ToArray();
            var queryPairs = _comboStr.Where(o => splitValue.Any(p => o == p)).GroupBy(r => r)
                      .Select(grp => new
                      {
                          Value = grp.Key,
                          Count = grp.Count(),
                      });
            if (queryPairs.Count() == splitValue.Count())
            {
                totalPairs = Convert.ToDecimal(queryPairs.Min(o => o.Count));
                DiscountPrice = totalPairs * _promotionRules.PromotionValue;
                
                return true;
            }
            return false;
        }
    }

}
