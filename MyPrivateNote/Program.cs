using System;
using System.Collections.Generic;

namespace MyPrivateNote
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = $"{Constants.MyProgram} v.{Constants.Version}";
            List<MyNoteData> mynotedata = new List<MyNoteData>();
            var myNote = new MyPrivateNoteMainUI();
            myNote.Start(mynotedata);
        }
    }
}
