namespace Hook.HookLib
{
	/// <summary>
	/// The following constant shows the symbolic constant names, hexadecimal/ decimal values, and mouse or keyboard equivalents for the virtual-key codes used by the system.
	/// The codes are listed in numeric order.
	/// References at https://docs.microsoft.com/en-us/windows/desktop/inputdev/virtual-key-codes
	/// </summary>
	public static class VKCodeConst
	{
		public const int LEFT_MOUSE = 1; //Left mouse button
		public const int RIGHT_MOUSE = 2; //Right mouse button
		public const int CANCEL = 3; //CANCEL key
		public const int MMOUSE = 4; //Middle mouse button
		public const int X1_MOUSE = 5; //X1 mouse button
		public const int X2_MOUSE = 6; //X2 mouse button
									   //... Undefined at 0x07
		public const int BACKSPACE = 8; //BACKSPACE key
		public const int TAB = 9; //TAB key
								  //... Reserved from 0x0A to 0x0B
		public const int CLEAR = 12; //CLEAR key
		public const int ENTER = 13; //ENTER key
									 //... Undefined from 0x0E to 0x0F
		public const int SHIFT = 16; //SHIFT key
		public const int CONTROL = 17; //CTRL key
		public const int ALT = 18; //ALT key
		public const int PAUSE = 19; //PAUSE key
		public const int CAPS = 20; //CAPS LOCK key
									//... IME Kana Mode/ IME Hanguel mode/ IME Hangul Mode at 0x15
									//... Undefined at 0x16
									//... IME Junja mode at 0x17
									//... IME final mode at 0x18
									//... IME Hanja Mode/ IME Kanji Mode at 0x19
									//... Undefined at 0x1A
		public const int ESC = 27; //ESC key
								   //... IME Convert at 0x1C
								   //... IME nonconvert at 0x1D
								   //... IME accept at 0x1E
								   //... IME mode change request at 0x1F
		public const int SPACE = 32; //SPACEBAR key
		public const int PAGE_UP = 33; //PAGE UP key
		public const int PAGE_DOWN = 34; //PAGE DOWN key
		public const int END = 35; //END key
		public const int HOME = 36; //HOME key
		public const int LEFT = 37; //LEFT ARROW key
		public const int UP = 38; // ARROW key Up
		public const int RIGHT = 39; //RIGHT ARROW key
		public const int DOWN = 40; //DOWN ARROW key
		public const int SELECT = 41; //SELECT key
		public const int PRINT = 42; //PRINT SCREEN key
		public const int EXECUTE = 43; //EXECUTE key
		public const int SNAPSHOT = 44; //SNAPSHOT key
		public const int INSERT = 45; //INS key
		public const int DELETE = 46; //DEL key
		public const int HELP = 47; //HELP key
		public const int NUM0 = 48;
		public const int NUM1 = 49;
		public const int NUM2 = 50;
		public const int NUM3 = 51;
		public const int NUM4 = 52;
		public const int NUM5 = 53;
		public const int NUM6 = 54;
		public const int NUM7 = 55;
		public const int NUM8 = 56;
		public const int NUM9 = 57;
		//... Undefined from 0x3A to 0x40
		public const int A = 65;
		public const int B = 66;
		public const int C = 67;
		public const int D = 68;
		public const int E = 69;
		public const int F = 70;
		public const int G = 71;
		public const int H = 72;
		public const int I = 73;
		public const int J = 74;
		public const int K = 75;
		public const int L = 76;
		public const int M = 77;
		public const int N = 78;
		public const int O = 79;
		public const int P = 80;
		public const int Q = 81;
		public const int R = 82;
		public const int S = 83;
		public const int T = 84;
		public const int U = 85;
		public const int V = 86;
		public const int W = 87;
		public const int X = 88;
		public const int Y = 89;
		public const int Z = 90;
		public const int LEFT_WINDOWS = 91; //Left Windows key (Natural keyboard)
		public const int RIGHT_WINDOWS = 92; //Right Windows key (Natural keyboard)
		public const int APP = 93; //Applications key (Natural keyboard)
								   //... Reserved at 0x5E
		public const int SLEEP = 95; //Computer Sleep key
		public const int NUMPAD_0 = 96;
		public const int NUMPAD_1 = 97;
		public const int NUMPAD_2 = 98;
		public const int NUMPAD_3 = 99;
		public const int NUMPAD_4 = 100;
		public const int NUMPAD_5 = 101;
		public const int NUMPAD_6 = 102;
		public const int NUMPAD_7 = 103;
		public const int NUMPAD_8 = 104;
		public const int NUMPAD_9 = 105;
		public const int MULTIPLY = 106; //Multiply key
		public const int ADD = 107; //Add key
		public const int SEPARATOR = 108; //Separator key
		public const int SUBTRACT = 109; //Subtract key
		public const int DECIMAL = 110; //Decimal key
		public const int DIVIDE = 111; //Devide key
		public const int F1 = 112;
		public const int F2 = 113;
		public const int F3 = 114;
		public const int F4 = 115;
		public const int F5 = 116;
		public const int F6 = 117;
		public const int F7 = 118;
		public const int F8 = 119;
		public const int F9 = 120;
		public const int F10 = 121;
		public const int F11 = 122;
		public const int F12 = 123;
		public const int F13 = 124;
		public const int F14 = 125;
		public const int F15 = 126;
		public const int F16 = 127;
		public const int F17 = 128;
		public const int F18 = 129;
		public const int F19 = 130;
		public const int F20 = 131;
		public const int F21 = 132;
		public const int F22 = 133;
		public const int F23 = 134;
		public const int F24 = 135;
		//... Unsigned from 0x88 to 0x8F
		public const int NUMLOCK = 144; //NUM LOCK key 
		public const int SCROLL = 145; //SCROLL LOCK key
									   //... OEM specific from 0x92 to 0x96
									   //... Unassigned from 0x97 to 0x9F
		public const int LEFT_SHIFT = 160; //Left SHIFT key
		public const int RIGHT_SHIFT = 161; //Right SHIFT key
		public const int LEFT_CTRL = 162; //Left CONTROL key
		public const int RIGHT_CTRL = 163; //Right CONTROL key
		public const int LEFT_MENU = 164; //Left MENU key
		public const int RIGHT_MENU = 165; //Right MENU key
		public const int BROWSER_BACK = 166; //Browser Back key
		public const int BROWSER_FORWARD = 167; //Browser Forward key
		public const int BROWSER_REFRESH = 168; //Browser Refresh key
		public const int BROWSER_STOP = 169; //Browser Stop key
		public const int BROWSER_SEARCH = 170; //Browser Search key
		public const int BROWSER_FAV = 171; //Browser Favorites key
		public const int BROWSER_HOME = 172; //Browser Start and Home key
		public const int VOLUME_MUTE = 173; //Volume Mute key
		public const int VOLUME_DOWN = 174; //Volume Down key
		public const int VOLUME_UP = 175; //Volume Up key
		public const int NEXT_TRACK = 176; //Next Track key
		public const int PREV_TRACK = 177; //Previous Track key
		public const int STOP_MEDIA = 178; //Stop Media key
		public const int PLAY_MEDIA = 179; //Play/Pause Media key
		public const int MAIL = 180; //Start Mail key
		public const int MEDIA = 181; //Select Media key
		public const int APP_1 = 182; //Start Application 1 key
		public const int APP_2 = 183; //Start Application 2 key
									  //... Reserved from 0xB8 to 0xB9
		public const int OEM_1 = 186; //Used for miscellaneous characters
		public const int OEM_PLUS = 187; //For any country/region, the '+' key
		public const int OEM_COMMA = 188; //For any country/region, the ',' key
		public const int OEM_MINUS = 189; //For any country/region, the '-' key
		public const int OEM_PERIOD = 190; //For any country/region, the '.' key
		public const int OEM_2 = 191; //For the US standard keyboard, the '/?' key
		public const int OEM_3 = 192; //For the US standard keyboard, the '`~' key
									  //... Reserved from 0xC1 to 0xD7
									  //... Unsigned from 0xD8 to 0xDA
		public const int OEM_4 = 219; //For the US standard keyboard, the '[{' key
		public const int OEM_5 = 220; //For the US standard keyboard, the '\|' key
		public const int OEM_6 = 221; //For the US standard keyboard, the ']}' key
		public const int OEM_7 = 222; //For the US standard keyboard, the 'single-quote/double quote' key
		public const int OEM_8 = 223; //Used for miscellaneous characters; it can vary by keyboard
									  //... Reserved at 0xE0
									  //... OEM specific at 0xE1
		public const int OEM_102 = 226; //Either the angle bracket key or the backslash key on the RT 102-key keyboard
										//OEM specific from 0xE3 to 0xE4
		public const int PROCESS_KEY = 229; //IME PROCESS key
											//... OEM specific at 0xE6
		public const int PACKET = 231; //he VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods
									   //... Unassigned at 0xE8
									   //... OEM specific from 0xE9 to 0xF5
		public const int ATTN = 246; //Attn key
		public const int CRSEL = 247; //CrSel key
		public const int EXSEL = 248; //ExSel key
		public const int EREOF = 249; //Erase EOF key
		public const int PLAY = 250; //Play key
		public const int ZOOM = 251; //Zoom key
									 //... Reserved at 0xFC
		public const int PA1 = 253; //PA1 key
		public const int OEM_CLEAR = 254; //Clear key
	}
}
