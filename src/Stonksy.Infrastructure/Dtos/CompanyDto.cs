using Stonksy.Core.Model;

namespace Stonksy.Infrastructure.Dtos
{
    public class CompanyDto
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Market { get; set; }
        
        public Company MapToCompany()
        {
            return new(Symbol, Name, Market);
        }
    }
}