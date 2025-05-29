using Savas.Library.Enum;
using Savas.Library.Interface;
using System;
using System.Windows.Forms; // Panel ve Timer için
using System.Drawing; // Image için
using Timer = System.Windows.Forms.Timer; // Ambiguity'yi kaldırmak için

namespace Savas.Library.Concrete
{
    public class Oyun : IOyun
    {
        #region Alanlar

        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private TimeSpan _gecenSure;
        private readonly Panel _ucaksavarPanel;

        #endregion

        #region Olaylar

        public event EventHandler GecenSureDegisti;

        #endregion

        #region Özellikler

        public bool DevamEdiyorMu { get; private set; }

        public TimeSpan GecenSure
        {
            get => _gecenSure;
            private set
            {
                _gecenSure = value;
                GecenSureDegisti?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Metotlar

        public Oyun(Panel ucaksavarPanel)
        {
            _ucaksavarPanel = ucaksavarPanel;
            _gecenSureTimer.Tick += GecenSureTimer_Tick;
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }

        public void Baslat()
        {
            if (DevamEdiyorMu) return;

            DevamEdiyorMu = true;
            _gecenSureTimer.Start();
            UcaksavarOlustur();
        }

        private void UcaksavarOlustur()
        {
            try
            {
                var ucaksavar = new Ucaksavar(_ucaksavarPanel.Width)
                {
                    Image = Image.FromFile(@"C:\Users\ESMANUR\Desktop\SavasOyunu\Gorseller\Ucaksavar.png")
                };

                _ucaksavarPanel.Controls.Add(ucaksavar);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Görsel yüklenemedi: {ex.Message}");
            }
        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            _gecenSureTimer.Stop();
        }

        public void AtesEt()
        {
            throw new NotImplementedException();
        }

        public void UcaksavariHareketEttir(Yon yon)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}