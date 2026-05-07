using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ObuV
{
    public partial class AdminProductForm : Form
    {
        private int? _productId;

        public AdminProductForm(int? productId = null)
        {
            InitializeComponent();
            _productId = productId;
            this.Text = productId == null ? "Добавить товар" : "Редактировать товар";
        }

        private void AdminProductForm_Load(object sender, EventArgs e)
        {
            if (_productId.HasValue)
                LoadProduct(_productId.Value);
        }

        private void LoadProduct(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Product WHERE ProductID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        txtArticle.Text = r["ProductArticleNumber"].ToString();
                        txtName.Text = r["ProductName"].ToString();
                        txtUnit.Text = r["Unit"].ToString();
                        txtCost.Text = r["Cost"].ToString();
                        txtManufacturer.Text = r["Manufacturer"].ToString();
                        txtSupplier.Text = r["Supplier"].ToString();
                        txtCategory.Text = r["Category"].ToString();
                        txtDiscount.Text = r["DiscountAmount"].ToString();
                        txtStock.Text = r["QuantityInStock"].ToString();
                        txtDescription.Text = r["Description"].ToString();
                        txtPhoto.Text = r["Photo"].ToString();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArticle.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Заполните обязательные поля (Артикул, Наименование)!");
                return;
            }

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd;

                if (_productId == null)
                {
                    cmd = new SqlCommand(@"
                    INSERT INTO Product (ProductArticleNumber, ProductName, Unit, Cost,
                        Manufacturer, Supplier, Category, DiscountAmount, QuantityInStock, Description, Photo)
                    VALUES (@article, @name, @unit, @cost, @mfr, @sup, @cat, @disc, @qty, @desc, @photo)", conn);
                }
                else
                {
                    cmd = new SqlCommand(@"
                    UPDATE Product SET
                        ProductArticleNumber = @article,
                        ProductName = @name, Unit = @unit, Cost = @cost,
                        Manufacturer = @mfr, Supplier = @sup, Category = @cat,
                        DiscountAmount = @disc, QuantityInStock = @qty,
                        Description = @desc, Photo = @photo
                    WHERE ProductID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", _productId.Value);
                }

                cmd.Parameters.AddWithValue("@article", txtArticle.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@unit", txtUnit.Text);
                cmd.Parameters.AddWithValue("@cost", decimal.Parse(txtCost.Text));
                cmd.Parameters.AddWithValue("@mfr", txtManufacturer.Text);
                cmd.Parameters.AddWithValue("@sup", txtSupplier.Text);
                cmd.Parameters.AddWithValue("@cat", txtCategory.Text);
                cmd.Parameters.AddWithValue("@disc", int.Parse(txtDiscount.Text));
                cmd.Parameters.AddWithValue("@qty", int.Parse(txtStock.Text));
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@photo", txtPhoto.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Сохранено успешно!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
