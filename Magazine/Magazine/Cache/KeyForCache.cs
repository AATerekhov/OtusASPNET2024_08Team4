namespace MagazineHost.Cache
{
    public static class KeyForCache
    {
        public static string MagazineKey(Guid _magazineId) => $"Magazine_{_magazineId}";
        public static string MagazinesByMagazineOwnerIdKey(Guid _magazineOwnerId) => $"MagazinesByMagazineOwnerId_{_magazineOwnerId}";
        public static string MagazineLinesByMagazineIdKey(Guid _magazineId) => $"MagazineLinesByMagazineId_{_magazineId}";

        public static string MagazineLineKey(Guid _magazineLineId) => $"MagazineLine_{_magazineLineId}";
    }
}
