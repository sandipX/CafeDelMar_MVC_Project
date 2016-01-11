using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CafeDelMar.Models
{
    public class OrdersContext
    {
        public int PlaceOrder(FoodOrdered o1)
        {
            int count = 0;
            List<Orders> tOrder = o1.FoodItems;
            string cStr = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cStr))
            {
                using (SqlCommand cmd = new SqlCommand("AddOrder", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oId = new SqlParameter("oId", SqlDbType.Int);
                    SqlParameter fId = new SqlParameter("fId", SqlDbType.Int);
                    SqlParameter qnty = new SqlParameter("qty", SqlDbType.Int);
                    oId.Value = o1.OrderId;
                    cmd.Parameters.Add(oId);
                    try
                    {
                        cn.Open();
                        foreach (Orders item in tOrder)
                        {
                            fId.Value = item.FoodId;
                            qnty.Value = item.Quantity;
                            cmd.Parameters.Add(fId);
                            cmd.Parameters.Add(qnty);
                            count += cmd.ExecuteNonQuery();
                        }

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
            return count;
        }
        public FoodOrdered GetSingleOrder(int OrderId)
        {
            FoodOrdered fd = new FoodOrdered();
            fd.OrderId = OrderId;
            string cStr = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cStr))
            {
                using (SqlCommand cmd = new SqlCommand("GetSingleOrder", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oId = new SqlParameter("oId", SqlDbType.Int);
                    oId.Value = OrderId;
                    cmd.Parameters.Add(oId);
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Orders ordr = new Orders();
                            ordr.FoodId = Convert.ToInt32(dr["FoodID"]);
                            ordr.Quantity = Convert.ToInt32(dr["Quantity"]);
                            fd.FoodItems.Add(ordr);
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

            return fd;
        }
    }
}