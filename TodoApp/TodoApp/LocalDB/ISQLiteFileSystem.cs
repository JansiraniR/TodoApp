using System;
namespace TodoApp.LocalDB
{
    public interface ISQLiteFileSystem
    {
        string DataFolderPath { get; }
    }
}
