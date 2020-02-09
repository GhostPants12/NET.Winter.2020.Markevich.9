using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Notebook.Part1
{
    public class NoteBook
    {
        private List<Note> noteList;

        /// <summary>Initializes a new instance of the <see cref="NoteBook"/> class.</summary>
        public NoteBook()
        {
            this.noteList = new List<Note>();
        }

        /// <summary>Gets the <see cref="Note"/> at the specified index.</summary>
        /// <param name="index">The index.</param>
        /// <value>The <see cref="Note"/>.</value>
        /// <returns><see cref="Note"/> at the specified index.</returns>
        public Note this[int index]
        {
            get
            {
                if (index >= 0 && index <= this.noteList.Count)
                {
                    return this.noteList[index];
                }

                return null;
            }
        }

        /// <summary>Adds note to the notebook.</summary>
        /// <param name="note">The note to add.</param>
        public void Add(Note note) => this.noteList.Add(note);

        /// <summary>Removes the specified note from the notebook.</summary>
        /// <param name="note">The note to remove.</param>
        public void Remove(Note note) => this.noteList.Remove(note);

        /// <summary>Removes the note at the specified position.</summary>
        /// <param name="position">The position.</param>
        public void RemoveAt(int position) => this.noteList.RemoveAt(position);

        /// <summary>Sorts this instance.</summary>
        public void Sort() => this.noteList.Sort();

        /// <summary>Converts notebook to string.</summary>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public override string ToString()
        {
            StringBuilder noteBookAsString = new StringBuilder();
            int noteCounter = 0;
            foreach (Note note in this.noteList)
            {
                noteBookAsString.Append($"Note #{noteCounter}\n");
                noteCounter++;
                noteBookAsString.Append(note.ToString());
            }

            return noteBookAsString.ToString();
        }
    }
}
