namespace DemoApp.Business.Group.Manager
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="GroupQueryManager" />.
    /// </summary>
    public class GroupQueryManager : TenantIdQueryManager<DemoReadOnlyDbContext, Group, GroupReadModel, GroupErrorCode>, IGroupQueryManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupQueryManager"/> class.........
        /// </summary>
        private readonly IGroupQueryRepository _groupQueryRepository;

        /// <summary>
        /// Defines the _mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupQueryManager"/> class.
        /// </summary>
        /// <param name="groupRepository">The groupRepository<see cref="IGroupQueryRepository"/>.</param>
        /// <param name="logger">The logger<see cref="ILogger{GroupQueryManager}"/>.</param>
        /// <param name="mapper">The mapper<see cref="IMapper"/>.</param>
        public GroupQueryManager(IGroupQueryRepository groupRepository, ILogger<GroupQueryManager> logger, IMapper mapper)
            : base(groupRepository, logger, mapper)
        {
            EnsureArg.IsNotNull(groupRepository, nameof(groupRepository));
            EnsureArg.IsNotNull(logger, nameof(logger));
            EnsureArg.IsNotNull(mapper, nameof(mapper));

            _groupQueryRepository = groupRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// The EntityQueryAsync.
        /// </summary>
        /// <param name="filterCriteria">The filterCriteria<see cref="FilterCriteria{Group}"/>.</param>
        /// <returns>The <see cref="Task{IEnumerable{Group}}"/>.</returns>
        protected override Task<IEnumerable<Group>> EntityQueryAsync(FilterCriteria<Group> filterCriteria)
        {
            IncludeContacts(filterCriteria);
            return base.EntityQueryAsync(filterCriteria);
        }

        /// <summary>
        /// The GetByNamesAsync.
        /// </summary>
        /// <param name="tenantId">The tenantId<see cref="long"/>.</param>
        /// <param name="searchTerm">The searchTerm<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{ManagerResponseTyped{GroupErrorCode, GroupSearchReadModel}}"/>.</returns>
        public async Task<ManagerResponseTyped<GroupErrorCode, GroupSearchReadModel>> GetByNamesAsync(long tenantId, string searchTerm)
        {
            try
            {
                var filterCriteria = new FilterCriteria<Group>()
                {
                    Predicate = filterGroup =>
                        filterGroup.Name.StartsWith(searchTerm) && filterGroup.TenantId == tenantId
                };
                IncludeContacts(filterCriteria);
                var groups = await _groupQueryRepository.FetchByCriteriaAsync(filterCriteria).ConfigureAwait(false);
                return new ManagerResponseTyped<GroupErrorCode, GroupSearchReadModel>(_mapper.Map<IEnumerable<Group>, IEnumerable<GroupSearchReadModel>>(groups));
            }
            catch (Exception exception)
            {
                return new ManagerResponseTyped<GroupErrorCode, GroupSearchReadModel>(exception);
            }
        }

        /// <summary>
        /// The GetGroupListing.
        /// </summary>
        /// <param name="tenantIds">The tenantIds<see cref="IEnumerable{long}"/>.</param>
        /// <returns>The <see cref="Task{ManagerResponseTyped{GroupErrorCode, GroupListing}}"/>.</returns>
        public async Task<ManagerResponseTyped<GroupErrorCode, GroupListingReadModel>> GetGroupListingAsync(IEnumerable<long> tenantIds)
        {
            try
            {
                var response = await _groupQueryRepository.FetchByAsync(group => tenantIds.Contains(group.TenantId), group => new GroupListingReadModel { Name = group.Name, Id = group.Id }).ConfigureAwait(false);
                return new ManagerResponseTyped<GroupErrorCode, GroupListingReadModel>(response);
            }
            catch (Exception exception)
            {
                return new ManagerResponseTyped<GroupErrorCode, GroupListingReadModel>(GroupErrorCode.UnknownError, exception);
            }
        }

        /// <summary>
        /// The IncludeContacts.
        /// </summary>
        /// <param name="filterCriteria">The filterCriteria<see cref="FilterCriteria{Group}"/>.</param>
        private static void IncludeContacts(FilterCriteria<Group> filterCriteria)
        {
            filterCriteria.Includes.Add(group => @group.ContactGroups.Select(contactGroup => contactGroup.Presence));
            filterCriteria.Includes.Add(group => @group.ContactGroups.Select(contactGroup => contactGroup.Contact));
        }
    }
}
