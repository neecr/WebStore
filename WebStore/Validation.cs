using FluentValidation;
using WebStore.Models;

namespace WebStore;
public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(category => category.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage("Name of the category is too short.")
            .MaximumLength(30)
            .WithMessage("Name of the category is too long.");
    }
}

public class OrderProductValidator : AbstractValidator<OrderProduct>
{
    public OrderProductValidator()
    {
        RuleFor(op => op.Count)
            .LessThanOrEqualTo(100)
            .WithMessage("Too many products.");
    }
}

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(order => order.Date)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("Can't create an order according to the time entered.");
    }
}

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
            .MinimumLength(3)
            .WithMessage("Name of the product is too short.")
            .MaximumLength(30)
            .WithMessage("Name of the product is too long.");
        RuleFor(product => product.Price)
            .LessThanOrEqualTo(10000)
            .WithMessage("The price is too high.");
    }
}

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Login)
            .MinimumLength(3)
            .WithMessage("Login is too short.")
            .MaximumLength(30)
            .WithMessage("Login is too long.");

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("Password can't be empty.")
            .MinimumLength(8)
            .WithMessage("Password should contains at least 8 characters.")
            .Matches("[A-Z]+")
            .WithMessage("Password should contains at least 1 uppercase letter.")
            .Matches("[a-z]+")
            .WithMessage("Password should contains at least 1 lowercase letter.")
            .Matches("[0-9]+")
            .WithMessage("Password should contain at least one digit.");
    }
}

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Email)
            .EmailAddress()
            .WithMessage("Incorrect E-Mail.");

        RuleFor(customer => customer.FirstName)
            .MinimumLength(3)
            .WithMessage("First name of the customer is too short.")
            .MaximumLength(30)
            .WithMessage("First name of the customer is too long.");

        RuleFor(customer => customer.LastName)
            .MinimumLength(3)
            .WithMessage("Last name of the customer is too short.")
            .MaximumLength(30)
            .WithMessage("Last name of the customer is too long.");
    }
}