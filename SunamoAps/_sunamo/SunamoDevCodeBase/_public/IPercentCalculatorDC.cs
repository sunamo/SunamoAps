namespace SunamoAps._sunamo.SunamoDevCodeBase;

public interface IPercentCalculatorDC
{
    double OverallSum { get; set; }
    double Last { get; set; }
    /// <summary>
    /// Create.
    /// </summary>
    IPercentCalculatorDC Create(double overallSum);
    /// <summary>
    /// Add one percent.
    /// </summary>
    void AddOnePercent();
    /// <summary>
    /// Percent for.
    /// </summary>
    int PercentFor(double value, bool isLast);
    /// <summary>
    /// Reset computed sum.
    /// </summary>
    void ResetComputedSum();
}
