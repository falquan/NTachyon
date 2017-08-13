namespace NTachyon.Api.Test
{
    public static class CronExpressions
    {
        public static string FiveArguments = "0 12 * */2 Mon";
        public static string SixArguments = "0 0 12 * */2 Mon";
        public static string InvalidExpression = "not a cron expression";
        public static string FiveArgumentsUrlEncoded = "0%2012%20%2A%20%2A%2F2%20Mon";
        public static string SixArgumentsUrlEncoded = "0%200%2012%20%2A%20%2A%2F2%20Mon";
    }
}