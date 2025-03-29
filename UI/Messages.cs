namespace FFEC
{
    internal static class Messages
    {

        public static void RaiseArgumentNullExceptionMessage(string error)
        {
            RaiseErrorMessage($"Были введены некорректные данные. Ошибка: {error}");
        }

        public static void RaiseKeyNotFoundExceptionMessage(string error, Type type)
        {
            RaiseErrorMessage($"Не удалось получить {type} из словаря. Ошибка: {error}");
        }

        public static void RaiseSerializeJTokenToFontMessage(string error, JToken token)
        {
            RaiseErrorMessage($"Не удалось сериализовать JToken ({token}) в Font. Ошибка: {error}");
        }

        public static void RaiseSerializeJTokenToFontMessage(string error)
        {
            RaiseErrorMessage($"Не удалось сериализовать Font в JObject. Ошибка: {error}");
        }

        public static void RaiseReadFileNotFoundExceptionMessage(string error)
        {
            RaiseErrorMessage($"Не удалось прочитать файл. Ошибка: {error}");
        }

        public static void RaiseWriteFileNotFoundExceptionMessage(string error)
        {
            RaiseErrorMessage($"Не удалось записать файл. Ошибка: {error}");
        }

        public static void RaiseExceptionMessage(string error)
        {
            RaiseErrorMessage($"Произошла непредвиденная ошибка. Ошибка: {error}");
        }

        public static void RaiseErrorMessage(string text)
        {
            MessageBox.Show(caption: "Внимание", icon: MessageBoxIcon.Error, text: text, buttons: MessageBoxButtons.OK);
        }

        public static DialogResult RaiseDeleteAllMessage()
        {
            return RaiseConfirmedMessage("Вы собираетесь удалить все конфигурации. Вы уверены в своём выборе?");
        }

        public static DialogResult RaiseConfirmedMessage(string text)
        {
            return MessageBox.Show(caption: "Подтверждение", icon: MessageBoxIcon.Question, text: text, buttons: MessageBoxButtons.OKCancel);
        }

        public static DialogResult RaiseInformationMessage(string text)
        {
            return MessageBox.Show(caption: "Уведомление", icon: MessageBoxIcon.Information, text: text, buttons: MessageBoxButtons.OK);
        }

        public static DialogResult RaiseJokeMessage(string text)
        {
            return MessageBox.Show(caption: "Think about it 🤔", icon: MessageBoxIcon.None, text: text, buttons: MessageBoxButtons.RetryCancel);
        }
    }
}
