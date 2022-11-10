using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace _11_Flyweight
{
    public class TextForamatting
    {
        public static void Test() 
        {
            var ft = new ForamttedText("hello world");
            ft.Caplitalize(0, 5);
            System.Console.WriteLine(ft);

            var bft = new BetterForamttedText("hello world");
            bft.GetRange(5, 10).Capitalize = true;
            System.Console.WriteLine(bft);
        }
    }
    internal class ForamttedText
    {
        private string plainText;
        private bool[] caplitalize;
        public ForamttedText(string plainText)
        {
            this.plainText = plainText?? throw new ArgumentNullException(paramName: nameof(plainText));;
            caplitalize = new bool[plainText.Length];
        }
        public void Caplitalize(int start, int end)
        {
            for (int i = start; i <= end ; i++)
            {
                caplitalize[i] = true;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                sb.Append(caplitalize[i]? char.ToUpper(plainText[i]): plainText[i]);
            }
            return sb.ToString();
        }
    }
    // better way 
    internal class TextRange
    {
        public int Start { get; set; }
        public int End { get; set; }
        public bool Capitalize { get; set; }
        // you can add more formatting options easily as the following
        // public bool Italic { get; set; }
        // public bool Bold { get; set; }
        public bool Covers(int position)
        {
            return position >= Start && position <= End;
        }
    }
    internal class BetterForamttedText
    {
        private string plainText;
        private List<TextRange> formatting = new List<TextRange>();
        public BetterForamttedText(string plainText)
        {
            this.plainText = plainText?? throw new ArgumentNullException(paramName: nameof(plainText));;
            
        }
        public TextRange GetRange(int start, int end)
        {
            var range = new TextRange(){Start = start, End = end};
            formatting.Add(range);
            return range;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                var c = plainText[i];
                foreach (var range in formatting)
                {
                    if(range.Covers(i))
                    {
                        // apply the changes
                        if (range.Capitalize) c= char.ToUpper(c);
                    }
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}