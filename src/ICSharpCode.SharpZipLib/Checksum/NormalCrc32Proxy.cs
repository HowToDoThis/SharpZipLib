namespace ICSharpCode.SharpZipLib.Checksum
{
	internal class NormalCrc32Proxy : Crc32ProxyBase
	{
		private readonly uint _poly = 0x04C11DB7;

		protected override uint CalculateCrc(uint crc, byte input, uint[] lookupTable) => lookupTable[(byte)(((crc >> 24) & 0xFF) ^ input)] ^ (crc << 8);

		protected override uint CalculateLookupValue(uint lookupValue) => (lookupValue & (1L << 31)) > 0 ? _poly ^ (lookupValue << 1) : (lookupValue << 1);

		protected override uint InitLookupValue(uint index) => index << 24;
	}
}
