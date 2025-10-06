namespace RPGGame.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обов’язкове поле конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonFight;
        private System.Windows.Forms.Button buttonShop;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;

        /// <summary>
        /// Очищення ресурсів, що використовуються.
        /// </summary>
        /// <param name="disposing">true, якщо потрібно вивільнити керовані ресурси; інакше — false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Ініціалізація елементів форми.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFight = new System.Windows.Forms.Button();
            this.buttonShop = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFight
            // 
            this.buttonFight.Location = new System.Drawing.Point(371, 276);
            this.buttonFight.Name = "buttonFight";
            this.buttonFight.Size = new System.Drawing.Size(180, 74);
            this.buttonFight.TabIndex = 1;
            this.buttonFight.Text = "Подорож";
            this.buttonFight.UseVisualStyleBackColor = true;
            this.buttonFight.Click += new System.EventHandler(this.buttonFight_Click);
            // 
            // buttonShop
            // 
            this.buttonShop.Location = new System.Drawing.Point(701, 276);
            this.buttonShop.Name = "buttonShop";
            this.buttonShop.Size = new System.Drawing.Size(149, 74);
            this.buttonShop.TabIndex = 2;
            this.buttonShop.Text = "Магазин";
            this.buttonShop.UseVisualStyleBackColor = true;
            this.buttonShop.Click += new System.EventHandler(this.buttonShop_Click);
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(68, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(750, 244);
            this.listBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 63);
            this.button1.TabIndex = 4;
            this.button1.Text = "Інвентар";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 477);
            this.Controls.Add(this.buttonFight);
            this.Controls.Add(this.buttonShop);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "RPG Game";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }
    }
}

