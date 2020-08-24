namespace DemoApp.Service.Controllers.Query
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="GroupQueryController" />.
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = ApiConstants.ApiVersion)]
    [Produces(SupportedContentTypes.Json, SupportedContentTypes.Xml)]
    [QueryRoute]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class GroupQueryController : Controller
    {
        /// <summary>
        /// Defines the _manager.
        /// </summary>
        private readonly IGroupQueryManager _manager;

        /// <summary>
        /// Defines the _tenantIdProvider.
        /// </summary>
        private readonly ITenantIdProvider _tenantIdProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupQueryController"/> class.
        /// </summary>
        /// <param name="manager">The manager<see cref="IGroupQueryManager"/>.</param>
        /// <param name="tenantIdProvider">The tenantIdProvider<see cref="ITenantIdProvider"/>.</param>
        public GroupQueryController(IGroupQueryManager manager, ITenantIdProvider tenantIdProvider)
        {
            EnsureArg.IsNotNull(manager, nameof(manager));
            EnsureArg.IsNotNull(tenantIdProvider, nameof(tenantIdProvider));

            _manager = manager;
            _tenantIdProvider = tenantIdProvider;
        }

        /// <summary>
        /// The GetAll.
        /// </summary>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(typeof(ManagerResponseTyped<GroupErrorCode, GroupReadModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _manager.GetAllAsync(_tenantIdProvider.TenantIds).ConfigureAwait(false);
            return result.ToStatusCode();
        }

        /// <summary>
        /// The GetById.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpGet(nameof(GetById))]
        [ProducesResponseType(typeof(ManagerResponseTyped<GroupErrorCode, GroupReadModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([Required, FromQuery] long id)
        {
            var result = await _manager.GetByIdAsync(_tenantIdProvider.TenantIds, id).ConfigureAwait(false);
            return result.ToStatusCode();
        }

        /// <summary>
        /// The GetByIds.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpGet(nameof(GetByIds))]
        [ProducesResponseType(typeof(ManagerResponseTyped<GroupErrorCode, GroupReadModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIds([Required, FromQuery] IEnumerable<long> ids)
        {
            var result = await _manager.GetByIdAsync(_tenantIdProvider.TenantIds, ids).ConfigureAwait(false);
            return result.ToStatusCode();
        }

        /// <summary>
        /// The GetContactListing.
        /// </summary>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpGet(nameof(GetGroupListing))]
        [ProducesResponseType(typeof(ManagerResponseTyped<GroupErrorCode, GroupListingReadModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGroupListing()
        {
            var result = await _manager.GetGroupListingAsync(_tenantIdProvider.TenantIds).ConfigureAwait(false);
            return result.ToStatusCode();
        }
    }
}
