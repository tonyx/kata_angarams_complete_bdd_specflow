using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowAnagramsKata
{
    [Binding]
    public class AnagramSteps
    {
        private Anagrammer _anagrammer;
        private HashSet<HashSet<string>> _anagrams;
        [Given(@"no words")]
        public void GivenNoWords()
        {
            _anagrammer = new Anagrammer();
        }

        [When(@"I ask for the anagrams")]
        public void WhenIAskForTheSetOfTheSetsOfAnagrams()
        {
            _anagrams = _anagrammer.Anagrams();
        }

        [Then(@"I get an empty set")]
        public void ThenTheResultShouldBeAnEmptySet()
        {
            var expected = new HashSet<HashSet<string>>();
            Assert.That(expected, Is.EqualTo(_anagrams));
        }

        [Given(@"the words: (.*)")]
        public void GivenTheWordsFoo(string words)
        {
            _anagrammer = new Anagrammer(WordList(words.Split(',')));
            
        }

        [Then(@"I get a set containing a set containing the words: (.*)")]
        public void ThenIGetASetContainingASetContainingTheWordsFoo(string words)
        {
            Assert.That(_anagrams.Contains(WordList(words.Split(',')), new SetOfSetEqualityComparer()));
        }

        [Then(@"I get a set containing the words: (.*)")]
        public void ThenASetContainingTheWordsDoing(string word)
        {
            HashSet<string> expected = new HashSet<string>();
            foreach (var str in word.Split(','))
            {
                expected.Add(str.Trim());                
            }
            Assert.That(_anagrams.Contains(expected,new SetOfSetEqualityComparer()));
        }

        [Then(@"I get sets containing the following sets of words:")]
        public void ThenIGetSetsContainingTheFollowingSetsOfWords(Table table)
        {
            foreach (var row in table.Rows)
            {
                HashSet<string> aSet = WordList(row[0].Split(','));
                Assert.That(_anagrams.Contains(aSet, new SetOfSetEqualityComparer()));
            }
        }


        private static HashSet<string> WordList(string[] aWords)
        {
            var wordList = new HashSet<string>();
            foreach (var str in aWords)
            {
                wordList.Add(str.Trim());
            }
            return wordList;
        }
    }
}
