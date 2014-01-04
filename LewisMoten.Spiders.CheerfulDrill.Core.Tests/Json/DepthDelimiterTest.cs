using System;
using LewisMoten.Spiders.CheerfulDrill.Core.Json;
using NUnit.Framework;

namespace LewisMoten.Spiders.CheerfulDrill.Core.Tests.Json
{
    [TestFixture]
    public class DepthDelimiterTest
    {
        private const string DepthTooShallow = "The delimter has not been started.";
        private const string DepthTooDeep = "The delimiter is full.";

        private static void DoNothing()
        {
        }

        [Test]
        public void DefaultsToRealizeItHasNothingToDelimit()
        {
            var delimiter = new DepthDelimiter(DoNothing);
            Assert.That(delimiter.CanDelimit, Is.False);
        }

        [Test]
        public void DoesNotCloseWithoutDepth()
        {
            var delimiter = new DepthDelimiter(DoNothing);
            var ex = Assert.Throws<InvalidOperationException>(delimiter.Completed);
            Assert.That(ex.Message, Is.EqualTo(DepthTooShallow));
        }

        [Test]
        public void DoesNotDelimitOnFirstDelimit()
        {
            int count = 0;
            var delimiter = new DepthDelimiter(() => { count++; });
            delimiter.StartNew();
            delimiter.Delimit();
            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public void DoesNotDelimitPastRange()
        {
            const int max = 10;
            var delimiter = new DepthDelimiter(DoNothing, max);
            for (int i = 0; i < max; i++)
            {
                delimiter.StartNew();
            }
            var ex = Assert.Throws<InvalidOperationException>(delimiter.StartNew);
            Assert.That(ex.Message, Is.EqualTo(DepthTooDeep));
        }

        [Test]
        public void DoesNotDelimitWithoutDepth()
        {
            var delimiter = new DepthDelimiter(DoNothing);
            var ex = Assert.Throws<InvalidOperationException>(delimiter.Delimit);
            Assert.That(ex.Message, Is.EqualTo(DepthTooShallow));
        }

        [Test]
        public void FirstDepthDelimitsOnSecondDelimitAfterSecondDepthClosed()
        {
            int count = 0;
            var delimiter = new DepthDelimiter(() => { count++; });
            delimiter.StartNew();
            delimiter.Delimit();
            delimiter.StartNew();
            delimiter.Delimit();
            delimiter.Completed();
            delimiter.Delimit();
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void PerformsActionOnSecondDelimit()
        {
            int count = 0;
            var delimiter = new DepthDelimiter(() => { count++; });
            delimiter.StartNew();
            delimiter.Delimit();
            delimiter.Delimit();
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void RecognizesItHasNothingLeftToDelimit()
        {
            var delimiter = new DepthDelimiter(DoNothing);
            delimiter.StartNew();
            delimiter.Completed();
            Assert.That(delimiter.CanDelimit, Is.False);
        }

        [Test]
        public void RecognizesItHasSomethingToDelimit()
        {
            var delimiter = new DepthDelimiter(DoNothing);
            delimiter.StartNew();
            Assert.That(delimiter.CanDelimit, Is.True);
        }

        [Test]
        public void RequiresAction()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new DepthDelimiter(null));
            const string parameterName = "addDelimiter";
            string expectedMessage = new ArgumentNullException(parameterName).Message;
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void RequiresValidDepthLimit()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new DepthDelimiter(DoNothing, 0));
            const string parameterName = "maxDepth";
            string expectedMessage = new ArgumentOutOfRangeException(parameterName).Message;
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void SecondDepthDelimitsOnSecondDelimit()
        {
            int count = 0;
            var delimiter = new DepthDelimiter(() => { count++; });
            delimiter.StartNew();
            delimiter.Delimit();
            delimiter.StartNew();
            delimiter.Delimit();
            delimiter.Delimit();
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void SecondDepthDoesNotDelimitOnFirstDelimit()
        {
            int count = 0;
            var delimiter = new DepthDelimiter(() => { count++; });
            delimiter.StartNew();
            delimiter.Delimit();
            delimiter.StartNew();
            delimiter.Delimit();
            Assert.That(count, Is.EqualTo(0));
        }
    }
}