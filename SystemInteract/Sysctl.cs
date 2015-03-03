using System;
using System.IO;

namespace SystemInteract
{
    public class Sysctl
    {
        private ISystemFactory _system;

        public Sysctl(ISystemFactory system)
        {
            _system = system;
        }

        private String KeyToPath(String key)
        {
            return "/proc/sys/" + key.Replace('.', '/');
        }

        /// <summary>
        /// Get the value of a sysctl key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public String Get(String key)
        {
            Stream fs = _system.Open(key, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            String ret = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return ret;
        }

        /// <summary>
        /// Set the value of a sysctl key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Write(String key, String value)
        {
            Stream fs = _system.Open(key, FileMode.Open, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(value);
            sw.Close();
            fs.Close();
        }
    }
}
