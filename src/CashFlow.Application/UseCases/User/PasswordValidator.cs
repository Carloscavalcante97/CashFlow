using CashFlow.Exception;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace CashFlow.Application.UseCases.User
{
    public partial class PasswordValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "PasswordValidator";
        private const string ERROR_MESSAGE_KEY = "ErrorMessage";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return $"{{{ERROR_MESSAGE_KEY}}} - " + errorCode;
        }

        public override bool IsValid(FluentValidation.ValidationContext<T> context, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
                return false;
            }
            if(password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
                return false;
            }
            if(Numbers().IsMatch(password) == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
                return false;
            }
            if (UppercaseLetters().IsMatch(password) == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
                return false;
            }
            if (SpecialCharacter().IsMatch(password) == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
                return false;
            }
            if(LowercaseLetters().IsMatch(password) == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
                return false;
            }
            return true;
        }

        [GeneratedRegex(@"[0-9]+")]
        private static partial Regex Numbers();
        [GeneratedRegex(@"[A-Z]+")]
        private static partial Regex UppercaseLetters();
        [GeneratedRegex(@"[\!\&\*\?]+")]
        private static partial Regex SpecialCharacter();
        [GeneratedRegex(@"[a-z]+")]
        private static partial Regex LowercaseLetters();
    }
}
