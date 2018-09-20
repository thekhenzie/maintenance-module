using System;

namespace Rivington.IG.API
{
    /// <inheritdoc />
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class EnableCorsAttribute : Microsoft.AspNetCore.Cors.EnableCorsAttribute
    {
        // set default CorsName to AppSettings.CorsName
        public EnableCorsAttribute() : base(Domain.CustomCodes.AppSettings.CorsName)
        {
        }

        public EnableCorsAttribute(string policyName)
            : base(policyName)
        {
        }
    }
}
