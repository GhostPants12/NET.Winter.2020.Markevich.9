using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Notebook.Part1
{
    public sealed class NoteBookService : IView
    {
        private static NoteBookService instance;
        private NoteBook noteBook;

        /// <summary>Initializes static members of the <see cref="NoteBookService"/> class.</summary>
        static NoteBookService()
        {
            instance = new NoteBookService();
        }

        /// <summary>Prevents a default instance of the <see cref="NoteBookService"/> class from being created.</summary>
        private NoteBookService()
        {
            this.noteBook = new NoteBook();
        }

        /// <summary>Gets the instance of NoteBookService class.</summary>
        /// <value>The instance.</value>
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

        /// <summary>Renders note with the specified number to the console.</summary>
        /// <param name="noteNumber">The note number.</param>
        public void Render(int noteNumber)
        {
            Console.WriteLine($"Note #{noteNumber}");
            Console.WriteLine(this[noteNumber].ToString());
        }

        /// <summary>Renders note with the specified numbers to the console.</summary>
        /// <param name="noteNumbers">The note numbers.</param>
        public void Render(params int[] noteNumbers)
        {
            for (int i = 0; i < noteNumbers.Length; i++)
            {
                Console.WriteLine($"Note #{noteNumbers[i]}");
                Console.WriteLine(this[noteNumbers[i]].ToString());
            }
        }

        /// <summary>Renders all the notes in notebook to the console.</summary>
        public void Render()
        {
            Console.WriteLine(this.noteBook.ToString());
        }
    }
}
