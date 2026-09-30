namespace SunamoAps._sunamo.SunamoDevCodeBase;

public interface IProgressBarDC
{
    bool IsRegistered { get; set; }
    int WriteOnlyDividableBy { get; set; }
    /// <summary>
    /// Init.
    /// </summary>
    void Init(IPercentCalculatorDC pc);
    /// <summary>
    /// Init.
    /// </summary>
    void Init(IPercentCalculatorDC pc, bool isNotUt);
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
