using System;
using System.Collections.Generic;
using Xunit;
using MyPrivateNote;

namespace TestMyPrivateNote
{
    public class UnitTestPrivateNote
    {
        private readonly MyPrivateNotes _myPrivateNote;

        public UnitTestPrivateNote()
        {
            _myPrivateNote = new MyPrivateNotes();
        }

        [Fact]
        public void CorrectData()
        {

            Assert.Equal(0, 0);
        }

        []
        [Theory]
        [InlineData(new List<MyNoteData>(),
                    new MyNoteData { ID=0, TITLE = "Первый тест", BODY = "Содержимое сообщения", IsDeleted = false },
                    new MyNoteResult { Result = true, Message = "Note sucessfuly added", NoteData = new List<MyNoteData>() }
                    )]
       
        public void MyPrivateNoteCorrectOperations(List<MyNoteData> myNoteDataList, MyNoteData myNoteData, MyNoteResult result)
        {

            var testResult = _myPrivateNote.AddNote(myNoteDataList, myNoteData);

            Assert.Equal(result.Result, testResult.Result);
            Assert.Equal(result.Message, testResult.Message);
        }
    }
}
