using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Data
{
    public interface INewsRepo
    {
        public IEnumerable<News> GetAllNews();

        public News GetNewsById(string Id);

        public void AddNews(News news);
        public void DeleteNews(News news);







    }
}
