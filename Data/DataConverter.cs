namespace FFEC
{
    internal class DataConverter
    {
        public static string ColorToString(Color color)
        {
            return $"[{color.A},{color.R},{color.B},{color.G}]";
        }

        public static Font JTokenToFont(JToken token)
        {
            try
            {
                return token is not null ? BuildFont(
                            familyName: token["Name"].Value<string>(),
                            emSize: token["Size"].Value<float>(),
                            unit: (GraphicsUnit)Enum.Parse(typeof(GraphicsUnit), token["Unit"].Value<string>()),
                            gdiCharSet: token["GdiCharSet"].Value<byte>(),
                            gdiVerticalFont: token["GdiVerticalFont"].Value<bool>(),
                            isBold: token["Bold"].Value<bool>(),
                            isItalic: token["Italic"].Value<bool>(),
                            isStrikeout: token["Strikeout"].Value<bool>(),
                            isUnderline: token["Underline"].Value<bool>()
                        ) : throw new Exception("В сериализатор JTokenToFont был передан нулевой JToken");
            }
            catch (Exception exception) { Messages.RaiseSerializeJTokenToFontMessage(exception.Message, token); }
            return Form.DefaultFont;
        }

        private static Font BuildFont(bool isBold, bool isItalic, bool isStrikeout, bool isUnderline, string familyName, float emSize, GraphicsUnit unit, byte gdiCharSet, bool gdiVerticalFont)
        {
            FontStyle style = FontStyle.Regular;
            if (isBold)
            {
                style |= FontStyle.Bold;
            }

            if (isItalic)
            {
                style |= FontStyle.Italic;
            }

            if (isStrikeout)
            {
                style |= FontStyle.Strikeout;
            }

            if (isUnderline)
            {
                style |= FontStyle.Underline;
            }

            return new Font(familyName: familyName, emSize: emSize, unit: unit, gdiCharSet: gdiCharSet, gdiVerticalFont: gdiVerticalFont, style: style);
        }

        public static JObject FontToJObject(Font font)
        {
            JObject obj = [];
            try
            {
                if (font is null)
                {
                    throw new Exception("В сериализатор FontToJObject был передан нулевой Font");
                }

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
