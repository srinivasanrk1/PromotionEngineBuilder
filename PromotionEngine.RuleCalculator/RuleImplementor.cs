using PromotionEngine.DTO;
using PromotionEngine.RuleCalculator.Conditions;
using PromotionEngine.Rules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.RuleCalculator
{
    public class RuleImplementor : IRule<PromotionCart>
    {
        public IList<BaseRule> Conditions { get; set; }
        private IList<PromotionRules> _promtionRules { get; set; }


        public RuleImplementor(List<PromotionRules> promtionRules)
        {
            Conditions = new List<BaseRule>();
            _promtionRules = promtionRules;

        }
        PromotionCart IRule<PromotionCart>.Apply(PromotionCart obj)
        {
            if (obj.TotalValue > 0)
                obj.Products.Add(new SKUItems { SKUId = "Discount", Price = Conditions.Sum(o => o.DiscountPrice) });
            return obj;
        }

        void IRule<PromotionCart>.ClearConditions()
        {
            Conditions.Clear();
        }
        bool validateCart(PromotionCart promotionCart)
        {
            return promotionCart.Products == null ? true :
                   promotionCart?.TotalValue == 0 ? true : false;

        }

        void IRule<PromotionCart>.Initialize(PromotionCart promotionCart)
        {
            int cartValue = 0;
            if (validateCart(promotionCart)) return;
            foreach (var promotionRule in _promtionRules)
            {
                bool validate = Conditions.Any(o => o.SKUid.Contains(promotionRule.SKUids) && o.CondnPassed());
                if (validate) continue;
                switch (promotionRule.PromotionType)
                {

                    case PromotionType.ItemCount:
                        cartValue = promotionCart.Products.Where(o => o.SKUId == promotionRule.SKUids).Count();
                        Conditions.Add(new CountPromo(cartValue, promotionRule));
                        break;
                    case PromotionType.Combo:
                        var purchaselist = promotionCart.Products.Select(o => o.SKUId).ToArray();
                        Conditions.Add(new ComboPromo(purchaselist, promotionRule));
                        break;
                    case PromotionType.Percentage:
                        cartValue = promotionCart.Products.Where(o => o.SKUId == promotionRule.SKUids).Count();
                        decimal cartPrice = promotionCart.Products.Where(o => o.SKUId == promotionRule.SKUids).Sum(o => o.Price);
                        Conditions.Add(new PercentagePromo(cartValue, cartPrice, promotionRule));
                        break;
                    default: break;

                }
            }


        }

        bool IRule<PromotionCart>.IsValid()
        {
            return Conditions?.Count(o => o.CondnPassed()) > 0;
        }


    }
}
