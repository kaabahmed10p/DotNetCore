using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DomainModel;
using DomainModel.Model;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly ILogger _logger;
		private readonly IDataAccessProvider _dataAccessProvider;
		
		public ValuesController(IDataAccessProvider dataAccessProvider, ILogger<ValuesController> logger)
		{
			_dataAccessProvider = dataAccessProvider;
			_logger = logger;
		}

        // GET api/values
        [HttpGet]
		public IEnumerable<DataEventRecord> Get()
		{
             _logger.LogInformation( "Getting item without id");
			return _dataAccessProvider.GetDataEventRecords();
		}

        // GET api/values/5
        [HttpGet("{id}")]
        public DataEventRecord Get(int id)
        {
             _logger.LogWarning( "Getting item with id - {0}", id);
			return _dataAccessProvider.GetDataEventRecord(id);
		}
		
		// POST api/values
		[HttpPost]
        public void Post([FromBody]DataEventRecord value)
        {
			_dataAccessProvider.AddDataEventRecord(value);
		}

		[HttpPut("{id}")]
		public void Put(long id, [FromBody]DataEventRecord value)
		{
			_dataAccessProvider.UpdateDataEventRecord(id, value);
		}

		[HttpDelete("{id}")]
		public void Delete(long id)
		{
			_dataAccessProvider.DeleteDataEventRecord(id);
		}
	}
}
