namespace BlazorBasic.Salary;

public class Salary(decimal yearly)
{
    public decimal Yearly { get; set; } = yearly;

    public decimal Monthly
    {
        get => decimal.Round(Yearly / 12, 2);
        set => Yearly = value * 12;
    }

    public decimal Weekly
    {
        get => decimal.Round(Yearly / 52, 2);
        set => Yearly = value * 52;
    }

    public decimal Daily
    {
        get => decimal.Round(Yearly / 260, 2);
        set => Yearly = value * 260;
    }
    
    public decimal Hourly
    {
        get => decimal.Round(Yearly / 1950, 2);
        set => Yearly = value * 1950;
    }
    
    public decimal ByMinute
    {
        get => decimal.Round(Yearly / 1950 / 60, 2);
        set => Yearly = value * 1950 * 60;
    }
    
    public decimal BySecond
    {
        get => decimal.Round(Yearly / 1950 / 3600, 2);
        set => Yearly = value * 1950 * 3600;
    }
    
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
            """;
    }
}