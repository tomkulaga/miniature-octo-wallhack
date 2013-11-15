namespace PCB
{
    partial class DesignView
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
            this.renderControl = new SharpDX.Windows.RenderControl();
            this.SuspendLayout();
            // 
            // renderControl
            // 
            this.renderControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renderControl.Location = new System.Drawing.Point(113, 42);
            this.renderControl.Name = "renderControl";
            this.renderControl.Size = new System.Drawing.Size(475, 335);
            this.renderControl.TabIndex = 1;
            // 
            // DesignView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 460);
            this.Controls.Add(this.renderControl);
            this.Name = "DesignView";
            this.Text = "DesignView";
            this.ResumeLayout(false);

        }

        #endregion

        private SharpDX.Windows.RenderControl renderControl;
    }
}