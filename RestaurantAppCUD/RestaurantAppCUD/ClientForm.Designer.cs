namespace RestaurantAppCUD
{
    partial class ClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dniTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.notification = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre(s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Edad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Dirección";
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(451, 245);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 7;
            this.nextBtn.Text = "Siguiente";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.registerClient);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 78);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(237, 23);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.validateNameTextBox);
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(12, 137);
            this.ageTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(237, 23);
            this.ageTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 612);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 15);
            this.label5.TabIndex = 18;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(289, 78);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(237, 23);
            this.lastNameTextBox.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Apellidos";
            // 
            // dniTextBox
            // 
            this.dniTextBox.Location = new System.Drawing.Point(289, 137);
            this.dniTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dniTextBox.Name = "dniTextBox";
            this.dniTextBox.Size = new System.Drawing.Size(237, 23);
            this.dniTextBox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(289, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Documento";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(12, 196);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(237, 23);
            this.addressTextBox.TabIndex = 5;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(289, 196);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(237, 23);
            this.emailTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Correo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(12, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "Introduzca sus datos personales";
            // 
            // notification
            // 
            this.notification.AutoSize = true;
            this.notification.Location = new System.Drawing.Point(12, 249);
            this.notification.Name = "notification";
            this.notification.Size = new System.Drawing.Size(337, 15);
            this.notification.TabIndex = 27;
            this.notification.Text = "                                                                                 " +
    "                             ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 289);
            this.Controls.Add(this.notification);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dniTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrese en nuestro sistema";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label4;
        private Button nextBtn;
        private TextBox nameTextBox;
        private TextBox ageTextBox;
        private Label label5;
        private TextBox lastNameTextBox;
        private Label label6;
        private TextBox dniTextBox;
        private Label label7;
        private TextBox addressTextBox;
        private TextBox emailTextBox;
        private Label label3;
        private Label label8;
        private Label notification;
        private ErrorProvider errorProvider;
    }
}