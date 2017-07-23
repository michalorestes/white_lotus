using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WhiteLotus_mainCW
{
    public class Forum
    {
        private int categoryID;
        private int postID;
        private int messageID;
        private int userID; 

        private string title;
        private string text;
        private DateTime date;

        public int CategoryID
        {
            get
            {
                return categoryID;
            }

            set
            {
                categoryID = value;
            }
        }

        public int PostID
        {
            get
            {
                return postID;
            }

            set
            {
                postID = value;
            }
        }

        public int MessageID
        {
            get
            {
                return messageID;
            }

            set
            {
                messageID = value;
            }
        }

        public int UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public Forum()
        {

        }


        public Forum(int categoryID, string postTitle, DateTime postDate, int userID)
        {
            this.categoryID = categoryID;
            this.title = postTitle;
            this.date = postDate;
            this.userID = userID; 
        }


    }
}