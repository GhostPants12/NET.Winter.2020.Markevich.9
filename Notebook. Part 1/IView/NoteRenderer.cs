using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Part1
{
    public class NoteRenderer : IView
    {
        /// <summary>Renders data to the console.</summary>
        /// <param name="dataToRender">Some string to render to the console.</param>
        public void Render(string dataToRender)
        {
            Console.WriteLine();
        }

        /// <summary>Renders the notes to the console.</summary>
        /// <param name="note">The note to render.</param>
        public void RenderNote(Note note)
        {
            this.Render(note.ToString());
        }

    }
}
