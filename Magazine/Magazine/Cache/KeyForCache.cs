namespace MagazineHost.Cache
{
    public static class KeyForCache
    {
        public static string RewardMagazineKey(string methodName) => $"RewardMagazine{methodName}";
        public static string RewardMagazineLineKey(string methodName) => $"RewardMagazineLine{methodName}";
    }
}
