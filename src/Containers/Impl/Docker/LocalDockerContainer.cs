﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.R.Containers.Docker {
    public class LocalDockerContainer : IContainer {
        public string Id { get; set; }
    }
}
