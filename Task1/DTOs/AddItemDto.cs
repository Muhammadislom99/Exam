using FluentValidation;

namespace Task1.DTOs;

public class AddItemDto
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
}

public class AddItemDtoValidator : AbstractValidator<AddItemDto>
{
    public AddItemDtoValidator()
    {
        RuleFor(o => o.ProductName)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(o => o.Price)
            .Must(price => price >= 0);
    }
}