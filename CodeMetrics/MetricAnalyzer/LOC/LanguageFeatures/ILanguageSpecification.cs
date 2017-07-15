namespace CodeMetrics.MetricAnalyzer.LOC
{
    public interface ILanguageSpecification
    {
        string FileFilter { get; }
        string FileExtention { get; }
        string SingleLineComment { get; }
        string StartMultiLineComment { get; }
        string EndMultilineComment { get; }
        string OpenBracket { get; }
        string CloseBracket { get; }
    }
}
