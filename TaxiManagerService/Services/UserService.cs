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
        private readonly IQueries<User> _queries;
        private readonly ICommands<User> _commands;
        private readonly ISecurityService _securityService;
        private readonly IUserSpecification _userSpecification;

        public UserService(IQueries<User> queries, ICommands<User> commands, ISecurityService securityService, IUserSpecification userSpecification)
        {
            _queries = queries;
            _commands = commands;
            _securityService = securityService;
            _userSpecification = userSpecification;
        }

        #region LoginAndRegister
        public async Task<User> FindByEmailAsync(string email)
        {
            var user = _queries.FindUserByEmail(email) ?? throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Usuario no existe"));
            return await Task.FromResult(user);
        }

        public async Task<AuthenticationDto> LoginAsync(LoginDto loginDto)
        {
            if(string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Email y contrasena son obligatorios"));
            
            var userInDb = _queries.FindUserByEmail(loginDto.Email) ?? throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Usuario no existe"));

            var hashedPassword = _securityService.Hash(loginDto.Password);

            if(userInDb.Password != hashedPassword)
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Contrasena incorrecta"));

            var response = new AuthenticationDto
            {
                User = userInDb.ToUserDto(),
                AccessToken = _securityService.GenerateJwtToken(userInDb.Id.ToString(), userInDb.Email)
            };

            return await Task.FromResult(response);
        }

        public async Task<AuthenticationDto> RegisterAsync(RegisterDto registerDto)
        {
            if (IsRegisterValid(registerDto))
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Todos los campos son obligatorios (Email, Contraseña, Nombre(s), Apellido(s) y Celular)"));

            if (!UserTypes.ListOfUserTypes.Contains(registerDto.UserType.ToUpper())) 
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Tipo de usuario invalido"));

            var spec = _userSpecification.FindUsersBySpecficications(new UserSpecParamsDto {Email = registerDto.Email});

            var userInDb = _queries.GetEntityBySpec(spec);
            
            if(userInDb != null) 
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.ValidationException, "Email esta en uso"));

            var hashedPassword = _securityService.Hash(registerDto.Password);

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Email = registerDto.Email,
                Password = hashedPassword,
                UserType = registerDto.UserType.ToUpper(),
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Telephone = registerDto.PhoneNumber,
                CreateDate = DateTime.UtcNow
            };

            _commands.AddEntity(newUser);

            var authenticationResponse = new AuthenticationDto
            {
                User = newUser.ToUserDto(),
                AccessToken = _securityService.GenerateJwtToken(newUser.Id.ToString(), newUser.Email)
            };
            return await Task.FromResult(authenticationResponse);
        }

        public async Task<User> FindByIdAsync(Guid id)
        {
            var spec = _userSpecification.FindUserById(id);

            var user = _queries.GetEntityBySpec(spec);

            if (user != null)
                return await Task.FromResult(user);

            throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.NotFoundException, "Usuario no existe"));
        }

        #endregion

        #region Drivers
        public Task<List<UserDto>> GetAllDrivers(DriverSpecParamsDto driverSpecParamsDto)
        {
            var spec = _userSpecification.FindDriverBySpecification(driverSpecParamsDto);

            var listOfDrivers = _queries.GetEntitiesBySpec(spec);

            if(listOfDrivers.Count == 0)
                throw new TaxiManagerException(new TaxiManagerError(ErrorNumber.NotFoundException, "No hay conductores registrados"));

            var listOfDriversDto = new List<UserDto>();

            listOfDrivers.ForEach(u => listOfDriversDto.Add(u.ToUserDto()));

            return Task.FromResult(listOfDriversDto);
        }

        public Task<UserDto> GetDriver(DriverSpecParamsDto driverSpecParamsDto)
        {
            var spec = _userSpecification.FindDriverBySpecification(driverSpecParamsDto);

            var driver = _queries.GetEntityBySpec(spec);

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