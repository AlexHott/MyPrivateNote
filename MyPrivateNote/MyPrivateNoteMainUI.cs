using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyPrivateNote
{
    class MyPrivateNoteMainUI
    {
        public void Start(List<MyNoteData> mynotedata)
        {
            var comandREsult = new MyNoteResult();

            string usercommand;

            Console.WriteLine("Type help if you need help.");
            Console.WriteLine("");
            Console.Write(">");

            while (1 == 1)
            {
                usercommand = Console.ReadLine();

                CommandParse(mynotedata, usercommand);

                Console.Write(">");
            }
        }

        private void CommandParse(List<MyNoteData> mynotedata, string usercommand)
        {

            if (usercommand == "help")
            {
                Help();
                return;
            }

            if (usercommand == "add")
            {
                AddNote(mynotedata);
                return;
            }

            if (usercommand == "list")
            {
                ListNote(mynotedata);
                return;
            }

            if (usercommand == "del")
            {
                DelNote(mynotedata);
                return;
            }

            if (usercommand == "edit")
            {
                EditNote(mynotedata);
                return;
            }

            Console.WriteLine("Wrong command");
        }
        private void AddNote(List<MyNoteData> mynotedata)
        {
            Console.Clear();
            Console.WriteLine("Type TITLE");
            Console.Write(">");
            var title = Console.ReadLine();


            Console.WriteLine("Type Body");
            Console.Write(">");
            var body = Console.ReadLine();

            var newNote = new MyNoteData { BODY = body, TITLE = title };

            var privateNote = new MyPrivateNotes();
            var addResult = privateNote.AddNote(mynotedata, newNote);

            Console.WriteLine(addResult.Message);
            Console.WriteLine("You want add more? (y/n)");
            Console.Write(">");
            var yesno = Console.ReadLine();
            if (Confirm(yesno))
            { AddNote(mynotedata); }
            else { this.Start(mynotedata); }

        }
        private void ListNote(List<MyNoteData> mynotedataList)
        {
            var privateNote = new MyPrivateNotes();
            var myNoteList = privateNote.ListNote(mynotedataList);
            Console.Clear();
            Console.WriteLine("ID     TITLE");

            if (!myNoteList.Result)
            {
                Console.WriteLine(myNoteList.Message);
            }
            else
            {
                foreach (var noteitem in myNoteList.NoteData)
                {
                    Console.WriteLine($"{noteitem.ID}     {noteitem.TITLE}");
                }
            }
            return;
        }

        private void DelNote(List<MyNoteData> mynotedata)
        {
            var privateNote = new MyPrivateNotes();
            Console.Clear();
            Console.WriteLine("Type ID Note for delete");
            Console.Write(">");
            var iddel = Console.ReadLine();

            var delREsult = privateNote.DelNote(mynotedata, iddel);

            Console.WriteLine(delREsult.Message);
            Console.WriteLine("You want add more? (y/n)");
            Console.Write(">");
            var yesno = Console.ReadLine();
            if (Confirm(yesno))
            { DelNote(mynotedata); }
            else { Start(mynotedata); }
        }

        private void EditNote(List<MyNoteData> mynotedata)
        {
            var privateNote = new MyPrivateNotes();
            Console.Clear();
            Console.WriteLine("Type ID Note for edit");
            Console.Write(">");
            var idedit = Console.ReadLine();

            var readRes = privateNote.ReadNote(mynotedata, idedit);

            if (readRes.Result)
            {
                var updNote = new MyNoteData {ID= readRes.NoteData.First().ID, TITLE="", BODY="" };
                Console.WriteLine("Type new Title");
                Console.Write(">");
                var title = Console.ReadLine();
                updNote.TITLE = title;
                Console.WriteLine("Type new Body");
                Console.Write(">");
                var body = Console.ReadLine();
                updNote.BODY = body;

                var updREs = privateNote.Edit(mynotedata, updNote);
                Console.WriteLine(updREs.Message);
                Console.WriteLine("You want update more? (y/n)");
            }
            else
            {
                Console.WriteLine(readRes.Message);
                Console.WriteLine("Note not updated. You want update more? (y/n)");
            }

            Console.Write(">");
            var yesno = Console.ReadLine();
            if (Confirm(yesno))
            { EditNote(mynotedata); }
            else { Start(mynotedata); }
        }

        private void Help()
        {
            Console.WriteLine(Constants.Help);
            return;
        }

     private bool Confirm(string usercommand)
        {
            bool result = true;
            if (usercommand == "y")
            { result = true; return result; }
            if (usercommand == "n")
            { result = false; return result; }
            Console.WriteLine("Type y or n");
            Console.Write(">");
            usercommand = Console.ReadLine();
            result = Confirm(usercommand);
            return result;
        }
    }
}
