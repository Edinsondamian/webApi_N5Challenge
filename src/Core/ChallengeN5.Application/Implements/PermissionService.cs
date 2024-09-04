namespace ChallengeN5.Application.Implements;

public class PermissionService : IPermissionService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPermissionTypeRepository _permissionTypeRepository;

    public PermissionService(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPermissionRepository permissionRepository,
        IEmployeeRepository employeeRepository,
        IPermissionTypeRepository permissionTypeRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _permissionRepository = permissionRepository;
        _employeeRepository = employeeRepository;
        _permissionTypeRepository = permissionTypeRepository;
    }

    public async Task<List<PermissionDto>> GetAllPermissions(GetPermissionsDto getPermissionsDto)
    {
        if (!string.IsNullOrEmpty(getPermissionsDto.EmployeeId) && !string.IsNullOrEmpty(getPermissionsDto.PermissionTypeId))
            return _mapper.Map<List<PermissionDto>>(
                await _permissionRepository.GetListAsync(
                    x => x.EmployeeId == getPermissionsDto.EmployeeId &&
                    x.PermissionTypeId == getPermissionsDto.PermissionTypeId));

        if (!string.IsNullOrEmpty(getPermissionsDto.EmployeeId))
            return _mapper.Map<List<PermissionDto>>(
                await _permissionRepository.GetListAsync(x => x.EmployeeId == getPermissionsDto.EmployeeId));

        if (!string.IsNullOrEmpty(getPermissionsDto.PermissionTypeId))
            return _mapper.Map<List<PermissionDto>>(
                await _permissionRepository.GetListAsync(x => x.PermissionTypeId == getPermissionsDto.PermissionTypeId));

        return _mapper.Map<List<PermissionDto>>(await _permissionRepository.GetAllAsync());
    }

    public async Task<PermissionDto> SavePermission(PostPermissionsDto postPermissionsDto)
    {
        var employee = _mapper.Map<EmployeeDto>(await _employeeRepository.GetFirstAsync(x => x.Id == postPermissionsDto.EmployeeId))
            ?? throw new EntityNotFoundException(ExceptionDetailCode.CODE_DP0001);

        var permissionType = _mapper.Map<PermissionTypeDto>(await _permissionTypeRepository.GetFirstAsync(x => x.Id == postPermissionsDto.PermissionTypeId))
            ?? throw new EntityNotFoundException(ExceptionDetailCode.CODE_DP0002);

        PermissionDto permissionDto = new()
        {
            Id = Guid.NewGuid().ToString(),
            EmployeeId = postPermissionsDto.EmployeeId,
            PermissionTypeId = postPermissionsDto.PermissionTypeId,
            Description = postPermissionsDto.Description
        };

        await _permissionRepository.AddAsync(_mapper.Map<Permission>(permissionDto));
        await _unitOfWork.CommitAsync();

        return permissionDto;
    }

    public async Task<PermissionDto> UpdatePermission(string permissionId, PutPermissionsDto putPermissionsDto)
    {
        var permission = _mapper.Map<PermissionDto>(
            await _permissionRepository.GetFirstAsync(x => x.Id == permissionId && x.PermissionTypeId == putPermissionsDto.PermissionTypeId))
            ?? throw new EntityNotFoundException(ExceptionDetailCode.CODE_DP0003);

        permission.PermissionTypeId = putPermissionsDto.PermissionTypeId;
        permission.Description = putPermissionsDto.Description;

        _permissionRepository.Modify(_mapper.Map<Permission>(permission));
        await _unitOfWork.CommitAsync();

        return permission;
    }
}
