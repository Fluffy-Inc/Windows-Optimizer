using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsOptimizer.UI
{
    public class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            Text = "Sobre";
            Size = new Size(420, 260);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            var lblTitle = new Label
            {
                Text = "Windows Optimizer",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            var lblVersion = new Label
            {
                Text = "Versão: 1.0.0",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(22, 60)
            };

            var lblDesc = new Label
            {
                Text =
                    "Ferramenta de otimização e manutenção\n" +
                    "do sistema Windows.\n\n" +
                    "Este aplicativo executa scripts administrativos\n" +
                    "para limpeza e verificação do sistema.",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(22, 85)
            };

            var lblAuthor = new Label
            {
                Text = "Desenvolvido por: Fluffy Inc",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                AutoSize = true,
                ForeColor = Color.DimGray,
                Location = new Point(22, 170)
            };

            var btnClose = new Button
            {
                Text = "Fechar",
                Size = new Size(90, 30),
                Location = new Point(290, 180)
            };

            btnClose.Click += (_, _) => Close();

            Controls.Add(lblTitle);
            Controls.Add(lblVersion);
            Controls.Add(lblDesc);
            Controls.Add(lblAuthor);
            Controls.Add(btnClose);
        }
    }
}
