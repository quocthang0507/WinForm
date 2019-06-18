namespace Hook.HookLib
{
	class UsingHookKey
	{
		KeyboardListener keyboardListener;

		public UsingHookKey()
		{
			keyboardListener = new KeyboardListener();
			keyboardListener.KeyDown += keyboardListener_KeyDown;
		}

		private void keyboardListener_KeyDown(object sender, RawKeyEventArgs args)
		{
			switch (args.VKCode)
			{
				case VKCodeConst.A:
					break;
				default:
					break;
			}
		}
	}
}
