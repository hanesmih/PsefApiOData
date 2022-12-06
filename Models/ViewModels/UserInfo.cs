namespace PsefApiOData.Models
{
    /// <summary>
    /// Represents a User information.
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Gets or sets the unique identifier for the User.
        /// </summary>
        /// <value>The User's unique identifier.</value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the User name.
        /// </summary>
        /// <value>The User's name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the User email.
        /// </summary>
        /// <value>The User's email.</value>
        public string Email { get; set; }
    }
}