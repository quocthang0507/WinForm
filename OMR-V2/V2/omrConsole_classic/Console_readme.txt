OMR Engine Console ReadMe

1: Console can work either on command line parameters or step by step commands. 
2: If command line paramers are given, the application enters a command line
   mode and won't be able to take any commands during the session.
3: A Command line argument can be built by writing several commands seperated 
   by a [SPACE]. 

4: Commands format is as following:
	[command][SPACE][commandArgument]
			Or
	[Parameter][Space][Specification]

5: Followings are the supported commands: (not case sensative)

_________________________________________________________________________
|    Command	|    Argument	|           Explanation			|
|_______________|_______________|_______________________________________|
| help		| Nil/Empty	| Previews this readme text		|
|		| 		|					|
| exit		| Nil/Empty	| Halts any ongoing process and exits	|
|		|		| the console.				|
|		| 		|					|
| process	| Single	| Creates an OMR engine and processes	|
|		|		| the given Image synchronoulsy.	|
|		| 		|					|
| 		| multiple	| Creates an OMR engine and processes	|
|		|		| all the jpg images in directory using |
|		|		| single thread. If mutiple threads are |
|		|		| required, it must be set using param-	|
|		|		| eter, "EnableMT". If done, process 	|
|		|		| will be completed using multiple 	|
|		|		| threads as specified by property, 	|
|		|		| "MaximumThreads".			|
|		|		|					|
|_______________|_______________|_______________________________________|

6: Followings are the available parameters: (not case sensative)
   Please also note that file/directory paths should be enclosed in commas. 

   Examples: 
   "123.jpg"
   "d:\My OMR Record\123.jpg"
   "\..\File 123.jpg"
   "d:\myImageCollection"
_________________________________________________________________________
|    Paramter 	|           Expected Value/Specification 		|
|_______________|_______________________________________________________|
| CamImage	| The path of target image, in case of single processs,	|
|		| or the directory path of jpg images, in case of 	|
|		| multiple images. 					|
|		|							|
| OutputDir	| The output Directory where the results will be saved. |
|		| By default, it is the same as the console root dir.	|
|		| 							|
| SheetDb	| The path of MS Access Database to be used for sheet	|
|		| extraction.	 					|
|		|							|
| SheetName 	| Name of table in MS Access DB which contains the def- | 
|		| initions of OMR sheet.				|
|		|							|
| AnswerKey	| Set the name of answer key for evaluating scores.	|
|		|							|
| EnableMT	| Must be either True or False.				|
|		| Controls Multithreading while processing in multiple	|
|		| mode.							|
|		|							|
| MaximumThreads| An integral value (1-16) indicating the number of 	|
|		| threads to be used in multithread process.		|
|_______________|_______________________________________________________|