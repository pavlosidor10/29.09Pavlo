namespace RPGGame.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обов’язкове поле конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelHealth;
        private System.Windows.Forms.Label labelMana;
        private System.Windows.Forms.Label labelGold;
        private System.Windows.Forms.Label labelStrength;
        private System.Windows.Forms.Label labelEndurance;
        private System.Windows.Forms.Label labelAgility;
        private System.Windows.Forms.Label labelIntelligence;
        private System.Windows.Forms.Button buttonFight;
        private System.Windows.Forms.Button buttonShop;

        private System.Windows.Forms.ListBox listBox1;

        /// <summary>
        /// Очистка ресурсів, що використовуються.
        /// </summary>
        /// <param name="disposing">true, якщо потрібно вивільнити керовані ресурси; інакше — false.</param>
       
        /// <summary>
        /// Ініціалізація елементів форми.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.labelHealth = new System.Windows.Forms.Label();
            this.labelMana = new System.Windows.Forms.Label();
            this.labelGold = new System.Windows.Forms.Label();
            this.labelStrength = new System.Windows.Forms.Label();
            this.labelEndurance = new System.Windows.Forms.Label();
            this.labelAgility = new System.Windows.Forms.Label();
            this.labelIntelligence = new System.Windows.Forms.Label();
            this.buttonFight = new System.Windows.Forms.Button();
            this.buttonShop = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(12, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(250, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Гравець: ---";
            // 
            // labelHealth
            // 
            this.labelHealth.Location = new System.Drawing.Point(12, 32);
            this.labelHealth.Name = "labelHealth";
            this.labelHealth.Size = new System.Drawing.Size(250, 20);
            this.labelHealth.TabIndex = 1;
            this.labelHealth.Text = "Здоров\'я: ---";
            // 
            // labelMana
            // 
            this.labelMana.Location = new System.Drawing.Point(12, 52);
            this.labelMana.Name = "labelMana";
            this.labelMana.Size = new System.Drawing.Size(250, 20);
            this.labelMana.TabIndex = 2;
            this.labelMana.Text = "Мана: ---";
            // 
            // labelGold
            // 
            this.labelGold.Location = new System.Drawing.Point(12, 72);
            this.labelGold.Name = "labelGold";
            this.labelGold.Size = new System.Drawing.Size(250, 20);
            this.labelGold.TabIndex = 3;
            this.labelGold.Text = "Золото: ---";
            // 
            // labelStrength
            // 
            this.labelStrength.Location = new System.Drawing.Point(12, 92);
            this.labelStrength.Name = "labelStrength";
            this.labelStrength.Size = new System.Drawing.Size(250, 20);
            this.labelStrength.TabIndex = 4;
            this.labelStrength.Text = "Сила: ---";
            // 
            // labelEndurance
            // 
            this.labelEndurance.Location = new System.Drawing.Point(12, 112);
            this.labelEndurance.Name = "labelEndurance";
            this.labelEndurance.Size = new System.Drawing.Size(250, 20);
            this.labelEndurance.TabIndex = 5;
            this.labelEndurance.Text = "Витривалість: ---";
            // 
            // labelAgility
            // 
            this.labelAgility.Location = new System.Drawing.Point(12, 132);
            this.labelAgility.Name = "labelAgility";
            this.labelAgility.Size = new System.Drawing.Size(250, 20);
            this.labelAgility.TabIndex = 6;
            this.labelAgility.Text = "Спритність: ---";
            // 
            // labelIntelligence
            // 
            this.labelIntelligence.Location = new System.Drawing.Point(12, 152);
            this.labelIntelligence.Name = "labelIntelligence";
            this.labelIntelligence.Size = new System.Drawing.Size(250, 20);
            this.labelIntelligence.TabIndex = 7;
            this.labelIntelligence.Text = "Інтелект: ---";
            // 
            // buttonFight
            // 
            this.buttonFight.Location = new System.Drawing.Point(321, 257);
            this.buttonFight.Name = "buttonFight";
            this.buttonFight.Size = new System.Drawing.Size(80, 30);
            this.buttonFight.TabIndex = 9;
            this.buttonFight.Text = "Бій";
            this.buttonFight.UseVisualStyleBackColor = true;
            // 
            // buttonShop
            // 
            this.buttonShop.Location = new System.Drawing.Point(500, 257);
            this.buttonShop.Name = "buttonShop";
            this.buttonShop.Size = new System.Drawing.Size(80, 30);
            this.buttonShop.TabIndex = 10;
            this.buttonShop.Text = "Магазин";
            this.buttonShop.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(300, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(280, 204);
            this.listBox1.TabIndex = 11;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(815, 360);
            this.Controls.Add(this.labelHealth);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelGold);
            this.Controls.Add(this.labelStrength);
            this.Controls.Add(this.labelEndurance);
            this.Controls.Add(this.labelAgility);
            this.Controls.Add(this.labelIntelligence);
            this.Controls.Add(this.buttonFight);
            this.Controls.Add(this.buttonShop);
            this.Controls.Add(this.listBox1);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }
    }
}
