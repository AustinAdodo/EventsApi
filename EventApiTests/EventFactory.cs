﻿using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApiTests
{
    public class EventFactory : WebApplicationFactory<Program>
    {
        public EventFactory()
        {
        }
    }
}
        