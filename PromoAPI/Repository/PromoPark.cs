using AutoMapper;
using PromoAPI.Data;
using PromoAPI.Model;
using PromoAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using PromoAPI.Model.DTO;

namespace PromoAPI.Repository
{
    public class PromoPark : IPromoPark
    {
        private readonly PromoContext _context;
        private readonly IMapper _mapper;

        public PromoPark(PromoContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<PromoParkModel> GetallPromoPark()
        {
            var allData = _context.PromoParks.ToList();
            return _mapper.Map<IEnumerable<PromoParkModel>>(allData); 
        }
        public async Task<PromoParkModel> GetPromoParkbyId(int Id)
        {
            var databyid =await _context.PromoParks.FindAsync(Id);

            return  _mapper.Map<PromoParkModel>(databyid);
        }

        public async Task<int> CreatePromoPark(PromoParkModel promoPark)
        {
            var data = new PromoParkDTO(){ 
                Title = promoPark.Title,
                Sorce = promoPark.Sorce,
                Descbtion = promoPark.Descbtion,
                Date = promoPark.Date
            };
            _context.PromoParks.Add(data);
           await _context.SaveChangesAsync();

            return data.Id;

        }

        public async Task UpdatePromoPark(int id, PromoParkModel promoParkModel)
        {
            var data = new PromoParkDTO(){
                 Id = promoParkModel.Id,
                 Title = promoParkModel.Title,
                 Sorce = promoParkModel.Sorce,
                 Descbtion = promoParkModel.Descbtion,
                 Date = promoParkModel.Date
            };
            _context.PromoParks.Update(data);
             await _context.SaveChangesAsync();
          
        }

        public async Task DeletePromoPark(int id)
        {
            var deleteItme = _context.PromoParks.Find(id);
            _context.Remove(deleteItme);
            await _context.SaveChangesAsync();
        }

    }
}
