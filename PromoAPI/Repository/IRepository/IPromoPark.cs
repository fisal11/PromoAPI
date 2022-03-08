using PromoAPI.Model;

namespace PromoAPI.Repository.IRepository
{
    public interface IPromoPark
    {
        IEnumerable<PromoParkModel> GetallPromoPark();
        Task<PromoParkModel> GetPromoParkbyId(int Id);
       
        Task<int> CreatePromoPark(PromoParkModel promoParkModel);
        Task UpdatePromoPark(int id,PromoParkModel promoParkModel);
        Task DeletePromoPark(int id);

    }
}
