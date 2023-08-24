namespace MagicVilla.Common.Helper
{
    public static class SuccessResponseMessageHelper
    {
        public static string CreateSuccessMessage(string action)
        {
            return $"{action} was successful.";
        }
    }
}
