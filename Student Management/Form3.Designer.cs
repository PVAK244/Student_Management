namespace Student_Management
{
    partial class Form3
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
            this.lsvStudents = new System.Windows.Forms.ListView();
            this.lsbClass = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lsvStudents
            // 
            this.lsvStudents.HideSelection = false;
            this.lsvStudents.Location = new System.Drawing.Point(372, 145);
            this.lsvStudents.Name = "lsvStudents";
            this.lsvStudents.Size = new System.Drawing.Size(400, 200);
            this.lsvStudents.TabIndex = 7;
            this.lsvStudents.UseCompatibleStateImageBehavior = false;
            // 
            // lsbClass
            // 
            this.lsbClass.FormattingEnabled = true;
            this.lsbClass.ItemHeight = 15;
            this.lsbClass.Location = new System.Drawing.Point(12, 145);
            this.lsbClass.Name = "lsbClass";
            this.lsbClass.Size = new System.Drawing.Size(307, 199);
            this.lsbClass.TabIndex = 8;
            this.lsbClass.SelectedIndexChanged += new System.EventHandler(this.lsbClass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(132, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "List of Classes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(514, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "List of Students";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsbClass);
            this.Controls.Add(this.lsvStudents);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvStudents;
        private System.Windows.Forms.ListBox lsbClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}