using Microsoft.AspNetCore.Mvc;
using WebApplication3.Controllers;
using WebApplication3.Models;

namespace WebApplication3.TestProject;

public class AccountControllerTests
{
    [Fact]
    public void Ctor_CreatesInstance()
    {
        // Arrange & Act
        var controller = new AccountController();

        // Assert
        Assert.NotNull(controller);
    }

    [Fact]
    public void Index_ReturnsViewResult_WithListOfAccounts()
    {
        // Arrange
        var controller = new AccountController();

        // Act
        var result = controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Account>>(viewResult.ViewData.Model);
        Assert.NotNull(model);
        Assert.NotEmpty(model);
        Assert.Equal(3, model.Count()); // Assuming the initial list has 3 accounts
    }

    [Fact]
    public void Details_ReturnsViewResult_WithAccount()
    {
        // Arrange
        var controller = new AccountController();
        int testAccountId = 1;

        // Act
        var result = controller.Details(testAccountId);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<Account>(viewResult.ViewData.Model);
        Assert.NotNull(model);
        Assert.Equal(testAccountId, model.Id);
        Assert.Equal("Tekući račun", model.Name);
        Assert.Equal(1000.00M, model.Total); 
    }

    [Fact]
    public void Create_Post_AddsAccount_AndRedirectsToIndex()
    {
        // Arrange
        var controller = new AccountController();
        var newAccount = new Account { Id = 4, Name = "Novi račun", Total = 2000.00M };
        // Act

        var result = controller.Create(newAccount);

        // Assert
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);

        // Verify the account was added
        var indexResult = controller.Index();
        var viewResult = Assert.IsType<ViewResult>(indexResult);
        var model = Assert.IsAssignableFrom<IEnumerable<Account>>(viewResult.ViewData.Model);
        Assert.Contains(model, a => a.Id == newAccount.Id && a.Name == newAccount.Name && a.Total == newAccount.Total);
    }
}
