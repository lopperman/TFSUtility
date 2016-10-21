using System.IO;


namespace TFSCommunication.Syncing
{
    public class SyncToAccess
    {
        private TFSConnect _connect;
        private string _filePath;


        public SyncToAccess(TFSConnect connect, string accessFilePath)
        {
            this._connect = connect;
            this._filePath = accessFilePath;

        }

        public string ConnectionString => string.Format("", _filePath);


    }
}
