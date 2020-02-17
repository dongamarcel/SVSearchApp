using SimonsVoss.Infra.Interfaces;

namespace Services.Configuration
{
    public class DefaultSearchConfiguration : ISearchConfiguration
    {
        public int FactorCompleteMatch => 10;
    }
}
