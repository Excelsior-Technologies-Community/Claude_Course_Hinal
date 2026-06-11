using System.Collections.Generic;

namespace CLAUDE_API.Models
{
    public class PromptTestCase
    {
        public string Scenario { get; set; }
        public string TaskDescription { get; set; }
        public Dictionary<string, string> PromptInputs { get; set; }
        public List<string> SolutionCriteria { get; set; }
    }

    public class ModelGrade
    {
        public List<string> Strengths { get; set; }
        public List<string> Weaknesses { get; set; }
        public string Reasoning { get; set; }
        public double Score { get; set; }
    }

    public class EvalResult
    {
        public string Output { get; set; }
        public PromptTestCase TestCase { get; set; }
        public double Score { get; set; }
        public string Reasoning { get; set; }
        public List<string> Strengths { get; set; }
        public List<string> Weaknesses { get; set; }
    }

    public class EvalSummary
    {
        public List<EvalResult> Results { get; set; }
        public double AverageScore { get; set; }
    }

    public class GenerateDatasetRequest
    {
        public string TaskDescription { get; set; }
        public Dictionary<string, string> PromptInputsSpec { get; set; }
        public int NumCases { get; set; } = 3;
    }

    public class RunEvaluationRequest
    {
        public List<PromptTestCase> Dataset { get; set; }
        public string PromptTemplate { get; set; }
        public string ExtraCriteria { get; set; }
    }
}