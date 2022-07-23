using NewApiService.DAL;
using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Data
{
    public class NewsRepoImpl:INewsRepo
    {
        DBUtility dbutility = new DBUtility();
        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            //return newsList;
            var obj= await dbutility.UtilityGetAllNewsAsync();
            return obj;
        }

        public async Task<News> GetNewsByIdAsync(string Id)
        {
            //return newsList.FirstOrDefault(x => x.NewsId.Equals(Id));
            var obj= await dbutility.UtilityGetNewsByIdAsync(Id);
            return obj;
        }

        public async Task AddNewsAsync(News news)
        {
            if (news != null)
            {
                await dbutility.UtilityAddNewsAsync(news);
                await dbutility.UtilityUpdateNewscountAsync( news.NewsAuthor);
            }
        }

        public async Task DeleteNewsAsync(string Id)
        {
            //var tempNews = GetNewsById(news.NewsId);
            //if (tempNews != null)
            //{
            //    int pos = newsList.IndexOf(tempNews);
            //    newsList.RemoveAt(pos);

            //}
                await dbutility.UtilityDeleteNewsAsync(Id);
        }


        //List<News> newsList = new List<News>()
        //{
        //    new News { NewsId ="N1" ,NewsAuthor="Omkar",NewsCategory="technical",ApprovedBy="true",NewsLocation="India", NewsTitle="testing1 title",NewsMatter="testing testing testing" ,NewsTime=new DateTime(2022,07,20) },
        //    new News { NewsId ="N2" ,NewsAuthor="Omkar",NewsCategory="General",ApprovedBy="true",NewsLocation="India", NewsTitle="testing1 title",NewsMatter="testing testing testing" ,NewsTime=new DateTime(2022,07,19) },
        //    new News { NewsId ="N3" ,NewsAuthor="Omkar",NewsCategory="General",ApprovedBy="true",NewsLocation="India", NewsTitle="testing1 title",NewsMatter="testing testing testing" ,NewsTime=new DateTime(2022,07,19) }
        //};




    }
}
