using System;
using LewisMoten.Spiders.CheerfulDrill.Core.Json;
using NUnit.Framework;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Tests.Json
{
    [TestFixture]
    public class JsonEncoderTest
    {
        private const string JavaScriptEscapeCharacters = "'\"\\\n\r\t\b\f";

        [Test]
        public void EncodeGlyphEscapesUpperAscii()
        {
            for (int i = char.MinValue; i < char.MaxValue; i++)
            {
                if (JavaScriptEscapeCharacters.IndexOf((char) i) != -1)
                {
                    continue;
                }
                if (i >= 32 && i <= 127)
                {
                    continue;
                }

                Assert.That(JsonEncoder.Encode((char) i), Is.EqualTo(string.Format("\\u{0:X04}", i)));
            }
        }

        [Test]
        public void EncodesDate()
        {
            var date = new DateTime(2014, 3, 9, 6, 9, 2, 123, DateTimeKind.Utc);
            Assert.That(JsonEncoder.Encode(date), Is.EqualTo("Sun Mar 09 2014 06:09:02.123 UTC"));

            date = new DateTime(DateTime.MinValue.Ticks, DateTimeKind.Utc);
            Assert.That(JsonEncoder.Encode(date), Is.EqualTo("Mon Jan 01 0001 00:00:00.000 UTC"));

            date = new DateTime(DateTime.MaxValue.Ticks, DateTimeKind.Utc);
            Assert.That(JsonEncoder.Encode(date), Is.EqualTo("Fri Dec 31 9999 23:59:59.999 UTC"));
        }

        [Test]
        public void EncodesGlyphEscapeCharacters()
        {
            foreach (char glyph in JavaScriptEscapeCharacters)
            {
                Assert.That(JsonEncoder.Encode(glyph), Is.Not.EqualTo(glyph));
                Assert.That(JsonEncoder.Encode(glyph), Is.StringStarting(@"\"));
            }
        }

        [Test]
        public void EncodesGlyphLowerAscii()
        {
            for (int i = 32; i < 127; i++)
            {
                if (JavaScriptEscapeCharacters.IndexOf((char) i) != -1)
                {
                    continue;
                }
                var glyph = (char) i;
                var text = new string(glyph, 1);
                Assert.That(JsonEncoder.Encode(glyph), Is.EqualTo(text), "Failed for ASCII {0}", i);
            }
        }

        [Test]
        public void EncodesStringSameAsChar()
        {
            for (char c = char.MinValue; c < char.MaxValue; c++)
            {
                var text = new string(c, 1);
                Assert.That(JsonEncoder.Encode(c), Is.EqualTo(JsonEncoder.Encode(text)));
            }
        }
    }
}