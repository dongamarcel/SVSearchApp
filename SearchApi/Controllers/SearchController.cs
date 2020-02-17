using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimonsVoss.Infra.Factory;
using SimonsVoss.Infra.Interfaces;

namespace SearchApi.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet("{input}", Name = "Get")]
        public IEnumerable<ISearchResult> Get(string input) => DependencyFactory.Instance.Resolve<ISearchService>().Search(input);

        [HttpGet]
        public IEnumerable<ISearchResult> Get() => null;
    }
}
