using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UniqueWords
{
    internal class WordsFinder
    {
        Regex regex = new Regex(@"(?i)(?<![\'])[-a-zа-я\'’]{2,}(?:-[a-zа-я\'’]{2,})?|[-a-zа-я\'’]{3,}(?![\'])", RegexOptions.Compiled);
        Dictionary<string,int> _words = new Dictionary<string,int>();
        Dictionary<string, int> _result;
        string _text, _filePath, _resultPath;
         

        public WordsFinder(string filePath, string resultPath) 
        { 
            _filePath = filePath;
            _resultPath = resultPath;
        }
        public void WriteToFile()
        {
            try
            {
           
                var sw = new StreamWriter(_resultPath, false, Encoding.Unicode);
                foreach (var res in _result)
                {
                    sw.WriteLine(res.Key + " " + res.Value);
                }
                sw.Close();
            }
            catch(Exception e) 
            { Console.WriteLine(e.Message); }
            
            
        }
        public void ReadFromFile() 
        {
            try
            {
                var streamReader = new StreamReader(_filePath);
                _text = streamReader.ReadToEnd();
                foreach (Match match in regex.Matches(_text))
                {
                    string Word = match.Value;
                    Word = Word.ToLower();
                    if (_words.ContainsKey(Word))
                    {
                        _words[Word]++;
                    }
                    else { _words.Add(Word, 1); }
                }
                streamReader.Close();

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            
        }
        
        
        public void SortWordsList()
        {
            _result = _words.AsParallel().OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
