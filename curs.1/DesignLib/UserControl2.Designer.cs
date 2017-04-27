namespace DesignLib
{
    partial class UserControl2
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl2));
            this.orderpan = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // orderpan
            // 
            this.orderpan.BackColor = System.Drawing.Color.Transparent;
            this.orderpan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("orderpan.BackgroundImage")));
            this.orderpan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.orderpan.Location = new System.Drawing.Point(176, 67);
            this.orderpan.Name = "orderpan";
            this.orderpan.Size = new System.Drawing.Size(542, 345);
            this.orderpan.TabIndex = 23;
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.Controls.Add(this.orderpan);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(895, 507);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel orderpan;
    }
}
