using System.Collections.Generic;

namespace CodeMetrics.MetricAnalyzer.LOC
{
    /// <summary>
    /// Singleton which contains all the language feature objects.
    /// </summary>
    public sealed class SpecificationCollection
    {
        private static SpecificationCollection _instance; //singleton instance
        private static readonly object lockObject = new object(); // for thread safety

        private SpecificationCollection()
        {
            AddMatchFeatures();
        }

        public static List<ILanguageSpecification> MatchFeatureList { get; protected set; }

        public static SpecificationCollection GetInstance
        {
            get
            {
                lock (lockObject)
                    if (_instance == null)
                    {
                        _instance = new SpecificationCollection();
                    }
                return _instance;
            }
        }

        private void AddMatchFeatures()
        {
            MatchFeatureList = new List<ILanguageSpecification>();
            MatchFeatureList.Add(new CSharpSpecification());
            MatchFeatureList.Add(new JavaSpecification());
            MatchFeatureList.Add(new CPPSpecification());
        }
    }
}
