using System;
using System.Collections.Generic;
using System.Text;

namespace Notebook.Part1
{
    public interface IView
    {
        /// <summary>Renders data to the console.</summary>
        /// <param name="dataToRender">Some string to render to the console.</param>
        void Render(string dataToRender);
    }
}
