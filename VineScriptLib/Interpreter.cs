﻿using System.IO;
using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using VineScriptLib.Core;
using VineScriptLib.Compilers.LinesFormatter;
using VineScriptLib.Compilers.Vine;

namespace VineScriptLib
{
    public class Interpreter
    {                
        private VineStory story;

        public Interpreter(VineStory story)
        {
            this.story = story;
        }

        public string Execute(StreamReader istream)
        {
            return Execute(istream.ReadToEnd());
        }

        public string Execute(string vinecode)
        {
            // Print input
            Console.WriteLine(vinecode);

            // Remove whitespace at the start & end of each lines
            string wsRemoved = Compilers.Utils.RemoveWhiteSpace(vinecode);

            // Start timer
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Compile Vine code
            var vineCompiler = new VineCompiler();
            string parsed = vineCompiler.Parse(wsRemoved, story);

            // Formatting lines (removes empty lines containing Vine code)
            var formatCompiler = new LinesFormatterCompiler();
            string formatOutput = formatCompiler.FormatLines(wsRemoved, parsed);
            
            // Print before trimming whitespace
            Console.WriteLine(formatOutput);

            // Remove whitespace at the start & end of each lines (again)
            // TODO: keep only one space between words
            string finalOutput = Compilers.Utils.RemoveWhiteSpace(formatOutput);

            // Stop timer
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            
            // Finale output
            Console.WriteLine("### FORMATTED OUTPUT: ###");
            if (finalOutput.Length > 0)
                Console.WriteLine(finalOutput);
            Console.WriteLine("### END ###");

            // Timer output
            Console.WriteLine(string.Format("Time elapsed: {0} ms", elapsedMs.ToString("0.00")));

            return finalOutput;
        }

        public string Eval(StreamReader istream)
        {
            return Eval(istream.ReadToEnd());
        }

        public string Eval(string expr)
        {
            // Print input
            Console.WriteLine(expr);

            // Remove whitespace at the start & end of each lines
            string wsRemoved = Compilers.Utils.RemoveWhiteSpace(expr);

            // Start timer
            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Compile Vine code
            var vineCompiler = new VineCompiler();
            string parsed = vineCompiler.Eval(wsRemoved, story);
            
            // Remove whitespace at the start & end of each lines (again)
            // TODO: keep only one space between words
            string finalOutput = Compilers.Utils.RemoveWhiteSpace(parsed);

            // Stop timer
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            
            // Finale output
            Console.WriteLine("### FORMATTED OUTPUT: ###");
            if (finalOutput.Length > 0)
                Console.WriteLine(finalOutput);
            Console.WriteLine("### END ###");

            // Timer output
            Console.WriteLine(string.Format("Time elapsed: {0} ms", elapsedMs.ToString("0.00")));

            return finalOutput;
        }
    }
}
