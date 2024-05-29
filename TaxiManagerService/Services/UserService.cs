using TaxiManagerDomain.Constants;
using TaxiManagerDomain.Dtos;
using TaxiManagerDomain.Entities;
using TaxiManagerDomain.Errors;
using TaxiManagerDomain.Mappers;
using TaxiManagerInfrastructure.Interfaces;
using TaxiManagerService.Interfaces;

namespace TaxiManagerService.Services
{
    public class UserService : IUserService
    {
        private readonly IQueries<User> _userQueries;
        private readonly IQueries<Role> _roleQueries;
        private readonly ICommands<User> _userCommands;
        private readonly ISecurityService _securityService;
        private readonly IUserSpecification _specificationUser;

        public UserService(IQueries<User> userQueries, IQueries<Role> roleQueries, ICommands<User> userCommands, ISecurityService securityService, IUserSpecification specificationUser)
        {
            _userQueries = userQueries;
            _roleQueries = roleQueries;
            _userCommands = userCommands;
            _securityService = securityService;
            _specificationUser = specificationUser;
        }

        #region LoginAndRegister
        public async Task<User> FindByEmailAsync(string email)
        {
            var spec = _specificationUser.FindUsersBySpecficications(new UserSpecParamsDto{Email=email});
            var user = _userQueries.GetEntityBySpec(spec) ?? throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Usuario no existe"));
            return await Task.FromResult(user);
        }

        public async Task<AuthenticationDto> LoginAsync(LoginDto loginDto)
        {
            if(string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Email y contrasena son obligatorios"));
            
            var spec = _specificationUser.FindUsersBySpecficications(new UserSpecParamsDto{Email=loginDto.Email});
            var userInDb = _userQueries.GetEntityBySpec(spec) ?? throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Usuario no existe"));

            var hashedPassword = _securityService.Hash(loginDto.Password);

            if(userInDb.Password != hashedPassword)
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Contrasena incorrecta"));

            var response = new AuthenticationDto
            {
                User = userInDb.ToUserDto(),
                AccessToken = _securityService.GenerateJwtToken(userInDb)
            };

            return await Task.FromResult(response);
        }

        public async Task<AuthenticationDto> RegisterAsync(RegisterDto registerDto)
        {
            if (IsRegisterValid(registerDto))
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Todos los campos son obligatorios (Email, Contraseña, Nombre(s), Apellido(s) y Celular)"));

            registerDto.UserTypes.ForEach(u => {
                if(!UserTypes.ListOfUserTypes.Contains(u.ToUpper()))
                    throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Tipo de usuario invalido"));
            }); 

            var rolesInDb = _roleQueries.GetAllEntities();

            if (rolesInDb.Count == 0)
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.NotFoundException, "No hay roles en la base de datos"));
                    
            var rolesForUser = rolesInDb.Where(r => registerDto.UserTypes.Contains(r.Name)).ToList();

            var spec = _specificationUser.FindUsersBySpecficications(new UserSpecParamsDto {Email = registerDto.Email});

            var userInDb = _userQueries.GetEntityBySpec(spec);
            
            if(userInDb != null) 
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Email esta en uso"));

            var hashedPassword = _securityService.Hash(registerDto.Password);

            var newUser = registerDto.ToUser(hashedPassword);
            newUser.Id = Guid.NewGuid();
            newUser.Roles = rolesForUser;

            try
            {
                _userCommands.AddEntity(newUser);

                var authenticationResponse = new AuthenticationDto
                {
                    User = newUser.ToUserDto(),
                    AccessToken = _securityService.GenerateJwtToken(newUser)
                };
                return await Task.FromResult(authenticationResponse);
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            var spec = _specificationUser.FindUserById(id);

            var user = _userQueries.GetEntityBySpec(spec);

            if (user != null)
                return await Task.FromResult(user);

            throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.NotFoundException, "Usuario no existe"));
        }

        #endregion

        #region Drivers
        public Task<List<UserDto>> GetAllDrivers(DriverSpecParamsDto driverSpecParamsDto)
        {
            var spec = _specificationUser.FindDriverBySpecification(driverSpecParamsDto);

            var listOfDrivers = _userQueries.GetEntitiesBySpec(spec);

            if(listOfDrivers.Count == 0)
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.NotFoundException, "No hay conductores registrados"));

            var listOfDriversDto = new List<UserDto>();

            listOfDrivers.ForEach(u => listOfDriversDto.Add(u.ToUserDto()));

            return Task.FromResult(listOfDriversDto);
        }

        public Task<UserDto> GetDriver(DriverSpecParamsDto driverSpecParamsDto)
        {
            var spec = _specificationUser.FindDriverBySpecification(driverSpecParamsDto);

            var driver = _userQueries.GetEntityBySpec(spec);

            if(driver != null)
                return Task.FromResult(driver.ToUserDto());

            throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.NotFoundException, "Driver no existe"));
        }

        #endregion

        #region PrivateMethods
        private static bool IsRegisterValid(RegisterDto registerDto)
        {
            return string.IsNullOrEmpty(registerDto.Email) ||
                            string.IsNullOrEmpty(registerDto.Password) ||
                            string.IsNullOrEmpty(registerDto.FirstName) ||
                            string.IsNullOrEmpty(registerDto.LastName) ||
                            string.IsNullOrEmpty(registerDto.PhoneNumber);
        }

        #endregion
        
    }
}