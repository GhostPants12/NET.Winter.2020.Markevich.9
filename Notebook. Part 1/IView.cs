using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Part1
{
    public interface IView
    {
        /// <summary>Renders the specified note number to the console.</summary>
        /// <param name="noteNumber">The note number.</param>
        void Render(int noteNumber);

        /// <summary>Renders the specified note numbers to the console.</summary>
        /// <param name="noteNumbers">The note numbers.</param>
        void Render(params int[] noteNumbers);

        /// <summary>Renders the whole notebook to the console.</summary>
        void Render();
    }
}
