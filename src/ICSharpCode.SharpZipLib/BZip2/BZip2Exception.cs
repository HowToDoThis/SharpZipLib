namespace ICSharpCode.SharpZipLib.BZip2
{
	/// <summary>
	/// BZip2Exception represents exceptions specific to BZip2 classes and code.
	/// </summary>
	public class BZip2Exception : SharpZipBaseException
	{
		/// <summary>
		/// Initialise a new instance of <see cref="BZip2Exception" /> with its message string.
		/// </summary>
		/// <param name="message">A <see cref="string"/> that describes the error.</param>
		public BZip2Exception(string message) : base(message)
		{ }
	}
}
