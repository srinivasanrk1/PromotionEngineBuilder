using PromotionEngine.DTO;
using System.Linq;
using System.Collections.Generic;
using PromotionEngine.Rules;
namespace PromotionEngine.RuleCalculator
{
    public class PromotionEngineCalculator
    {
        PromotionCart _promoCart;
        public List<PromotionRules> _promtionRules { get; set; }
        public PromotionEngineCalculator(PromotionCart promoCart, List<PromotionRules> promotionRules)
        {
            _promoCart = promoCart;
            _promtionRules = promotionRules;
        }

        public PromotionCart Run()
        {
            _promoCart
                .ApplyRule(new RuleImplementor(_promtionRules));

            return _promoCart;
        }
    }
}
