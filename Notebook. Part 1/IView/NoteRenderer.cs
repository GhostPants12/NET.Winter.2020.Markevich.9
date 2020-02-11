using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Part1
{
    internal class NoteRenderer : IView
    {
        /// <summary>Renders data to the console.</summary>
        /// <param name="dataToRender">Some string to render to the console.</param>
        public void Render(string dataToRender)
        {
            Console.WriteLine();
        }

        /// <summary>Renders the notes to the console.</summary>
        /// <param name="noteBook">The notebook to take notes from.</param>
        /// <param name="numbers">The numbers of notes to render.</param>
        public void RenderNote(Note note)
        {
            this.Render(note.ToString());
        }

    }
}
