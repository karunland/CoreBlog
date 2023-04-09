using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerdal;
        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public Writer GetByIdd(int id)
        {
            return _writerdal.GetById(id);
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterbyId(int id) => _writerdal.GetAll(x => x.Id == id);

        public void TAdd(Writer t)
        {
            _writerdal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Writer t)
        {
            throw new NotImplementedException();
        }

    }
}
