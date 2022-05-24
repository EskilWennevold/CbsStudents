using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CbsStudents.Data;
using System.Security.Claims;


namespace cbsStudents.Controllers
{
    [Authorize]
    public class EventCommentController : Controller
    {
        private readonly CbsStudentsContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public EventCommentController(RoleManager<IdentityRole> roleManager,CbsStudentsContext context, UserManager<IdentityUser> userManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
            this._context = context;

        }

        // GET: EventComment
        public async Task<IActionResult> Index()
        {
            var cbsStudentsContext = _context.EventComment.Include(e => e.Event).Include(e => e.User);
            return View(await cbsStudentsContext.ToListAsync());
        }

        [AllowAnonymous]
        // GET: EventComment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventComment = await _context.EventComment
                .Include(e => e.Event)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EventCommentId == id);
            if (eventComment == null)
            {
                return NotFound();
            }

            return View(eventComment);
        }

        // GET: EventComment/Create
        
        public IActionResult Create(int id)
        {
            
            ViewBag.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.EventId = id;

            return View();
        }

        // POST: EventComment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventCommentId,Text,EventId,UserId")] EventComment eventComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventComment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Event");            
            }
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventId", eventComment.EventId);
            ViewData["UserId"] = new SelectList(_context.IdentityUserClaim, "Id", "Id", eventComment.UserId);
            return RedirectToAction("Index","Event"); 
        }

        // GET: EventComment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventComment = await _context.EventComment.FindAsync(id);
            if (eventComment == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventId", eventComment.EventId);
            ViewData["UserId"] = new SelectList(_context.IdentityUserClaim, "Id", "Id", eventComment.UserId);
            return View(eventComment);
        }

        // POST: EventComment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventCommentId,Text,EventId,UserId")] EventComment eventComment)
        {
            if (id != eventComment.EventCommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventCommentExists(eventComment.EventCommentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","Event");
            }
            ViewData["EventId"] = new SelectList(_context.Event, "EventId", "EventId", eventComment.EventId);
            ViewData["UserId"] = new SelectList(_context.IdentityUserClaim, "Id", "Id", eventComment.UserId);
            return View(eventComment);
        }

        // GET: EventComment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventComment = await _context.EventComment
                .Include(e => e.Event)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EventCommentId == id);
            if (eventComment == null)
            {
                return NotFound();
            }

            return View(eventComment);
        }

        // POST: EventComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventComment = await _context.EventComment.FindAsync(id);
            _context.EventComment.Remove(eventComment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Event");
        }

        private bool EventCommentExists(int id)
        {
            return _context.EventComment.Any(e => e.EventCommentId == id);
        }
    }
}
