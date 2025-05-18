namespace Shared.Constants;

public static class Regex
{
    public const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    public const string PhoneNumber = @"^\+?[1-9]\d{1,14}$";
    public const string CreditCardNumber = 	@"^\d{13,19}$";
}