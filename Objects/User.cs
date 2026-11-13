using System;
using System.io;
using System.Security.Cryptography;


public class User
{

	private int id { get; set; }
	private string fullName { get; set {
        } 
    }
	private string email { get; set; }
	private string password { get; set; }
	private DateTime birthDate { get; set; }
	private int taxId { get; set; }
	private string imageURL { get; set; }
    private List<UserCaracteristics> caracteristics { get; set; }

    public User(int id, string fullName, string email, string password, DateTime birthDate, int taxId, string imageURL, List<UserCaracteristics> caracteristics)
    {
        this.id = id;
        this.fullName = fullName;
        this.email = email;
        this.password = HashPassword(password);
        this.birthDate = birthDate;
        this.taxId = taxId;
        this.imageURL = imageURL;
        this.caracteristics = caracteristics;
        this.caracteristics.Add(UserCaracteristics.isActive);
    }

    public static string HashPassword(string password)
    {
        if (password == null)
        {
            throw new ArgumentNullException(nameof(password));
        }

        const int iterations = 100000;
        byte[] salt = new byte[16];

        using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
        {
            randomNumberGenerator.GetBytes(salt);
        }

        using (Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
        {
            byte[] hash = deriveBytes.GetBytes(32);
            return $"{iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }
    }

    private static T ValidateNotNull<T>(T value, string parameterName)
    {
        if (value is null)
        {
            throw new ArgumentNullException(parameterName);
        }

        return value;
    }








}


