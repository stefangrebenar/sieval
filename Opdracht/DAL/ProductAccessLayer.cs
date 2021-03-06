using Opdracht.Models;
using System.Data.SqlClient;

namespace Opdracht.DAL
{
    public class ProductAccessLayer
    {
        private const string ConnectionString = @"Data Source=localhost;Initial Catalog=Products;Trusted_Connection=True;Database=SievalArtikelDb";

        public List<ProductModel> GetProductList()
        {
            var productList = new List<ProductModel>();
            string sqlQuery = "SELECT ProductId, Sku, ProductName, Price FROM Products";

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
                SqlDataReader rdr = sqlCmd.ExecuteReader();

                while (rdr.Read())
                {
                    var productModel = new ProductModel();
                    productModel.Id = Convert.ToInt32(rdr["ProductId"]);
                    productModel.Sku = rdr["Sku"].ToString();
                    productModel.ProductName = rdr["ProductName"].ToString();
                    productModel.Price = Convert.ToDecimal(rdr["Price"]);
                    productList.Add(productModel);

                }

                sqlCon.Close();
            }

            return productList;
        }

        public ProductModel GetProduct(int id)
        {
            var productModel = new ProductModel();
            string sqlQuery = "SELECT ProductId, Sku, ProductName, Price FROM Products WHERE ProductId = " + id;

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
                SqlDataReader rdr = sqlCmd.ExecuteReader();

                while (rdr.Read())
                {
                    productModel.Id = Convert.ToInt32(rdr["ProductId"]);
                    productModel.Sku = rdr["Sku"].ToString();
                    productModel.ProductName = rdr["ProductName"].ToString();
                    productModel.Price = Convert.ToDecimal(rdr["Price"]);

                }

                sqlCon.Close();
            }

            return productModel;
        }

        public bool AddProduct(ProductModel productModel)
        {
            string sqlQuery = "INSERT INTO Products VALUES(@Sku, @ProductName, @Price)";
            int result;
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand(sqlQuery,sqlCon);
                sqlCmd.Parameters.AddWithValue("@Sku", productModel.Sku);
                sqlCmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
                sqlCmd.Parameters.AddWithValue("@Price", productModel.Price);

                sqlCon.Open();
                result = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

            }
            return result == 1;
        }

        public bool UpdateProduct(ProductModel productModel)
        {
            string sqlQuery = "UPDATE Products SET Sku = @Sku, ProductName = @ProductName, Price = @Price WHERE ProductId = @Id";
            int result;
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Sku", productModel.Sku);
                sqlCmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
                sqlCmd.Parameters.AddWithValue("@Price", productModel.Price);
                sqlCmd.Parameters.AddWithValue("@Id", productModel.Id);

                sqlCon.Open();
                result = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

            }
            return result == 1;
        }

        public bool DeleteProduct(int id)
        {
            string sqlQuery = "DELETE FROM Products WHERE ProductId = " + id;
            int result;

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
                sqlCon.Open();
                result = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            return result == 1;
        }
    }
}
