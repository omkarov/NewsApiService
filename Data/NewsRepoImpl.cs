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
        public IEnumerable<News> GetAllNews()
        {
            //return newsList;
            return dbutility.UtilityGetAllNews();
        }

        public News GetNewsById(string Id)
        {
            //return newsList.FirstOrDefault(x => x.NewsId.Equals(Id));
            return dbutility.UtilityGetNewsById(Id);
        }

        public void AddNews(News news)
        {
            if (news != null)
            {
                newsList.Add(news);
            }
        }

        public void DeleteNews(News news)
        {
            var tempNews = GetNewsById(news.NewsId);
            if (tempNews != null)
            {
                int pos = newsList.IndexOf(tempNews);
                newsList.RemoveAt(pos);
            }
        }


        List<News> newsList = new List<News>()
        {
            new News { NewsId ="N1" ,NewsAuthor="Omkar",NewsCategory="technical",ApprovedBy="true",NewsLocation="India", NewsTitle="testing1 title",NewsMatter="testing testing testing" ,NewsTime=new DateTime(2022,07,20) },
            new News { NewsId ="N2" ,NewsAuthor="Omkar",NewsCategory="General",ApprovedBy="true",NewsLocation="India", NewsTitle="testing1 title",NewsMatter="testing testing testing" ,NewsTime=new DateTime(2022,07,19) },
            new News { NewsId ="N2" ,NewsAuthor="Omkar",NewsCategory="General",ApprovedBy="true",NewsLocation="India", NewsTitle="testing1 title",NewsMatter="testing testing testing" ,NewsTime=new DateTime(2022,07,19) }
        };




    }
}
