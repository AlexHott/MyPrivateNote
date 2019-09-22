using System;
using System.Collections.Generic;
using System.Text;

namespace MyPrivateNote
{
    public class MyNoteData
    {
        public int ID { get; set; }
        public string TITLE { get; set; }
        public string BODY { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public class MyNoteResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public List<MyNoteData> NoteData { get; set; }
    }
}
