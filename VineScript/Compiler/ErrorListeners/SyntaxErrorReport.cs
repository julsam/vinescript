﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace VineScript.Compiler
{
    public struct SyntaxErrorReport
    {
        public string Filename { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public IToken OffendingSymbol { get; set; }
        public string FullMessage { get; set; }
        public string ErrorMessage { get; set; }
        public string Underline { get; set; }

        public SyntaxErrorReport(string filename, int line, int column, 
            IToken offendingSymbol, string message, string errorMsg, string underline)
        {
            this.Filename = filename;
            this.Line = line;
            this.Column = column;
            this.OffendingSymbol = offendingSymbol;
            this.FullMessage = message;
            this.ErrorMessage = errorMsg;
            this.Underline = underline;
        }
    }
}
