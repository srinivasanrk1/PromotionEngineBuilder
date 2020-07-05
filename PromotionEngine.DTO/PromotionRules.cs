using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.DTO
{
    public enum PromotionType
    {
        ItemCount = 0,
        Combo = 1,
        Percentage = 2
    }
    public class PromotionRules
    {
        public PromotionType PromotionType;
        public string SKUids;
        public int Count;
        public decimal PromotionValue;

    }
}
