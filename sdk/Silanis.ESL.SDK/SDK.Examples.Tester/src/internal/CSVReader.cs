using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDK.Examples
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

        public readonly int INITIAL_READ_SIZE = 64;
        public readonly char DEFAULT_SEPARATOR = ',';
        public readonly char DEFAULT_QUOTE_CHARACTER = '"';
        public readonly char DEFAULT_ESCAPE_CHARACTER = '\\';
        public readonly int DEFAULT_SKIP_LINES = 0;

        internal CsvReader(StreamReader reader) {
            _sr = reader;
            _separator = DEFAULT_SEPARATOR;
            _quotechar = DEFAULT_QUOTE_CHARACTER;
            _escape = DEFAULT_ESCAPE_CHARACTER;
            _skipLines = DEFAULT_SKIP_LINES;
        }

        internal CsvReader(StreamReader reader, char separator) {
            _sr = reader;
            this._separator = separator;
            _quotechar = DEFAULT_QUOTE_CHARACTER;
            _escape = DEFAULT_ESCAPE_CHARACTER;
            _skipLines = DEFAULT_SKIP_LINES;
        }

        internal CsvReader(StreamReader reader, char separator, char quotechar) {

            _sr = reader;
            this._separator = separator;
            this._quotechar = quotechar;
            _escape = DEFAULT_ESCAPE_CHARACTER;
            _skipLines = DEFAULT_SKIP_LINES;
        }

        internal CsvReader(StreamReader reader, char separator,
                         char quotechar, char escape) {
            _sr = reader;
            this._separator = separator;
            this._quotechar = quotechar;
            this._escape = escape;
            _skipLines = DEFAULT_SKIP_LINES;
        }

        internal CsvReader(StreamReader reader, char separator, char quotechar, int line) {
            _sr = reader;
            this._separator = separator;
            this._quotechar = quotechar;
            _escape = DEFAULT_ESCAPE_CHARACTER;
            _skipLines = line;
        }

        internal CsvReader(StreamReader reader, char separator, char quotechar, char escape, int line) {
            _sr = reader;
            this._separator = separator;
            this._quotechar = quotechar;
            this._escape = escape;
            _skipLines = line;
        }

        public IList<string[]> readAll() {

            var allElements = new List<string[]>();
            while (_hasNext) {
                var nextLineAsTokens = readNext();
                if (nextLineAsTokens != null)
                    allElements.Add(nextLineAsTokens);
            }
            return allElements;

        }

        public string[] readNext() {

            var nextLine = getNextLine();
            return _hasNext ? parseLine(nextLine) : null;
        }

        private string getNextLine() {
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

        private string[] parseLine(string nextLine) {

            if (nextLine == null) {
                return null;
            }

            var tokensOnThisLine = new List<string>();
            var sb = new StringBuilder(INITIAL_READ_SIZE);
            var inQuotes = false;
            do {
                if (inQuotes) {
                    // continuing a quoted section, reappend newline
                    sb.Append("\n");
                    nextLine = getNextLine();
                    if (nextLine == null)
                        break;
                }
                for (var i = 0; i < nextLine.Length; i++) {

                    var c = nextLine[i];
                    if (c == _escape) {
                        if( isEscapable(nextLine, inQuotes, i) ){ 
                            sb.Append(nextLine[i+1]);
                            i++;
                        } else {
                            i++; // ignore the escape
                        }
                    } else if (c == _quotechar) {
                        if( isEscapedQuote(nextLine, inQuotes, i) ){ 
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
                    && ( nextLine[i+1] == _quotechar || nextLine[i+1] == _escape);
        }

        private bool isEscapedQuote(string nextLine, bool inQuotes, int i) {
            return inQuotes  // we are in quotes, therefore there can be escaped quotes in here.
                && nextLine.Length > (i+1)  // there is indeed another character to check.
                    && nextLine[i+1] == _quotechar;
        }
    }
}

