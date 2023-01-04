using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using System.Text.Json;
using API.APIModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChallengesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Challenges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChallengeAM>>> GetChallenges()
        {
            if (_context.Challenges == null)
            {
                return NotFound();
            }
            return await _context.Challenges
                .Include(c => c.Options)
                .OrderBy(c => c.OrderInSequence)
                .Select(c=> ToChallengeAM(c))
                //.Select(c=> new ChallengeAM { 
                //    Id = c.Id, 
                //    Name = c.Name, 
                //    Description = c.Description, 
                //    Text = c.Text, 
                //    Question = c.Question, 
                //    OrderInSequence = c.OrderInSequence, 
                //    Options = c.Options.Select(o=> new ChallengeOptionAM { Id = o.Id, Content = o.Content, IsCorrect = o.IsCorrect}).ToList()
                // })
                .ToListAsync();
        }

        private static ChallengeAM ToChallengeAM(Challenge challenge) =>
            new ChallengeAM
            {
                Id = challenge.Id,
                Name = challenge.Name,
                Description = challenge.Description,
                Text = challenge.Text,
                Question = challenge.Question,
                OrderInSequence = challenge.OrderInSequence,
                Options = challenge.Options.Select(o => new ChallengeOptionAM { Id = o.Id, Content = o.Content, IsCorrect = o.IsCorrect }).ToList()
            };


        // GET: api/Challenges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Challenge>> GetChallenge(int id)
        {
            if (_context.Challenges == null)
            {
                return NotFound();
            }
            var challenge = await _context.Challenges.FindAsync(id);

            if (challenge == null)
            {
                return NotFound();
            }

            return challenge;
        }

        // PUT: api/Challenges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChallenge(int id, ChallengeAM challenge)
        {
            if (id != challenge.Id)
            {
                return BadRequest();
            }

            var savedChallenge = await _context.Challenges.Include(c => c.Options).FirstOrDefaultAsync(c => c.Id == id);

            savedChallenge.OrderInSequence = challenge.OrderInSequence;
            savedChallenge.Name= challenge.Name;
            savedChallenge.Text= challenge.Text;
            savedChallenge.Description= challenge.Description;
            savedChallenge.Question= challenge.Question;

            savedChallenge.Options.Clear();
            savedChallenge.Options = challenge.Options.Select(o => new ChallengeOption { Content = o.Content, IsCorrect = o.IsCorrect }).ToList();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChallengeExists(id))
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

        // POST: api/Challenges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Challenge>> PostChallenge(Challenge challenge)
        {
            if (_context.Challenges == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Challenges'  is null.");
                
            }
            var options = challenge.Options.Select(o => new ChallengeOption { Content = o.Content, IsCorrect = o.IsCorrect }).ToList();

            challenge.Options.Clear();
            challenge.Options.AddRange(options);

            _context.Challenges.Add(challenge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChallenge", new { id = challenge.Id }, challenge);
        }

        // DELETE: api/Challenges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChallenge(int id)
        {
            if (_context.Challenges == null)
            {
                return NotFound();
            }
            var challenge = await _context.Challenges.Include(c => c.Options).FirstOrDefaultAsync(c => c.Id == id);
            
            if (challenge == null)
            {
                return NotFound();
            }

           
           // _context.RemoveRange(challenge.Options);
            _context.Challenges.Remove(challenge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChallengeExists(int id)
        {
            return (_context.Challenges?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
