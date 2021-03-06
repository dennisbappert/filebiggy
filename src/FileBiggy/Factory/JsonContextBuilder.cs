using System.Collections.Generic;

namespace FileBiggy.Factory
{
    public class JsonContextBuilder<T>
    {
        private readonly Dictionary<string, string> _tuples;

        public JsonContextBuilder(Dictionary<string, string> tuples)
        {
            _tuples = tuples;
        }

        public Builder<T> WithDatabaseDirectory(string path)
        {
            _tuples.Add(ConnectionStringConstants.Path, path);
            return new Builder<T>(_tuples);
        }
    }
}