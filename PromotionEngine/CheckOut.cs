using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine {
    public class CheckOut {

        public double GetTotal(string faceValue,
            string activePromotion,
            string checkOutInput) {

            string[] chunks = faceValue.Split(new[] { ';' });
            Dictionary<string, string> prices = new Dictionary<string, string>();
            foreach (var chunk in chunks) {
                string[] vals = chunk.Split(new[] { ' ' });
                prices.Add(vals[1], vals[0]);
            }

            string[] checkOutList = checkOutInput.Split(new[] { ' ' });
            Dictionary<string, string> unitsVsItems = new Dictionary<string, string>();
            foreach (var item in checkOutList) {
                string[] vals = item.Split(new[] { ' ' });
                unitsVsItems.Add(vals[1], vals[0]);
            }

            double total = 0;
            foreach (var items in unitsVsItems.Keys) {
                total += Convert.ToDouble(prices[items]) * Convert.ToDouble(unitsVsItems[items]);
            }
            return 0;
        }
    }
}
