﻿using JsTestAdapter.TestServerClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarmaTestAdapterTests.Expectations
{
    public static class SpecExtensions
    {
        private static string FormatNull()
        {
            return FormatValue(null);
        }

        private static string FormatValue(this object value)
        {
            if (value == null)
            {
                return "null";
            }
            if (value is string)
            {
                return string.Format(@"""{0}""", value);
            }
            if (value is char)
            {
                return string.Format(@"'{0}'", value);
            }
            return string.Format(@"{0}", value);
        }

        public static StringBuilder AppendLine(this StringBuilder sb, string format, params object[] args)
        {
            return sb.AppendFormat(format, args).AppendLine();
        }

        public static string Format(this IEnumerable<Spec> specs)
        {
            return string.Join("", specs.Select(s => s.Format()));
        }

        public static string Format(this ExpectedSpec spec)
        {
            var text = new StringBuilder();

            if (spec != null)
            {
                text.AppendLine("=====================================================================");
                text.AppendLine("Expected spec");
                text.AppendLine("---------------------------------------------------------------------");
                text.AppendLine("FullyQualifiedName: {0}", spec.FullyQualifiedName.FormatValue());
                text.AppendLine("DisplayName:        {0}", spec.DisplayName.FormatValue());
                text.AppendLine("Description:        {0}", spec.Description.FormatValue());
                text.AppendLine("FileName:           {0}", spec.FileName.FormatValue());
                text.AppendLine("LineNumberFrom:     {0}", spec.LineNumberFrom.FormatValue());
                text.AppendLine("LineNumberTo:       {0}", spec.LineNumberTo.FormatValue());
                text.AppendLine("Success:            {0}", spec.Success.FormatValue());
                text.AppendLine("Skipped:            {0}", spec.Skipped.FormatValue());
                text.AppendLine("Output:             {0}", spec.Output.FormatValue());
                text.AppendLine("StackTrace:         {0}", spec.StackTrace.FormatValue());
                text.AppendLine("IsValid:            {0}", spec.IsValid.FormatValue());
                text.AppendLine("InvalidReason:      {0}", spec.InvalidReason.FormatValue());
                text.AppendLine("=====================================================================");
                text.AppendLine();
            }

            return text.ToString();
        }

        public static string Format(this Spec spec)
        {
            var text = new StringBuilder();

            if (spec != null)
            {
                text.AppendLine("=====================================================================");
                text.AppendLine("Karma spec");
                text.AppendLine("---------------------------------------------------------------------");
                text.AppendLine("FullyQualifiedName: {0}", spec.FullyQualifiedName.FormatValue());
                text.AppendLine("DisplayName:        {0}", spec.DisplayName.FormatValue());
                text.AppendLine("Id:                 {0}", spec.Id.FormatValue());
                text.AppendLine("Description:        {0}", spec.Description.FormatValue());
                text.AppendLine("Suite:              {0}", spec.Suite.FormatSuite());
                text.AppendLine("Source:             {0}", spec.Source.Format());
                if (spec.Results != null)
                {
                    foreach (var result in spec.Results)
                    {
                        result.Format(text);
                    }
                }
                text.AppendLine("=====================================================================");
                text.AppendLine();
            }

            return text.ToString();
        }

        public static string FormatSuite(this IEnumerable<string> suite)
        {
            return suite != null ? string.Format("[ {0} ]", string.Join(", ", suite.Select(s => s.FormatValue()))) : FormatNull();
        }

        public static string Format(this Source source)
        {
            if (source == null)
            {
                return FormatNull();
            }
            var result = source.FileName;
            if (source.LineNumber.HasValue)
            {
                result += string.Format(" Line {0}", source.LineNumber);
            }
            if (source.ColumnNumber.HasValue)
            {
                result += string.Format(" Column {0}", source.ColumnNumber);
            }
            return result.FormatValue();
        }

        public static void Format(this SpecResult result, StringBuilder text)
        {
            text.AppendLine("---------------------------------------------------------------------");
            text.AppendLine("Result:             {0}", result.Name.FormatValue());
            text.AppendLine("Success:            {0}", result.Success.FormatValue());
            text.AppendLine("Skipped:            {0}", result.Skipped.FormatValue());
            text.AppendLine("Output:             {0}", result.Output.FormatValue());
            text.AppendLine("Time:               {0}", result.Time.FormatValue());
        }

        public static string GetOutcome(this SpecResult result)
        {
            if (result.Skipped)
            {
                return "Skipped";
            }
            return result.Success ? "Passed" : "Failed";
        }
    }
}
