using ETicaretAPI.Application.ViewModels.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductViewModel>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Ürün adı boş geçilemez...")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Ürün adı min 5 karakterli olmalı");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Ürün adı boş geçilemez...")
                .Must(s => s > 0)
                    .WithMessage("Ürün stok adeti 0 dan büyük olmalı.");

            RuleFor(p => p.Price)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Ürün adı boş geçilemez...")
                .Must(s => s > 0)
                    .WithMessage("Ürün fiyatı 0 dan büyük olmalı.");
        }           
    }
}
