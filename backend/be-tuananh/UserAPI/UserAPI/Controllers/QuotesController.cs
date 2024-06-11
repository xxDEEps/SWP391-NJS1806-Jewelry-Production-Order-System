﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private QuoteServices _context;

        public QuotesController(QuoteServices context)
        {
            _context = context;
        }

        // GET: api/Quotes
        [HttpGet]
        public IActionResult GetQuotes()
        {
            var quoteList = _context.GetQuotes();
            return Ok(quoteList);
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(int id)
        {
            var quote = _context.GetQuote(id);

            if (quote == null)
            {
                return NotFound();
            }

            return quote;
        }

        // PUT: api/Quotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuote(int id, Quote quote)
        {
            if (_context.GetQuotes() == null)
            {
                return NotFound();
            }
            if (_context.GetQuote(id) == null)
            {
                return BadRequest();
            }


            _context.UpdateQuote(id, quote);

            return NoContent();
        }

        // POST: api/Quotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote(Quote quote)
        {
            
            if (_context.GetQuotes() == null)
            {
                return NotFound();
            }
           

            _context.AddQuote(quote);

            return NoContent();
        }

        // DELETE: api/Quotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            var quote = _context.GetQuote(id);
            if (quote == null)
            {
                return NotFound();
            }

            _context.DeleteQuote(id);

            return NoContent();
        }

        //private bool QuoteExists(int id)
        //{
        //    return _context.Quotes.Any(e => e.QuoteId == id);
        //}
    }
}