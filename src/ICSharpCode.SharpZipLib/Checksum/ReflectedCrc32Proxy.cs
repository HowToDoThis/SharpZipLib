namespace ICSharpCode.SharpZipLib.Checksum
{
	internal class ReflectedCrc32Proxy : Crc32ProxyBase
	{
		private readonly uint _poly = 0xEDB88320u;

		protected override uint CalculateCrc(uint crc, byte input, uint[] lookupTable) => lookupTable[(byte)(crc ^ input)] ^ (crc >> 8);

		protected override uint CalculateLookupValue(uint lookupValue) => (lookupValue & 1) == 1 ? _poly ^ (lookupValue >> 1) : (lookupValue >> 1);

		protected override uint InitLookupValue(uint index) => index;
	}
}
