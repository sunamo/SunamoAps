namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal class ThisApp
{

    /// <summary>
    /// Success.
    /// </summary>
    internal static void Success(string message, params string[] args)
    {
        SetStatus(TypeOfMessageShared.Success, message, args);
    }

    /// <summary>
    /// Info.
    /// </summary>
    internal static void Info(string message, params string[] args)
    {
        SetStatus(TypeOfMessageShared.Information, message, args);
    }

    /// <summary>
    /// Error.
    /// </summary>
    internal static void Error(string message, params string[] args)
    {
        SetStatus(TypeOfMessageShared.Error, message, args);
    }

    /// <summary>
    /// Appeal.
    /// </summary>
    internal static void Appeal(string message, params string[] args)
    {
        SetStatus(TypeOfMessageShared.Appeal, message, args);
    }

    /// <summary>
    /// Set status.
    /// </summary>
    internal static void SetStatus(TypeOfMessageShared messageType, string status, params string[] args)
    {
        var formattedMessage = string.Format(status, args);
        if (formattedMessage.Trim() != string.Empty)
        {
            if (StatusSetted == null)
            {
                // For unit tests - no handler attached
            }
            else
            {
                StatusSetted(messageType, formattedMessage);
            }
        }
    }

    internal static event Action<TypeOfMessageShared, string>? StatusSetted;
}
