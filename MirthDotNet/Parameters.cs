using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirthDotNet
{
    public class Parameters : NameValueCollection, IEnumerable<KeyValuePair<string, string>>
    {
        public new IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            foreach (string key in base.Keys)
            {
                yield return new KeyValuePair<string, string>(key, base[key]);
            }
        }
    }
}
