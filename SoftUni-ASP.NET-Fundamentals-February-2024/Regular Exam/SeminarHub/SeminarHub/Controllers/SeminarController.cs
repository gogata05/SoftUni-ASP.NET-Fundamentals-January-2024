using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Entities;
using SeminarHub.Models.Category;
using SeminarHub.Models.Seminar;
namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext _data;

        public SeminarController(SeminarHubDbContext data)
        {
            _data = data;
        }

        public async Task<IActionResult> Add()
        {
            SeminarFormModel seminarModel = new SeminarFormModel()
            {
                Categories = GetCategories()
            };

            return View(seminarModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormModel seminarModel)
        {
            if (!GetCategories().Any(e => e.Id == seminarModel.CategoryId))
            {
                ModelState.AddModelError(nameof(seminarModel.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                return View(seminarModel);
            }

            string currentUserId = GetUserId();

            var seminarToAdd = new Seminar()
            {
                OrganizerId = currentUserId,
                Topic = seminarModel.Topic,
                Lecturer = seminarModel.Lecturer,
                Details = seminarModel.Details,
                DateAndTime = seminarModel.DateAndTime,
                Duration = seminarModel.Duration,
                CategoryId = seminarModel.CategoryId,
            };

            await _data.Seminars.AddAsync(seminarToAdd);
            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Seminar");
        }

        public async Task<IActionResult> All()
        {
            var seminarsToDisplay = await _data
                .Seminars
                .Select(e => new SeminarViewModel()
                {
                    Id = e.Id,
                    Topic = e.Topic,
                    Lecturer = e.Lecturer,
                    Organizer = e.Organizer.UserName,
                    DateAndTime = e.DateAndTime.ToString("dd/MM/yyyy H:mm"),
                    Category = e.Category.Name,
                }).ToListAsync();

            return View(seminarsToDisplay);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var seminarToEdit = await _data.Seminars.FindAsync(id);

            if (seminarToEdit == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != seminarToEdit.OrganizerId)
            {
                return Unauthorized();
            }

            SeminarFormModel seminarModel = new SeminarFormModel()
            {
                Categories = GetCategories(),
                Topic = seminarToEdit.Topic,
                Lecturer = seminarToEdit.Lecturer,
                Details = seminarToEdit.Details,
                DateAndTime = seminarToEdit.DateAndTime,
                Duration = seminarToEdit.Duration,
                CategoryId = seminarToEdit.CategoryId,
            };

            return View(seminarModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SeminarFormModel model)
        {
            var seminarToEdit = await _data.Seminars.FindAsync(id);

            if (seminarToEdit == null)
            {
                return BadRequest();
            }

            string currentUser = GetUserId();

            if (currentUser != seminarToEdit.OrganizerId)
            {
                return Unauthorized();
            }

            if (!GetCategories().Any(e => e.Id == model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
            }

            seminarToEdit.Topic = model.Topic;
            seminarToEdit.Lecturer = model.Lecturer;
            seminarToEdit.Details = model.Details;
            seminarToEdit.DateAndTime = model.DateAndTime;
            seminarToEdit.Duration = model.Duration;
            seminarToEdit.CategoryId = model.CategoryId;

            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Seminar");
        }

        public async Task<IActionResult> Details(int id)//"Details" button
        {
            var seminarDetails = await _data
               .Seminars
               .Where(e => e.Id == id)
               .Select(e => new SeminarViewDetailsModel()
               {
                   Id = e.Id,
                   Topic = e.Topic,
                   Lecturer = e.Lecturer,
                   Organizer = e.Organizer.UserName,
                   DateAndTime = e.DateAndTime.ToString("dd/MM/yyyy H:mm"),//?
                   Category = e.Category.Name,
                   Duration = e.Duration,
                   Details = e.Details,
               }).FirstOrDefaultAsync();

            if (seminarDetails == null)
            {
                return BadRequest();
            }

            return View(seminarDetails);
        }

        public async Task<IActionResult> Joined()
        {
            string currentUserId = GetUserId();

            var userSeminars = await _data
                .SeminarParticipants
                .Where(ab => ab.ParticipantId == currentUserId)
                .Select(ab => new SeminarViewModel()
                {
                    Id = ab.Seminar.Id,
                    Topic = ab.Seminar.Topic,
                    Lecturer = ab.Seminar.Lecturer,
                    Organizer = ab.Seminar.Organizer.UserName,
                    DateAndTime = ab.Seminar.DateAndTime.ToString("dd/MM/yyyy H:mm"),
                    Category = ab.Seminar.Category.Name,
                }).ToListAsync();

            return View(userSeminars);
        }

        public async Task<IActionResult> Join(int id)
        {
            var seminarToAdd = await _data
                .Seminars
                .FindAsync(id);

            if (seminarToAdd == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            var entry = new SeminarParticipant()
            {
                SeminarId = seminarToAdd.Id,
                ParticipantId = currentUserId,
            };

            if (await _data.SeminarParticipants.ContainsAsync(entry))
            {
                return RedirectToAction("Joined", "Seminar");
            }

            await _data.SeminarParticipants.AddAsync(entry);
            await _data.SaveChangesAsync();

            return RedirectToAction("Joined", "Seminar");
        }

        public async Task<IActionResult> Leave(int id)
        {
            var seminarId = id;
            var currentUser = GetUserId();
            var seminarToRemove = await _data.Seminars.FindAsync(seminarId);

            if (seminarToRemove == null)
            {
                return BadRequest();
            }

            var entry = await _data.SeminarParticipants
            .FirstOrDefaultAsync(ab => ab.ParticipantId == currentUser
            && ab.SeminarId == seminarId);
            _data.SeminarParticipants.Remove(entry);
            await _data.SaveChangesAsync();

            return RedirectToAction("Joined", "Seminar");//!
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seminar = await _data.Seminars.FindAsync(id);

            if (seminar == null)
            {
                return NotFound();
            }

            _data.Seminars.Remove(seminar);
            await _data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var seminar = await _data.Seminars
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new SeminarDeleteModel
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    DateAndTime = s.DateAndTime.ToString("dd/MM/yyyy HH:mm")
                })
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return NotFound();
            }

            return View(seminar);
        }

        private IEnumerable<CategoryViewModel> GetCategories()//*
            => _data
                .Categories
                .Select(t => new CategoryViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                });
       
        private string GetUserId()
           => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}