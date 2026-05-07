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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT o.OrderID, o.OrderCode, o.OrderStatus,
                   o.OrderDate, o.DeliveryDate,
                   u.UserSurname + ' ' + u.UserName AS ClientName,
                   pp.City + ', ' + pp.Street + ', ' + CAST(pp.House AS NVARCHAR) AS Address
            FROM [Order] o
            LEFT JOIN [User] u ON o.UserID = u.UserID
            LEFT JOIN PickupPoint pp ON o.PickupPointID = pp.PointID
            ORDER BY o.OrderDate DESC";

                var cmd = new SqlCommand(query, conn);
                var table = new System.Data.DataTable();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);

                dgvOrders.DataSource = table;
                dgvOrders.Columns["OrderID"].Visible = false;
                dgvOrders.Columns["OrderCode"].HeaderText = "Код заказа";
                dgvOrders.Columns["OrderStatus"].HeaderText = "Статус";
                dgvOrders.Columns["OrderDate"].HeaderText = "Дата заказа";
                dgvOrders.Columns["DeliveryDate"].HeaderText = "Дата доставки";
                dgvOrders.Columns["ClientName"].HeaderText = "Клиент";
                dgvOrders.Columns["Address"].HeaderText = "Пункт выдачи";
            }
        }
    }
}
