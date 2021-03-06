﻿using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Pixela.Extensions
{
    public static class TaskExtensions
    {
        public static ConfiguredTaskAwaitable<T> Stay<T>(this Task<T> obj)
        {
            return obj.ConfigureAwait(false);
        }
    }
}