namespace todo_list
{

    // Ctrl + A: select all
    // Ctrl + K F: reindent selected
    // Ctrl + M M: close all

    using System; // better inside namespace to resolve conflicts

    public static class Poco // plain old class object
    {
        public class User
        {
            public int UserId;
            public string Email;
            public string Password;
            public DateTime? LoginDate;
            public string AuthAccessToken;
            public DateTime? AuthExpirationDate;
        }

        public class TodoItem
        {
            public int TodoItemId;
            public int UserId;
            public string Title;
            public string Description;
            public DateTime? CreationDate;
            public string Tags;
        }

        public class WorkList
        {
            public TodoItem[] Items;
        }
    }

    public static class Dto // data transfer object
    {
        public class Response
        {
            public string Message;

            public string ExceptionMessage;
            public string ExceptionType;
        }

        public class Response<TContent> : Response
        {
            public TContent Content;

            public Response(TContent content)
            {
                this.Content = content;
            }
        }

        public static Response<T> Wrap<T>(T content)
        {
            return new Response<T>(content);
        }
    }


}
