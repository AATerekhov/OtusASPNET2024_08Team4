namespace Diary.Cache
{
    public static class KeyForCache
    {
        public static string DiaryKey(Guid _diaryId) => $"Diary_{_diaryId}";
        public static string DiariesByDiaryOwnerIdKey(Guid _diaryOwnerId) => $"DiariesByDiaryOwnerId_{_diaryOwnerId}";
        public static string DiaryLinesByDiaryIdKey(Guid _diaryId) => $"DiaryLinesByDiaryIdKey_{_diaryId}";

        public static string DiaryLineKey(Guid _diaryLineId) => $"DiaryLine_{_diaryLineId}";
    }
}
