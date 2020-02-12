using System;
using Moq;
using Notebook.Part1;
using NUnit.Framework;

namespace NoteBookTest
{
    public class Tests
    {
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
        public void NoteBookServiceTests()
        {
            Note firstNote = new Note("123");
            Note secondNote = new Note("123");
            Note thirdNote = new Note("123");
            NoteBookService.Instance.AddNote(firstNote);
            Assert.AreEqual(true, NoteBookService.Instance[0].Equals(firstNote));
            NoteBookService.Instance.RemoveNoteAt(0);
            NoteBookService.Instance.AddNote(secondNote);
            Assert.AreEqual(true, NoteBookService.Instance[0].Equals(secondNote));
            NoteBookService.Instance.RemoveNote(secondNote);
            NoteBookService.Instance.AddNote(thirdNote);
            Assert.AreEqual(true, NoteBookService.Instance[0].Equals(thirdNote));
        }

        [Test]
        public void IViewBehaviourTests()
        {
            var mockViewer = new Mock<IView>();
            mockViewer.Setup(foo => foo.Render(It.IsAny<string>())).Verifiable();
            IView viewer = mockViewer.Object;
            viewer.Render("abc");
            mockViewer.Verify(foo => foo.Render("abc"), Times.Exactly(1));
        }
    }
}