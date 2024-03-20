namespace SalaryCalculator.Salary;

public class Salary(decimal yearly)
{
    private decimal _taxRatePercent = 0m;
    
    public decimal TaxRatePercent
    {
        get => _taxRatePercent;
        set => _taxRatePercent = value > 100 ? 100 : value;
    }

    public decimal Yearly { get; set; } = yearly;
    public decimal YearlyAfterTax => decimal.Round(Yearly * (1 - TaxRatePercent / 100), 2);

    public decimal Monthly
    {
        get => decimal.Round(Yearly / 12, 2) * (1 - TaxRatePercent / 100);
        set => Yearly = value * 12;
    }
    public decimal MonthlyAfterTax => decimal.Round(Monthly * (1 - TaxRatePercent / 100), 2);

    public decimal Weekly
    {
        get => decimal.Round(Yearly / 52, 2) * (1 - TaxRatePercent / 100);
        set => Yearly = value * 52;
    }
    
    public decimal WeeklyAfterTax => decimal.Round(Weekly * (1 - TaxRatePercent / 100), 2);

    public decimal Daily
    {
        get => decimal.Round(Yearly / 260, 2) * (1 - TaxRatePercent / 100);
        set => Yearly = value * 260;
    }
    
    public decimal DailyAfterTax => decimal.Round(Daily * (1 - TaxRatePercent / 100), 2);
    
    public decimal Hourly
    {
        get => decimal.Round(Yearly / 1950, 2) * (1 - TaxRatePercent / 100);
        set => Yearly = value * 1950;
    }
    
    public decimal HourlyAfterTax => decimal.Round(Hourly * (1 - TaxRatePercent / 100), 2);
    
    public decimal ByMinute
    {
        get => decimal.Round(Yearly / 1950 / 60, 2) * (1 - TaxRatePercent / 100);
        set => Yearly = value * 1950 * 60;
    }
    
    public decimal ByMinuteAfterTax => decimal.Round(ByMinute * (1 - TaxRatePercent / 100), 2);
    
    public decimal BySecond
    {
        get => decimal.Round(Yearly / 1950 / 3600, 2) * (1 - TaxRatePercent / 100);
        set => Yearly = value * 1950 * 3600;
    }
    
    public decimal BySecondAfterTax => decimal.Round(BySecond * (1 - TaxRatePercent / 100), 2);
    
    public override string ToString()
    {
        return
            $"""
            Yearly: {Yearly:0.##}
            Monthly: {Monthly:0.##}
            Weekly: {Weekly:0.##}
            Daily: {Daily:0.##}
            Hourly: {Hourly:0.##}
            By minute: {ByMinute:0.##}
            By second: {BySecond:0.##}
            Yearly after tax: {YearlyAfterTax:0.##}
            Monthly after tax: {MonthlyAfterTax:0.##}
            Weekly after tax: {WeeklyAfterTax:0.##}
            Daily after tax: {DailyAfterTax:0.##}
            Hourly after tax: {HourlyAfterTax:0.##}
            By minute after tax: {ByMinuteAfterTax:0.##}
            By second after tax: {BySecondAfterTax:0.##}
            """;
    }
}