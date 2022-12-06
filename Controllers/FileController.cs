using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsefApiOData.Misc;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static PsefApiOData.ApiInfo;

namespace PsefApiOData.Controllers
{
    /// <summary>
    /// Represents a RESTful service of File Management.
    /// </summary>
    [Authorize]
    [ApiVersion(V0_1)]
    public class FileController : ODataController
    {
        /// <summary>
        /// File management REST service.
        /// </summary>
        /// <param name="operation">File operation.</param>
        public FileController(FileOperation operation)
        {
            _operation = operation;
        }

        /// <summary>
        /// Upload user file.
        /// </summary>
        /// <param name="file">User file</param>
        /// <returns>The user file relative path.</returns>
        [HttpPost]
        [ODataRoute(nameof(UploadUserFile))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(string), Status200OK)]
        [ProducesResponseType(typeof(string), Status400BadRequest)]
        public async Task<IActionResult> UploadUserFile(IFormFile file)
        {
            string userId = ApiHelper.GetUserId(HttpContext.User);
            string currentDate = DateTime.Today.ToString(
                "yyyy-MM-dd",
                DateTimeFormatInfo.InvariantInfo);
            string[] pathSegment = { "upload", "user", userId, currentDate };

            return await _operation.UploadFile(
                Url,
                file,
                pathSegment,
                _userPermittedExtensions,
                _maxFileSize);
        }

        /// <summary>
        /// Upload banner image file.
        /// </summary>
        /// <param name="file">Banner image file</param>
        /// <returns>The banner file relative path.</returns>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [HttpPost]
        [ODataRoute(nameof(UploadBanner))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(string), Status200OK)]
        [ProducesResponseType(typeof(string), Status400BadRequest)]
        public async Task<IActionResult> UploadBanner(IFormFile file)
        {
            string[] pathSegment = { "upload", "banner" };
            return await _operation.UploadFile(
                Url,
                file,
                pathSegment,
                _imagePermittedExtensions,
                _maxFileSize);
        }

        /// <summary>
        /// Upload news image file.
        /// </summary>
        /// <param name="file">News image file</param>
        /// <returns>The news file relative path.</returns>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [HttpPost]
        [ODataRoute(nameof(UploadNewsImage))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(string), Status200OK)]
        [ProducesResponseType(typeof(string), Status400BadRequest)]
        public async Task<IActionResult> UploadNewsImage(IFormFile file)
        {
            string[] pathSegment = { "upload", "news" };
            return await _operation.UploadFile(
                Url,
                file,
                pathSegment,
                _imagePermittedExtensions,
                _maxFileSize);
        }

        /// <summary>
        /// Upload unduhan file.
        /// </summary>
        /// <param name="file">Unduhan file</param>
        /// <returns>The unduhan file relative path.</returns>
        [MultiRoleAuthorize(
            ApiRole.Admin,
            ApiRole.SuperAdmin)]
        [HttpPost]
        [ODataRoute(nameof(UploadUnduhan))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(string), Status200OK)]
        [ProducesResponseType(typeof(string), Status400BadRequest)]
        public async Task<IActionResult> UploadUnduhan(IFormFile file)
        {
            string[] pathSegment = { "upload", "unduhan" };
            return await _operation.UploadFile(
                Url,
                file,
                pathSegment,
                _unduhanPermittedExtensions,
                _maxFileSize);
        }

        /// <summary>
        /// Upload unduhan file.
        /// </summary>
        /// <param name="file">Unduhan file</param>
        /// <returns>The unduhan file relative path.</returns>
        [HttpPost]
        [ODataRoute(nameof(UploadLaporan))]
        [Produces(JsonOutput)]
        [ProducesResponseType(typeof(string), Status200OK)]
        [ProducesResponseType(typeof(string), Status400BadRequest)]
        public async Task<IActionResult> UploadLaporan(IFormFile file)
        {
            string userId = ApiHelper.GetUserId(HttpContext.User);
            string currentDate = DateTime.Today.ToString(
                "yyyy-MM-dd",
                DateTimeFormatInfo.InvariantInfo);
            string[] pathSegment = { "upload", "laporan", userId, currentDate };

            return await _operation.UploadFile(
                Url,
                file,
                pathSegment,
                _unduhanPermittedExtensions,
                _maxFileSize);
        }

        private readonly FileOperation _operation;
        private readonly string[] _userPermittedExtensions = { ".pdf" };
        private readonly string[] _unduhanPermittedExtensions = { ".pdf", ".xlsx", ".docx" };
        private readonly string[] _imagePermittedExtensions = { ".gif", ".jpg", ".jpeg", ".png" };
        private const int _maxFileSize = 5300000;
    }
}