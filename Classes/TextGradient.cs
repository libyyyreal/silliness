using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace silliness.Classes
{
    internal class TextGradient
    {
        // METHOD GIVEN FROM @cheemspookiealt ON DISCORD, ALL CREDITS GO TO HIM FOR THIS FILE
        public static string MakeGradient(string starth, string endh, string text)
        {
            Color start = htoc(starth);
            Color end = htoc(endh);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int len = text.Length;
            float delay = Time.time * 0.5f;
            for (int i = 0; i < len; i++)
            {
                float t = ((float)i / Mathf.Max(len - 1, 1) + delay) % 1f;
                Color c = Color.Lerp(start, end, t);
                sb.Append($"<color=#{ctoh(c)}>{text[i]}</color>");
            }
            return sb.ToString();
        }
        private static Color htoc(string hex)
        {
            if (hex.StartsWith("#")) hex = hex.Substring(1);
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return new Color32(r, g, b, 255);
        }
        private static string ctoh(Color c)
        {
            Color32 c32 = c;
            return $"{c32.r:X2}{c32.g:X2}{c32.b:X2}";
        }
    }
}
