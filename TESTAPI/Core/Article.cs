﻿using System.Text.RegularExpressions;

namespace TESTAPI.Core
{
    public class Article
    {
        public int Id { get; set; }

        public string Unit { get; set; } = "";

        public string Image { get; set; } = "";

        public decimal Price { get; set; }

        private string pricePerUnitText = "";
        public string PricePerUnitText
        {
            get { return pricePerUnitText; }
            set {
                pricePerUnitText = value;
                var m = Regex.Match(pricePerUnitText, @"(?:\()(\d*,\d*)(?: €/Liter\))");
                if (!m.Success) PricePerLiter = null;
                PricePerLiter = decimal.TryParse(m.Groups[1].Value, out decimal rez) ? rez : null;
            }
        }

        public decimal? PricePerLiter { get; private set; }

        private string shortDescription = "";
        public string ShortDescription
        {
            get { return shortDescription; }
            set
            {
                shortDescription = value;
                var m = Regex.Match(shortDescription, @"^(\d*) x (\d*,*\d*)(?:L \(Glas\))");
                if (!m.Success) {
                    BottleCount = null;
                    BottleVolume = null;
                }
                BottleCount = int.TryParse(m.Groups[1].Value, out int cnt) ? cnt : null;
                BottleVolume = decimal.TryParse(m.Groups[2].Value, out decimal vlm) ? vlm : null;
            }
        }

        public int? BottleCount { get; private set; }

        public decimal? BottleVolume { get; private set; }

    }
}

