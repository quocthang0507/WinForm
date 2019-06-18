using System;
using System.Windows.Input;

namespace Hook.HookLib
{
	/// <summary>
	/// Transmission info into Keyboard event
	/// </summary>
	public class RawKeyEventArgs : EventArgs
	{
		/// <summary>
		/// VKCode of the key
		/// </summary>
		public int VKCode;

		/// <summary>
		/// WPF Key of the key
		/// </summary>
		public Key Key;

		/// <summary>
		/// Is the hitted key system key
		/// </summary>
		public bool IsSysKey;

		/// <summary>
		/// Create raw keyvent arguments
		/// </summary>
		/// <param name="VKCode"></param>
		/// <param name="isSyskey"></param>
		public RawKeyEventArgs(int VKCode, bool isSyskey)
		{
			this.VKCode = VKCode;
			this.IsSysKey = isSyskey;
			this.Key = KeyInterop.KeyFromVirtualKey(VKCode);
		}
	}
}
