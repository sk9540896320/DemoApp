namespace DemoApp.Business.Group.Manager
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Validators;

    /// <summary>
    /// Defines the <see cref="GroupCommandManager" />.
    /// </summary>
    public class GroupCommandManager : TenantIdCommandManager<DemoDbContext, DemoReadOnlyDbContext, GroupErrorCode, Group, GroupCreateModel, GroupUpdateModel>, IGroupCommandManager
    {
        /// <summary>
        /// Defines the _createDuplicateModelValidator.
        /// </summary>
        private readonly GroupCreateDuplicateModelValidator _createDuplicateModelValidator;

        /// <summary>
        /// Defines the _mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Defines the _groupQueryRepository.
        /// </summary>
        private readonly IGroupQueryRepository _groupQueryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupCommandManager"/> class.
        /// </summary>
        /// <param name="createModelValidator">The createModelValidator<see cref="GroupCreateModelValidator"/>.</param>
        /// <param name="updateModelValidator">The updateModelValidator<see cref="GroupUpdateModelValidator"/>.</param>
        /// <param name="createDuplicateModelValidator">The createDuplicateModelValidator<see cref="GroupCreateDuplicateModelValidator"/>.</param>
        /// <param name="logger">The logger<see cref="ILogger{GroupCommandManager}"/>.</param>
        /// <param name="mapper">The mapper<see cref="IMapper"/>.</param>
        /// <param name="groupQueryRepository">The groupQueryRepository<see cref="IGroupQueryRepository"/>.</param>
        /// <param name="groupCommandRepository">The groupCommandRepository<see cref="IGroupCommandRepository"/>.</param>
        public GroupCommandManager(
            GroupCreateModelValidator createModelValidator,
            GroupUpdateModelValidator updateModelValidator,
            GroupCreateDuplicateModelValidator createDuplicateModelValidator,
            ILogger<GroupCommandManager> logger,
            IMapper mapper
            , IGroupQueryRepository groupQueryRepository
            , IGroupCommandRepository groupCommandRepository)
            : base(groupQueryRepository, groupCommandRepository, createModelValidator, updateModelValidator, logger, mapper, GroupErrorCode.IdDoesNotExist, GroupErrorCode.IdNotUnique)
        {
            EnsureArg.IsNotNull(groupCommandRepository, nameof(groupCommandRepository));
            EnsureArg.IsNotNull(groupQueryRepository, nameof(groupQueryRepository));

            _createDuplicateModelValidator = createDuplicateModelValidator;
            _mapper = mapper;
            _groupQueryRepository = groupQueryRepository;
        }

        /// <summary>
        /// The CloneAsync.
        /// </summary>
        /// <param name="tenantId">The tenantId<see cref="long"/>.</param>
        /// <param name="groupCreateDuplicateModel">The groupCreateDuplicateModel<see cref="GroupCreateDuplicateModel"/>.</param>
        /// <returns>The <see cref="Task{ManagerResponse{GroupErrorCode}}"/>.</returns>
        public async Task<ManagerResponse<GroupErrorCode>> CloneAsync(long tenantId, GroupCreateDuplicateModel groupCreateDuplicateModel)
        {
            var errorRecords = new ErrorRecords<GroupErrorCode>();
            var result = await _createDuplicateModelValidator.ValidateAsync(groupCreateDuplicateModel);
            if (!result.IsValid)
                errorRecords.Add(new ErrorRecord<GroupErrorCode>(0, result));

            var group = await CheckIdExists(groupCreateDuplicateModel, errorRecords);

            if (errorRecords.Any())
                return new ManagerResponse<GroupErrorCode>(errorRecords);

            var groupCreateModel = _mapper.Map<Group, GroupCreateModel>(group);
            groupCreateModel.Name = groupCreateDuplicateModel.Name;
            return await CreateAsync(tenantId, groupCreateModel);
        }

        /// <summary>
        /// The CreateValidationAsync.
        /// </summary>
        /// <param name="tenantId">The tenantId<see cref="long"/>.</param>
        /// <param name="indexedModels">The indexedModels<see cref="IList{IIndexedItem{GroupCreateModel}}"/>.</param>
        /// <returns>The <see cref="Task{ErrorRecords{GroupErrorCode}}"/>.</returns>
        protected override async Task<ErrorRecords<GroupErrorCode>> CreateValidationAsync(long tenantId, IList<IIndexedItem<GroupCreateModel>> indexedModels)
        {
            var baseErrorRecords = await base.CreateValidationAsync(tenantId, indexedModels).ConfigureAwait(false);

            var duplicateNameCheck = await UniqueValidationAsync(indexedModels);

            return new ErrorRecords<GroupErrorCode>(baseErrorRecords.Concat(duplicateNameCheck));
        }

        /// <summary>
        /// The UpdateValidationAsync.
        /// </summary>
        /// <param name="tenantId">The tenantId<see cref="long"/>.</param>
        /// <param name="indexedModels">The indexedModels<see cref="IList{IIndexedItem{GroupUpdateModel}}"/>.</param>
        /// <returns>The <see cref="Task{ErrorRecords{GroupErrorCode}}"/>.</returns>
        protected override async Task<ErrorRecords<GroupErrorCode>> UpdateValidationAsync(long tenantId, IList<IIndexedItem<GroupUpdateModel>> indexedModels)
        {
            var baseErrorRecords = await base.UpdateValidationAsync(tenantId, indexedModels).ConfigureAwait(false);
            var duplicateNameCheck = await UniqueWithIdValidationAsync(indexedModels);
            return new ErrorRecords<GroupErrorCode>(baseErrorRecords.Concat(duplicateNameCheck));
        }

        /// <summary>
        /// The DeleteValidationAsync.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="keys">The keys<see cref="IEnumerable{T}"/>.</param>
        /// <param name="entities">The entities<see cref="IEnumerable{Group}"/>.</param>
        /// <returns>The <see cref="Task{ErrorRecords{GroupErrorCode}}"/>.</returns>
        protected override async Task<ErrorRecords<GroupErrorCode>> DeleteValidationAsync<T>(IEnumerable<T> keys, IEnumerable<Group> entities)
        {
            var groups = entities.ToList();
            var baseErrorRecords = await base.DeleteValidationAsync(keys, groups);
            var group = await CheckIdExists(groups.Select(entity => entity.Id));

            if (!(group is null))
                return baseErrorRecords;
            var error = new List<ErrorRecord<GroupErrorCode>> { new ErrorRecord<GroupErrorCode>(GroupErrorCode.IdDoesNotExist, GroupErrorCode.IdDoesNotExist.ToString()) };
            return new ErrorRecords<GroupErrorCode>(baseErrorRecords.Concat(error));
        }

        /// <summary>
        /// The CheckIdExists.
        /// </summary>
        /// <param name="modelWithId">The modelWithId<see cref="IModelWithId"/>.</param>
        /// <param name="errorRecords">The errorRecords<see cref="ErrorRecords{GroupErrorCode}"/>.</param>
        /// <returns>The <see cref="Task{Group}"/>.</returns>
        private async Task<Group> CheckIdExists(IModelWithId modelWithId, ErrorRecords<GroupErrorCode> errorRecords)
        {
            var group = await CheckIdExists(new List<long> { modelWithId.Id });
            if (group is null)
                errorRecords.Add(new ErrorRecord<GroupErrorCode>(GroupErrorCode.IdDoesNotExist,
                    GroupErrorCode.IdDoesNotExist.ToString()));
            return group;
        }

        /// <summary>
        /// The UniqueWithIdValidationAsync.
        /// </summary>
        /// <param name="indexedModels">The indexedModels<see cref="IList{IIndexedItem{GroupUpdateModel}}"/>.</param>
        /// <returns>The <see cref="Task{ErrorRecords{GroupErrorCode}}"/>.</returns>
        private async Task<ErrorRecords<GroupErrorCode>> UniqueWithIdValidationAsync(IList<IIndexedItem<GroupUpdateModel>> indexedModels)
        {
            return await ValidationHelpers.UniqueWithIdValidationAsync(
                async (keys) =>
                {
                    var result = await _groupQueryRepository.FetchByAsync(group => keys.Contains(group.Name), group => new IdKey<string>(group.Id, group.Name)).ConfigureAwait(false);
                    return result.ToList();
                },
                indexedModels,
                item => item.Item.Name,
                GroupErrorCode.NameNotUnique).ConfigureAwait(false);
        }

        /// <summary>
        /// The UniqueValidationAsync.
        /// </summary>
        /// <param name="indexedModels">The indexedModels<see cref="IList{IIndexedItem{GroupCreateModel}}"/>.</param>
        /// <returns>The <see cref="Task{ErrorRecords{GroupErrorCode}}"/>.</returns>
        private async Task<ErrorRecords<GroupErrorCode>> UniqueValidationAsync(IList<IIndexedItem<GroupCreateModel>> indexedModels)
        {
            return await ValidationHelpers.UniqueValidationAsync(
                async (keys) =>
                {
                    var result = await _groupQueryRepository.FetchByAsync(group => keys.Contains(group.Name), group => new IdKey<string>(group.Id, group.Name)).ConfigureAwait(false);
                    return result.ToList();
                },
                indexedModels,
                item => item.Item.Name,
                GroupErrorCode.NameNotUnique).ConfigureAwait(false);
        }
    }
}
