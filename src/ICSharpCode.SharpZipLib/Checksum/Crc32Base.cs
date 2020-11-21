using System;

namespace ICSharpCode.SharpZipLib.Checksum
{
	/// <summary>
	/// CRC32 Base Class
	/// </summary>
	public abstract class Crc32Base : IChecksum
	{
		#region Instance Fields
		/// <summary>
		/// The CRC data checksum so far.
		/// </summary>
		private uint checkValue;

		#endregion

		#region IChecksum

		/// <summary>
		/// Return CRC data checksum computed so far
		/// </summary>
		/// <remarks>Recersed out = false</remarks>
		public long Value { get { return checkValue; } }

		/// <summary>
		/// Reset CRC data checksum
		/// </summary>
		public void Reset()
		{
			checkValue = 0;
		}

		/// <summary>
		/// Updates the checksum with the int bval.
		/// </summary>
		/// <param name = "bval">
		/// the byte is taken as the lower 8 bits of bval
		/// </param>
		/// <remarks>Reversed Data = true</remarks>
		public void Update(int bval)
		{
			checkValue = Proxy.Append(checkValue, new[] { (byte)bval }, 0, 1);
		}

		/// <summary>
		/// Updates the CRC data checksum with the bytes taken from
		/// a block of data.
		/// </summary>
		/// <param name="buffer">Contains the data to update the CRC with.</param>
		public void Update(byte[] buffer)
		{
			if (buffer == null)
				throw new ArgumentNullException(nameof(buffer));

			Update(new ArraySegment<byte>(buffer, 0, buffer.Length));
		}

		/// <summary>
		/// Update CRC data checksum based on a portion of a block of data
		/// </summary>
		/// <param name = "segment">
		/// The chunk of data to add
		/// </param>
		public void Update(ArraySegment<byte> segment)
		{
			checkValue = Proxy.Append(checkValue, segment.Array, segment.Offset, segment.Count);
		}

		#endregion

		internal abstract Crc32ProxyBase Proxy { get; }

		/// <summary>
		/// Initialise a default instance of <see cref="Crc32"></see>
		/// </summary>
		protected Crc32Base()
		{
			Reset();
		}
	}
}
