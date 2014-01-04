using System;
using System.Text;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Json
{
    public static class JsonEncoder
    {
        public static string Encode(DateTime date)
        {
            return date.ToUniversalTime().ToString("ddd MMM dd yyyy HH:mm:ss.fff 'UTC'");
        }

        public static string Encode(string text)
        {
            var sb = new StringBuilder();
            foreach (char glyph in text)
            {
                sb.Append(Encode(glyph));
            }
            return sb.ToString();
        }

        public static string Encode(char glyph)
        {
            switch (glyph)
            {
                case '\\':
                    return "\\\\";
                case '"':
                    return "\\\"";
                case '\'':
                    return "\\'";
                case '\n':
                    return "\\n";
                case '\r':
                    return "\\r";
                case '\t':
                    return "\\t";
                case '\b':
                    return "\\b";
                case '\f':
                    return "\\f";
            }
            int ascii = glyph;
            if (ascii < 32 || ascii > 127)
            {
                return string.Format(@"\u{0:X04}", ascii);
            }

            return new string(new[] {glyph});
        }
    }
}