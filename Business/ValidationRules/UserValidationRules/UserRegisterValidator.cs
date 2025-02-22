﻿using Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.UserValidationRules
{
    public class UserRegisterValidator : AbstractValidator<RegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez");
            RuleFor(x => x.FirstName).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter girişi yapın");
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri girişi yapın");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Parolalarınız eşleşmiyor");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
        }
    }
}
