using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPrivateNote
{
    public class MyPrivateNotes
    {
        public MyNoteResult AddNote (List<MyNoteData> mynotedataList, MyNoteData myNoteData)
        {
            var addResult = new MyNoteResult();
            addResult.NoteData = mynotedataList;
            try
            {
                int id = mynotedataList.Count() + 1;
                myNoteData.ID = id;
                mynotedataList.Add(myNoteData);
                addResult.Result = true;
                addResult.Message = "Note sucessfuly added";
            }
            catch(Exception e)
            {
                addResult.Result = false;
                addResult.Message = $"Note not added: {e.Message}";
            }

            return addResult;
        }
        public MyNoteResult ListNote(List<MyNoteData> mynotedataList)
        {
            var listResult = new MyNoteResult();
            

            if (mynotedataList.Any())
            {
                listResult.NoteData = mynotedataList;
                listResult.Result = true;
                listResult.NoteData = mynotedataList.Where(x => x.IsDeleted != true).ToList();
            }
            else
            {
                listResult.Message = "List of Note is empty";
                listResult.Result = false;
            }

            return listResult;
        }

        public MyNoteResult DelNote(List<MyNoteData> mynotedataList, string idNote)
        {
            var listResult = new MyNoteResult();

            var parsegood = int.TryParse(idNote, out int id);
            if (!parsegood)
            {
                listResult.Message = "Type correct ID";
                listResult.Result = false;
                return listResult;
            }

            var noteForDel = mynotedataList.Where(x => x.ID == id);

            if (noteForDel.Count() == 1)
            {
                noteForDel.First().IsDeleted = true;
                listResult.Message = "Note succesfuly deleted.";
                listResult.Result = true;
                return listResult;
            }
            else
            {
                listResult.Message = $"Not fine note whith id: {id}";
                listResult.Result = false;
                return listResult;
            }
           
        }

        public MyNoteResult ReadNote(List<MyNoteData> myNoteDataList, string idNote)
        {
            var listResult = new MyNoteResult();

            var parsegood = int.TryParse(idNote, out int id);
            if (!parsegood)
            {
                listResult.Message = "Type correct ID";
                listResult.Result = false;
                return listResult;
            }

            var noteForEdit = myNoteDataList.Where(x => x.ID == id && x.IsDeleted != true);

            if (!noteForEdit.Any())
            {
                listResult.Message = $"Not fine note whith id: {id}"; ;
                listResult.Result = false;
                return listResult;
            }

            listResult.Result = true;
            listResult.NoteData = noteForEdit.ToList();

            return listResult;
        }

        public MyNoteResult Edit (List<MyNoteData> myNoteDataList, MyNoteData myNoteData)
        {
            var listResult = new MyNoteResult();

            var currNote = myNoteDataList.Where(x => x.ID == myNoteData.ID);
            if (!currNote.Any())
            {
                listResult.Message = $"Not fine note whith id: {myNoteData.ID}"; ;
                listResult.Result = false;
                return listResult;
            }

            currNote.First().TITLE = myNoteData.TITLE;
            currNote.First().BODY = myNoteData.BODY;

            listResult.Message = $"Note is updated"; ;
            listResult.Result = true;
            return listResult;
        }

        public MyNoteResult Help ()
        {
            var listResult = new MyNoteResult();
            listResult.Message = Constants.Help;
            listResult.Result = true;
            return listResult;
        }
    }
}
