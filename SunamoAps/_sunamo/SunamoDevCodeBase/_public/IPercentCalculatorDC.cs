namespace SunamoAps._sunamo.SunamoDevCodeBase._public;

/// <summary>
/// Represents the i percent calculator DC type.
/// </summary>
public interface IPercentCalculatorDC
{
    /// <summary>
    /// Gets or sets the overall sum.
    /// </summary>
    double OverallSum { get; set; }
    /// <summary>
    /// Gets or sets the last.
    /// </summary>
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