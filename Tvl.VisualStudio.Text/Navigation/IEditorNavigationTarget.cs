﻿namespace Tvl.VisualStudio.Text.Navigation
{
    using System.Windows.Media;
    using Microsoft.VisualStudio.Text;

    public interface IEditorNavigationTarget
    {
        IEditorNavigationType EditorNavigationType
        {
            get;
        }

        string Name
        {
            get;
        }

        ImageSource Glyph
        {
            get;
        }

        SnapshotSpan Seek
        {
            get;
        }

        SnapshotSpan Span
        {
            get;
        }
    }
}
