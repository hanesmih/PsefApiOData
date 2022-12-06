using Microsoft.AspNetCore.Authorization;

namespace PsefApiOData.Misc
{
    /// <summary>
    /// Enum based multi role authorization attribute
    /// </summary>
    public class MultiRoleAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the MultiRoleAuthorizeAttribute.
        /// </summary>
        /// <param name="allowedRoles">List of allowed roles.</param>
        public MultiRoleAuthorizeAttribute(params string[] allowedRoles)
        {
            AllowedRoles = allowedRoles;
            Roles = string.Join(',', allowedRoles);
        }

        /// <summary>
        /// Gets list of roles that are allowed to access the resource.
        /// </summary>
        /// <value>Array of the list of roles.</value>
        public string[] AllowedRoles { get; }
    }
}