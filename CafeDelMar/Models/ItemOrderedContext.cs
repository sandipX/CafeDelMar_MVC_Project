using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CafeDelMar.Models
{
    public class ItemOrderedContext
    {
        public List<ItemOrdered> GetAllOrderDetail()
        {
            List<ItemOrdered> totalOrders = new List<ItemOrdered>();
            string cStr = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cStr))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllOrderedItems", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ItemOrdered i1 = new ItemOrdered();
                        i1.Name =dr[0].ToString();
                        i1.Count = Convert.ToInt32(dr[1]);
                        i1.TotalIncome = Convert.ToInt32(dr[2]);
                        totalOrders.Add(i1);
                    }
                    dr.Close();

                    }
                    catch (SqlException se)
                    {
                        
                        
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


            return totalOrders;
        }
    }
}
