using Savas.Library.Concrete;
using Savas.Library.Enum;
using System;
using System.Windows.Forms;

namespace Savas.Desktop
{
    public partial class AnaForm : Form
    {
        private readonly Oyun _oyun;

        public AnaForm()
        {
            InitializeComponent();
            _oyun = new Oyun(ucaksavarPanel, savasAlaniPanel);
            _oyun.GecenSureDegisti += Oyun_GecenSureDegisti;
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    _oyun.Baslat();
                    break;
                case Keys.Right:
                    _oyun.UcaksavariHareketEttir(Yon.Saga);
                    break;
                case Keys.Left:
                    _oyun.UcaksavariHareketEttir(Yon.Sola);
                    break;
                case Keys.Space:
                    _oyun.AtesEt();
                    break;
            }
        }

        private void Oyun_GecenSureDegisti(object sender, EventArgs e)
        {
            if (sureLabel.InvokeRequired)
            {
                sureLabel.Invoke(new Action(() => sureLabel.Text = _oyun.GecenSure.ToString()));
            }
            else
            {
                sureLabel.Text = _oyun.GecenSure.ToString();
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {

        }
    }
}