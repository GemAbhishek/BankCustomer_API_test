using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRepositoryDemo.Model;
using BookRepositoryDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookRepositoryDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        readonly log4net.ILog _log4net;

        ISellRepo iSell;

        public SellController(ISellRepo _db)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(SellController));

            iSell = _db;
        }

        [HttpPut("{id}/{qty}")]
        public IActionResult Put(int id, int qty)
        {
            _log4net.Info("PUT Request --- Sell update for id --"+id);

            int isDone = iSell.Update(id, qty);
            if (isDone == 1)
            {
                return Ok("Updated");
            }
            return NotFound("Error --Record Id Invalid");
        }
    }
}
