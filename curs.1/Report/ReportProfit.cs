using Controller;
using Model;

namespace Report
{
    public class ReportProfit
    {
        
        int id;
        string name;
        decimal money;
        

        public ReportProfit(int id, string name, decimal money)
        {
            this.id = id;
            this.name = name;
            this.money = money;
        }

        public override string ToString()
        {
            return id + " || " + name + " || " + money;
        }
    }
}
