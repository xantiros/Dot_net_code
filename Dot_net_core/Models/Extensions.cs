﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dot_net_core.Models
{
    static class Extensions
    {
        public static bool Empty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        public static bool NotEmpty(this string value)
        {
            return !value.Empty();
        }
    }
}
