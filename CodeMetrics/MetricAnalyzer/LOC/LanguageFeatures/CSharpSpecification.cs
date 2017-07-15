namespace CodeMetrics.MetricAnalyzer.LOC
{
    public class CSharpSpecification : ILanguageSpecification
    {
        public CSharpSpecification()
        {
            FileFilter = csharp.Default.FileFilter;
            FileExtention = csharp.Default.FileExtention;
            SingleLineComment = csharp.Default.SingleLineComment;
            StartMultiLineComment = csharp.Default.StartMultiLineComment;
            EndMultilineComment = csharp.Default.EndMultiLineComment;
            OpenBracket = csharp.Default.OpenBracket;
            CloseBracket = csharp.Default.CloseBracket;
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
