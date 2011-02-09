using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FXBC
{
    // Use this class to split script text into lines
    /* Syntax:
     * Comments as in C++/C#.
     * \ continues current line to next line.
     */
    class ScriptParser
    {
        // State of parser during parsing of single line
        private enum State
        {
            Normal,
            AfterSlash,
            AfterBackSlash,
            InsideSingleLineComment,
            InsideMultiLineComment,
            InsideMultiLineCommentAfterAsterisk
        }

        // Error message with syntax error
        private const string SYNTAX_MSG = "Syntax error in row {0}.";

        // Text to parse
        private string m_Text;
        // Current position in m_Text
        private int m_Pos;
        // Row number of current position
        private int m_RowNumber;

        // Creates and initializes parser
        public ScriptParser(string Text)
        {
            m_Text = Text;
            m_Pos = 0;
            m_RowNumber = 1;
        }

        // Returns true if parser reached end of parsed text
        public bool IsEnd()
        {
            return m_Pos >= m_Text.Length;
        }

        // Returns next parsed line of script
        // Yu must be sure we are not at the end of text to call this method!
        // Returns also empty lines.
        public void GetNextLine(out string Line, out int RowNumber)
        {
            State S = State.Normal;

            RowNumber = m_RowNumber;

            StringBuilder SB = new StringBuilder();
            char Ch;

            for (; ; )
            {
                // We reached the end
                if (IsEnd())
                {
                    // We are after '/'
                    if (S == State.AfterSlash)
                    {
                        SB.Append('/');
                        break;
                    }
                    // State is invalid for end
                    else if (S == State.AfterBackSlash || S == State.InsideMultiLineComment || S == State.InsideMultiLineCommentAfterAsterisk)
                        throw new Exception(string.Format(SYNTAX_MSG, m_RowNumber));
                    // State is OK for end
                    else
                        break;
                }

                // Read character
                Ch = m_Text[m_Pos++];

                if (Ch == '\r')
                {
                    // Ignore
                }
                else if (Ch == '\n')
                {
                    // Just end of line
                    if (S == State.Normal || S == State.InsideSingleLineComment)
                    {
                        m_RowNumber++;
                        break;
                    }
                    // Append pending '/' and and of line
                    else if (S == State.AfterSlash)
                    {
                        SB.Append('/');
                        m_RowNumber++;
                        break;
                    }
                    else if (S == State.AfterBackSlash)
                    {
                        // Ignore! - and switch to normal state
                        S = State.Normal;
                    }
                    else if (S == State.InsideMultiLineComment || S == State.InsideMultiLineCommentAfterAsterisk)
                    {
                        // Completely ignore.
                    }
                }
                else
                {
                    if (S == State.InsideMultiLineCommentAfterAsterisk)
                    {
                        // End of multiline comment
                        if (Ch == '/')
                            S = State.Normal;
                        // Just '*' and something new inside multiline comment - ignore
                    }
                    else if (S == State.InsideMultiLineComment)
                    {
                        if (Ch == '*')
                            S = State.InsideMultiLineCommentAfterAsterisk;
                    }
                    else if (S == State.InsideSingleLineComment)
                    {
                        // Ignore.
                    }
                    else if (S == State.AfterBackSlash)
                    {
                        // Add pending backslash and new char
                        SB.Append('\\');
                        SB.Append(Ch);
                        S = State.Normal;
                    }
                    else if (S == State.AfterSlash)
                    {
                        // Begin of single line comment
                        if (Ch == '/')
                            S = State.InsideSingleLineComment;
                        else if (Ch == '*')
                            S = State.InsideMultiLineComment;
                        // Just '/' and something - append that
                        else
                        {
                            SB.Append('/');
                            SB.Append(Ch);
                            S = State.Normal;
                        }
                    }
                    else // S == State.Normal
                    {
                        if (Ch == '/')
                            S = State.AfterSlash;
                        else if (Ch == '\\')
                            S = State.AfterBackSlash;
                        else
                            SB.Append(Ch);
                    }
                }
            }

            Line = SB.ToString();
        }
    }

    // Parses single line of script to extract command data such as source and destination file name
    class ScriptLineParser
    {
        // Text to parse
        private string m_Text;
        // Current position in m_Text
        int m_Pos;

        // Creates and initializes parser
        private ScriptLineParser(string Line)
        {
            m_Text = Line;
            m_Pos = 0;
        }

        // Returns true if parser reached end of parsed text
        public bool IsEnd() { return m_Pos >= m_Text.Length; }

        // Returns next token, like (aabbcc) or ("aa bb cc")
        // Tokens are parsed in similar way that Windows command line splits command into argument list.
        public string GetNextToken()
        {
            StringBuilder SB = new StringBuilder();
            char Ch;
            bool InsideQuotes = false;
            bool WasBackSlash = false;

            while (!IsEnd())
            {
                Ch = m_Text[m_Pos++];

                if (Ch == '"')
                {
                    if (WasBackSlash)
                    {
                        SB.Append('"');
                        WasBackSlash = false;
                    }
                    else
                        InsideQuotes = !InsideQuotes;
                }
                else if (Ch == '\\')
                {
                    if (WasBackSlash)
                    {
                        SB.Append("\\\\");
                        WasBackSlash = false;
                    }
                    else
                        WasBackSlash = true;
                }
                else if (Ch == ' ' || Ch == '\t')
                {
                    if (WasBackSlash)
                    {
                        SB.Append('\\');
                        WasBackSlash = false;
                    }
                    if (InsideQuotes)
                        SB.Append(Ch);
                    else
                        // end of parsing this token
                        break;
                }
                // other char
                else
                {
                    if (WasBackSlash)
                    {
                        SB.Append('\\');
                        WasBackSlash = false;
                    }
                    SB.Append(Ch);
                }
            }

            if (WasBackSlash)
                SB.Append('\\');
            return SB.ToString();
        }

        // State of parser during parsing of script line
        private enum ParsingState
        {
            Normal,
            ExpectingIgnoredParameter,
            ExpectingDestFileTxt,
            ExpectingDestFileBin
        }

        // Parses given line of script
        // Returns true if managed to obtain all output parameters correctly.
        // Doesn't throw exceptions.
        // If returned false, output parameters are undefined.
        public static bool ParseLine(string Line, out string SrcFile, out string DestFile, out bool IsDestFileText)
        {
            ScriptLineParser P = new ScriptLineParser(Line);

            ParsingState S = ParsingState.Normal;
            string Token, TokenL;

            SrcFile = "";
            DestFile = "";
            IsDestFileText = false;

            // Whether input file name is already found
            bool SrcFound = false;
            // Whether output file name and type s already found
            bool DestFound = false;

            while (!P.IsEnd())
            {
                Token = P.GetNextToken();
                Token = Token.Trim();

                if (Token.Length > 0)
                {
                    // We are not expecting anything particular here - just next parameter
                    if (S == ParsingState.Normal)
                    {
                        if (Token[0] == '/')
                        {
                            TokenL = Token.ToLower();
                            if (TokenL == "/fo")
                                S = ParsingState.ExpectingDestFileBin;
                            else if (TokenL == "/fc" || TokenL == "/fx" || TokenL == "/fh" || TokenL == "/p")
                                S = ParsingState.ExpectingDestFileTxt;
                            else if (TokenL == "/t" || TokenL == "/e" || TokenL == "/i" || TokenL == "/d" || TokenL == "/vn")
                                S = ParsingState.ExpectingIgnoredParameter;
                            else if (TokenL.StartsWith("/fo"))
                            {
                                if (!DestFound)
                                {
                                    DestFile = Token.Substring(3);
                                    IsDestFileText = false;
                                    DestFound = true;
                                }
                                // Second dest name
                                else
                                    return false;
                            }
                            else if (TokenL.StartsWith("/fc") || TokenL.StartsWith("/fx") || TokenL.StartsWith("/fh"))
                            {
                                if (!DestFound)
                                {
                                    DestFile = Token.Substring(3);
                                    IsDestFileText = true;
                                    DestFound = true;
                                }
                                // Second dest name
                                else
                                    return false;
                            }
                            else if (TokenL.StartsWith("/p"))
                            {
                                if (!DestFound)
                                {
                                    DestFile = Token.Substring(3);
                                    IsDestFileText = true;
                                    DestFound = true;
                                }
                                // Second dest name
                                else
                                    return false;
                            }
                            else if (TokenL.StartsWith("/t") || TokenL.StartsWith("/e") || TokenL.StartsWith("/i") || TokenL.StartsWith("/d") || TokenL.StartsWith("/vn"))
                            {
                                // Ignore.
                            }
                        }
                        // Input file name
                        else
                        {
                            if (!SrcFound)
                            {
                                SrcFile = Token;
                                SrcFound = true;
                            }
                            // Second source file name
                            else
                                return false;
                        }
                    }
                    // We are expecting something
                    else
                    {
                        if (S == ParsingState.ExpectingDestFileBin)
                        {
                            if (!DestFound)
                            {
                                DestFile = Token;
                                IsDestFileText = false;
                                DestFound = true;
                            }
                            // Second dest name
                            else
                                return false;
                        }
                        else if (S == ParsingState.ExpectingDestFileTxt)
                        {
                            if (!DestFound)
                            {
                                DestFile = Token;
                                IsDestFileText = true;
                                DestFound = true;
                            }
                            // Second dest name
                            else
                                return false;
                        }
                        // ExpectingIgnoredParameter - just ignore.
                        S = ParsingState.Normal;
                    }
                }
            }

            return (SrcFound && DestFound);
        }
    }

    // This structure represents single compilation task as parsed from script
    // Objects of this class are attached to ListView items' Tag property.
    class Task
    {
        // Row number in script text
        public int Row;
        // Full script line - compilation parameters
        public string Parameters;
        // Name of source file, relative or absolute; "" if not known
        public string SrcFile;
        // Name of destination file, relative or absolute; "" if not known
        public string DestFile;
        // True if parameters indicate that destination file is going to be text file, not binary
        public bool IsDestFileText;
        // Last write time of source file; DateTime.MinValue if not known
        public DateTime SrcFileTime;
        // Last write time of destination file; DateTime.MinValue if not known
        public DateTime DestFileTime;
        // Compilation report; "" if empty
        public string Output;

        public Task(int Row, string Parameters, string SrcFile, string DestFile, bool IsDestFileText)
        {
            this.Row = Row;
            this.Parameters = Parameters;
            this.SrcFile = SrcFile;
            this.DestFile = DestFile;
            this.IsDestFileText = IsDestFileText;
            this.SrcFileTime = DateTime.MinValue;
            this.DestFileTime = DateTime.MinValue;
            this.Output = "";
        }
    }

    // Represents current application document
    /* Document consists of:
     * - Script text kept in the ScriptTextbox (this class has reference to that textbox).
     * - Generated tasks, kept in ListView1 (this class has reference to that ListView).
     * Modified status of the document is the modified status of script textbox.
     */
    class Document
    {
        // File name of script with full path
        private string m_FileName;
        // Reference to textbox with script
        private TextBox m_ScriptTextBox;
        // Reference to listview with tasks
        private ListView m_ListView1;
        // True if current script is parsed successfully and tasks are generated from it
        // Set when tasks are generated on user's demand (switching to Build tab).
        // Reset when user changes script.
        private bool m_TasksGenerated;

        // Creates new, empty document
        public Document(TextBox ScriptTextBox, ListView ListView1)
        {
            m_ScriptTextBox = ScriptTextBox;
            m_ListView1 = ListView1;
            m_FileName = null;
            m_TasksGenerated = false;

            m_ScriptTextBox.Clear(); // Causes OnScriptTextChanged call, but we don't mind
            m_ListView1.Items.Clear();
            m_ScriptTextBox.Modified = false;
        }

        // Creates document and loads it from given file
        // On error throws exception.
        public Document(TextBox ScriptTextBox, ListView ListView1, string FileName)
        {
            m_ScriptTextBox = ScriptTextBox;
            m_ListView1 = ListView1;
            m_FileName = FileName;
            m_TasksGenerated = false;

            using (StreamReader File = new StreamReader(FileName, Encoding.ASCII))
                m_ScriptTextBox.Text = File.ReadToEnd();

            m_ListView1.Items.Clear(); // Causes OnScriptTextChanged call, but we don't mind
            m_ScriptTextBox.Modified = false;
        }

        // Returns true if document has known file name (was saved or loaded from file)
        public bool HasFileName() { return m_FileName != null && m_FileName != ""; }
        // Get document file name with full path
        // Null if there is no name.
        public string GetFileName() { return m_FileName; }
        // Set document file name with full path
        public void SetFileName(string NewFileName) { m_FileName = NewFileName; }
        // Get only document name, without path and extension
        public string GetDocumentName() { return Path.ChangeExtension(Path.GetFileName(m_FileName), null); }
        // Returns true if document was modified after last save
        public bool GetModified() { return m_ScriptTextBox.Modified; }
        // Returns directory of document, without file name
        public string GetFileDirectory() { return Path.GetDirectoryName(m_FileName); }

        // Save document to file
        // Document must already have file name.
        // On error: throw exception.
        public void SaveToFile()
        {
            if (!HasFileName())
                throw new Exception("Document doesn't have a file name.");

            using (StreamWriter File = new StreamWriter(m_FileName, false, Encoding.ASCII))
                File.Write(m_ScriptTextBox.Text);

            m_ScriptTextBox.Modified = false;
        }

        // Call this method whern script text is changed
        public void OnScriptTextChanged()
        {
            // Generated task list is no longer valid
            if (m_TasksGenerated)
            {
                m_TasksGenerated = false;
                m_ListView1.Items.Clear();
            }
        }

        // Parses script and generates tasks
        public void GenerateTasks()
        {
            if (m_TasksGenerated) return;

            ScriptParser Parser = new ScriptParser(m_ScriptTextBox.Text);
            string Line;
            int Row;
            ListViewItem Item;
            Task t;
            string SrcFile;
            string DestFile;
            bool IsDestFileText;

            m_ListView1.Items.Clear();

            while (!Parser.IsEnd())
            {
                Parser.GetNextLine(out Line, out Row);

                Line = Line.Trim();
                if (Line.Length > 0)
                {
                    if (!ScriptLineParser.ParseLine(Line, out SrcFile, out DestFile, out IsDestFileText))
                    {
                        SrcFile = "";
                        DestFile = "";
                        IsDestFileText = false;
                    }
                    t = new Task(Row, Line, SrcFile, DestFile, IsDestFileText);

                    Item = new ListViewItem();
                    Item.Text = Row.ToString();
                    Item.SubItems.Add(Line);
                    Item.SubItems.Add("");
                    Item.SubItems.Add("");
                    Item.Tag = t;
                    m_ListView1.Items.Add(Item);
                }
            }

            m_TasksGenerated = true;
        }
    }
}
