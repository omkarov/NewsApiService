using Microsoft.Data.SqlClient;
using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.DAL
{
    public class DBUtility
    {
        SqlConnection con = null;
        SqlCommand command = null;
        public string conStr = @"Data Source=MUM02L10266\SQLEXPRESS;Initial Catalog=Newsdb;User ID=sa;Password=Password123 ";
        string Qry = string.Empty;

        public void GetConnection()
        {
            try
            {
                con = new SqlConnection(conStr);
                con.Open();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Error in Connection " + se.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
        }

        //get all news
        public List<News> UtilityGetAllNews()
        {
            List<News> newslist = new List<News>();
            string getAllQuery = "select * from news ";
            GetConnection();
            command = new SqlCommand(getAllQuery, con);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        News news = new News();

                        news.NewsId = reader[0].ToString();
                        news.NewsAuthor = reader[1].ToString();
                        news.NewsCategory = (reader[2]).ToString();
                        news.ApprovedBy = reader["ApprovedBy"].ToString();
                        news.NewsLocation = (reader["NewsLocation"]).ToString();
                        news.NewsTitle = reader["NewsTitle"].ToString();
                        news.NewsMatter = reader["NewsMatter"].ToString();
                        news.NewsTime = Convert.ToDateTime(reader["NewsTime"]);
                        
                        newslist.Add(news);
                    }
                }
            }
            catch (Exception se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                con.Close();
            }
            return newslist;
        }

        //getnewsbyid
        public News UtilityGetNewsById(string newsId)
        {
            string getAllQuery = $"select * from news where NewsId= @Id ";  
            GetConnection();
            command = new SqlCommand(getAllQuery, con);

            SqlParameter idParam = new SqlParameter("@Id", newsId);
            command.Parameters.Add(idParam);
            News news = new News();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        news.NewsId = reader[0].ToString();
                        news.NewsAuthor = reader[1].ToString();
                        news.NewsCategory = (reader[2]).ToString();
                        news.ApprovedBy = reader["ApprovedBy"].ToString();
                        news.NewsLocation = (reader["NewsLocation"]).ToString();
                        news.NewsTitle = reader["NewsTitle"].ToString();
                        news.NewsMatter = reader["NewsMatter"].ToString();
                        news.NewsTime = Convert.ToDateTime(reader["NewsTime"]);
                    }
                }
                return news;
            }
            catch (Exception se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                con.Close();
            }
            return news;
        }


        //add news



        //deletenews
        public void UtilityDeleteNews(string newsId)
        {
            string getAllQuery = $" delete from news where newsId=@ ";

        }




        //updatenews

        //---------------------------------------------------

        //get all users
        public List<Account> UtilitygetAllUsers()
        {
            try
            {
                List<Account> userList = new List<Account>();
                Qry = $"select * from account";
                GetConnection();
                command = new SqlCommand(Qry, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userList.Add(new Account()
                        {
                            EmpId = reader[0].ToString(),
                            Name = reader[1].ToString(),
                            Email = reader[2].ToString(),
                            Password = reader[3].ToString(),
                            RoleId = (int)reader[4],
                            DateOfBirth = Convert.ToDateTime(reader[5]),
                            Nationality = reader[6].ToString(),
                            NewsCount = (int)reader[7],
                            UserIsApprovedByAdmin = Convert.ToBoolean(reader[8])


                        });
                    }
                }
                return userList;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();

            }
        }



        //getUserbyid
        public Account UtilityGetUserById(string empId)
        {
            string getAllQuery = $"select * from account where EmpId= @Id ";
            GetConnection();
            command = new SqlCommand(getAllQuery, con);
            SqlParameter idParam = new SqlParameter("@Id", empId);
            command.Parameters.Add(idParam);
            Account acc = new Account();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        acc.EmpId = reader[0].ToString();
                        acc.Name = reader[1].ToString();
                        acc.Email = reader[2].ToString();
                        acc.Password = reader[3].ToString();
                        acc.RoleId = (int)reader[4];
                        acc.DateOfBirth = Convert.ToDateTime(reader[5]);
                        acc.Nationality = reader[6].ToString();
                        acc.NewsCount = (int)reader[7];
                        acc.UserIsApprovedByAdmin = Convert.ToBoolean(reader[8]);
                    };
                }
                }
            catch (Exception se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                con.Close();
            }
                return acc;
        }








    }
}
