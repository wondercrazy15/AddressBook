using ContactBook.Controllers;
using ContactBook.DBL.Models;
using ContactBook.DBL.Utilities;
using ContactBook.Models;
using ContactBook.Services.Interfaces;
using ContactBook.Services.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Contact.UnitTest
{
    [TestClass]
    public class ContackApiTest
    {
        private readonly Mock<IContactService> _contactServiceMock;
        private readonly Mock<IWebHostEnvironment> _webHostEnvironmentMock;
        private readonly ContactController _controller;

        public ContackApiTest()
        {
            _contactServiceMock = new Mock<IContactService>();
            _webHostEnvironmentMock = new Mock<IWebHostEnvironment>();

            _controller = new ContactController(_contactServiceMock.Object, _webHostEnvironmentMock.Object);
        }


        [Fact]
        public async Task Index_ReturnsViewWithContacts()
        {
            // Arrange
            var expectedContacts = new List<ContactsModel>
            {
                new ContactsModel
                {
                    Id = 1,
                    FirstName = "Jonathan",
                    LastName = "Corbett",
                    Company = "Test Company",
                    Phone = "1234567891",
                    Email = "Jonathan@gmail.com",
                    ProfileImage = GenerateImage.GenerateAvatar("Jonathan", "Corbett")
                },
                new ContactsModel
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Deo",
                    Company = "Test Company",
                    Phone = "1234567891",
                    Email = "John@gmail.com",
                    ProfileImage = GenerateImage.GenerateAvatar("John", "Deo")
                }
            };

            _contactServiceMock.Setup(repo => repo.GetContactsByFiltersAsync(It.IsAny<string>())).ReturnsAsync(expectedContacts);

            // Act
            var result = await _controller.Index("searchTerm");

            // Assert
            var viewResult = Xunit.Assert.IsType<ViewResult>(result);
            var model = Xunit.Assert.IsAssignableFrom<ContactModel>(viewResult.ViewData.Model);
            Xunit.Assert.Equal(expectedContacts, model.Contacts);
        }


        [Fact]
        public async Task SaveContact_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var validModel = new ContactsModel
            {
                Id = 1,
                FirstName = "Jonathan",
                LastName = "Corbett",
                Company = "Test Company",
                Phone = "1234567891",
                Email = "Jonathan@gmail.com",
                ProfileImage = GenerateImage.GenerateAvatar("Jonathan", "Corbett")
            };

            // Act
            var result = await _controller.SaveContact(validModel);

            // Assert
            var redirectToActionResult = Xunit.Assert.IsType<RedirectToActionResult>(result);
            Xunit.Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task SaveContact_InvalidModel_ReturnsPartialView()
        {
            // Arrange
            var invalidModel = new ContactsModel();
            _controller.ModelState.AddModelError("FirstName", "FirstName is required.");
            _controller.ModelState.AddModelError("LastName", "LastName is required.");
            _controller.ModelState.AddModelError("Phone", "Phone is required.");

            // Act
            var result = await _controller.SaveContact(invalidModel);

            // Assert
            var partialViewResult = Xunit.Assert.IsType<PartialViewResult>(result);
            Xunit.Assert.Equal(invalidModel, partialViewResult.Model);
        }


        [Fact]
        public async Task ContactDetails_ReturnsViewWithContact()
        {
            // Arrange
            var expectedContact = new ContactsModel
            {
                Id = 1,
                FirstName = "Jonathan",
                LastName = "Corbett",
                Company = "Test Company",
                Phone = "1234567891",
                Email = "Jonathan@gmail.com",
                ProfileImage = GenerateImage.GenerateAvatar("Jonathan", "Corbett")
            };
            _contactServiceMock.Setup(repo => repo.GetContectsByIdAsync(It.IsAny<int>())).ReturnsAsync(expectedContact);

            // Act
            var result = await _controller.ContactDetails(1);

            // Assert
            var viewResult = Xunit.Assert.IsType<ViewResult>(result);
            var model = Xunit.Assert.IsAssignableFrom<ContactModel>(viewResult.ViewData.Model);
            Xunit.Assert.Equal(expectedContact, model.contactsModel);
        }
    }
}
