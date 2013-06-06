using System;
using System.Diagnostics;

namespace HomeAmation.Pcl.Model
{
    public static class Utility
    {
        /// <summary>
        /// Display console debuggin infor. DateTime.Now, calling this. , string msg
        /// </summary>
        /// <param name="from"></param>
        /// <param name="msg"></param>
        public static void Log(object from, string msg)
        {
            Debug.WriteLine("Debug Log: {0} {1} {2}", DateTime.Now, from, msg);
            
        }
    }
}
