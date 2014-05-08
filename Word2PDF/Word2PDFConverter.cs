using Microsoft.Office.Interop.Word;
using System.IO;
using System;

namespace Word2PDF
{
    public class Word2PDFConverter
    {
        private static Application wordApp = new Application();
        private static Document doc;

        private static string ErrorMsgFileDoesNotExist = @"Selected file does not exist!";

        public static bool ConvertToPDF(string inputFile, string outputFile)
        {
            bool success = false;
            wordApp.Visible = false;

            if (!File.Exists(inputFile))
            {
                throw new Exception(ErrorMsgFileDoesNotExist);
            }
            else
            {
                doc = wordApp.Documents.Open(FileName: inputFile, Visible: false);
                doc.SaveAs2(FileName: outputFile, FileFormat: WdSaveFormat.wdFormatPDF);
                doc.Close();

                if (File.Exists(outputFile))
                {
                    success = true;
                }
            }

            return success;
        }
    }
}
