using Newtonsoft.Json;
using PromotionEngine.DTO;
using PromotionEngine.RuleCalculator;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace PromotionEngineTest
{

    public class PromotionEngineTest
    {
        public List<PromotionRules> promtionRules;
        public PromotionEngineTest()
        {
            using (StreamReader r = new StreamReader(@"Settings.json"))
            {
                string data = r.ReadToEnd();
                promtionRules = JsonConvert.DeserializeObject<List<PromotionRules>>(data);
            }
        }
        [Fact]
        public void ShouldAcceptDeafultValues()

        {  // ARRANGE
            var productA = new SKUItems { Price = 0m, SKUId = "A" };
            var productB = new SKUItems { Price = 0m, SKUId = "B" };
            var productC = new SKUItems { Price = 0m, SKUId = "C" };
            var productD = new SKUItems { Price = 0m, SKUId = "D" };


            var cart = new PromotionCart
            {
                Products = new List<SKUItems> {
                    productA,  productA, productA,
                    productB, productB, productB, productB, productB,
                    productC,
                    productD }
            };



            var sut = new PromotionEngineCalculator(cart, promtionRules);

            // ACT
            PromotionCart result = sut.Run();

            // ASSERT
            const decimal expectedTotal = 0M;

            result.TotalValue.Should().Be(expectedTotal);

        }
        [Fact]
        public void ShouldPassScenario1()

        {  // ARRANGE
            var productA = new SKUItems { Price = 50m, SKUId = "A" };
            var productB = new SKUItems { Price = 30m, SKUId = "B" };
            var productC = new SKUItems { Price = 20m, SKUId = "C" };

            using (StreamReader r = new StreamReader(@"Settings.json"))
            {
                string data = r.ReadToEnd();
                promtionRules = JsonConvert.DeserializeObject<List<PromotionRules>>(data);
            }
            var cart = new PromotionCart
            {
                Products = new List<SKUItems> {
                    productA,
                    productB,
                    productC
                  }
            };



            var sut = new PromotionEngineCalculator(cart, promtionRules);

            // ACT
            PromotionCart result = sut.Run();

            // ASSERT
            const decimal expectedTotal = 100m;

            result.TotalValue.Should().Be(expectedTotal);

        }
        [Fact]
        public void ShouldPassScenario2()

        {  // ARRANGE
            var productA = new SKUItems { Price = 50m, SKUId = "A" };
            var productB = new SKUItems { Price = 30m, SKUId = "B" };
            var productC = new SKUItems { Price = 20m, SKUId = "C" };
            var productD = new SKUItems { Price = 15m, SKUId = "D" };

            using (StreamReader r = new StreamReader(@"Settings.json"))
            {
                string data = r.ReadToEnd();
                promtionRules = JsonConvert.DeserializeObject<List<PromotionRules>>(data);
            }
            var cart = new PromotionCart
            {
                Products = new List<SKUItems> {
                    productA,  productA, productA,productA,productA,
                    productB, productB, productB, productB, productB,
                    productC
                }
            };



            var sut = new PromotionEngineCalculator(cart, promtionRules);

            // ACT
            PromotionCart result = sut.Run();

            // ASSERT
            const decimal expectedTotal = 370M;

            result.TotalValue.Should().Be(expectedTotal);

        }
        [Fact]
        public void ShouldPassScenario3()

        {  // ARRANGE
            var productA = new SKUItems { Price = 50m, SKUId = "A" };
            var productB = new SKUItems { Price = 30m, SKUId = "B" };
            var productC = new SKUItems { Price = 20m, SKUId = "C" };
            var productD = new SKUItems { Price = 15m, SKUId = "D" };

            using (StreamReader r = new StreamReader(@"Settings.json"))
            {
                string data = r.ReadToEnd();
                promtionRules = JsonConvert.DeserializeObject<List<PromotionRules>>(data);
            }
            var cart = new PromotionCart
            {
                Products = new List<SKUItems> {
                    productA,  productA, productA,
                    productB, productB, productB, productB, productB,
                    productC,
                    productD }
            };



            var sut = new PromotionEngineCalculator(cart, promtionRules);

            // ACT
            PromotionCart result = sut.Run();

            // ASSERT
            const decimal expectedTotal = 280m;

            result.TotalValue.Should().Be(expectedTotal);

        }
        [Fact]
        public void ShouldPassIfPercentDiscountApplied()

        {  // ARRANGE
            var productA = new SKUItems { Price = 50m, SKUId = "A" };
            var productB = new SKUItems { Price = 30m, SKUId = "B" };
            var productC = new SKUItems { Price = 20m, SKUId = "C" };
            var productD = new SKUItems { Price = 15m, SKUId = "D" };

            using (StreamReader r = new StreamReader(@"Settings1.json"))
            {
                string data = r.ReadToEnd();
                promtionRules = JsonConvert.DeserializeObject<List<PromotionRules>>(data);
            }
            var cart = new PromotionCart
            {
                Products = new List<SKUItems> {
                    productA,  productA, productA,
                    productB, productB, productB, productB, productB,
                    productD }
            };



            var sut = new PromotionEngineCalculator(cart, promtionRules);

            // ACT
            PromotionCart result = sut.Run();

            // ASSERT
            const decimal expectedTotal = 264.55M;

            result.TotalValue.Should().Be(expectedTotal);

        }
        [Fact]
        public void ShouldPassOnlyOneDiscountMusteBeApplied()

        {  // ARRANGE
            var productA = new SKUItems { Price = 50m, SKUId = "A" };
            var productB = new SKUItems { Price = 30m, SKUId = "B" };
            var productC = new SKUItems { Price = 20m, SKUId = "C" };
            var productD = new SKUItems { Price = 15m, SKUId = "D" };

            using (StreamReader r = new StreamReader(@"Settings2.json"))
            {
                string data = r.ReadToEnd();
                promtionRules = JsonConvert.DeserializeObject<List<PromotionRules>>(data);
            }
            var cart = new PromotionCart
            {
                Products = new List<SKUItems> {
                    productA,  productA, productA,
                    productB, productB, productB, productB, productB,
                    productD }
            };



            var sut = new PromotionEngineCalculator(cart, promtionRules);

            // ACT
            PromotionCart result = sut.Run();

            // ASSERT
            const decimal expectedTotal = 250M;

            result.TotalValue.Should().Be(expectedTotal);

        }

    }
}
