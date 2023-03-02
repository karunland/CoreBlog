using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriterManager
    {
        IWriterDal _writerService;
        public WriterManager(IWriterDal writerService)
        {
            _writerService = writerService;
        }

        public void WriterAdd(Writer writer)
        {
            _writerService.Insert(writer);
        }
    }
}
