namespace CodeMetrics.MetricAnalyzer.LOC
{
    public class JavaSpecification : ILanguageSpecification
    {
        public JavaSpecification()
        {
            FileFilter = java.Default.FileFilter;
            FileExtention = java.Default.FileExtention;
            SingleLineComment = java.Default.SingleLineComment;
            StartMultiLineComment = java.Default.StartMultiLineComment;
            EndMultilineComment = java.Default.EndMultiLineComment;
            OpenBracket = java.Default.OpenBracket;
            CloseBracket = java.Default.CloseBracket;
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
