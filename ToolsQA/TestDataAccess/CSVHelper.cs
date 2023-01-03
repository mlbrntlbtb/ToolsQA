using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.TestDataAccess
{
    public class CSVHelper
    {
        DataTable testData;
        string path = "";

        public CSVHelper(string Path)
        {
            this.path = Path;
            this.testData = CSVParse(path);
        }
        public static DataTable CSVParse(string path)
        {
            long lineNumber = 0;
            DataTable dt = new DataTable();
            string[] fields = null;
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.Delimiters = new string[] { "," };
                parser.HasFieldsEnclosedInQuotes = true; // for commas inside fields
                while (!parser.EndOfData)
                {
                    try
                    {
                        lineNumber = parser.LineNumber;
                        fields = parser.ReadFields();
                        if (lineNumber > 1) // if data field
                        {
                            dt.Rows.Add(fields);
                        }
                        else if (lineNumber == 1) // if first line (header)
                        {
                            foreach (string header in fields)
                            {
                                dt.Columns.Add(header);
                            }
                        }
                    }
                    catch (MalformedLineException) /* for unescaped/trailing double quotes (only happens when user erases escape-string intended double-quotes outside of Test Runner, which breaks CSV standards) */
                    {
                        parser.Close();
                        parser.Dispose();
                        return null;
                    }
                    catch // other exceptions handled by main function
                    {
                        parser.Close();
                        parser.Dispose();
                        throw;
                    }
                }
                parser.Close();
                parser.Dispose();
                return dt;
            }
        }

        public string GetTargetValue(string varName)
        {
            foreach (DataRow row in testData.Rows)
            {
                if (row[0].ToString().Equals(varName))
                {
                    return row[1].ToString();
                }
            }
            return null;
        }
    }
}
