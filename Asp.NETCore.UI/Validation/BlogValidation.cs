using DataEntityLayer.Concrete;
using FluentValidation;

namespace Asp.NETCore.UI.Validation
{
    public class BlogValidation:AbstractValidator<Blog>
    {
        public BlogValidation() {

            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlık boş Geçemezsiniz");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("en az üç karakter isim girmelisiniz");
            RuleFor(x => x.BlogTitle).MaximumLength(50).WithMessage("50 karakterden fazla Başlık Giremezsiniz");
            RuleFor(x => x.WriterID).NotEmpty().WithMessage("Yazar Seçmediniz");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori Seçmediniz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik kısmı boş geçilemez");
            RuleFor(x => x.BlogCreateDate).NotEmpty().WithMessage("Tarih boş geçilemez");
            RuleFor(x => x.BlogStatus).NotEmpty().WithMessage("Durm boş geçilemez");
           

        }
    }
}
