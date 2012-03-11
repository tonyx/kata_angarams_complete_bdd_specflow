using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SpecFlowAnagramsKata.tests
{
    [TestFixture]
    class AnagramsTest
    {
        [Test]
        public void EqualsAreAnagrams()
        {
            // given
            Anagrammer anagrammer = new Anagrammer();

            // when
            bool result = anagrammer.AreAnagrams("foo", "foo");

            // then
            Assert.That(result,Is.EqualTo(true));
        }

        [Test]
        public void ReversedAreAnagrams()
        {
            // given
            Anagrammer anagrammer = new Anagrammer();

            // when
            bool result = anagrammer.AreAnagrams("foo", "oof");

            // then
            Assert.That(result, Is.EqualTo(true));
        }

    }
}
