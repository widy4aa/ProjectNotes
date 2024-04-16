using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNotes.Base
{
    public class System
    {
        private static System _instance;
        private readonly TaskQueue _taskQueue;
        private readonly Database _database;

        private System()
        {
            _taskQueue = new TaskQueue();
            _database = new Database();
        }

        public static System Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new System();
                }
                return _instance;
            }
        }

        public TaskQueue TaskQueue => _instance._taskQueue;
        public Database Database => _instance._database;
    }

}
