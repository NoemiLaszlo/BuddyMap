//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using BuddyMap.DataAccess;
//using BuddyMap.Models;
//using BuddyMap.Models.Database;
//using Microsoft.Extensions.DependencyInjection;

//namespace BuddyMap.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class APIAnswersController : ControllerBase
//    {
//        private readonly Context _context;
//        public IServiceProvider Provider { get; set; }

//        public APIAnswersController(IServiceProvider provider, Context context)
//        {
//            Provider = provider;
//            _context = context;
//        }

//        // GET: api/Answers
//        [HttpGet]
//        public IEnumerable<Answer> GetAnswers()
//        {
//            return _context.Answers;
//        }

//        // GET: api/Answers/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetAnswer([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var answer = await _context.Answers.FindAsync(id);

//            if (answer == null)
//            {
//                return NotFound();
//            }

//            return Ok(answer);
//        }

//        // PUT: api/Answers/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutAnswer([FromRoute] int id, [FromBody] Answer answer)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            //if (id != answer.AnswerId)
//            //{
//            //    return BadRequest();
//            //}

//            _context.Entry(answer).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!AnswerExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Answers
//        [HttpPost]
//        public async Task<IActionResult> PostAnswer([FromBody] Answer answer)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var memdb = Provider.GetService<MemoryDB>();
//            memdb.Answers.Add(answer);

//            //_context.Answers.Add(answer);
//            //await _context.SaveChangesAsync();

//            //return CreatedAtAction("GetAnswer", new { id = answer.AnswerId }, answer);
//            return null;
//        }

//        // DELETE: api/Answers/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAnswer([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var answer = await _context.Answers.FindAsync(id);
//            if (answer == null)
//            {
//                return NotFound();
//            }

//            _context.Answers.Remove(answer);
//            await _context.SaveChangesAsync();

//            return Ok(answer);
//        }

//        //private bool AnswerExists(int id)
//        //{
//        //    return _context.Answers.Any(e => e.AnswerId == id);
//        //}
//    }
//}