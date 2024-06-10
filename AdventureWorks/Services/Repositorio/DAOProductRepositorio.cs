using AdventureWorks.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AdventureWorks.Services.Repositorio
{
    public class DAOProductRepositorio : IProductoRepositorio
    {
        private readonly String CadenaDeConexion =
            "server=(localdb)\\MSSQLLocalDB;database=AdventureWorks2016;Integrated Security=True";

        private readonly SqlConnection _conexion;
        private SqlCommand? _comando = null;
        public DAOProductRepositorio()
        {
            _conexion = new SqlConnection(CadenaDeConexion);
        }

        public async Task<List<Product>> DameTodos()
        {
            List<Product> lista = new();
            _conexion.Open();
            String sentencia = "SELECT " +
                               "ProductID, Name, ProductNumber, MakeFlag, FinishedGoodsFlag, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice," +
                               "SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture, ProductLine, Class," +
                               "Style, ProductSubcategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate, rowguid, ModifiedDate " +
                               "FROM [AdventureWorks2016].[Production].[Product]";
            _comando = new SqlCommand(sentencia, this._conexion);
            SqlDataReader reader = _comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product miProducto = new()
                    {
                        ProductId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        ProductNumber = reader.GetString(2),
                        MakeFlag = reader.GetBoolean(3),
                        FinishedGoodsFlag = reader.GetBoolean(4),
                        Color = reader.GetString(5),
                        SafetyStockLevel = reader.GetInt16(6),
                        ReorderPoint = reader.GetInt16(7),
                        ListPrice = reader.GetDecimal(8),
                        SizeUnitMeasureCode = reader.GetString(9),
                        WeightUnitMeasureCode = reader.GetString(10),
                        Weight = reader.GetDecimal(11),
                        DaysToManufacture = reader.GetInt32(12),



                    };
                    lista.Add(miProducto);
                }
            }
            return await Task.Run(()=>lista);
        }

        public async Task<Product?> DameUno(int Id)
        {
            return await Task.Run(()=>new Product());
        }

        public async Task<bool> BorrarProducto(int Id)
        {
            return await Task.Run(() => true);
        }

        public async Task<bool> Agregar(Product product)
        {
            return await Task.Run(() => true);
        }

        public async Task<bool> Modificar(int Id, Product product)
        {
            return await Task.Run(() => true);
        }
    }
}
