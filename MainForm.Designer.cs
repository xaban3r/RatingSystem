namespace RatingSystem
{
    partial class MainForm
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
            this.topFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.allFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.nameMaterialLabel = new MaterialSkin.Controls.MaterialLabel();
            this.roundedPictureBox1 = new RatingSystem.RoundedPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // topFlowLayoutPanel
            // 
            this.topFlowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.topFlowLayoutPanel.Location = new System.Drawing.Point(25, 219);
            this.topFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topFlowLayoutPanel.Name = "topFlowLayoutPanel";
            this.topFlowLayoutPanel.Size = new System.Drawing.Size(318, 270);
            this.topFlowLayoutPanel.TabIndex = 7;
            // 
            // allFlowLayoutPanel
            // 
            this.allFlowLayoutPanel.AutoScroll = true;
            this.allFlowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.allFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.allFlowLayoutPanel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.allFlowLayoutPanel.Location = new System.Drawing.Point(537, 152);
            this.allFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.allFlowLayoutPanel.Name = "allFlowLayoutPanel";
            this.allFlowLayoutPanel.Size = new System.Drawing.Size(324, 337);
            this.allFlowLayoutPanel.TabIndex = 8;
            this.allFlowLayoutPanel.WrapContents = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.materialLabel1.Location = new System.Drawing.Point(34, 178);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(125, 19);
            this.materialLabel1.TabIndex = 9;
            this.materialLabel1.Text = "Высший рейтинг";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(555, 115);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(27, 19);
            this.materialLabel2.TabIndex = 10;
            this.materialLabel2.Text = "Все";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(117, 54);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(149, 19);
            this.materialLabel3.TabIndex = 12;
            this.materialLabel3.Text = "Добро пожаловать!";
            // 
            // nameMaterialLabel
            // 
            this.nameMaterialLabel.AutoSize = true;
            this.nameMaterialLabel.Depth = 0;
            this.nameMaterialLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.nameMaterialLabel.Location = new System.Drawing.Point(117, 88);
            this.nameMaterialLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.nameMaterialLabel.Name = "nameMaterialLabel";
            this.nameMaterialLabel.Size = new System.Drawing.Size(138, 19);
            this.nameMaterialLabel.TabIndex = 13;
            this.nameMaterialLabel.Text = "nameMaterialLabel";
            // 
            // roundedPictureBox1
            // 
            this.roundedPictureBox1.CornerRadius = 0;
            this.roundedPictureBox1.Location = new System.Drawing.Point(15, 54);
            this.roundedPictureBox1.Name = "roundedPictureBox1";
            this.roundedPictureBox1.Size = new System.Drawing.Size(80, 80);
            this.roundedPictureBox1.TabIndex = 11;
            this.roundedPictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.nameMaterialLabel);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.roundedPictureBox1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.allFlowLayoutPanel);
            this.Controls.Add(this.topFlowLayoutPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel allFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel topFlowLayoutPanel;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private RoundedPictureBox roundedPictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel nameMaterialLabel;
    }
}