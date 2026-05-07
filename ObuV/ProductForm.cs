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

namespace ObuV
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void LoadProducts(string search = "", string category = "", string manufacturer = "", string sort = "")
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT ProductID, ProductArticleNumber, ProductName, Cost,
                   Manufacturer, Supplier, Category, DiscountAmount, QuantityInStock
            FROM Product
            WHERE 1=1";

                if (!string.IsNullOrEmpty(search))
                    query += " AND (ProductName LIKE @search OR ProductArticleNumber LIKE @search OR Description LIKE @search)";

                if (!string.IsNullOrEmpty(category) && category != "Все категории")
                    query += " AND Category = @category";

                if (!string.IsNullOrEmpty(manufacturer) && manufacturer != "Все производители")
                    query += " AND Manufacturer = @manufacturer";

                switch (sort)
                {
                    case "Название А-Я": query += " ORDER BY ProductName ASC"; break;
                    case "Название Я-А": query += " ORDER BY ProductName DESC"; break;
                    case "Цена (возр.)": query += " ORDER BY Cost ASC"; break;
                    case "Цена (убыв.)": query += " ORDER BY Cost DESC"; break;
                    case "Скидка (возр.)": query += " ORDER BY DiscountAmount ASC"; break;
                    case "Скидка (убыв.)": query += " ORDER BY DiscountAmount DESC"; break;
                    default: query += " ORDER BY ProductID"; break;
                }

                using (var cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(search))
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                    if (!string.IsNullOrEmpty(category) && category != "Все категории")
                        cmd.Parameters.AddWithValue("@category", category);
                    if (!string.IsNullOrEmpty(manufacturer) && manufacturer != "Все производители")
                        cmd.Parameters.AddWithValue("@manufacturer", manufacturer);

                    var table = new System.Data.DataTable();
                    var adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);

                    dgvProducts.DataSource = table;
                    dgvProducts.Columns["ProductID"].Visible = false;


                    dgvProducts.Columns["ProductArticleNumber"].HeaderText = "Артикул";
                    dgvProducts.Columns["ProductName"].HeaderText = "Наименование";
                    dgvProducts.Columns["Cost"].HeaderText = "Цена";
                    dgvProducts.Columns["Manufacturer"].HeaderText = "Производитель";
                    dgvProducts.Columns["Supplier"].HeaderText = "Поставщик";
                    dgvProducts.Columns["Category"].HeaderText = "Категория";
                    dgvProducts.Columns["DiscountAmount"].HeaderText = "Скидка (%)";
                    dgvProducts.Columns["QuantityInStock"].HeaderText = "На складе";

                    ColorDiscountRows();
                }
            }
        }

        private void ColorDiscountRows()
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.IsNewRow) continue;
                int discount = Convert.ToInt32(row.Cells["DiscountAmount"].Value);
                if (discount > 15)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E8B57");
                    row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        private void LoadFilterData()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                var cmdCat = new SqlCommand("SELECT DISTINCT Category FROM Product ORDER BY Category", conn);
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("Все категории");
                using (var r = cmdCat.ExecuteReader())
                    while (r.Read()) cmbCategory.Items.Add(r.GetString(0));
                cmbCategory.SelectedIndex = 0;

                var cmdMan = new SqlCommand("SELECT DISTINCT Manufacturer FROM Product ORDER BY Manufacturer", conn);
                cmbManufacturer.Items.Clear();
                cmbManufacturer.Items.Add("Все производители");
                using (var r = cmdMan.ExecuteReader())
                    while (r.Read()) if (!r.IsDBNull(0)) cmbManufacturer.Items.Add(r.GetString(0));
                cmbManufacturer.SelectedIndex = 0;
            }

                cmbSort.Items.Clear();
                cmbSort.Items.AddRange(new string[] {
                "По умолчанию", "Название А-Я", "Название Я-А",
                "Цена (возр.)", "Цена (убыв.)", "Скидка (возр.)", "Скидка (убыв.)"
                });
                cmbSort.SelectedIndex = 0;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            bool isAdmin = CurrentUser.IsAdmin;
            bool canFilter = CurrentUser.IsAdmin || CurrentUser.IsManager;

            btnAdd.Visible = isAdmin;
            btnEdit.Visible = isAdmin;
            btnDelete.Visible = isAdmin;
            btnOrders.Visible = isAdmin || CurrentUser.IsManager;

            txtSearch.Visible = canFilter;
            cmbCategory.Visible = canFilter;
            cmbManufacturer.Visible = canFilter;
            cmbSort.Visible = canFilter;
            btnSearch.Visible = canFilter;
            btnReset.Visible = canFilter;

            lblRole.Text = "Вы вошли как: " + CurrentUser.FullName + " (" + CurrentUser.RoleName + ")";

            LoadFilterData();

            LoadProducts();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            var orderForm = new OrderForm();
            orderForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ProductID"].Value);

            var result = MessageBox.Show("Удалить товар?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    var cmd = new SqlCommand("DELETE FROM Product WHERE ProductID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadProducts();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ProductID"].Value);
            var form = new AdminProductForm(id);
            if (form.ShowDialog() == DialogResult.OK)
                LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AdminProductForm();
            if (form.ShowDialog() == DialogResult.OK)
                LoadProducts();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.Clear();
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProducts(
                txtSearch.Text,
                cmbCategory.SelectedItem?.ToString(),
                cmbManufacturer.SelectedItem?.ToString(),
                cmbSort.SelectedItem?.ToString()
            );
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategory.SelectedIndex = 0;
            cmbManufacturer.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            LoadProducts();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
