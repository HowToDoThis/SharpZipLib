namespace ICSharpCode.SharpZipLib.Checksum
{
	/// <summary>
	/// CRC-32 with reversed data and unreversed output
	/// </summary>
	/// <remarks>
	/// Using Force.CRC32 System. Thanks force-net.
	/// </remarks>
	public sealed class Crc32 : Crc32Base
	{
		private static readonly ReflectedCrc32Proxy proxy = new ReflectedCrc32Proxy();
		internal override Crc32ProxyBase Proxy => proxy;

		internal static uint ComputeCrc32(uint oldCrc, byte bval)
		{
			return ~proxy.Append(~oldCrc, new[] { bval }, 0, 1);
		}
	}
}
