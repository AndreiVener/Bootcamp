using System;
using System.IO;

namespace SB
{
    public class ParserFactory
    {
        public Parser CreateParser(string path)
        {
            var fi = new FileInfo(path);
            switch (fi.Extension)
            {
                case ".json": return new JSONParser();
                case ".csv": return new CsvParser();
                case ".xml": return new XmlParser();
            }

            return null;
        }
    }
}