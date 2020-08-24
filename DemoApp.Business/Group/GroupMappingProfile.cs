namespace DemoApp.Business.Group
{
    using Models;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="GroupMappingProfile" />.
    /// </summary>
    public class GroupMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMappingProfile"/> class.
        /// </summary>
        public GroupMappingProfile()
        {
            CreateMap<Group, GroupReadModel>()
                .ForMember(groupReadModel => groupReadModel.MemberCount, memberConfigurationExpression => memberConfigurationExpression.MapFrom(group => group.ContactGroups.Count(contactGroup => contactGroup.Contact.IsActive)))
                .ForMember(groupReadModel => groupReadModel.ContactGroupCreateModels, memberConfigurationExpression => memberConfigurationExpression.Ignore());

            CreateMap<ContactGroup, ContactGroupCreateModel>();

            CreateMap<GroupCreateModel, Group>()
                .ForMember(group => group.Id, memberConfigurationExpression => memberConfigurationExpression.Ignore())
                .ForMember(group => group.DateCreated, memberConfigurationExpression => memberConfigurationExpression.Ignore())
                .ForMember(group => group.DateModified, memberConfigurationExpression => memberConfigurationExpression.Ignore())
                .ForMember(group => group.TenantId, memberConfigurationExpression => memberConfigurationExpression.Ignore())
                .ForMember(group => group.ContactGroups, memberConfigurationExpression => memberConfigurationExpression.MapFrom(groupCreateModel => groupCreateModel.ContactGroupCreateModels));

            CreateMap<GroupUpdateModel, Group>()
                .ForMember(group => group.TenantId, memberConfigurationExpression => memberConfigurationExpression.Ignore())
                .ForMember(group => group.DateCreated, memberConfigurationExpression => memberConfigurationExpression.Ignore())
                .ForMember(group => group.DateModified, memberConfigurationExpression => memberConfigurationExpression.Ignore())
                .ForMember(group => group.ContactGroups, memberConfigurationExpression => memberConfigurationExpression.Ignore());

            CreateMap<Group, GroupCreateModel>()
                .ForMember(groupCreateModel => groupCreateModel.Name, memberConfigurationExpression => memberConfigurationExpression.Ignore())
                .ForMember(groupCreateModel => groupCreateModel.ContactGroupCreateModels, memberConfigurationExpression => memberConfigurationExpression.MapFrom(group => group.ContactGroups));

            CreateMap<Group, GroupSearchReadModel>()
                .ForMember(groupSearchReadModel => groupSearchReadModel.ContactGroups,
                    memberConfigurationExpression => memberConfigurationExpression.MapFrom(group => group.ContactGroups.Where(contactGroup => contactGroup.Contact.IsActive)));
        }
    }
}
