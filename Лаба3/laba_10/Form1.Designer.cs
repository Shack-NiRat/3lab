namespace laba_10
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.provider_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.buyer_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.order_number = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.res = new System.Windows.Forms.Label();
            this.go = new System.Windows.Forms.Button();
            this.addRow = new System.Windows.Forms.Button();
            this.go_Excel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // provider_textBox
            // 
            this.provider_textBox.Location = new System.Drawing.Point(86, 12);
            this.provider_textBox.Name = "provider_textBox";
            this.provider_textBox.Size = new System.Drawing.Size(164, 20);
            this.provider_textBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поставщик";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 45);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(67, 13);
            this.label.TabIndex = 2;
            this.label.Text = "Покупатель";
            // 
            // buyer_textBox
            // 
            this.buyer_textBox.Location = new System.Drawing.Point(86, 45);
            this.buyer_textBox.Name = "buyer_textBox";
            this.buyer_textBox.Size = new System.Drawing.Size(164, 20);
            this.buyer_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(631, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Заказ №:";
            // 
            // order_number
            // 
            this.order_number.Location = new System.Drawing.Point(692, 15);
            this.order_number.Name = "order_number";
            this.order_number.Size = new System.Drawing.Size(96, 20);
            this.order_number.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(634, 45);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(154, 20);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(770, 255);
            this.dataGridView1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Итого:";
            this.label3.UseMnemonic = false;
            // 
            // res
            // 
            this.res.AutoSize = true;
            this.res.Location = new System.Drawing.Point(15, 360);
            this.res.Name = "res";
            this.res.Size = new System.Drawing.Size(0, 13);
            this.res.TabIndex = 10;
            // 
            // go
            // 
            this.go.Location = new System.Drawing.Point(330, 374);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(185, 23);
            this.go.TabIndex = 11;
            this.go.Text = "Сформировать документ в Word";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.go_Click);
            // 
            // addRow
            // 
            this.addRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addRow.Location = new System.Drawing.Point(736, 335);
            this.addRow.Name = "addRow";
            this.addRow.Size = new System.Drawing.Size(52, 50);
            this.addRow.TabIndex = 12;
            this.addRow.Text = "+";
            this.addRow.UseVisualStyleBackColor = true;
            this.addRow.Click += new System.EventHandler(this.addRow_Click);
            // 
            // go_Excel
            // 
            this.go_Excel.Location = new System.Drawing.Point(330, 403);
            this.go_Excel.Name = "go_Excel";
            this.go_Excel.Size = new System.Drawing.Size(185, 23);
            this.go_Excel.TabIndex = 13;
            this.go_Excel.Text = "Сформировать документ в Excel";
            this.go_Excel.UseVisualStyleBackColor = true;
            this.go_Excel.Click += new System.EventHandler(this.go_Excel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 455);
            this.Controls.Add(this.go_Excel);
            this.Controls.Add(this.addRow);
            this.Controls.Add(this.go);
            this.Controls.Add(this.res);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.order_number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buyer_textBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.provider_textBox);
            this.Name = "Form1";
            this.Text = "Сформировать накладную";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox provider_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox buyer_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox order_number;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label res;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.Button addRow;
        private System.Windows.Forms.Button go_Excel;
    }
}

