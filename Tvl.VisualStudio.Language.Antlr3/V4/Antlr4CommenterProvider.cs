﻿namespace Tvl.VisualStudio.Language.AntlrV4
{
    using System;
    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Text.Operations;
    using Microsoft.VisualStudio.Utilities;
    using Tvl.VisualStudio.Text;

    [Export(typeof(ICommenterProvider))]
    [ContentType(Antlr4Constants.AntlrContentType)]
    public sealed class Antlr4CommenterProvider : ICommenterProvider
    {
        private static readonly LineCommentFormat LineCommentFormat = new LineCommentFormat("//");
        private static readonly BlockCommentFormat BlockCommentFormat = new BlockCommentFormat("/*", "*/");

        [Import]
        private ITextUndoHistoryRegistry TextUndoHistoryRegistry
        {
            get;
            set;
        }

        public ICommenter GetCommenter(ITextView textView)
        {
            Func<Commenter> factory = () => new Commenter(textView, TextUndoHistoryRegistry, LineCommentFormat, BlockCommentFormat);
            return textView.Properties.GetOrCreateSingletonProperty<Commenter>(factory);
        }
    }
}
