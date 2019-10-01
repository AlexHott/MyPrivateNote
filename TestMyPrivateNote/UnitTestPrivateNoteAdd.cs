using System;
using System.Collections.Generic;
using Xunit;
using MyPrivateNote;
using System.Linq;

namespace TestMyPrivateNote
{
    public class UnitTestPrivateNoteAdd
    {
        public static IEnumerable<object[]> GetTestQueryData()
        {
            yield return new object[]
            {
                new List<MyNoteData>(),
                new MyNoteData
                    {
                        TITLE = "test1" ,
                        BODY = "testestest1",
                        IsDeleted = false,
                        ID =0
                    },
                new MyNoteResult
                {
                    Result = true,
                    Message = "Note sucessfuly added"
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetTestQueryData))]
        public void MyPrivateNoteTest(List<MyNoteData> dataList, MyNoteData data, MyNoteResult result)
        {
            var myNoteEgine = new MyPrivateNotes();

            var test = myNoteEgine.AddNote(dataList, data);

            Assert.Equal(result.Result, test.Result);
            Assert.Equal(result.Message, test.Message);
        }
    }
}    

