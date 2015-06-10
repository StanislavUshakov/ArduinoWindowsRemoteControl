using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    /// <summary>
    /// This class is used for saving Dictionary<Tkey, TValue> objects to the text file
    /// </summary>
    public class DictionaryRepository
    {
        #region Private Constants

        private const string KeyValueDelimeter = ":::";
        private const string ItemsDelimeter = "\r\n;;;\r\n";

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves Dictionary<TKey, TValue> to the text file named filename
        /// </summary>
        /// <typeparam name="TKey">Type of Dictionary keys</typeparam>
        /// <typeparam name="TValue">Type of Dictionary values</typeparam>
        /// <param name="dictionary">Dictionary to be saved</param>
        /// <param name="filename">Filename for saving</param>
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

        /// <summary>
        /// Loads Dictionary<TKey, TValue> from the text file named filename
        /// </summary>
        /// <typeparam name="TKey">Type of Dictionary keys</typeparam>
        /// <typeparam name="TValue">Type of Dictionary values</typeparam>
        /// <param name="filename">Filename of the file with the saved Dictionary</param>
        /// <returns>Loaded Dictionary</returns>
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
                    TKey key;
                    TValue value;

                    if (typeof(TKey).IsEnum)
                    {
                        key = (TKey)Enum.Parse(typeof(TKey), parts[0]);
                    }
                    else
                    {
                        key = (TKey)Convert.ChangeType(parts[0], typeof(TKey));
                    }

                    if (typeof(TValue).IsEnum)
                    {
                        value = (TValue)Enum.Parse(typeof(TValue), parts[1]);
                    }
                    else
                    {
                        value = (TValue)Convert.ChangeType(parts[1], typeof(TValue));
                    }
                    result.Add(key, value);
                }
            }

            return result;
        }

        #endregion
    }
}
