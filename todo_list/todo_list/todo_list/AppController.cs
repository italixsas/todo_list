namespace todo_list
{
    using Model;
    using RestSharp.Portable;
    using RestSharp.Portable.HttpClient;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class AppController
    {
        static String DbPath;

        public static void InitSQLite(String path)
        {
            DbPath = path;

            using (var c = new SQLite.SQLiteConnection(DbPath, false))
            {
                c.CreateTable<TaskItem>();
            }
        }

        public static void AddTask(TaskItem task)
        {
            using (var c = new SQLite.SQLiteConnection(DbPath, false))
            {
                c.Insert(task);
            }
        }

        public static void UpdateTask(TaskItem task)
        {
            using (var c = new SQLite.SQLiteConnection(DbPath, false))
            {
                c.Update(task);
            }
        }

        public static void DeleteTask(TaskItem task)
        {
            // lo using in automatico viene trasformato in un try catch e finally in cui chiude la connessione
            using (var c = new SQLite.SQLiteConnection(DbPath, false))
            {
                c.Delete(task.Id);
            }
        }

        public static TaskItem GetTask(int id)
        {
            using (var c = new SQLite.SQLiteConnection(DbPath, false))
            {
                return c.Get<TaskItem>(x => x.Id == id);
            }
        }

        public static TaskItem[] GetTasks(System.Linq.Expressions.Expression<Func<TaskItem, bool>> predicate = null)
        {
            using (var c = new SQLite.SQLiteConnection(DbPath, false))
            {
                var query = c.Table<TaskItem>();
                if (predicate != null)
                    query = query.Where(predicate);

                return query.ToArray();
            }
        }

        public static async Task Login(string username, string password, Action<Poco.User> success, Action<string> fail, Action<Exception> exception = null)
        {
            try
            {
                RestClient svc = new RestClient("http://listy-api.azurewebsites.net/"); // SerViCe

                svc.IgnoreResponseStatusCode = true;

                RestRequest req = new RestRequest("users/login", Method.POST);

                var data = new Poco.User() { Email = username, Password = password };
                req.AddJsonBody(data);


                System.Diagnostics.Debug.WriteLine("({0}) {1}\n REQUEST \n{2}",
                    req.Method,
                    svc.BaseUrl + req.Resource,
                    Newtonsoft.Json.JsonConvert.SerializeObject(data));                

                var res = await svc.Execute<Dto.Response<Poco.User>>(req);    // <Dto>.Wrap<Poco.User>(req);

                // http://old.dylanbeattie.net/cheatsheets/dot_net_string_format_cheat_sheet.pdf

                String hh = String.Format("({0}) {1}\n RESPONSE \n{2}",
    req.Method,
    svc.BaseUrl + req.Resource,
    Newtonsoft.Json.JsonConvert.SerializeObject(res));

                hh=hh.Replace(",", ",\n");

                System.Diagnostics.Debug.WriteLine(hh);

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Poco.User user = res.Data.Content;

                    // was: if (success != null) success.Invoke();
                   
                    success?.Invoke(user); 
                }
                else
                {
                    // res.Data?  do following stuff if we have this attribute, otherwise return default value for the expected type
                    fail?.Invoke(res.Data?.Message ?? res.StatusDescription);
                }

            }
            catch (Exception ex)
            {
                exception?.Invoke(ex);
            }
        }

        public static async Task Register(string username, string password, Action<Poco.User> success, Action<string> fail, Action<Exception> exception = null)
        {
            // https://en.wikipedia.org/wiki/Delegate_(CLI)

            try
            {
                RestClient svc = new RestClient("http://listy-api.azurewebsites.net/");

                svc.IgnoreResponseStatusCode = true;

                RestRequest req = new RestRequest("users/register", Method.POST);

                req.AddJsonBody(new Poco.User() { Email = username, Password = password });

                var res = await svc.Execute<Dto.Response<Poco.User>>(req);

                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Poco.User user = res.Data.Content;
                    // Action<Poco.User> is delegate of function with one parameter of type Poco.User

                    success?.Invoke(user); // now I call the callback passing a user as it is expected                    
                }
                else
                {
                    fail?.Invoke(res.Data.Message ?? res.StatusDescription);
                }

            }
            catch (Exception ex)
            {
                exception?.Invoke(ex);
            }
        }
    }
}
