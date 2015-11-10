﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Languages.Editor.Controller;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.R.Package.Commands;
using Microsoft.VisualStudio.R.Package.Interop;
using Microsoft.VisualStudio.R.Package.Shell;
using Microsoft.VisualStudio.R.Package.Utilities;
using Microsoft.VisualStudio.R.Packages.R;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace Microsoft.VisualStudio.R.Package.Help {
    [Guid(WindowGuid)]
    internal class HelpWindowPane : ToolWindowPane {
        internal const string WindowGuid = "9E909526-A616-43B2-A82B-FD639DCD40CB";

        private WebBrowser _browser;

        public HelpWindowPane() {
            Caption = Resources.HelpWindowCaption;
            BitmapImageMoniker = KnownMonikers.StatusHelp;

            _browser = new WebBrowser();
            _browser.Navigated += OnNavigated;

            Content = _browser;
            NavigateTo(HelpHomeCommand.HomeUrl);

            this.ToolBar = new CommandID(RGuidList.RCmdSetGuid, RPackageCommandId.helpWindowToolBarId);
            Controller c = new Controller();
            c.AddCommandSet(GetCommands());
            this.ToolBarCommandTarget = new CommandTargetToOleShim(null, c);
        }

        private void OnNavigated(object sender, NavigationEventArgs e) {
            IVsUIShell shell = AppShell.Current.GetGlobalService<IVsUIShell>(typeof(SVsUIShell));
            shell.UpdateCommandUI(1);
        }

        public void NavigateTo(string url) {
            if (_browser != null) {
                _browser.Navigate(url);
            }
        }

        public static void Navigate(string url) {
            HelpWindowPane pane = ToolWindowUtilities.ShowWindowPane<HelpWindowPane>(0, focus: false);
            if (pane != null) {
                pane.NavigateTo(url);
            }
        }

        private IEnumerable<ICommand> GetCommands() {
            List<ICommand> commands = new List<ICommand>() {
                new HelpPreviousCommand(_browser),
                new HelpNextCommand(_browser),
                new HelpHomeCommand(_browser),
                new HelpRefreshCommand(_browser)
            };
            return commands;
        }

        protected override void Dispose(bool disposing) {
            if (disposing && _browser != null) {
                _browser.Navigated -= OnNavigated;
                _browser.Dispose();
                _browser = null;
            }
            base.Dispose(disposing);
        }
    }
}
