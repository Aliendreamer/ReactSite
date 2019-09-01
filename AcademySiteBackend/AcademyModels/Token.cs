namespace AcademyModels
{
	public sealed class Token
	{
		public string AccessToken { get; }
		public int ExpiresIn { get; }

		public Token(string token, int expiresIn)
		{
			AccessToken = token;
			ExpiresIn = expiresIn;
		}
	}
}