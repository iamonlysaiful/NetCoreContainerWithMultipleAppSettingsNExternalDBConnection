using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreAppWithMultipleAppSettings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DapperDBContext _dbContext;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, DapperDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        [HttpGet]
        public IEnumerable<object> Get()
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_dbContext.Connection))
                {
                    var sql = @"SELECT     
                           *
                           FROM Building
                           Order by id ASC";
                    var data = conn.Query<object>(sql, null, commandTimeout: 1800).ToList();
                    return data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
