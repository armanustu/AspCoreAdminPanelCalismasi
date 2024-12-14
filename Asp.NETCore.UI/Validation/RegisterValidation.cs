using DataEntityLayer.Concrete;
using FluentValidation;

namespace Asp.NETCore.UI.Validation
{
	public class RegisterValidation:AbstractValidator<Writer>
	{
        public RegisterValidation()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("İsim boş Geçemezsiniz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("en az üç karakter isim girmelisiniz");
            RuleFor(x => x.WriterMail).EmailAddress().NotEmpty();
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("şifre boş geçemezsiniz");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Resim boş geçilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez");
            RuleFor(x => x.RepeatPassword).NotEmpty().WithMessage("Tekrar şifre boş geçilemez");

        }

		
	}
}
