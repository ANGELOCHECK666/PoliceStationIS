using System;

public class RegisterUserModel
{
    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public DateTime BirthDate { get; set; }

    public string PassportSeries { get; set; }

    public string PassportNumber { get; set; }

    public string PhoneNumber { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public int DepartmentId { get; set; }

    public int PostId { get; set; }

    public int RankId { get; set; }

    public int UserRoleId { get; set; }
}