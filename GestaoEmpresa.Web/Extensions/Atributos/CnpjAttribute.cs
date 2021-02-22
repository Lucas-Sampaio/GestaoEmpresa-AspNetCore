using GestaoEmpresa.Dominio;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresa.Web.Extensions.Atributos
{
    public class CnpjAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return Cnpj.Validar(value.ToString()) ? ValidationResult.Success : new ValidationResult("CNPJ em formato inválido");
        }

        //classe para usar a validacao no frontend
        public class CnpjAttributeAdapter : AttributeAdapterBase<CnpjAttribute>
        {
            public CnpjAttributeAdapter(CnpjAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
            {
            }

            public override void AddValidation(ClientModelValidationContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }
                MergeAttribute(context.Attributes, "data-val", "true");
                MergeAttribute(context.Attributes, "data-val-cnpj", GetErrorMessage(context));
            }

            public override string GetErrorMessage(ModelValidationContextBase validationContext)
            {
                return "CNPJ em formato inválido";
            }
        }
        public class CnpjValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
        {
            private readonly IValidationAttributeAdapterProvider _baseProvider = new ValidationAttributeAdapterProvider();
            public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
            {
                if (attribute is CnpjAttribute cnpjAttribute)
                {
                    return new CnpjAttributeAdapter(cnpjAttribute, stringLocalizer);
                }
                return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
            }
        }
    }
}
