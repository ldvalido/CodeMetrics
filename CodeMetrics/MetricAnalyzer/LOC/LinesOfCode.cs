using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CodeMetrics.MetricAnalyzer.LOC
{
    public class LinesOfCode : ILinesOfCode
    {
        public bool ParseSuccess { get; private set; }
        private string _fileName;
        private ILanguageSpecification _language;
        private SpecificationCollection _specificationCollection = SpecificationCollection.GetInstance; 
        private int _totalLines = 0;
        public Dictionary<int, string> CommentLineDictionary { get; protected set; }
        public Dictionary<int, string> EmptyLineDictionary { get; protected set; }
        public Dictionary<int, string> BracketLineDictionary { get; protected set; }
        public Dictionary<int, string> CodeLineDictionary { get; protected set; }
        public string[] AllLines 
        {
            get { return lines.ToArray(); }  
        }

        private List<string> lines = new List<string>();
        public List<Exception> Exceptions = new List<Exception>();

        public LinesOfCode(string path)
        {
            _language = GetLanguageFromFileExtention(path);
            initDictionaries();
            GetFileInfo(path);
            ParseLines();
        }

        public LinesOfCode(string path, ILanguageSpecification languageSpec) : this(path)
        {
            _language = languageSpec;
        }

        private ILanguageSpecification GetLanguageFromFileExtention(string path)
        {
            FileInfo fi = new FileInfo(path);
            string ext = fi.Extension;
            foreach (ILanguageSpecification spec in SpecificationCollection.MatchFeatureList)
            {
                if (spec.FileExtention == ext)
                    return spec;
            }
            return null;
        }

        private void initDictionaries()
        {
            CommentLineDictionary = new Dictionary<int, string>();
            EmptyLineDictionary = new Dictionary<int, string>();
            BracketLineDictionary = new Dictionary<int, string>();
            CodeLineDictionary = new Dictionary<int, string>();
        }

        private void ParseLines()
        {
            if (_language == null)
            {
                ParseSuccess = false;
                return;
            }
            if (lines == null) return;

            int lineNr = 1;
            bool isBlockComment = false;
            foreach (var line in lines)
            {
                // find empty line
                Regex r = new Regex(@"\s");
                var trimmedLine = r.Replace(line, string.Empty);
                if (string.IsNullOrEmpty(trimmedLine))
                    EmptyLineDictionary.Add(lineNr, line);
                else
                {
                    // find comments
                    if (trimmedLine.StartsWith(_language.SingleLineComment) || trimmedLine.StartsWith(_language.StartMultiLineComment) || trimmedLine.EndsWith(_language.EndMultilineComment) || (isBlockComment))
                    {
                        CommentLineDictionary.Add(lineNr, line);
                        //find start of comment block
                        if (line.Contains(_language.StartMultiLineComment))
                            isBlockComment = true;
                        //find end of comment block
                        if (line.Contains(_language.EndMultilineComment))
                            isBlockComment = false;
                    }
                    else
                    {
                        FindBracketsOrCodeLines(lineNr, line);
                    }
                }
                lineNr++;
            }
            _totalLines = lineNr - 1;
            ParseSuccess = true;
        }

        private void FindBracketsOrCodeLines(int lineNr, string line)
        {
            //find brackets or code
            var trimmedLine = line.Trim();
            if (trimmedLine.Length == 1)
            {
                if (trimmedLine.Contains(_language.OpenBracket))
                    BracketLineDictionary.Add(lineNr, line);
                if (trimmedLine.Contains(_language.CloseBracket))
                    BracketLineDictionary.Add(lineNr, line);
            }
            else if (trimmedLine.Length > 1)
            {
                CodeLineDictionary.Add(lineNr, line);
            }
        }

        private void GetFileInfo(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    _fileName = new FileInfo(path).Name;
                    var reader = new StreamReader(path);
                    while (!reader.EndOfStream)
                    {
                        lines.Add(reader.ReadLine());
                    }
                }
            }
            catch (NullReferenceException nre)
            {
                Exceptions.Add(nre);
            }
            catch (AccessViolationException ave)
            {
                Exceptions.Add(ave);
            }
            catch (IOException ioe)
            {
                Exceptions.Add(ioe);
            }
        }

        #region ILinesOfCode Members

        public string FileName
        {
            get
            {
                return _fileName;
            }
        }

        public int TotalLines
        {
            get
            {
                return _totalLines;
            }
        }

        public int CommentLines
        {
            get
            {
                return CommentLineDictionary.Count;
            }
        }

        public int EmptyLines
        {
            get
            {
                return EmptyLineDictionary.Count;
            }
        }

        public int CodeLines
        {
            get { return CodeLineDictionary.Count; }
        }

        public int BracketLines
        {
            get { return BracketLineDictionary.Count; }
        }

        #endregion
    }
}
