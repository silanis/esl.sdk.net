using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDK.Examples
{
    internal class CSVReader
    {
        private StreamReader sr;
        private bool hasNext = true;
        private bool linesSkiped;
        private readonly char escape;
        private int skipLines;
        private readonly char quotechar;
        private readonly char separator;

        public readonly int INITIAL_READ_SIZE = 64;
        public readonly char DEFAULT_SEPARATOR = ',';
        public readonly char DEFAULT_QUOTE_CHARACTER = '"';
        public readonly char DEFAULT_ESCAPE_CHARACTER = '\\';
        public readonly int DEFAULT_SKIP_LINES = 0;

        internal CSVReader(StreamReader reader) {
            this.sr = reader;
            this.separator = DEFAULT_SEPARATOR;
            this.quotechar = DEFAULT_QUOTE_CHARACTER;
            this.escape = DEFAULT_ESCAPE_CHARACTER;
            this.skipLines = DEFAULT_SKIP_LINES;
        }

        internal CSVReader(StreamReader reader, char separator) {
            this.sr = reader;
            this.separator = separator;
            this.quotechar = DEFAULT_QUOTE_CHARACTER;
            this.escape = DEFAULT_ESCAPE_CHARACTER;
            this.skipLines = DEFAULT_SKIP_LINES;
        }

        internal CSVReader(StreamReader reader, char separator, char quotechar) {

            this.sr = reader;
            this.separator = separator;
            this.quotechar = quotechar;
            this.escape = DEFAULT_ESCAPE_CHARACTER;
            this.skipLines = DEFAULT_SKIP_LINES;
        }

        internal CSVReader(StreamReader reader, char separator,
                         char quotechar, char escape) {
            this.sr = reader;
            this.separator = separator;
            this.quotechar = quotechar;
            this.escape = escape;
            this.skipLines = DEFAULT_SKIP_LINES;
        }

        internal CSVReader(StreamReader reader, char separator, char quotechar, int line) {
            this.sr = reader;
            this.separator = separator;
            this.quotechar = quotechar;
            this.escape = DEFAULT_ESCAPE_CHARACTER;
            this.skipLines = line;
        }

        internal CSVReader(StreamReader reader, char separator, char quotechar, char escape, int line) {
            this.sr = reader;
            this.separator = separator;
            this.quotechar = quotechar;
            this.escape = escape;
            this.skipLines = line;
        }

        public IList<string[]> readAll() {

            List<string[]> allElements = new List<string[]>();
            while (hasNext) {
                string[] nextLineAsTokens = readNext();
                if (nextLineAsTokens != null)
                    allElements.Add(nextLineAsTokens);
            }
            return allElements;

        }

        public string[] readNext() {

            string nextLine = getNextLine();
            return hasNext ? parseLine(nextLine) : null;
        }

        private string getNextLine() {
            if (!this.linesSkiped) {
                for (int i = 0; i < skipLines; i++) {
                    sr.ReadLine();
                }
                this.linesSkiped = true;
            }
            string nextLine = sr.ReadLine();
            if (nextLine == null) {
                hasNext = false;
            }
            return hasNext ? nextLine : null;
        }

        private string[] parseLine(string nextLine) {

            if (nextLine == null) {
                return null;
            }

            List<string> tokensOnThisLine = new List<string>();
            StringBuilder sb = new StringBuilder(INITIAL_READ_SIZE);
            bool inQuotes = false;
            do {
                if (inQuotes) {
                    // continuing a quoted section, reappend newline
                    sb.Append("\n");
                    nextLine = getNextLine();
                    if (nextLine == null)
                        break;
                }
                for (int i = 0; i < nextLine.Length; i++) {

                    char c = nextLine[i];
                    if (c == this.escape) {
                        if( isEscapable(nextLine, inQuotes, i) ){ 
                            sb.Append(nextLine[i+1]);
                            i++;
                        } else {
                            i++; // ignore the escape
                        }
                    } else if (c == quotechar) {
                        if( isEscapedQuote(nextLine, inQuotes, i) ){ 
                            sb.Append(nextLine[i+1]);
                            i++;
                        }else{
                            inQuotes = !inQuotes;
                            // the tricky case of an embedded quote in the middle: a,bc"d"ef,g
                            if(i>2 //not on the beginning of the line
                               && nextLine[i-1] != this.separator //not at the beginning of an escape sequence 
                               && nextLine.Length>(i+1) &&
                               nextLine[i+1] != this.separator //not at the  end of an escape sequence
                               ){
                                sb.Append(c);
                            }
                        }
                    } else if (c == separator && !inQuotes) {
                        tokensOnThisLine.Add(sb.ToString());
                        sb = new StringBuilder(INITIAL_READ_SIZE); // start work on next token
                    } else {
                        sb.Append(c);
                    }
                }
            } while (inQuotes);
            tokensOnThisLine.Add(sb.ToString());
            return tokensOnThisLine.ToArray();

        }

        private bool isEscapable(string nextLine, bool inQuotes, int i) {
            return inQuotes  // we are in quotes, therefore there can be escaped quotes in here.
                && nextLine.Length > (i+1)  // there is indeed another character to check.
                    && ( nextLine[i+1] == quotechar || nextLine[i+1] == this.escape);
        }

        private bool isEscapedQuote(string nextLine, bool inQuotes, int i) {
            return inQuotes  // we are in quotes, therefore there can be escaped quotes in here.
                && nextLine.Length > (i+1)  // there is indeed another character to check.
                    && nextLine[i+1] == quotechar;
        }
    }
}

