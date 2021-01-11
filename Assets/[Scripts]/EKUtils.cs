using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EKUtils
{
    public static class EKUtils
    {
        public static string GetCode(this Color color)
        {
            return ColorUtility.ToHtmlStringRGBA(color);
        }

        public static Color GetColor(this string code)
        {
            Color c;
            ColorUtility.TryParseHtmlString("#" + code, out c);
            return c;
        }
    }
}