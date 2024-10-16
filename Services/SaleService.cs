using Data.Entities;
using Data.Repository;

namespace Services
{
    public class SaleService
    {
        private readonly SaleRepository _saleRepository;
        public SaleService(SaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public void Delete(int id)
        {
            _saleRepository.Delete(id);
        }

        public List<Sale> Get()
        {
            return _saleRepository.Get();
        }

        public Sale? Get(int id)
        {
            return _saleRepository.Get(id);
        }

        public Sale Update(Sale entity)
        {
            return _saleRepository.Update(entity);
        }

        public int Add(Sale entity)
        {
            return _saleRepository.CreateSale(entity);
        }

    }
}
