using System;
using System.Collections.Generic;
using System.Linq;

namespace CLAUDE_API.Models
{
    public class EvalService
    {
        private static readonly List<PromptTestCase> _staticDataset = new List<PromptTestCase>
        {
            new PromptTestCase
            {
                Scenario = "Testing with technical computer science terminology",
                TaskDescription = "Summarize technical documentation clearly and concisely",
                PromptInputs = new Dictionary<string, string>
                {
                    { "text", "A binary search tree (BST) is a rooted binary tree data structure with the key of each internal node being greater than all the keys in the left subtree and less than the ones in its right subtree." },
                    { "language", "English" }
                },
                SolutionCriteria = new List<string>
                {
                    "Summary must be under 50 words",
                    "Must preserve the core technical meaning",
                    "Should use plain language"
                }
            },
            new PromptTestCase
            {
                Scenario = "Testing with medical research findings",
                TaskDescription = "Summarize technical documentation clearly and concisely",
                PromptInputs = new Dictionary<string, string>
                {
                    { "text", "A randomized controlled trial involving 1,200 participants found that daily supplementation of 2000 IU vitamin D3 significantly reduced the incidence of upper respiratory tract infections by 42% compared to placebo over a 12-month period." },
                    { "language", "English" }
                },
                SolutionCriteria = new List<string>
                {
                    "Summary must be under 50 words",
                    "Must include key statistics",
                    "Must be accessible to non-medical readers"
                }
            },
            new PromptTestCase
            {
                Scenario = "Testing with complex mathematical concepts",
                TaskDescription = "Summarize technical documentation clearly and concisely",
                PromptInputs = new Dictionary<string, string>
                {
                    { "text", "The Riemann Hypothesis conjectures that all non-trivial zeros of the Riemann zeta function have a real part equal to 1/2, with profound implications for the distribution of prime numbers." },
                    { "language", "English" }
                },
                SolutionCriteria = new List<string>
                {
                    "Summary must be under 50 words",
                    "Must explain significance to a general audience",
                    "Must avoid unnecessary jargon"
                }
            }
        };

        private static readonly List<string> _staticOutputs = new List<string>
        {
            "A BST is a tree structure where each node's value is larger than all values in its left branch and smaller than all values in its right branch, enabling efficient search operations.",
            "A 12-month trial with 1,200 people showed that taking 2000 IU of vitamin D3 daily reduced respiratory infections by 42% compared to a placebo group.",
            "The Riemann Hypothesis is an unsolved math problem suggesting that a specific set of numbers all share a key property, which would reveal deep patterns in how prime numbers are distributed."
        };

        private static readonly List<ModelGrade> _staticGrades = new List<ModelGrade>
        {
            new ModelGrade
            {
                Score = 9.0,
                Reasoning = "The summary is concise, accurate, and uses plain language while preserving technical meaning. Meets all criteria.",
                Strengths  = new List<string> { "Clear and concise", "Preserves technical accuracy", "Uses plain language" },
                Weaknesses = new List<string> { "Could mention time complexity", "Missing example use case" }
            },
            new ModelGrade
            {
                Score = 8.5,
                Reasoning = "Key statistics are preserved and language is accessible. Slightly over-simplified but meets all requirements.",
                Strengths  = new List<string> { "Includes key 42% statistic", "Accessible language", "Under word limit" },
                Weaknesses = new List<string> { "Duration could be more prominent", "Placebo comparison slightly vague" }
            },
            new ModelGrade
            {
                Score = 7.5,
                Reasoning = "Good layman explanation of a complex topic. Avoids jargon effectively but loses some precision.",
                Strengths  = new List<string> { "Avoids complex jargon", "Explains significance clearly", "Under 50 words" },
                Weaknesses = new List<string> { "Loses some mathematical precision", "Does not mention it is unsolved" }
            }
        };

        // Generate Dataset
        public List<PromptTestCase> GenerateDataset(
            string taskDescription,
            Dictionary<string, string> promptInputsSpec,
            int numCases = 3)
        {
            return _staticDataset
                .Take(Math.Min(numCases, _staticDataset.Count))
                .Select(tc => new PromptTestCase
                {
                    Scenario = tc.Scenario,
                    TaskDescription = string.IsNullOrWhiteSpace(taskDescription)
                                         ? tc.TaskDescription : taskDescription,
                    PromptInputs = tc.PromptInputs,
                    SolutionCriteria = tc.SolutionCriteria
                })
                .ToList();
        }

        // Run Evaluation
        public EvalSummary RunEvaluation(
            List<PromptTestCase> dataset,
            string promptTemplate,
            string extraCriteria = null)
        {
            var results = new List<EvalResult>();

            for (int i = 0; i < dataset.Count; i++)
            {
                var tc = dataset[i];
                var output = i < _staticOutputs.Count
                    ? _staticOutputs[i]
                    : "Static demo output for test case " + (i + 1);

                var grade = i < _staticGrades.Count
                    ? _staticGrades[i]
                    : new ModelGrade
                    {
                        Score = 7.0,
                        Reasoning = "Output meets most of the specified criteria.",
                        Strengths = new List<string> { "Relevant", "Well structured" },
                        Weaknesses = new List<string> { "Could be more specific" }
                    };

                results.Add(new EvalResult
                {
                    Output = output,
                    TestCase = tc,
                    Score = grade.Score,
                    Reasoning = grade.Reasoning,
                    Strengths = grade.Strengths,
                    Weaknesses = grade.Weaknesses
                });
            }

            double avg = results.Count > 0 ? results.Average(r => r.Score) : 0;
            return new EvalSummary { Results = results, AverageScore = avg };
        }
    }
}