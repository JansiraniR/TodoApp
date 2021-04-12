using System;
using System.IO;

namespace TodoApp.LocalDB
{
    public class SQLiteFileSystem : ISQLiteFileSystem
    {
        public SQLiteFileSystem()
        {
        }

        public string DataFolderPath
        {
            get
            {
                var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, "TodoApp.db3");
                
            }
        }

    }
}
