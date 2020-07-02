﻿using System;
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
            Dictionary<string, string> checkOutValues = new Dictionary<string, string>();
            foreach (var item in checkOutList) {
                string[] vals = item.Split(new[] { ' ' });
                checkOutValues.Add(vals[1], vals[0]);
            }


            string[] promorules = activePromotion.Split(new[] { ';' });
            List<Tuple<string, int, double>> promotion = new List<Tuple<string, int, double>>();
            foreach (var promorule in promorules) {
                string[] chunks2 = promorule.Split(new[] { ' ' });

                promotion.Add(new Tuple<string, int, double>(chunks2[1],
                    Convert.ToInt16(chunks2[0]),
                    Convert.ToDouble(chunks2[2])));
            }

            double total = 0;
            foreach (var item in checkOutValues.Keys) {
                double price = ApplyPromotion(promotion, item, Convert.ToDouble(prices[item]));
                double unit = Convert.ToDouble(checkOutValues[item]);

                total += unit * price;
            }
            return 0;
        }

        private double ApplyPromotion(List<Tuple<string, int, double>> promotion,
            string item, double v) {
            foreach (var tuple in promotion) {
                if (tuple.Item1.Contains(item)) {
                    return tuple.Item3;
                }
            }

            return v;
        }
    }
}
