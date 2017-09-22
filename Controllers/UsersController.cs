using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DomainModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    public class UsersController : Controller
    {
		private readonly ILogger _logger;
		private readonly IDataAccessProvider _dataAccessProvider;
		public UsersController(IDataAccessProvider dataAccessProvider, ILogger<ValuesController> logger)
		{
			_dataAccessProvider = dataAccessProvider;
			_logger = logger;
		}
		// GET: /<controller>/
		public IActionResult Index()
        {
			_logger.LogInformation("Getting item without id");
			var results = _dataAccessProvider.GetDataEventRecords().FirstOrDefault();
			return View(results);
        }
    }
}
