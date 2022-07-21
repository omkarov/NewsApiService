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

        
        public  void  GetConnection()
        {
            try
            {
                con = new SqlConnection(conStr);
                 con.OpenAsync();
            }
            catch (SqlException se)
            {
                Console.WriteLine("Error in Connection " + se.Message);
            }
        }

        public async Task CloseConnection()
        {
            try
            {
                if (con != null)
                {
                    await con.CloseAsync();
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
        }

        //get all news
        public async Task<List<News>> UtilityGetAllNewsAsync()
        {
            List<News> newslist = new List<News>();
            string getAllQuery = "select * from news ";
            GetConnection();
            command = new SqlCommand(getAllQuery, con);
            try
            {
                SqlDataReader reader = await command.ExecuteReaderAsync();
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
                await con.CloseAsync();
            }
            return newslist;
        }

        //getnewsbyid
        public async Task<News> UtilityGetNewsByIdAsync(string newsId)
        {
            string getAllQuery = $"select * from news where NewsId= @Id ";
           GetConnection();
            command = new SqlCommand(getAllQuery, con);

            SqlParameter idParam = new SqlParameter("@Id", newsId);
             command.Parameters.Add(idParam);
            News news = new News();
            try
            {
                SqlDataReader reader = await command.ExecuteReaderAsync();
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
            }
            catch (Exception se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                await con.CloseAsync();
            }
            return news;

        }

        //add news
        public async Task UtilityAddNewsAsync(News news)
        {
            string getAllQuery = $"Insert into news VALUES('{news.NewsId}','{news.NewsAuthor}' ,'{news.NewsCategory}' , '{news.ApprovedBy}','{news.NewsLocation}','{news.NewsTitle}','{news.NewsMatter}','{news.NewsTime}' ) ";
            GetConnection();
            command = new SqlCommand(getAllQuery, con);
            
            try
            {
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    Console.WriteLine(reader);
                }

            }
            catch (Exception se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                await con.CloseAsync();
            }

        }
        //deletenews
        public async Task UtilityDeleteNewsAsync(string newsId)
        {
            try
            {
            bool isDeleted  =   false;
            string delQuery = $" delete from news where newsId=@Id";
             GetConnection();
            command = new SqlCommand(delQuery, con);
            SqlParameter idParam = new SqlParameter("@Id", newsId);
            command.Parameters.Add(idParam);
            int res  =  await command.ExecuteNonQueryAsync();
                if (res>0)
                {
                    Console.WriteLine("RowDeleted");
                    isDeleted   =   true;
                }
                //return isDeleted;

            }
            catch (Exception se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                await con.CloseAsync();
            }

        }


        //updatenews

        //---------------------------------------------------
        
        //get all users
        public List<Account> UtilitygetAllUsers()
        {
                List<Account> userList = new List<Account>();
            try
            {
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
            }
            catch (Exception se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                con.Close();
            }
            return userList;
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

        //UtilityGetUserByEmail
        public Account UtilityGetUserByEmail(string email)
        {
            string getAllQuery = $"select * from account where Email = '{email}' ";
            GetConnection();
            command = new SqlCommand(getAllQuery, con);
            //SqlParameter idParam = new SqlParameter("@Id", email);
            //command.Parameters.Add(idParam);
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

        PasswordManager passwordm = new PasswordManager();
        //add user
        public void UtilityAddAccount(Account acc)
        {
            string hpwd = passwordm.HashPasswordEncoder(acc.Password);

            string getAllQuery = $"Insert into account VALUES('{acc.EmpId}','{acc.Name}' ,'{acc.Email}' , '{hpwd}','{acc.RoleId}','{acc.DateOfBirth}','{acc.Nationality}','{acc.NewsCount}','{acc.UserIsApprovedByAdmin}' ) ";
            GetConnection();
            command = new SqlCommand(getAllQuery, con);

            try
            {
                int res = command.ExecuteNonQuery();
                if (res  >  0)
                {
                    Console.WriteLine("Row Inserted");
                }
                else
                    Console.WriteLine("Insertion Failed.");

            }
            catch (Exception se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                con.Close();
            }

        }

        

        //delete user
        public void UtilityDeleteAccount(string empId)
        {
            try
            {
                bool isDeleted   =   false;
            string delQuery = $" delete from account where EmpId=@Id";
            GetConnection();
            command = new SqlCommand(delQuery, con);
            SqlParameter idParam = new SqlParameter("@Id", empId);
            command.Parameters.Add(idParam);
            int res  =  command.ExecuteNonQuery();

                if (res>0)
                {
                    Console.WriteLine("Row Deleted");
                    isDeleted  =  true;
                }
                //return isDeleted;

            }
            catch (Exception se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                con.Close();
            }

        }

        //approve user






    }
}
