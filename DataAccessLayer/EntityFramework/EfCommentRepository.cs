using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentRepository : ICommentDal
    {
        ICommentDal _commetDal;
        public EfCommentRepository(ICommentDal commentDal)
        {
            _commetDal = commentDal;
        }
        public List<Comment> GetAll(int blogId)
        {
            using (var item = new Context())
            {
                List<Comment> x = item.Comments.Where(x => x.BlogId == blogId).ToList();
                return x;
            }
        }
    }
}
