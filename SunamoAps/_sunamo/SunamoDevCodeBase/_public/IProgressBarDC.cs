namespace SunamoAps._sunamo.SunamoDevCodeBase._public;

/// <summary>
/// Represents the i progress bar DC type.
/// </summary>
public interface IProgressBarDC
{
    /// <summary>
    /// Gets or sets the is registered.
    /// </summary>
    bool IsRegistered { get; set; }
    /// <summary>
    /// Gets or sets the write only dividable by.
    /// </summary>
    int WriteOnlyDividableBy { get; set; }
    /// <summary>
    /// Init.
    /// </summary>
    void Init(IPercentCalculatorDC percentCalculator);
    /// <summary>
    /// Init.
    /// </summary>
    void Init(IPercentCalculatorDC percentCalculator, bool isNotUt);
    /// <summary>
    /// Done one.
    /// </summary>
    void DoneOne(object asyncResult);
    /// <summary>
    /// Done one.
    /// </summary>
    void DoneOne();
    /// <summary>
    /// Done one.
    /// </summary>
    void DoneOne(int count);
    /// <summary>
    /// Start.
    /// </summary>
    void Start(int totalCount);
    /// <summary>
    /// Done.
    /// </summary>
    void Done();
}