using Microsoft.Office.Interop.Word;
using System.IO;
using System;

namespace Word2PDF
{
    public class Word2PDFConverter
    {
        private static Application wordApp = new Application();
        private static Document doc;

        private static const string ErrorMsgFileDoesNotExist = @"Selected file does not exist!";

        public static void ConvertToPDF(string sourceFile)
        {
            if (!File.Exists(sourceFile))
            {
                throw new Exception(ErrorMsgFileDoesNotExist));
            }
        }
    }
}
