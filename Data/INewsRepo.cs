using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Data
{
    public interface INewsRepo
    {
        public  Task<IEnumerable<News>> GetAllNewsAsync();

        public  Task<News> GetNewsByIdAsync(string Id);

        public  Task AddNewsAsync(News news);
        public  Task DeleteNewsAsync(string Id);







    }
}
