﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Markdown.Editor.Test;

namespace Microsoft.R.Editor.Application.Test.Fixtures {
    // Fixture doesn't import itself. Use AssemblyFixtureImportAttribute
    [ExcludeFromCodeCoverage]
    public class REditorApplicationServicesFixture : MarkdownEditorServicesFixture {
        protected override IEnumerable<string> GetAssemblyNames() => base.GetAssemblyNames().Concat(new[] {
            "Microsoft.Languages.Editor.Application.dll",
            "Microsoft.R.Editor.Application.Test.dll"
        });
    }
}