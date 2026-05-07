namespace ObuV
{
    partial class AdminProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblArticle = new System.Windows.Forms.Label();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.txtPhoto = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            int labelX = 20;
            int fieldX = 160;
            int width = 300;
            int rowH = 35;
            int startY = 20;

            this.lblArticle.Text = "Артикул:";
            this.lblArticle.Location = new System.Drawing.Point(labelX, startY);
            this.lblArticle.AutoSize = true;
            this.txtArticle.Location = new System.Drawing.Point(fieldX, startY - 3);
            this.txtArticle.Size = new System.Drawing.Size(width, 20);
            this.txtArticle.Name = "txtArticle";

            this.lblName.Text = "Наименование:";
            this.lblName.Location = new System.Drawing.Point(labelX, startY + rowH);
            this.lblName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(fieldX, startY + rowH - 3);
            this.txtName.Size = new System.Drawing.Size(width, 20);
            this.txtName.Name = "txtName";

            this.lblUnit.Text = "Ед. изм.:";
            this.lblUnit.Location = new System.Drawing.Point(labelX, startY + rowH * 2);
            this.lblUnit.AutoSize = true;
            this.txtUnit.Location = new System.Drawing.Point(fieldX, startY + rowH * 2 - 3);
            this.txtUnit.Size = new System.Drawing.Size(width, 20);
            this.txtUnit.Name = "txtUnit";

            this.lblCost.Text = "Цена:";
            this.lblCost.Location = new System.Drawing.Point(labelX, startY + rowH * 3);
            this.lblCost.AutoSize = true;
            this.txtCost.Location = new System.Drawing.Point(fieldX, startY + rowH * 3 - 3);
            this.txtCost.Size = new System.Drawing.Size(width, 20);
            this.txtCost.Name = "txtCost";

            this.lblManufacturer.Text = "Производитель:";
            this.lblManufacturer.Location = new System.Drawing.Point(labelX, startY + rowH * 4);
            this.lblManufacturer.AutoSize = true;
            this.txtManufacturer.Location = new System.Drawing.Point(fieldX, startY + rowH * 4 - 3);
            this.txtManufacturer.Size = new System.Drawing.Size(width, 20);
            this.txtManufacturer.Name = "txtManufacturer";

            this.lblSupplier.Text = "Поставщик:";
            this.lblSupplier.Location = new System.Drawing.Point(labelX, startY + rowH * 5);
            this.lblSupplier.AutoSize = true;
            this.txtSupplier.Location = new System.Drawing.Point(fieldX, startY + rowH * 5 - 3);
            this.txtSupplier.Size = new System.Drawing.Size(width, 20);
            this.txtSupplier.Name = "txtSupplier";

            this.lblCategory.Text = "Категория:";
            this.lblCategory.Location = new System.Drawing.Point(labelX, startY + rowH * 6);
            this.lblCategory.AutoSize = true;
            this.txtCategory.Location = new System.Drawing.Point(fieldX, startY + rowH * 6 - 3);
            this.txtCategory.Size = new System.Drawing.Size(width, 20);
            this.txtCategory.Name = "txtCategory";

            this.lblDiscount.Text = "Скидка (%):";
            this.lblDiscount.Location = new System.Drawing.Point(labelX, startY + rowH * 7);
            this.lblDiscount.AutoSize = true;
            this.txtDiscount.Location = new System.Drawing.Point(fieldX, startY + rowH * 7 - 3);
            this.txtDiscount.Size = new System.Drawing.Size(width, 20);
            this.txtDiscount.Name = "txtDiscount";

            this.lblStock.Text = "На складе:";
            this.lblStock.Location = new System.Drawing.Point(labelX, startY + rowH * 8);
            this.lblStock.AutoSize = true;
            this.txtStock.Location = new System.Drawing.Point(fieldX, startY + rowH * 8 - 3);
            this.txtStock.Size = new System.Drawing.Size(width, 20);
            this.txtStock.Name = "txtStock";

            this.lblDescription.Text = "Описание:";
            this.lblDescription.Location = new System.Drawing.Point(labelX, startY + rowH * 9);
            this.lblDescription.AutoSize = true;
            this.txtDescription.Location = new System.Drawing.Point(fieldX, startY + rowH * 9 - 3);
            this.txtDescription.Size = new System.Drawing.Size(width, 60);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";

            this.lblPhoto.Text = "Фото (имя файла):";
            this.lblPhoto.Location = new System.Drawing.Point(labelX, startY + rowH * 9 + 65);
            this.lblPhoto.AutoSize = true;
            this.txtPhoto.Location = new System.Drawing.Point(fieldX, startY + rowH * 9 + 62);
            this.txtPhoto.Size = new System.Drawing.Size(width, 20);
            this.txtPhoto.Name = "txtPhoto";

            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(160, startY + rowH * 9 + 95);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#00FA9A");
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(270, startY + rowH * 9 + 95);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.BackColor = System.Drawing.ColorTranslator.FromHtml("#7FFF00");
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, startY + rowH * 9 + 140);
            this.Font = new System.Drawing.Font("Times New Roman", 10f);
            this.BackColor = System.Drawing.Color.White;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblArticle, txtArticle,
                lblName, txtName,
                lblUnit, txtUnit,
                lblCost, txtCost,
                lblManufacturer, txtManufacturer,
                lblSupplier, txtSupplier,
                lblCategory, txtCategory,
                lblDiscount, txtDiscount,
                lblStock, txtStock,
                lblDescription, txtDescription,
                lblPhoto, txtPhoto,
                btnSave, btnCancel
            });
            this.Name = "AdminProductForm";
            this.Load += new System.EventHandler(this.AdminProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblArticle;
        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.TextBox txtPhoto;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}