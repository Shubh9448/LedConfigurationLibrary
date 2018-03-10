using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LedConfigurationLibrary.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string FilePath(this string fileName)
        {
            return $"{ ConfigurationManager.AppSettings["filePath"]} \\ { fileName }";
        }


        public static List<PrePostText> SaveToFile(this List<SettingsModel> models, string filename, List<string> preWrittenText)
        {
            List<string> lines = new List<string>();
            List<string> spacing = new List<string>();

            spacing.Add("\n");
            spacing.Add("\n");

            List<string> post_text = new List<string>();
            List<PrePostText> t = new List<PrePostText>();

            foreach (SettingsModel s in models)
            {

                post_text.Add($"{s.Font}");
                post_text.Add($"{s.FontTypeSwap}");
                post_text.Add($"{s.RGBforeground}");
                post_text.Add($"{s.RGBbackground}");
                post_text.Add($"{s.FieldSize}");
                //post_text.Add($"{s.FieldSize}");
                //post_text.Add($"{s.Font}");
                //post_text.Add($"{s.FontTypeSwap}");
                //post_text.Add($"{s.SwapFontType}");
                //post_text.Add($"{s.SwapAfterTime}");
                //post_text.Add($"{s.RGBforeground}");
                //post_text.Add($"{s.RGBbackground}");
                //post_text.Add($"{s.TextPosition}");
                //post_text.Add($"{s.Static}");
                //post_text.Add($"{s.Swap}");
                //post_text.Add($"{s.SwapPosition}");
                //post_text.Add($"{s.SwapPositionAfter}");
                //post_text.Add($"{s.ScrollFrequency}");

            }

            
            int counter = 0;
            foreach (var pre in preWrittenText)
            {
                

                
                    PrePostText newText = new PrePostText();
                    newText.PreText = preWrittenText[counter];
                    newText.PostText = post_text[counter];
                    counter++;
                    t.Add(newText);
                

                
            }

            foreach (var line in t)
            {
                lines.Add($"{line.PreText}({line.PostText});");
            }

            
            if (!File.Exists(filename.FilePath()))
            {
                File.WriteAllLines(filename.FilePath(), lines);
            }

            else
            {
                File.AppendAllLines(filename.FilePath(), spacing);
                File.AppendAllLines(filename.FilePath(), lines);
            }

            return t;


        }
    }
}
