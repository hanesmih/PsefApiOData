using Microsoft.AspNetCore.Mvc;

namespace PsefApiOData
{
    internal class ApiInfo
    {
        internal const string CurrentUser = "CurrentUser";
        internal const string DontSetKeyOnPatch = "must not set on patch.";
        internal const string IdRoute = "({id})";
        internal const string JsonOutput = "application/json";
        internal const string SchemeOauth2 = "oauth2";

        internal const string V0_1 = "0.1";
        internal const string V1_0 = "1.0";
        internal const string V1_1 = "1.1";

        internal static readonly ApiVersion Ver0_1 = ApiVersion.Parse(V0_1);
        internal static readonly ApiVersion Ver1_0 = ApiVersion.Parse(V1_0);
        internal static readonly ApiVersion Ver1_1 = ApiVersion.Parse(V1_1);
    }
}