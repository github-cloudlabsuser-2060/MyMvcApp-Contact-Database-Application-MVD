using Xunit;
using MyMvcApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult_WithListOfUsers()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Index(null);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IEnumerable<User>>(viewResult.Model);
        }

        [Fact]
        public void Details_ReturnsViewResult_WithUser()
        {
            // Arrange
            var controller = new UserController();
            int testUserId = 1;

            // Act
            var result = controller.Details(testUserId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<User>(viewResult.Model);
        }

        [Fact]
        public void Create_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "Test User" };

            // Act
            var result = controller.Create(user);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }

        [Fact]
        public void Edit_Get_ReturnsViewResult_WithUser()
        {
            // Arrange
            var controller = new UserController();
            int testUserId = 1;

            // Act
            var result = controller.Edit(testUserId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<User>(viewResult.Model);
        }

        [Fact]
        public void Edit_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "Updated User" };

            // Act
            var result = controller.Edit(user.Id, user);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }

        [Fact]
        public void Index_WithSearchString_FiltersUsers()
        {
            // Arrange
            UserController.userlist.Clear();
            UserController.userlist.Add(new User { Id = 1, Name = "Alice", Email = "alice@example.com" });
            UserController.userlist.Add(new User { Id = 2, Name = "Bob", Email = "bob@example.com" });
            var controller = new UserController();

            // Act
            var result = controller.Index("Alice") as ViewResult;
            var model = result?.Model as IEnumerable<User>;

            // Assert
            Assert.Single(model);
            Assert.Equal("Alice", model.First().Name);
        }

    }
}