using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using motekarteknologi.Data;
using motekarteknologi.Models;

namespace motekarteknologi.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class SendGridsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SendGridsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SendGrids
        [HttpGet]
        public IEnumerable<SendGrid> GetSendGrid()
        {
            return _context.SendGrid;
        }

        // GET: api/SendGrids/GetSendGrid/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSendGrid([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sendGrid = await _context.SendGrid.SingleOrDefaultAsync(m => m.ID == id);

            if (sendGrid == null)
            {
                return NotFound();
            }

            return Ok(sendGrid);
        }

        // PUT: api/SendGrids/PutSendGrid/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSendGrid([FromRoute] string id, [FromBody] SendGrid sendGrid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sendGrid.ID)
            {
                return BadRequest();
            }

            _context.Entry(sendGrid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SendGridExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(200, sendGrid);
        }

        // POST: api/SendGrids
        [HttpPost]
        public async Task<IActionResult> PostSendGrid([FromBody] SendGrid sendGrid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SendGrid.Add(sendGrid);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSendGrid", new { id = sendGrid.ID }, sendGrid);
        }

        // DELETE: api/SendGrids/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSendGrid([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sendGrid = await _context.SendGrid.SingleOrDefaultAsync(m => m.ID == id);
            if (sendGrid == null)
            {
                return NotFound();
            }

            _context.SendGrid.Remove(sendGrid);
            await _context.SaveChangesAsync();

            return Ok(sendGrid);
        }

        private bool SendGridExists(string id)
        {
            return _context.SendGrid.Any(e => e.ID == id);
        }
    }
}