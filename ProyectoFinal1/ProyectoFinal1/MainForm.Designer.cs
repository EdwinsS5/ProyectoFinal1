using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinal1
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtPrompt;
        private System.Windows.Forms.Button btnInvestigar;
        private System.Windows.Forms.RichTextBox txtResultado;
        private System.Windows.Forms.Button btnGenerar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            txtPrompt = new TextBox();
            btnInvestigar = new Button();
            txtResultado = new RichTextBox();
            btnGenerar = new Button();
            SuspendLayout();
            // 
            // txtPrompt
            // 
            txtPrompt.BorderStyle = BorderStyle.FixedSingle;
            txtPrompt.Font = new Font("Segoe UI", 12F);
            txtPrompt.ForeColor = Color.Gray;
            txtPrompt.Location = new Point(40, 32);
            txtPrompt.Name = "txtPrompt";
            txtPrompt.Size = new Size(600, 34);
            txtPrompt.TabIndex = 0;
            // 
            // btnInvestigar
            // 
            btnInvestigar.BackColor = Color.FromArgb(66, 133, 244);
            btnInvestigar.Cursor = Cursors.Hand;
            btnInvestigar.FlatAppearance.BorderSize = 0;
            btnInvestigar.FlatStyle = FlatStyle.Flat;
            btnInvestigar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnInvestigar.ForeColor = Color.White;
            btnInvestigar.Location = new Point(660, 28);
            btnInvestigar.Name = "btnInvestigar";
            btnInvestigar.Size = new Size(140, 44);
            btnInvestigar.TabIndex = 1;
            btnInvestigar.Text = "Investigar";
            btnInvestigar.UseVisualStyleBackColor = false;
            btnInvestigar.Click += btnInvestigar_Click;
            // 
            // txtResultado
            // 
            txtResultado.BackColor = Color.FromArgb(250, 250, 250);
            txtResultado.BorderStyle = BorderStyle.FixedSingle;
            txtResultado.Font = new Font("Segoe UI", 12F);
            txtResultado.Location = new Point(40, 90);
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(760, 320);
            txtResultado.TabIndex = 2;
            txtResultado.Text = "";
            // 
            // btnGenerar
            // 
            btnGenerar.BackColor = Color.FromArgb(41, 180, 84);
            btnGenerar.Cursor = Cursors.Hand;
            btnGenerar.Enabled = false;
            btnGenerar.FlatAppearance.BorderSize = 0;
            btnGenerar.FlatStyle = FlatStyle.Flat;
            btnGenerar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerar.ForeColor = Color.White;
            btnGenerar.Location = new Point(40, 430);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(760, 52);
            btnGenerar.TabIndex = 3;
            btnGenerar.Text = "Generar Documentos";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // MainForm
            // 
            BackColor = Color.FromArgb(245, 247, 250);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(840, 520);
            Controls.Add(btnGenerar);
            Controls.Add(txtResultado);
            Controls.Add(btnInvestigar);
            Controls.Add(txtPrompt);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Investigador Automático";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}