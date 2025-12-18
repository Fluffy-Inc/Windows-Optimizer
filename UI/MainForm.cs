using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsOptimizer.UI
{
    public class MainForm : Form
    {
        private Label lblTitle = null!;
        private Label lblSubtitle = null!;
        private GroupBox grpOptimizations = null!;
        private Label lblStatus = null!;

        private Button btnTemp = null!;
        private Button btnNetwork = null!;
        private Button btnRam = null!;
        private Button btnSfc = null!;
        private Button btnAbout = null!;
        private Button btnCredits = null!;
        private Button btnExit = null!;

        public MainForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            // ===== Janela =====
            Text = "Windows Optimizer";
            Size = new Size(560, 500);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // ===== Título =====
            lblTitle = new Label
            {
                Text = "Windows Optimizer",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            // ===== Subtítulo =====
            lblSubtitle = new Label
            {
                Text = "Ferramentas avançadas de otimização do Windows",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                ForeColor = Color.DimGray,
                Location = new Point(22, 60)
            };

            // ===== Grupo =====
            grpOptimizations = new GroupBox
            {
                Text = "Otimizações",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Size = new Size(500, 240),
                Location = new Point(20, 100)
            };

            btnTemp = CreateButton(
                "Limpar Arquivos Temporários",
                30,
                () => RunBat("Limpar Arquivos Temporários.bat")
            );

            btnNetwork = CreateButton(
                "Limpar Cache de Rede",
                75,
                () => RunBat("Limpar Cache de Rede.bat")
            );

            btnRam = CreateButton(
                "Limpar Memória RAM (avançado)",
                120,
                RunRamCleaner
            );

            btnSfc = CreateButton(
                "Verificar Arquivos Corrompidos",
                165,
                () => RunBat("Verificar Arquivos Corrompidos.bat")
            );

            grpOptimizations.Controls.AddRange(new Control[]
            {
                btnTemp, btnNetwork, btnRam, btnSfc
            });

            // ===== Botão Sobre =====
            btnAbout = new Button
            {
                Text = "Sobre",
                Size = new Size(90, 30),
                Location = new Point(20, 360)
            };
            btnAbout.Click += (_, _) =>
            {
                using var about = new AboutForm();
                about.ShowDialog(this);
            };

            // ===== Botão Créditos =====
            btnCredits = new Button
            {
                Text = "Créditos",
                Size = new Size(90, 30),
                Location = new Point(130, 360)
            };
            btnCredits.Click += (_, _) =>
            {
                MessageBox.Show(
                    "Windows Optimizer v1.0\n\n" +
                    "Desenvolvido por: Dieguinho Fox\n" +
                    "Empresa: Fluffy Inc\n" +
                    "GitHub/Website: [https://github.com/Fluffy-Inc/Windows-Optimizer]",
                    "Créditos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            };

            // ===== Botão Sair =====
            btnExit = new Button
            {
                Text = "Sair",
                Size = new Size(90, 30),
                Location = new Point(430, 400)
            };
            btnExit.Click += (_, _) => Close();

            // ===== Status =====
            lblStatus = new Label
            {
                Text = "Pronto",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                ForeColor = Color.Gray,
                Location = new Point(20, 405)
            };

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(grpOptimizations);
            Controls.Add(lblStatus);
            Controls.Add(btnAbout);
            Controls.Add(btnCredits);
            Controls.Add(btnExit);
        }

        private Button CreateButton(string text, int top, Action onClick)
        {
            var btn = new Button
            {
                Text = text,
                Size = new Size(460, 35),
                Location = new Point(20, top)
            };
            btn.Click += (_, _) => onClick();
            return btn;
        }

        private void RunRamCleaner()
        {
            var result = MessageBox.Show(
                "ATENÇÃO\n\n" +
                "A limpeza de memória RAM pode causar:\n" +
                "- Travamentos temporários\n" +
                "- Lentidão momentânea\n" +
                "- Fechamento de processos\n\n" +
                "Deseja continuar?",
                "Aviso do sistema",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
                RunBat("Limpar Memória Ram.bat");
            else
                lblStatus.Text = "Operação cancelada.";
        }

        private void RunBat(string batName)
        {
            string path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "bats",
                "Windows Optimizer",
                "Windows Optimizer",
                batName
            );

            if (!File.Exists(path))
            {
                MessageBox.Show(
                    "Arquivo .bat não encontrado:\n\n" + path,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                lblStatus.Text = "Erro ao localizar arquivo.";
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c \"\"{path}\"\"",
                    UseShellExecute = true,
                    Verb = "runas",
                    WorkingDirectory = Path.GetDirectoryName(path)
                });

                lblStatus.Text = $"Executando: {batName}";
            }
            catch
            {
                lblStatus.Text = "Execução cancelada ou falha ao abrir com admin.";
            }
        }
    }
}
