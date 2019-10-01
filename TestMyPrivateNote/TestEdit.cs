using System;
using System.Collections.Generic;
using Xunit;
using MyPrivateNote;
using System.Linq;

namespace TestMyPrivateNote
{
    public class UnitTestPrivateNoteEdit
    {
        public static IEnumerable<object[]> GetTestQueryData()
        {
            yield return new object[]
            {
                new List<MyNoteData>
                {
                    new MyNoteData
                    {
                        TITLE = "test1" ,
                        BODY = "testestest1",
                        IsDeleted = false,
                        ID = 1
                    },
                    new MyNoteData
                    {
                        TITLE = "test4" ,
                        BODY = "testestest4",
                        IsDeleted = false,
                        ID = 2
                    },
                },
                new MyNoteData
                    {
                        TITLE = "test2" ,
                        BODY = "testestest2",
                        IsDeleted = false,
                        ID = 1
                    },
                new MyNoteResult
                {
                    Result = true,
                    Message = "Note is updated",
                }
            };
            yield return new object[]
           {
                new List<MyNoteData>
                {
                    new MyNoteData
                    {
                        TITLE = "test1" ,
                        BODY = "testestest1",
                        IsDeleted = false,
                        ID = 1
                    },
                    new MyNoteData
                    {
                        TITLE = "test4" ,
                        BODY = "testestest4",
                        IsDeleted = false,
                        ID = 2
                    },
                },
                new MyNoteData
                    {
                        TITLE = "test2" ,
                        BODY = "testestest2",
                        IsDeleted = false,
                        ID = 4
                    },
                new MyNoteResult
                {
                    Result = false,
                    Message = "Not fine note whith id: 4",
                }
           };
        }

        [Theory]
        [MemberData(nameof(GetTestQueryData))]
        public void MyPrivateNoteTest(List<MyNoteData> dataList, MyNoteData data, MyNoteResult result)
        {
            var myNoteEgine = new MyPrivateNotes();

            var test = myNoteEgine.Edit(dataList, data);

            Assert.Equal(result.Result, test.Result);
            Assert.Equal(result.Message, test.Message);
        }
    }
}

