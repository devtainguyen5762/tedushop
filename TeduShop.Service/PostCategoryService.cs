using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postcategory);
        void Update(PostCategory postcategory);
        void Detele(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParentId(int parentid);
        PostCategory GetById(int id);
        void SaveChange();
    }
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepositorycs _postcategoryrepository;
        IUnitOfWork _iunitofwork;
        public PostCategoryService(IPostCategoryRepositorycs postcategoryrepository,IUnitOfWork uniofwork)
        {
            this._postcategoryrepository = postcategoryrepository;
            this._iunitofwork = uniofwork;
        }
        public void Add(PostCategory postcategory)
        {
            _postcategoryrepository.Add(postcategory);
        }

        public void Detele(int id)
        {
            _postcategoryrepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postcategoryrepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentid)
        {
            return _postcategoryrepository.GetMulti(x => x.Status && x.ParentID == parentid);
        }

        public PostCategory GetById(int id)
        {
            return _postcategoryrepository.GetSingleById(id);
        }

        public void Update(PostCategory postcategory)
        {
            _postcategoryrepository.Update(postcategory);
        }

        public void SaveChange()
        {
            _iunitofwork.Commit();
        }
    }
}
