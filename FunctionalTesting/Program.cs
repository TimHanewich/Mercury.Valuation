using System;
using Mercury.Valuation;
using Yahoo.Finance;
using Newtonsoft.Json;
using TimHanewich.DataSetManagement;
using System.Collections.Generic;

namespace FunctionalTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = System.IO.File.ReadAllText("C:\Users\\TaHan\\Downloads\\09102020.json");
            Equity[] equities = JsonConvert.DeserializeObject<Equity[]>(content);

            DataSet ds = new DataSet();
            foreach (Equity e in equities)
            {
                DataRecord dr = new DataRecord();
                dr.
            }
            

        }
    }
}
