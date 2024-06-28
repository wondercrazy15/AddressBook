using ContactBook.Models;
using ContactBook.Services.Interfaces;
using ContactBook.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ContactController(IContactService contactService,IWebHostEnvironment webHostEnvironment)
        {
            _contactService = contactService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ActionResult> Index(string Search)
        {
            ContactModel model = new ContactModel();
            model.contactsModel = new ContactsModel();
            model.Contacts = await _contactService.GetContactsByFiltersAsync(Search);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> SaveContact(ContactsModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageUrl != null && model.ImageUrl.Contains("data:image/"))
                {
                    
                    byte[] bytes = Convert.FromBase64String(model.ImageUrl.Replace(model.ImageUrl.Substring(0, model.ImageUrl.IndexOf("base64,") + 7), ""));
                    model.ProfileImage = bytes;
                }

                if (model.Id > 0)
                {
                    await _contactService.Update(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    await _contactService.Add(model);
                    return Json(true);
                }
            }
            return PartialView(model);
        }

        [HttpGet]
        public async Task<ActionResult> ContactDetails(int id)
        {
            ContactModel model = new ContactModel();
            model.contactsModel = await _contactService.GetContectsByIdAsync(id);
            return View(model);
        }
    }
}
