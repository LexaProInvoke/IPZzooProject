namespace SPZlab1
{
    partial class AddAnimal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAnimalName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxKindOfAnimal = new System.Windows.Forms.TextBox();
            this.buttonAddAnimal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the name of the new animal";
            // 
            // textBoxAnimalName
            // 
            this.textBoxAnimalName.Location = new System.Drawing.Point(54, 79);
            this.textBoxAnimalName.Name = "textBoxAnimalName";
            this.textBoxAnimalName.Size = new System.Drawing.Size(246, 22);
            this.textBoxAnimalName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter kind of animal";
            // 
            // textBoxKindOfAnimal
            // 
            this.textBoxKindOfAnimal.Location = new System.Drawing.Point(54, 147);
            this.textBoxKindOfAnimal.Name = "textBoxKindOfAnimal";
            this.textBoxKindOfAnimal.Size = new System.Drawing.Size(246, 22);
            this.textBoxKindOfAnimal.TabIndex = 3;
            // 
            // buttonAddAnimal
            // 
            this.buttonAddAnimal.Location = new System.Drawing.Point(304, 199);
            this.buttonAddAnimal.Name = "buttonAddAnimal";
            this.buttonAddAnimal.Size = new System.Drawing.Size(95, 23);
            this.buttonAddAnimal.TabIndex = 4;
            this.buttonAddAnimal.Text = "AddAnimal";
            this.buttonAddAnimal.UseVisualStyleBackColor = true;
            // 
            // AddAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 243);
            this.Controls.Add(this.buttonAddAnimal);
            this.Controls.Add(this.textBoxKindOfAnimal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAnimalName);
            this.Controls.Add(this.label1);
            this.Name = "AddAnimal";
            this.Text = "AddAnimal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAnimalName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxKindOfAnimal;
        private System.Windows.Forms.Button buttonAddAnimal;
    }
}