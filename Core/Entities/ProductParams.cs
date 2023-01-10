namespace Core.Entities
{
    public class ProductParams
    {
        private const int MaxPageSize = 50;

        public int PageNumber {get; set;} = 1;

        public int _pageSize = 5;
        
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        // private string? _search;

        // public string? Search 
        // {
        //     get => _search;
        //     set => _search = value?.ToLower();
        // }
    }
}