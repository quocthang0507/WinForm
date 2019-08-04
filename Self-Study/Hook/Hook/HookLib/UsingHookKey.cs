using System.Linq;
using System.Reflection;

namespace Hook.HookLib
{
	/// <summary>
	/// Raise the Keyboard event
	/// Process when the key pressed
	/// </summary>
	public class UsingHookKey
	{
		private KeyboardListener keyboardListener;

		private int vkcode { get; set; }

		public UsingHookKey()
		{
			keyboardListener = new KeyboardListener();
			keyboardListener.KeyDown += keyboardListener_KeyDown;
		}

		/// <summary>
		/// The main process when the key pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void keyboardListener_KeyDown(object sender, RawKeyEventArgs args)
		{
			//switch (args.VKCode)
			//{
			//	case VKCodeConst.A:
			//		break;
			//	default:
			//		break;
			//}
			this.vkcode = args.VKCode;
			ShowResult();
		}

		/// <summary>
		/// Show the variable name instead of it's value
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private string LookupVariableName(int value)
		{
			var props = typeof(HookLib.VKCodeConst).GetFields(BindingFlags.Public | BindingFlags.Static);
			var wantedprop = props.FirstOrDefault(prop => (int)prop.GetValue(null) == value);
			return wantedprop.Name;
		}

		/// <summary>
		/// Get the variable name and show it on the textbox
		/// </summary>
		private void ShowResult()
		{
			MainWindow.Show(LookupVariableName(vkcode));
		}

	}
}
