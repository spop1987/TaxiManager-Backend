namespace TaxiManagerDomain.Dtos
{
    public class UserSpecParamsDto
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string Email { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
    }
}