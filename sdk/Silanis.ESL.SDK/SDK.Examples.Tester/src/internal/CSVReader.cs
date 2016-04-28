using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDK.Examples.Internal
{
    internal class CsvReader
    {
        private readonly StreamReader _sr;
        private bool _hasNext = true;
        private bool _linesSkiped;
        private readonly char _escape;
        private readonly int _skipLines;
        private readonly char _quotechar;
        private readonly char _separator;

        public readonly int InitialReadSize = 64;
        public readonly char DefaultSeparator = ',';
        public readonly char DefaultQuoteCharacter = '"';
        public readonly char DefaultEscapeCharacter = '\\';
        public readonly int DefaultSkipLines = 0;

        internal CsvReader(StreamReader reader) {
            _sr = reader;
            _separator = DefaultSeparator;
            _quotechar = DefaultQuoteCharacter;
            _escape = DefaultEscapeCharacter;
            _skipLines = DefaultSkipLines;
        }

        internal CsvReader(StreamReader reader, char separator) {
            _sr = reader;
            _separator = separator;
            _quotechar = DefaultQuoteCharacter;
            _escape = DefaultEscapeCharacter;
            _skipLines = DefaultSkipLines;
        }

        internal CsvReader(StreamReader reader, char separator, char quotechar) {

            _sr = reader;
            _separator = separator;
            _quotechar = quotechar;
            _escape = DefaultEscapeCharacter;
            _skipLines = DefaultSkipLines;
        }

        internal CsvReader(StreamReader reader, char separator,
                         char quotechar, char escape) {
            _sr = reader;
            _separator = separator;
            _quotechar = quotechar;
            _escape = escape;
            _skipLines = DefaultSkipLines;
        }

        internal CsvReader(StreamReader reader, char separator, char quotechar, int line) {
            _sr = reader;
            _separator = separator;
            _quotechar = quotechar;
            _escape = DefaultEscapeCharacter;
            _skipLines = line;
        }

        internal CsvReader(StreamReader reader, char separator, char quotechar, char escape, int line) {
            _sr = reader;
            _separator = separator;
            _quotechar = quotechar;
            _escape = escape;
            _skipLines = line;
        }

        public IList<string[]> ReadAll() {

            var allElements = new List<string[]>();
            while (_hasNext) {
                var nextLineAsTokens = ReadNext();
                if (nextLineAsTokens != null)
                    allElements.Add(nextLineAsTokens);
            }
            return allElements;

        }

        public string[] ReadNext() {

            var nextLine = GetNextLine();
            return _hasNext ? ParseLine(nextLine) : null;
        }

        private string GetNextLine() {
            if (!_linesSkiped) {
                for (var i = 0; i < _skipLines; i++) {
                    _sr.ReadLine();
                }
                _linesSkiped = true;
            }
            var nextLine = _sr.ReadLine();
            if (nextLine == null) {
                _hasNext = false;
            }
            return _hasNext ? nextLine : null;
        }

        private string[] ParseLine(string nextLine) {

            if (nextLine == null) {
                return null;
            }

            var tokensOnThisLine = new List<string>();
            var sb = new StringBuilder(InitialReadSize);
            var inQuotes = false;
            do {
                if (inQuotes) {
                    // continuing a quoted section, reappend newline
                    sb.Append("\n");
                    nextLine = GetNextLine();
                    if (nextLine == null)
                        break;
                }
                for (var i = 0; i < nextLine.Length; i++) {

                    var c = nextLine[i];
                    if (c == _escape) {
                        if( IsEscapable(nextLine, inQuotes, i) ){ 
                            sb.Append(nextLine[i+1]);
                            i++;
                        } else {
                            i++; // ignore the escape
                        }
                    } else if (c == _quotechar) {
                        if( IsEscapedQuote(nextLine, inQuotes, i) ){ 
                            sb.Append(nextLine[i+1]);
                            i++;
                        }else{
                            inQuotes = !inQuotes;
                            // the tricky case of an embedded quote in the middle: a,bc"d"ef,g
                            if(i>2 //not on the beginning of the line
                               && nextLine[i-1] != _separator //not at the beginning of an escape sequence 
                               && nextLine.Length>(i+1) &&
                               nextLine[i+1] != _separator //not at the  end of an escape sequence
                               ){
                                sb.Append(c);
                            }
                        }
                    } else if (c == _separator && !inQuotes) {
                        tokensOnThisLine.Add(sb.ToString());
                        sb = new StringBuilder(InitialReadSize); // start work on next token
                    } else {
                        sb.Append(c);
                    }
                }
            } while (inQuotes);
            tokensOnThisLine.Add(sb.ToString());
            return tokensOnThisLine.ToArray();

        }

        private bool IsEscapable(string nextLine, bool inQuotes, int i) {
            return inQuotes  // we are in quotes, therefore there can be escaped quotes in here.
                && nextLine.Length > (i+1)  // there is indeed another character to check.
                    && ( nextLine[i+1] == _quotechar || nextLine[i+1] == _escape);
        }

        private bool IsEscapedQuote(string nextLine, bool inQuotes, int i) {
            return inQuotes  // we are in quotes, therefore there can be escaped quotes in here.
                && nextLine.Length > (i+1)  // there is indeed another character to check.
                    && nextLine[i+1] == _quotechar;
        }
    }
}

