using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Notebook.Part1
{
    public sealed class NoteBookService
    {
        private static readonly NoteBookService instance;
        private readonly NoteBookRenderer renderer;
        private readonly NoteBook noteBook;

        /// <summary>Initializes static members of the <see cref="NoteBookService"/> class.</summary>
        static NoteBookService()
        {
            instance = new NoteBookService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteBookService"/> class.Prevents a default Instance of the <see cref="NoteBookService"/> class from being created.</summary>
        private NoteBookService()
        {
            this.noteBook = new NoteBook();
            this.renderer = new NoteBookRenderer();
        }

        /// <summary>Gets the Instance of NoteBookService class.</summary>
        /// <value>The Instance.</value>
        public static NoteBookService Instance
        {
            get => instance;
        }

        /// <summary>Gets the <see cref="Note"/> at the specified index.</summary>
        /// <param name="index">The index.</param>
        /// <value>The <see cref="Note"/>.</value>
        /// <returns><see cref="Note"/> at the index.</returns>
        public Note this[int index] => this.noteBook[index];

        /// <summary>Adds the note.</summary>
        /// <param name="note">The note.</param>
        public void AddNote(Note note) => this.noteBook.Add(note);

        /// <summary>Removes the note.</summary>
        /// <param name="note">The note.</param>
        public void RemoveNote(Note note) => this.noteBook.Remove(note);

        /// <summary>Removes the note at some position.</summary>
        /// <param name="pos">The position.</param>
        public void RemoveNoteAt(int pos) => this.noteBook.RemoveAt(pos);

        /// <summary>Sorts the note book.</summary>
        public void SortNoteBook() => this.noteBook.Sort();

        public void RenderNote(int pos) => this.renderer.RenderNotes(this.noteBook, pos);

        public void RenderNotes(params int[] positions) => this.renderer.RenderNotes(this.noteBook, positions);

        public void RenderNoteBook() => this.renderer.RenderNoteBook(this.noteBook);
    }
}
