namespace Diary.Cache
{
    public static class KeyForCache
    {
        public static string HabitDiaryKey(string methodName) => $"HabitDiary{methodName}";
        public static string HabitDiaryLineKey(string methodName) => $"HabitDiaryLine{methodName}";
    }
}
