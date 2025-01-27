namespace Diary.Cache
{
    public static class KeyForCache
    {
        public static string DiaryKey(Guid _diaryId) => $"Diary_{_diaryId}";
        public static string HabitKey(Guid _habitId) => $"Habit_{_habitId}";
        public static string HabitsByDiaryIdKey(Guid _diaryId) => $"HabitsByDiaryId_{_diaryId}";
        public static string HabitStateKey(Guid _habitStateId) => $"HabitState_{_habitStateId}";
        public static string HabitStatesByHabitIdKey(Guid _habitId) => $"HabitStatesByHabitId_{_habitId}";
        public static string DiariesByDiaryOwnerIdKey(Guid _diaryOwnerId) => $"DiariesByDiaryOwnerId_{_diaryOwnerId}";
        public static string DiaryLinesByDiaryIdKey(Guid _diaryId) => $"DiaryLinesByDiaryIdKey_{_diaryId}";

        public static string DiaryLineKey(Guid _diaryLineId) => $"DiaryLine_{_diaryLineId}";
    }
}
