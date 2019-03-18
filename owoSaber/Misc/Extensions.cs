using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace owoSaber.Misc
{
    public static class Extensions
    {
        public static string OwO(this string input)
        {
            try
            {
                if (input == null)
                    return null;

                if (input == "")
                    return "";

                string[] faces = new string[]
                {
                    "owo",
                    "UwU",
                    ">w<",
                    "^w^",
                };

                string text = input;
                string face = faces[new Random().Next(0, faces.Length)];

                text = Regex.Replace(text, @"[rl]", "w");
                text = Regex.Replace(text, @"[RL]", "W");
                text = Regex.Replace(text, @"ove", "uv");
                text = Regex.Replace(text, @"n(?!(?:\b|[y]))", "ny");
                text = Regex.Replace(text, @"N(?!(?:\b|[Y]))", "NY");
                text = Regex.Replace(text, @"[!]", $" {face}");

                return text;
            }
            catch
            {
                Logger.Debug($"Failed to OwO translate string: '{input}'");
                return input;
            }
        }

        public static string EscapeFormatting(this string text)
        {
            StringBuilder sb = new StringBuilder(text.Length);
            bool tag = false;

            for (int index = 0; index < text.Length; index++)
            {
                char c = text[index];

                if (tag)
                {
                    if (c == '>')
                        tag = false;
                }
                else
                {
                    if (c == '<')
                        tag = true;
                    else
                        sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public static string SafeOWO(this string input)
        {
            try
            {
                if (input == null)
                    return null;

                if (input == "")
                    return "";

                string text = $"{input} ";
                string[] words = input
                    .EscapeFormatting()
                    .Split(' ')
                    .Select(x => $"{x} ")
                    .Distinct()
                    .ToArray();

                Dictionary<string, string> lookup = new Dictionary<string, string>();
                foreach (string word in words)
                {
                    lookup.Add(word, word.OwO());
                    text = text.Replace(word, word.OwO());
                }

                return text.Remove(text.Length - 1);
            }
            catch
            {
                Logger.Debug($"Failed to safe OwO translate string: '{input}'");
                return input;
            }
        }
    }
}
