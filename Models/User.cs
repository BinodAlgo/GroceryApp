
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


public class User
{
  [Key]
  public int UserId { get; set; }

  public string? UserRole { get; set; }

  [Required]
  public string? Username { get; set; }

  [Required]
  public string? Password { get; set; }

  public string? Salt { get; set; }

  public void HashPassword()
  {
    Salt = GenerateSalt();
    Password = HashPasswordWithSalt(Password, Salt);
  }

  public bool CheckPassword(string passwordToCheck)
  {
    return HashPasswordWithSalt(passwordToCheck, Salt) == Password;
  }

  private static string GenerateSalt()
  {
    byte[] randomBytes = new byte[128 / 8];
    using (var generator = RandomNumberGenerator.Create())
    {
      generator.GetBytes(randomBytes);
      return Convert.ToBase64String(randomBytes);
    }
  }

  private static string HashPasswordWithSalt(string password, string salt)
  {
    byte[] hashed = KeyDerivation.Pbkdf2(
        password: password,
        salt: Convert.FromBase64String(salt),
        prf: KeyDerivationPrf.HMACSHA256,
        iterationCount: 10000,
        numBytesRequested: 256 / 8);

    return Convert.ToBase64String(hashed);
  }
}
