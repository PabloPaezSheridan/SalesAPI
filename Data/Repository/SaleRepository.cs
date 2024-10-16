using Data.Entities;

namespace Data.Repository
{
    public class SaleRepository
    {
        private readonly ApplicationContext _context;

        public SaleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Sale> Get()
        {
            return _context.Sales.ToList();
        }

        public Sale? Get(int id)
        {
            return _context.Sales.FirstOrDefault(s => s.Id == id);
        }

        public int CreateSale(Sale sale)
        {
            try
            {
                _context.Add(sale);
                _context.SaveChanges();
                return sale.Id;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void Delete(int id)
        {
            try
            {
                _context.Sales.Single(s => s.Id == id).State = Models.StateEnum.Deleted;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public Sale Update(Sale sale)
        {
            _context.Sales.Update(sale);
            _context.SaveChanges();
            return sale;
        }
    }
}
