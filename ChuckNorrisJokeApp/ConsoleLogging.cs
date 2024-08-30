namespace ChuckNorrisJokeApp;

public class ConsoleLogging
{
    public static void PassMessageToUser(string message, StatusCode statusCode)
    {
        switch (statusCode)
        {
            case StatusCode.Success:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
                break;
            case StatusCode.Failure:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
                break;
            case StatusCode.Information:
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
                Console.ResetColor();
                break;
            default:
                Console.WriteLine(message);
                break;
        }
    }

    public static void SuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    
    public static void FailureMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

public enum StatusCode
{
    Success,
    Failure,
    Information
}