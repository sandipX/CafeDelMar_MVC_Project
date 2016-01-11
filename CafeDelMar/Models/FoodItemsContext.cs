using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace CafeDelMar.Models
{
    public class FoodItemsContext
    {
        public List<FoodItems> GetAllItems()
        {
            List<FoodItems> FoodList = new List<FoodItems>();
            string cStr = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cStr))
            {
                using (SqlCommand cmd = new SqlCommand("GetItems", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            FoodItems fitem = new FoodItems();
                            fitem.ID = Convert.ToInt32(dr[0]);
                            fitem.Name = dr[1].ToString();
                            fitem.Price = Convert.ToInt32(dr[2]);
                            fitem.FoodType = Convert.ToInt32(dr[3]);
                            FoodList.Add(fitem);

                        }
                        dr.Close();
                    }
                    catch (SqlException se)
                    {
                        throw se;
                    }
                    finally
                    {
                        if (cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }

            return FoodList;
        }

    }
}