namespace OrderProcessingApi.Helpers;

public static class NullHelper
{
    public static string ForceString(this string? input)
    {
        return input ?? "";
    }

    public static string ForceStringFromInt(this int input)
    {
        return input == 0 ? "" : input.ToString();
    }
}