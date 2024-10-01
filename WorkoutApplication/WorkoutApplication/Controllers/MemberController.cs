using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using WorkoutApplication.Models;

namespace WorkoutApplication.Controllers
{
    public class MemberController : Controller
    {
        public async Task<IActionResult> Index()
        {
            Database db = new Database();
            var members = await db.GetMembersAsync();

            return View(members);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            Database db = new Database();

            await db.SaveMember(member);

            return Redirect("/Member");
        }

        public async Task<IActionResult> Delete(string id)
        {
            Database db = new Database();
            var member = await db.GetMember(id);
            return View(member);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMember(string id)
        {
            Database db = new Database();

            await db.DeleteMember(id);

            return Redirect("/Member");
        }

        public async Task<IActionResult> Show(string id)
        {
            Database db = new Database();
            var member = await db.GetMember(id);
            return View(member);
        }

        [HttpPost]
        public async Task<IActionResult> ShowMember(string id)
        {
            Database db = new Database();

            await db.ShowMember(id);

            return Redirect("/Member");
        }

        public async Task<IActionResult> Edit(string id)
        {
            Database db = new Database();
            var member = await db.GetMember(id);
            return View(member);
        }

        [HttpPost]
        public async Task<IActionResult> EditMember(string id, [FromBody] Member member)
        {
        Database db = new Database();
        
        await db.EditMember(id, member);
        
        return Redirect("/Member");
        }
    }
}
