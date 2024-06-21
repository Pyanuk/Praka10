using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Emias_WPF.Models;

namespace Emias_WPF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchDocumentsController : ControllerBase
    {
        private readonly UMIASContext _context;

        public ResearchDocumentsController(UMIASContext context)
        {
            _context = context;
        }

        // GET: api/ResearchDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResearchDocument>>> GetResearchDocuments()
        {
          if (_context.ResearchDocuments == null)
          {
              return NotFound();
          }
            return await _context.ResearchDocuments.ToListAsync();
        }

        // GET: api/ResearchDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResearchDocument>> GetResearchDocument(int? id)
        {
          if (_context.ResearchDocuments == null)
          {
              return NotFound();
          }
            var researchDocument = await _context.ResearchDocuments.FindAsync(id);

            if (researchDocument == null)
            {
                return NotFound();
            }

            return researchDocument;
        }

        // PUT: api/ResearchDocuments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResearchDocument(int? id, ResearchDocument researchDocument)
        {
            if (id != researchDocument.IdAppointment)
            {
                return BadRequest();
            }

            _context.Entry(researchDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchDocumentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ResearchDocuments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResearchDocument>> PostResearchDocument(ResearchDocument researchDocument)
        {
          if (_context.ResearchDocuments == null)
          {
              return Problem("Entity set 'UMIASContext.ResearchDocuments'  is null.");
          }
            _context.ResearchDocuments.Add(researchDocument);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResearchDocumentExists(researchDocument.IdAppointment))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResearchDocument", new { id = researchDocument.IdAppointment }, researchDocument);
        }

        // DELETE: api/ResearchDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResearchDocument(int? id)
        {
            if (_context.ResearchDocuments == null)
            {
                return NotFound();
            }
            var researchDocument = await _context.ResearchDocuments.FindAsync(id);
            if (researchDocument == null)
            {
                return NotFound();
            }

            _context.ResearchDocuments.Remove(researchDocument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResearchDocumentExists(int? id)
        {
            return (_context.ResearchDocuments?.Any(e => e.IdAppointment == id)).GetValueOrDefault();
        }
    }
}
