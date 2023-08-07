using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iflytek.Court.Office.Core.Models
{
    public class CommentSt
    {
        string text;
        Comment comment;
        public Comment Comment
        {
            set
            {
                comment = value;
                text = comment.Range.Text;
            }
            get
            {
                return comment;
            }
        }
        public bool IsChanged
        {
            get
            {
                try
                {
                    return comment.Range.Text != text;
                }
                catch
                {
                    IsDelete = true;
                    return false;
                }
            }
        }

        public bool IsDelete { private set; get; }

        public DateTime Date => comment.Date;

        public void Update()
        {
            text = comment.Range.Text;
        }
    }
}
