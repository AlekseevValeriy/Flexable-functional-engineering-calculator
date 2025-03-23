namespace FFEC
{
    internal static class Messages
    {

        public static void RaiseArgumentNullExceptionMessage(String error) => RaiseErrorMessage($"Были введены некорректные данные. Ошибка: {error}");
        public static void RaiseKeyNotFoundExceptionMessage(String error, Type type) => RaiseErrorMessage($"Не удалось получить {type} из словаря. Ошибка: {error}");
        public static void RaiseSerializeJTokenToFontMessage(String error, JToken token) => RaiseErrorMessage($"Не удалось сериализовать JToken ({token}) в Font. Ошибка: {error}");
        public static void RaiseSerializeJTokenToFontMessage(String error) => RaiseErrorMessage($"Не удалось сериализовать Font в JObject. Ошибка: {error}");
        public static void RaiseReadFileNotFoundExceptionMessage(String error) => RaiseErrorMessage($"Не удалось прочитать файл. Ошибка: {error}");
        public static void RaiseWriteFileNotFoundExceptionMessage(String error) => RaiseErrorMessage($"Не удалось записать файл. Ошибка: {error}");
        public static void RaiseExceptionMessage(String error) => RaiseErrorMessage($"Произошла непредвиденная ошибка. Ошибка: {error}");
        public static void RaiseErrorMessage(String text) => MessageBox.Show(caption: "Внимание", icon: MessageBoxIcon.Error, text: text, buttons: MessageBoxButtons.OK);

        public static DialogResult RaiseDeleteAllMessage() => RaiseConfirmedMessage("Вы собираетесь удалить все конфигурации. Вы уверены в своём выборе?");
        public static DialogResult RaiseConfirmedMessage(String text) => MessageBox.Show(caption: "Подтверждение", icon: MessageBoxIcon.Question, text: text, buttons: MessageBoxButtons.OKCancel);

    }
}
