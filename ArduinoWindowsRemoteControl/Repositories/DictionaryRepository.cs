using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Repositories
{
    public class DictionaryRepository
    {
        #region Private Constants

        private const string KeyValueDelimeter = ":::";
        private const string ItemsDelimeter = "\r\n;;;\r\n";

        #endregion

        #region Public Methods

        public void Save<TKey, TValue>(Dictionary<TKey, TValue> dictionary, string filename)
        {
            using (var writer = new StreamWriter(filename, false))
            {
                foreach (var kvp in dictionary)
                {
                    writer.Write(kvp.Key.ToString());
                    writer.Write(KeyValueDelimeter);
                    writer.Write(kvp.Value.ToString());
                    writer.Write(ItemsDelimeter);
                }
            }
        }

        public Dictionary<TKey, TValue> Load<TKey, TValue>(string filename)
        {
            var result = new Dictionary<TKey, TValue>();

            using (var reader = new StreamReader(filename))
            {
                var lines = reader.ReadToEnd();
                var items = lines.Split(new string[] { ItemsDelimeter }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in items)
                {
                    var parts = item.Split(new string[] { KeyValueDelimeter }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    result.Add((TKey)Convert.ChangeType(parts[0], typeof(TKey)), (TValue)Convert.ChangeType(parts[1], typeof(TValue)));
                }
            }

            return result;
        }

        #endregion
    }
}
