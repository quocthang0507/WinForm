using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.IO;
using System.Reflection;
using Microsoft.WindowsAPICodePack.Shell;

namespace JumplistDemo
{
    public class MyJumplist
    {
        private JumpList list;
      
        public MyJumplist(IntPtr windowHandle)
        {
            list = JumpList.CreateJumpListForIndividualWindow(TaskbarManager.Instance.ApplicationId, windowHandle);
            list.KnownCategoryToDisplay = JumpListKnownCategoryType.Recent;
            BuildList();
        }

        public void AddToRecent(string destination)
        {
            list.AddToRecent(destination);
            list.Refresh();
        }

        /// <summary>
        /// Builds the Jumplist
        /// </summary>
        private void BuildList()
        {
            JumpListCustomCategory userActionsCategory = new JumpListCustomCategory("Actions");
            JumpListLink userActionLink = new JumpListLink(Assembly.GetEntryAssembly().Location, "Clear History");
            userActionLink.Arguments = "-1";

            userActionsCategory.AddJumpListItems(userActionLink);
            list.AddCustomCategories(userActionsCategory);

            string notepadPath = Path.Combine(Environment.SystemDirectory, "notepad.exe");
            JumpListLink jlNotepad = new JumpListLink(notepadPath, "Notepad");
            jlNotepad.IconReference = new IconReference(notepadPath, 0);

            string calcPath = Path.Combine(Environment.SystemDirectory, "calc.exe");
            JumpListLink jlCalculator = new JumpListLink(calcPath, "Calculator");
            jlCalculator.IconReference = new IconReference(calcPath, 0);

            string mspaintPath = Path.Combine(Environment.SystemDirectory, "mspaint.exe");
            JumpListLink jlPaint = new JumpListLink(mspaintPath, "Paint");
            jlPaint.IconReference = new IconReference(mspaintPath, 0);

            list.AddUserTasks(jlNotepad);
            list.AddUserTasks(jlPaint);
            list.AddUserTasks(new JumpListSeparator());
            list.AddUserTasks(jlCalculator);

            list.Refresh();
        }
    }
}
