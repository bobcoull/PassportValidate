
namespace PassportValidationWeb
{
    /// <summary>
    /// useful methods 
    /// </summary>
    public static class HelperMethods
    {
        public static string RetunPassFailString(this bool isPassFail)
        {
            return (isPassFail) ? "Pass" : "Fail";
        }
    }
}