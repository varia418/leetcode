internal class Program
{
    public class TimeMap
    {
        private Dictionary<string, List<(int Timestamp, string Value)>> _dict;

        public TimeMap()
        {
            _dict = new();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (_dict.ContainsKey(key))
            {
                _dict[key].Add((timestamp, value));
            }
            else
            {
                _dict[key] = new()
                {
                    (timestamp, value)
                };
            }
        }

        public string Get(string key, int timestamp)
        {

            if (!_dict.ContainsKey(key))
            {
                return "";
            }

            int l = 0, r = _dict[key].Count - 1, m;

            if (timestamp < _dict[key][l].Timestamp) return "";
            if (timestamp > _dict[key][r].Timestamp) return _dict[key][r].Value;

            while (l <= r)
            {
                m = l + (r - l) / 2;

                int mTimestamp = _dict[key][m].Timestamp;

                if (mTimestamp > timestamp)
                {
                    r = m - 1;
                }
                else if (mTimestamp < timestamp)
                {
                    l = m + 1;
                }
                else
                {
                    return _dict[key][m].Value;
                }
            }

            return _dict[key][l - 1].Value;
        }
    }

    private static void Main(string[] args)
    {
        string s = string.Empty;

        TimeMap timeMap = new TimeMap();

        string[] actions = ["set", "set", "get", "get", "get", "get", "get"];

        var values = new List<Tuple<string, string?, int>>()
        {
            new Tuple<string, string?, int>("love", "high", 10),
            new Tuple<string, string?, int>("love", "low", 20),
            new Tuple<string, string?, int>("love", null, 5),
            new Tuple<string, string?, int>("love", null, 10),
            new Tuple<string, string?, int>("love", null, 15),
            new Tuple<string, string?, int>("love", null, 20),
            new Tuple<string, string?, int>("love", null, 25)
        };

        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "set":
                    timeMap.Set(values[i].Item1, values[i].Item2!, values[i].Item3);
                    break;
                case "get":
                    s = timeMap.Get(values[i].Item1, values[i].Item3);
                    System.Console.WriteLine(s);
                    break;
            }
        }
    }
}