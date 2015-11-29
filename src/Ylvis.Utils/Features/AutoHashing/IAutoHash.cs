namespace Ylvis.Utils.Features.AutoHashing
{
    public interface IAutoHash
    {
        int Id { get; }
        int UniqueHash { get; set; }

        void CalculateHash();
    }
}