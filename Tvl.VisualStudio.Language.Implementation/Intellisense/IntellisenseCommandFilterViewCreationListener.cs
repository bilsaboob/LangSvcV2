﻿namespace Tvl.VisualStudio.Language.Intellisense.Implementation
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Utilities;
    using IVsEditorAdaptersFactoryService = Microsoft.VisualStudio.Editor.IVsEditorAdaptersFactoryService;
    using IVsTextView = Microsoft.VisualStudio.TextManager.Interop.IVsTextView;
    using IVsTextViewCreationListener = Microsoft.VisualStudio.Editor.IVsTextViewCreationListener;

    [Export(typeof(IVsTextViewCreationListener))]
    [ContentType("text")]
    [Order]
    [TextViewRole(PredefinedTextViewRoles.Interactive)]
    [Name("IntellisenseCommandFilterViewCreationListener")]
    internal class IntellisenseCommandFilterViewCreationListener : IVsTextViewCreationListener
    {
        [Import]
        public IVsEditorAdaptersFactoryService EditorAdaptersFactoryService
        {
            get;
            private set;
        }

        void IVsTextViewCreationListener.VsTextViewCreated(IVsTextView textViewAdapter)
        {
            ITextView textView = EditorAdaptersFactoryService.GetWpfTextView(textViewAdapter);
            if (textView != null)
            {
                List<IntellisenseController> controllers;
                if (textView.Properties.TryGetProperty<List<IntellisenseController>>(typeof(IntellisenseController), out controllers))
                {
                    foreach (var controller in controllers)
                        controller.OnVsTextViewCreated(textViewAdapter);
                }
            }
        }
    }
}
