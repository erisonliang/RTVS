﻿using System;
using Microsoft.Languages.Editor;
using Microsoft.VisualStudio.R.Package.Commands;

namespace Microsoft.VisualStudio.R.Package.Plots.Commands {
    internal sealed class ExportPlotCommand : PlotWindowCommand {
        public ExportPlotCommand(PlotWindowPane pane) :
            base(pane, RPackageCommandId.icmdExportPlot) {
        }

        public override CommandStatus Status(Guid group, int id) {
            return CommandStatus.Supported;
        }

        public override CommandResult Invoke(Guid group, int id, object inputArg, ref object outputArg) {
            return CommandResult.Executed;
        }
    }
}
