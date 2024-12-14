using DataEntityLayer.Concrete;
using FluentValidation;

namespace Asp.NETCore.UI.Validation
{
    public class CategoriValidation:AbstractValidator<Category>
    {
        public CategoriValidation()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(c => c.CategoryDescription).NotEmpty().WithMessage("Kategori açıklama boş geçilemez");
            RuleFor(c => c.CategoryStatus).NotEmpty().WithMessage("Durum seçmediniz");
        }
    }
}
