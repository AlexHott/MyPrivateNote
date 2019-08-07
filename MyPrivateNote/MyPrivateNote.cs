using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPrivateNote
{
    public class MyPrivateNote
    {
        private static void AddNote (List<MyNoteData> mynotedata)
        {
            Console.Clear();
            Console.WriteLine("Type TITLE");
            Console.Write(">");
            var title = Console.ReadLine();


            Console.WriteLine("Type Body");
            Console.Write(">");
            var body = Console.ReadLine();

            int id = mynotedata.Count() + 1;
            mynotedata.Add(new MyNoteData { ID = id, TITLE = title, BODY = body });

            Console.WriteLine("Note succesfuly added. You want add more? (y/n)");
            Console.Write(">");
            var yesno = Console.ReadLine();
            if(Confirm(yesno))
            { AddNote(mynotedata); }
            else { Start(mynotedata); }

        }
        private static void ListNote(List<MyNoteData> mynotedata)
        {
            Console.Clear();
            Console.WriteLine("ID     TITLE");
            foreach (var noteitem in mynotedata.Where(x => x.IsDeleted != true))
            {
                Console.WriteLine($"{noteitem.ID}     {noteitem.TITLE}");
            }
            return;
        }

        private static void DelNote(List<MyNoteData> mynotedata)
        {
            Console.Clear();
            Console.WriteLine("Type ID Note for delete");
            Console.Write(">");
            var iddel = Console.ReadLine();

            var parsegood = int.TryParse(iddel, out int id);

            mynotedata.Find(x => x.ID == id).IsDeleted = true; 

            Console.WriteLine("Note succesfuly deleted. You want add more? (y/n)");
            Console.Write(">");
            var yesno = Console.ReadLine();
            if (Confirm(yesno))
            { DelNote(mynotedata); }
            else { Start(mynotedata); }
        }

        private static void EditNote(List<MyNoteData> mynotedata)
        {
            Console.Clear();
            Console.WriteLine("Type ID Note for edit");
            Console.Write(">");
            var idedit = Console.ReadLine();

            var parsegood = int.TryParse(idedit, out int id);

            var currNote = mynotedata.Find(x => x.ID == id);

            if (!(currNote is null))
            {
                Console.WriteLine("Type new Title");
                Console.Write(">");
                var title = Console.ReadLine();
                currNote.TITLE = title;
                Console.WriteLine("Type new Body");
                Console.Write(">");
                var body = Console.ReadLine();
                currNote.BODY = body;
                Console.WriteLine("Note succesfuly updated. You want update more? (y/n)");
            }
            else
            {
              Console.WriteLine("Wrong ID");
              Console.WriteLine("Note not updated. You want update more? (y/n)");
            }
            
            Console.Write(">");
            var yesno = Console.ReadLine();
            if (Confirm(yesno))
            { EditNote(mynotedata); }
            else { Start(mynotedata); }
        }

        private static void Help ()
        {
            Console.WriteLine(Constants.Help);
            return;
        }

        public static void Start(List<MyNoteData> mynotedata)
        {
            Console.Title = $"{Constants.MyProgram} v.{Constants.Version}";
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

        private static bool Confirm(string usercommand)
        {
            bool result = true;
            if (usercommand == "y")
            { result = true; return result; }
            if (usercommand == "n")
            { result =  false; return result; }
            Console.WriteLine("Type y or n");
            Console.Write(">");
            usercommand = Console.ReadLine();
            result = Confirm(usercommand);
            return result;
        }
            private static void CommandParse(List<MyNoteData> mynotedata, string usercommand)
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

    }
}
