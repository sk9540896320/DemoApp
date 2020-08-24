namespace DemoApp.Service.Controllers.Command
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="GroupCommandController" />.
    /// </summary>
    [ApiController]
    [Produces(SupportedContentTypes.Json, SupportedContentTypes.Xml)]
    [ApiExplorerSettings(GroupName = ApiConstants.ApiVersion)]
    [Consumes(SupportedContentTypes.Json, SupportedContentTypes.Xml)]
    [CommandRoute]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class GroupCommandController : ControllerBase
    {
        /// <summary>
        /// Defines the _manager.
        /// </summary>
        private readonly IGroupCommandManager _manager;

        /// <summary>
        /// Defines the _tenantIdProvider.
        /// </summary>
        private readonly ITenantIdProvider _tenantIdProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupCommandController"/> class.
        /// </summary>
        /// <param name="manager">The manager<see cref="IGroupCommandManager"/>.</param>
        /// <param name="tenantIdProvider">The tenantIdProvider<see cref="ITenantIdProvider"/>.</param>
        public GroupCommandController(IGroupCommandManager manager, ITenantIdProvider tenantIdProvider)
        {
            EnsureArg.IsNotNull(manager, nameof(manager));
            EnsureArg.IsNotNull(tenantIdProvider, nameof(tenantIdProvider));

            _manager = manager;
            _tenantIdProvider = tenantIdProvider;
        }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="groups">The groups<see cref="IEnumerable{GroupCreateModel}"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost(nameof(Create))]
        [ProducesResponseType(typeof(ManagerResponse<GroupErrorCode>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ManagerResponse<GroupErrorCode>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([Required] IEnumerable<GroupCreateModel> groups)
        {
            var result = await _manager.CreateAsync(_tenantIdProvider.TenantIds.FirstOrDefault(), groups).ConfigureAwait(false);
            return result.ToStatusCode();
        }

        /// <summary>
        /// The Clone.
        /// </summary>
        /// <param name="group">The group<see cref="GroupCreateDuplicateModel"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost(nameof(Clone))]
        [ProducesResponseType(typeof(ManagerResponse<GroupErrorCode>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ManagerResponse<GroupErrorCode>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Clone([Required] GroupCreateDuplicateModel group)
        {
            var result = await _manager.CloneAsync(_tenantIdProvider.TenantIds.FirstOrDefault(), group).ConfigureAwait(false);
            return result.ToStatusCode();
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <param name="groupUpdateModels">The groupUpdateModels<see cref="IEnumerable{GroupUpdateModel}"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPut(nameof(Update))]
        [ProducesResponseType(typeof(ManagerResponse<GroupErrorCode>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ManagerResponse<GroupErrorCode>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([Required] IEnumerable<GroupUpdateModel> groupUpdateModels)
        {
            var result = await _manager.UpdateAsync(_tenantIdProvider.TenantIds.FirstOrDefault(), groupUpdateModels).ConfigureAwait(false);
            return result.ToStatusCode();
        }

        /// <summary>
        /// The DeleteById.
        /// </summary>
        /// <param name="id">The id<see cref="long"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpDelete(nameof(DeleteById))]
        [ProducesResponseType(typeof(ManagerResponse<GroupErrorCode>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ManagerResponse<GroupErrorCode>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteById([Required] long id)
        {
            var result = await _manager.DeleteByIdAsync(_tenantIdProvider.TenantIds.FirstOrDefault(), id).ConfigureAwait(false);
            return result.ToStatusCode();
        }
    }
}
