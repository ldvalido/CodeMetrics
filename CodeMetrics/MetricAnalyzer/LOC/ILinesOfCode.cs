using System.Collections.Generic;

namespace CodeMetrics.MetricAnalyzer.LOC
{
    public interface ILinesOfCode
    {
        string FileName { get;}
        int TotalLines { get; }
        int CommentLines { get; }
        int EmptyLines { get; }
        int BracketLines { get; }
        int CodeLines { get; }

        Dictionary<int, string> EmptyLineDictionary {get;}
        Dictionary<int, string> BracketLineDictionary {get; }
        Dictionary<int, string> CommentLineDictionary {get; }
        Dictionary<int, string> CodeLineDictionary {get; }
    }
}
