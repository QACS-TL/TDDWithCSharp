using System.Linq;

namespace Tokeniser
{
    public class StringTokeniser
    {
        public String[] tokenise(String inputVal)
        {
            return inputVal.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        }
    }
}
