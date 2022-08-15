using DropBoxApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using File = DropBoxApp.Models.File;

namespace DropBoxApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileContext _context;

        public FileController(FileContext context)
        {
            _context = context;
        }
        #region
        // GET: api/Files
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<File>>> GetFiles()
        {
          if (_context.Files == null)
          {
              return NotFound();
          }
            return await _context.Files.ToListAsync();
        }*/
        #endregion

        // GET: api/Files/5
        [HttpGet("{id}")]
        public async Task<ActionResult<File>> GetFile(long id)
        {
            if (_context.Files == null)
            {
                return NotFound();
            }
            var file = await _context.Files.FindAsync(id);

            if (file == null)
            {
                return NotFound();
            }

            return file;
        }

        #region
        /*// PUT: api/Files/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutFile(File file)
        {
            _context.Entry(file).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }*/
        #endregion


        // POST: api/Files
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<File>> PostFile(File file)
        {
          if (_context.Files == null)
          {
              return Problem("Entity set 'FileContext.Files'  is null.");
          }
            _context.Files.Add(file);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetFile", new { id = file.Id }, file);
            return CreatedAtAction(nameof(GetFile), new { id = file.Id }, file);
        }

        #region
        // DELETE: api/Files/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(long id)
        {
            if (_context.Files == null)
            {
                return NotFound();
            }
            var file = await _context.Files.FindAsync(id);
            if (file == null)
            {
                return NotFound();
            }

            _context.Files.Remove(file);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool FileExists(long id)
        {
            return (_context.Files?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion
    }
}