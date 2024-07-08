using System.Security.Cryptography;
using System.Text;

namespace PetClinicDAO
{
	public class DAOUtilities
	{
		private static DAOUtilities? instance;

		public static DAOUtilities Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DAOUtilities();
				}
				return instance;
			}
		}

		// Generates a random salt
		private static string GenerateSalt()
		{
			byte[] salt = new byte[16];
			using (var rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(salt);
			}
			return Convert.ToBase64String(salt);
		}

		// Hashes a password with a salt using SHA-256
		public string HashPassword(string password)
		{
			string salt = GenerateSalt();
			byte[] saltBytes = Convert.FromBase64String(salt);
			byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
			byte[] combinedBytes = new byte[saltBytes.Length + passwordBytes.Length];
			Buffer.BlockCopy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
			Buffer.BlockCopy(passwordBytes, 0, combinedBytes, saltBytes.Length, passwordBytes.Length);

			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] hashBytes = sha256.ComputeHash(combinedBytes);
				return $"{salt}.{Convert.ToBase64String(hashBytes)}";
			}
		}

		// Verifies a password against a hashed value
		public bool VerifyPassword(string password, string hashedPassword)
		{
			var parts = hashedPassword.Split('.');
			if (parts.Length != 2)
			{
				return false;
			}
			string salt = parts[0];
			string hash = parts[1];

			byte[] saltBytes = Convert.FromBase64String(salt);
			byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
			byte[] combinedBytes = new byte[saltBytes.Length + passwordBytes.Length];
			Buffer.BlockCopy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
			Buffer.BlockCopy(passwordBytes, 0, combinedBytes, saltBytes.Length, passwordBytes.Length);

			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] hashBytes = sha256.ComputeHash(combinedBytes);
				return Convert.ToBase64String(hashBytes) == hash;
			}
		}
	}
}
