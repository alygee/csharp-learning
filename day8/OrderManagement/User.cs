namespace OrderManagement;

internal sealed class User
{
    internal User(Guid id, string firstName, string lastName, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        ValidateEmail(email);

        this.Id = id;
        this.FirstName = firstName.Trim();
        this.LastName = lastName.Trim();
        this.Email = email.Trim();
    }

    internal Guid Id { get; }

    internal string FirstName { get; }

    internal string LastName { get; }

    internal string Email { get; private set; }

    internal string FullName => $"{this.FirstName} {this.LastName}";

    internal void ChangeEmail(string newEmail)
    {
        ValidateEmail(newEmail);
        this.Email = newEmail.Trim();
    }

    public override string ToString()
    {
        return $"{this.FullName} <{this.Email}>";
    }

    private static void ValidateEmail(string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        string normalized = email.Trim();
        if (!normalized.Contains('@') || normalized.StartsWith('@') || normalized.EndsWith('@'))
        {
            throw new ArgumentException("Email должен содержать корректный символ '@'.", nameof(email));
        }
    }
}
