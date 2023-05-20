namespace RatingSystem
{
    partial class EmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            this.employeeNameMaterialLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.commentsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.goBackButton = new System.Windows.Forms.Button();
            this.saveCommentButton = new System.Windows.Forms.Button();
            this.profileRoundedPictureBox = new RatingSystem.RoundedPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.profileRoundedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // employeeNameMaterialLabel
            // 
            this.employeeNameMaterialLabel.AutoSize = true;
            this.employeeNameMaterialLabel.Depth = 0;
            this.employeeNameMaterialLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.employeeNameMaterialLabel.Location = new System.Drawing.Point(200, 44);
            this.employeeNameMaterialLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.employeeNameMaterialLabel.Name = "employeeNameMaterialLabel";
            this.employeeNameMaterialLabel.Size = new System.Drawing.Size(208, 19);
            this.employeeNameMaterialLabel.TabIndex = 1;
            this.employeeNameMaterialLabel.Text = "employeeNameMaterialLabel";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(200, 88);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(99, 19);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "Ваша оценка";
            this.materialLabel1.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.16F);
            this.richTextBox1.Location = new System.Drawing.Point(27, 500);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(843, 50);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // commentsFlowLayoutPanel
            // 
            this.commentsFlowLayoutPanel.AutoScroll = true;
            this.commentsFlowLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.commentsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.commentsFlowLayoutPanel.Location = new System.Drawing.Point(30, 191);
            this.commentsFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.commentsFlowLayoutPanel.Name = "commentsFlowLayoutPanel";
            this.commentsFlowLayoutPanel.Size = new System.Drawing.Size(841, 296);
            this.commentsFlowLayoutPanel.TabIndex = 6;
            this.commentsFlowLayoutPanel.WrapContents = false;
            // 
            // goBackButton
            // 
            this.goBackButton.BackColor = System.Drawing.SystemColors.Control;
            this.goBackButton.BackgroundImage = global::RatingSystem.Properties.Resources.back;
            this.goBackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.goBackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goBackButton.FlatAppearance.BorderSize = 0;
            this.goBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBackButton.Location = new System.Drawing.Point(822, 44);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(49, 45);
            this.goBackButton.TabIndex = 7;
            this.goBackButton.UseVisualStyleBackColor = false;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // saveCommentButton
            // 
            this.saveCommentButton.BackColor = System.Drawing.SystemColors.Control;
            this.saveCommentButton.FlatAppearance.BorderSize = 0;
            this.saveCommentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveCommentButton.Image = ((System.Drawing.Image)(resources.GetObject("saveCommentButton.Image")));
            this.saveCommentButton.Location = new System.Drawing.Point(826, 556);
            this.saveCommentButton.Name = "saveCommentButton";
            this.saveCommentButton.Size = new System.Drawing.Size(40, 40);
            this.saveCommentButton.TabIndex = 5;
            this.saveCommentButton.UseVisualStyleBackColor = false;
            this.saveCommentButton.Click += new System.EventHandler(this.saveCommentButton_Click);
            // 
            // profileRoundedPictureBox
            // 
            this.profileRoundedPictureBox.CornerRadius = 0;
            this.profileRoundedPictureBox.Location = new System.Drawing.Point(27, 44);
            this.profileRoundedPictureBox.Name = "profileRoundedPictureBox";
            this.profileRoundedPictureBox.Size = new System.Drawing.Size(130, 130);
            this.profileRoundedPictureBox.TabIndex = 0;
            this.profileRoundedPictureBox.TabStop = false;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.commentsFlowLayoutPanel);
            this.Controls.Add(this.saveCommentButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.employeeNameMaterialLabel);
            this.Controls.Add(this.profileRoundedPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "EmployeeForm";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Text = "EmployeeForm";
            ((System.ComponentModel.ISupportInitialize)(this.profileRoundedPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedPictureBox profileRoundedPictureBox;
        private MaterialSkin.Controls.MaterialLabel employeeNameMaterialLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button saveCommentButton;
        private System.Windows.Forms.FlowLayoutPanel commentsFlowLayoutPanel;
        private System.Windows.Forms.Button goBackButton;
    }
}