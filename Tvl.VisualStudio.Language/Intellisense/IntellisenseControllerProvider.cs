﻿namespace Tvl.VisualStudio.Language.Intellisense
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.Language.Intellisense;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Editor;
    using IVsEditorAdaptersFactoryService = Microsoft.VisualStudio.Editor.IVsEditorAdaptersFactoryService;

    public class IntellisenseControllerProvider : IIntellisenseControllerProvider
    {
        [Import]
        public IVsEditorAdaptersFactoryService EditorAdaptersFactoryService
        {
            get;
            private set;
        }

        [Import]
        public IIntellisenseSessionStackMapService IntellisenseSessionStackMapService
        {
            get;
            private set;
        }

        [Import]
        public ICompletionBroker CompletionBroker
        {
            get;
            private set;
        }

        [Import]
        public ISignatureHelpBroker SignatureHelpBroker
        {
            get;
            private set;
        }

        [Import]
        public IQuickInfoBroker QuickInfoBroker
        {
            get;
            private set;
        }

        [Import]
        public ISmartTagBroker SmartTagBroker
        {
            get;
            private set;
        }

        IIntellisenseController IIntellisenseControllerProvider.TryCreateIntellisenseController(ITextView textView, IList<ITextBuffer> subjectBuffers)
        {
            IntellisenseController controller = TryCreateIntellisenseController(textView, subjectBuffers);
            if (controller != null)
            {
                List<IntellisenseController> controllers = textView.Properties.GetOrCreateSingletonProperty<List<IntellisenseController>>(typeof(IntellisenseController), () => new List<IntellisenseController>());
                controllers.Add(controller);
            }

            return controller;
        }

        protected virtual IntellisenseController TryCreateIntellisenseController(ITextView textView, IList<ITextBuffer> subjectBuffers)
        {
            IntellisenseController controller = new IntellisenseController(textView, this);
            return controller;
        }
    }
}
