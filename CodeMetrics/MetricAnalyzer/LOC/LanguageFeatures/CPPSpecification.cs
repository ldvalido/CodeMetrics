namespace CodeMetrics.MetricAnalyzer.LOC
{
    public class CPPSpecification : ILanguageSpecification
    {
        public CPPSpecification()
        {
            FileFilter = cpp.Default.FileFilter;
            FileExtention = cpp.Default.FileExtention;
            SingleLineComment = cpp.Default.SingleLineComment;
            StartMultiLineComment = cpp.Default.StartMultiLineComment;
            EndMultilineComment = cpp.Default.EndMultiLineComment;
            OpenBracket = cpp.Default.OpenBracket;
            CloseBracket = cpp.Default.CloseBracket;
        }
        
        #region IMatchFeatures Members

        public string FileFilter 
        { 
            get; 
            protected set; 
        }

        public string FileExtention
        {
            get;
            protected set;
        }

        public string SingleLineComment
        {
            get;
            protected set;
        }

        public string StartMultiLineComment
        {
            get;
            protected set;
        }

        public string EndMultilineComment
        {
            get;
            protected set;
        }

        public string OpenBracket
        {
            get;
            protected set;
        }

        public string CloseBracket
        {
            get;
            protected set;
        }

        #endregion
    }
}
