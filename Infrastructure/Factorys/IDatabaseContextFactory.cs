﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Factorys
{
    public interface IDatabaseContextFactory
    {
        IDatabaseContext Context();
    }
}
