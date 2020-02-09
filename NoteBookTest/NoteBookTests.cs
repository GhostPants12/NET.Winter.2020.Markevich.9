using Notebook.Part1;
using NUnit.Framework;

namespace NoteBookTest
{
    public class Tests
    {
        [Test]
        public void NoteTests_ComparisonOperators()
        {
            Note firstNote = new Note("123");
            Note firstNoteCopy = firstNote;
            Note nullNote = null;
            Note nullNoteCopy = nullNote;
            Note secondNote = new Note("123");
            Assert.AreEqual(false, firstNote < secondNote);
            Assert.AreEqual(false, secondNote > firstNote);
            Assert.AreEqual(false, firstNote <= secondNote);
            Assert.AreEqual(false, secondNote >= firstNote);
            Assert.AreEqual(false, firstNote == secondNote);
            Assert.AreEqual(true, firstNote != secondNote);
            Assert.AreEqual(true, firstNoteCopy == firstNote);
            Assert.AreEqual(false, firstNote == nullNote);
            Assert.AreEqual(true, nullNote == nullNoteCopy);
        }

        [Test]
        public void NoteTests_Equals()
        {
            Note firstNote = new Note("123");
            Note firstNoteCopy = firstNote;
            Note nullNote = null;
            Note secondNote = new Note("123");
            Assert.AreEqual(true, firstNote.Equals(firstNoteCopy));
            Assert.AreEqual(false, firstNote.Equals(secondNote));
            Assert.AreEqual(false, firstNote.Equals(nullNote));
        }

        [Test]
        public void NoteBookTests_AllMethods()
        {
            Note firstNote = new Note("123");
            Note secondNote = new Note("123");
            Note thirdNote = new Note("123");
            NoteBook noteBook = new NoteBook();
            noteBook.Add(firstNote);
            noteBook.Add(secondNote);
            noteBook.Add(thirdNote);
            noteBook.Sort();
            NoteBook expected = new NoteBook();
            expected.Add(thirdNote);
            expected.Add(secondNote);
            expected.Add(firstNote);
            bool notesAreEqual = true;
            for (int i = 0; i < 3; i++)
            {
                if (noteBook[i] != expected[i])
                {
                    notesAreEqual = false;
                }
            }

            Assert.IsTrue(notesAreEqual);
            expected.Remove(firstNote);
            noteBook.Remove(firstNote);
            for (int i = 0; i < 2; i++)
            {
                if (noteBook[i] != expected[i])
                {
                    notesAreEqual = false;
                }
            }

            Assert.IsTrue(notesAreEqual);
            expected.RemoveAt(1);
            noteBook.RemoveAt(1);
            if (noteBook[0] != expected[0])
            {
                notesAreEqual = false;
            }

            Assert.IsTrue(notesAreEqual);
        }

        [Test]
        public void NoteBookServiceTests()
        {
            Note firstNote = new Note("123");
            Note secondNote = new Note("123");
            Note thirdNote = new Note("123");
            NoteBookService.Instance.AddNote(firstNote);
            Assert.AreEqual(true, NoteBookService.Instance[0] == firstNote);
            NoteBookService.Instance.RemoveNoteAt(0);
            NoteBookService.Instance.AddNote(secondNote);
            Assert.AreEqual(true, NoteBookService.Instance[0] == secondNote);
            NoteBookService.Instance.RemoveNote(secondNote);
            NoteBookService.Instance.AddNote(thirdNote);
            Assert.AreEqual(true, NoteBookService.Instance[0] == thirdNote);
        }
    }
}