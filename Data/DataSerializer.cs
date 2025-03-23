namespace FFEC
{
    internal class DataSerializer
    {
        public static String ColorToStringFormat(Color color) => $"[{color.A},{color.R},{color.B},{color.G}]";

        public static Font JTokenToFont(JToken token)
        {
            try
            {
                return token is not null ? BuildFont(
                            familyName: token["Name"].Value<String>(),
                            emSize: token["Size"].Value<Single>(),
                            unit: (GraphicsUnit)Enum.Parse(typeof(GraphicsUnit), token["Unit"].Value<String>()),
                            gdiCharSet: token["GdiCharSet"].Value<Byte>(),
                            gdiVerticalFont: token["GdiVerticalFont"].Value<Boolean>(),
                            isBold: token["Bold"].Value<Boolean>(),
                            isItalic: token["Italic"].Value<Boolean>(),
                            isStrikeout: token["Strikeout"].Value<Boolean>(),
                            isUnderline: token["Underline"].Value<Boolean>()
                        ) : throw new Exception("В сериализатор JTokenToFont был передан нулевой JToken");
            }
            catch (Exception exception) { Messages.RaiseSerializeJTokenToFontMessage(exception.Message, token); }
            return Form.DefaultFont;
        }
        private static Font BuildFont(Boolean isBold, Boolean isItalic, Boolean isStrikeout, Boolean isUnderline, String familyName, Single emSize, GraphicsUnit unit, Byte gdiCharSet, Boolean gdiVerticalFont)
        {
            FontStyle style = FontStyle.Regular;
            if (isBold) style = style | FontStyle.Bold;
            if (isItalic) style = style | FontStyle.Italic;
            if (isStrikeout) style = style | FontStyle.Strikeout;
            if (isUnderline) style = style | FontStyle.Underline;
            return new Font(familyName: familyName, emSize: emSize, unit: unit, gdiCharSet: gdiCharSet, gdiVerticalFont: gdiVerticalFont, style: style);
        }

        public static JObject FontToJObject(Font font)
        {
            JObject obj = new JObject();
            try
            {
                if (font is null) throw new Exception("В сериализатор FontToJObject был передан нулевой Font");
                obj["Name"] = font.Name;
                obj["Size"] = font.Size;
                obj["Unit"] = font.Unit.ToString();
                obj["Bold"] = font.Bold;
                obj["GdiCharSet"] = font.GdiCharSet;
                obj["GdiVerticalFont"] = font.GdiVerticalFont;
                obj["Italic"] = font.Italic;
                obj["Strikeout"] = font.Strikeout;
                obj["Underline"] = font.Underline;
                return obj;
            }
            catch (Exception exception) { Messages.RaiseSerializeJTokenToFontMessage(exception.Message); }
            return obj;
        }
    }
}
