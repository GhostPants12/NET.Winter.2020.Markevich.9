using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Part1
{
    internal class NoteBookRenderer
    {
        private readonly NoteRenderer noteRenderer = new NoteRenderer();

        public void RenderNote(Note note) => this.noteRenderer.RenderNote(note);

        /// <summary>Renders the notes to the console.</summary>
        /// <param name="noteBook">The notebook to take notes from.</param>
        /// <param name="numbers">The numbers of notes to render.</param>
        public void RenderNotes(NoteBook noteBook, params int[] numbers)
        {
            foreach (var number in numbers)
            {
                this.noteRenderer.Render($"Note #{number}");
                this.noteRenderer.RenderNote(noteBook[number]);
            }
        }

        /// <summary>Renders the notebook to the console.</summary>
        /// <param name="noteBook">The notebook.</param>
        public void RenderNoteBook(NoteBook noteBook)
        {
            this.noteRenderer.Render(noteBook.ToString());
        }
    }
}
