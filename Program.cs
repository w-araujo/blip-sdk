﻿using System;
using Take.Blip.Client.Console;

namespace Blip_sdk
{
    class Program
    {
        static int Main(string[] args) => ConsoleRunner.RunAsync(args).GetAwaiter().GetResult();
    }
}