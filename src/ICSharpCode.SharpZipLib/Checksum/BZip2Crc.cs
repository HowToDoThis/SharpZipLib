namespace ICSharpCode.SharpZipLib.Checksum
{
	/// <summary>
	/// CRC-32 with unreversed data and reversed output
	/// </summary>
	/// <remarks>
	/// Using Force.CRC32 System. Thanks force-net.
	/// </remarks>
	public sealed class BZip2Crc : Crc32Base
	{
		private static readonly NormalCrc32Proxy proxy = new NormalCrc32Proxy();
		internal override Crc32ProxyBase Proxy => proxy;

		internal static uint ComputeCrc32(uint oldCrc, byte bval)
		{
			return ~proxy.Append(~oldCrc, new[] { bval }, 0, 1);
		}
	}
}
