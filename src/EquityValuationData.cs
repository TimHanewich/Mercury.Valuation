using System;
using Yahoo.Finance;
using TimHanewich.DataSetManagement;

namespace Mercury.Valuation
{
    public class EquityValuationData
    {
        public float? PriceEarningsRatio {get; set;}
        public float? PriceEarningsGrowthRatio {get; set;} //Need to figure out a way to get this. It is NOT in yahoo finance.
        public float DividendYield {get; set;}
        public float DividendPayoutRatio {get; set;}
        public float? ProfitMargin {get; set;}
        public float? OperatingMargin {get; set;}
        public int AverageVolume {get; set;}
        public float? ReturnOnAssets {get; set;}
        public float? ReturnOnEquity {get; set;}
        public float? PriceSalesRatio {get; set;}
        public float? QuarterlyEarningsGrowth {get; set;}
        public float CashPerShare {get; set;}
        public float? PercentDebt {get; set;}
        public float? CurrentRatio {get; set;}

        public EquityValuationData()
        {

        }

        public EquityValuationData(Equity eq)
        {
            //Error checking
            if (eq.Summary == null || eq.Statistics == null)
            {
                throw new Exception("That equity was not complete. Please pass an equity with both summary and statistics attached.");
            }

            //PE raio
            PriceEarningsRatio = eq.Summary.PriceEarningsRatio;

            //PEG ratio - need to fill it in.
            
            //Dividend yield
            if (eq.Summary.ForwardDividendYield.HasValue)
            {
                DividendYield = eq.Summary.ForwardDividendYield.Value;
            }
            else
            {
                DividendYield = 0;
            }

            //Dividend payout ratio
            DividendPayoutRatio = eq.Statistics.DividendPayoutRatio;

            //Profit margin
            ProfitMargin = eq.Statistics.ProfitMargin;

            //Operating margin
            OperatingMargin = eq.Statistics.OperatingMargin;

            //Avg volume
            AverageVolume = eq.Summary.AverageVolume;

            //Return on assets
            ReturnOnAssets = eq.Statistics.ReturnOnAssets;

            //Return on equity
            ReturnOnEquity = eq.Statistics.ReturnOnEquity;

            //Price sales ratio
            if (eq.Statistics.RevenuePerShare.HasValue)
            {
                PriceSalesRatio = eq.Summary.Price / eq.Statistics.RevenuePerShare.Value;
            }
            else
            {
                PriceSalesRatio = null;
            }
            
            //Quarterly earnings growth
            QuarterlyEarningsGrowth = eq.Statistics.QuarterlyEarningsGrowth;

            //Cash per share
            if (eq.Statistics.TotalCashPerShare.HasValue)
            {
                CashPerShare = eq.Statistics.TotalCashPerShare.Value;
            }
            else
            {
                CashPerShare = 0;
            }
            
            //Percent debt
            if (eq.Statistics.TotalDebtEquityRatio.HasValue)
            {
                PercentDebt = eq.Statistics.TotalDebtEquityRatio.Value / (eq.Statistics.TotalDebtEquityRatio.Value + 1f);
            }
            else
            {
                PercentDebt = null;
            }

            //Current ratio
            CurrentRatio = eq.Statistics.CurrentRatio;


        }

        public DataRecord AsDataRecord()
        {
            DataRecord dr = new DataRecord();

            //PE Ratio
            if (PriceEarningsRatio.HasValue)
            {
                dr.AddAttribute("PriceEarningsRatio", PriceEarningsRatio.Value.ToString());
            }
            else
            {
                dr.AddAttribute("PriceEarningsRatio", "5000"); //Default PE ratio is 5,000 (i.e. if they are not profitable)
            }

            //

            return dr;
        }


    }
}