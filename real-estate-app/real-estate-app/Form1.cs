using real_estate_app.Models;
using System;
using System.Data;
using System.Windows.Forms;


namespace real_estate_app
{
    public partial class Form1 : Form
    {
        AppDbContext db = new();

        

        public Form1()
        {
            InitializeComponent();

            List<RealEstate> emlaklar = db.RealEstate.ToList();
            EmlaklariListele(emlaklar);


        }
        

       

        private void kayitOlButon_Click(object sender, EventArgs e)
        {
            string saticiIsim = SaticiIsim.Text;
            string saticiSoyisim= SaticiSoyisim.Text;
            string saticiTelNo = SaticiTelefon.Text;              
            if (saticiIsim != string.Empty && saticiIsim.All(char.IsLetter) && saticiSoyisim != string.Empty && saticiSoyisim.All(char.IsLetter) && saticiTelNo != string.Empty)
            {
                
                if (saticiTelNo.Length == 11&&saticiTelNo.All(char.IsDigit))
                {
                    bool saticiVarMi = db.Seller.Any();
                    int sonSaticiId = saticiVarMi ? db.Seller.Max(s => s.SellerId) : 0;
                    sonSaticiId++;
                    var satici = new Seller()
                    {
                        SellerId = sonSaticiId,
                        Name = saticiIsim,
                        Surname = saticiSoyisim,
                        Phone = saticiTelNo,

                    };
                    db.Seller.Add(satici);
                    db.SaveChanges();
                    MessageBox.Show("Hesap baþarýyla oluþturuldu.");
                }
                else
                {
                    MessageBox.Show("Telefon numaranýzý doðru formatta giriniz.");
                }

                
            }
            else
            {
                MessageBox.Show("Boþ alan býrakmayýnýz ayrýca girdiðiniz deðerlerin düzgün olduðundan emin olunuz.");
            }

           
            


        }


        private void SaticiPaneliButton_Click(object sender, EventArgs e)
        {
            
            KayitPanel.Visible = true;
            EmlakOlusturPanel.Visible = false;
            emlakListesiPanel.Visible = false;
        }

        private void EmlakKayitPaneliButon_Click(object sender, EventArgs e)

        {
            saticiListesiEmlakKayit.Items.Clear();
            foreach (Seller satici in db.Seller)
            {
                saticiListesiEmlakKayit.Items.Add(satici.Name);
            }
            EmlakOlusturPanel.Visible=true;
            KayitPanel.Visible = false;
            emlakListesiPanel.Visible = false;
            


        }
        private void emlakListesiPanelButon_Click(object sender, EventArgs e)
        {
            saticiFiltre.Items.Clear();
            foreach (Seller satici in db.Seller)
            {
                saticiFiltre.Items.Add($"{satici.Name} {satici.Surname}");
            }
            KayitPanel.Visible = false;
            EmlakOlusturPanel.Visible = false;
            emlakListesiPanel.Visible = true;
        }

        private void emlakKaydetButon_Click(object sender, EventArgs e)
        {
            if (adresGirisi.Text!=string.Empty&&fiyatGirisi.Text!= string.Empty&& fiyatGirisi.Text.All(char.IsDigit) && metrekareGirisi.Text!= string.Empty && metrekareGirisi.Text.All(char.IsDigit) && odaSayisiGirisi.Text!= string.Empty && odaSayisiGirisi.Text.All(char.IsDigit) && saticiListesiEmlakKayit !=null)
            {
                int saticiId = db.Seller.FirstOrDefault(s => s.Name == saticiListesiEmlakKayit.Text).SellerId;
                var emlak = new RealEstate
                {
                    Address = adresGirisi.Text,
                    City = sehirGirisi.Text,
                    District= ilceGirisi.Text,
                    RoomNumb = Convert.ToInt32(odaSayisiGirisi.Text),
                    Price = Convert.ToInt32(fiyatGirisi.Text),
                    SquareMeter = Convert.ToInt32(metrekareGirisi.Text),
                    SellerId = saticiId,
                };
                db.RealEstate.Add(emlak);
                db.SaveChanges();
                MessageBox.Show($"{adresGirisi.Text} adresli emlak baþarýyla oluþturuldu.");
                
            }
            else
            {
                MessageBox.Show("Lütfen boþ alan býrakmayýnýz ayrýca tüm kýsýmlarýn doðru formatta olduðundan emin olunuz.");
            }
        }

        private void filtreleButon_Click(object sender, EventArgs e)
        {
           
            List<RealEstate> filtrelenmisEmlakListesi= new List<RealEstate>();
            var emlakdb = db.RealEstate.ToList();
            bool metreKareVarMi, odaSayisiVarMi,fiyatVarMi,sehirVarMi,ilceVarMi,durumVarMi,saticiVarMi= false;
            metreKareVarMi = (metreKareFiltre.Text.ToString() != string.Empty);
            odaSayisiVarMi = (odaSayisiFiltre.Text.ToString() != string.Empty);
            fiyatVarMi = (fiyatFilteBaslangic.Text.ToString() != string.Empty && fiyatFiltreSon.Text.ToString() != string.Empty);
            saticiVarMi = (saticiFiltre.Text.ToString() != string.Empty);
            durumVarMi = (durumFiltre.Text.ToString() != string.Empty);
            sehirVarMi = (sehirFiltre.Text.ToString() != string.Empty);
            ilceVarMi = (ilceFiltre.Text.ToString() != string.Empty);
            // Yanlýþ formatta veri girildiðinde kontrol
            if (metreKareVarMi && !int.TryParse(metreKareFiltre.Text, out _))
            {
                MessageBox.Show("Lütfen metrekare deðeri için doðru formatta veri giriniz.");
                return;
            }

            if (fiyatVarMi && (!int.TryParse(fiyatFilteBaslangic.Text, out _) || !int.TryParse(fiyatFiltreSon.Text, out _)))
            {
                MessageBox.Show("Lütfen fiyat deðerleri için doðru formatta veri giriniz.");
                return;
            }

            if (odaSayisiVarMi && !int.TryParse(odaSayisiFiltre.Text, out _))
            {
                MessageBox.Show("Lütfen oda sayýsý için doðru formatta veri giriniz.");
                return;
            }
            if (sehirVarMi && int.TryParse(sehirFiltre.Text, out _))
            {
                MessageBox.Show("Lütfen þehir için doðru formatta veri giriniz.");
                return;
            }
            if (ilceVarMi && int.TryParse(ilceFiltre.Text, out _))
            {
                MessageBox.Show("Lütfen ilçe için doðru formatta veri giriniz.");
                return;
            }

            foreach (RealEstate emlak in emlakdb)
            {
                Seller satici = db.Seller.FirstOrDefault(s => s.SellerId == emlak.SellerId);
                string saticiIsim = $"{satici.Name} {satici.Surname}";
                string durum = (emlak.IsSaled) ? "Satýldý" : "Satýþta";
                if(metreKareVarMi&& emlak.SquareMeter > Convert.ToInt32(metreKareFiltre.Text)){
                        continue;
                }
                
                if (fiyatVarMi &&(emlak.Price > Convert.ToInt32(fiyatFiltreSon.Text) || emlak.Price < Convert.ToInt32(fiyatFilteBaslangic.Text)))
                {
                    continue;
                }
                
                if (odaSayisiVarMi && emlak.RoomNumb > Convert.ToInt32(odaSayisiFiltre.Text))
                {
                    continue;
                }
                if (saticiVarMi && saticiIsim != saticiFiltre.Text)
                {
                    continue;
                }
                if(durumVarMi&& durum != durumFiltre.Text)
                {
                    continue;
                }
                if (sehirVarMi && emlak.City != sehirFiltre.Text)
                {
                    continue;
                }
                if (ilceVarMi && emlak.District != ilceFiltre.Text)
                {
                    continue;
                }

                filtrelenmisEmlakListesi.Add(emlak);

            }
            
            


            if (filtrelenmisEmlakListesi!= null)
            {
                filtrelenmisEmlakListesiUi.Rows.Clear();
                filtrelenmisEmlakListesiUi.Columns.Clear();
                //Satýr ve sütunlarý temizledik



                EmlaklariListele(filtrelenmisEmlakListesi);




            }
            
           
            




        }
        public void EmlaklariListele(List<RealEstate> emlakListesi)
        {
            List<string> kolonIsimleriListe = new() { "Emlak ID","Adres", "Þehir", "Ýlçe", "Oda Sayisi", "Metrekare", "Fiyat", "Satýþ Durumu", "Satýcý","Ýlgili Nuamra"};
            foreach (string kolonIsmi in kolonIsimleriListe)
            {
                DataGridViewTextBoxColumn yeniKolon = new DataGridViewTextBoxColumn();
                yeniKolon.HeaderText = kolonIsmi;
                filtrelenmisEmlakListesiUi.Columns.Add(yeniKolon);
            }
            //Sütunlarý tek tek tanýmladýðýmýz deðerler ile doldurduk
            foreach (RealEstate emlak in emlakListesi)
            {
                string durum = emlak.IsSaled ? "Satýldý" : "Satýþta";
                Seller satici = db.Seller.FirstOrDefault(s => s.SellerId == emlak.SellerId);

                DataGridViewRow yeniSatir = new DataGridViewRow();
                // Emlak bilgilerini ilgili hücrelere yerleþtirdik
                yeniSatir.Cells.Add(new DataGridViewTextBoxCell { Value = emlak.RealEstateId });
                yeniSatir.Cells.Add(new DataGridViewTextBoxCell { Value = emlak.Address });
                yeniSatir.Cells.Add(new DataGridViewTextBoxCell { Value = emlak.City });
                yeniSatir.Cells.Add(new DataGridViewTextBoxCell { Value = emlak.District });
                yeniSatir.Cells.Add(new DataGridViewTextBoxCell { Value = emlak.RoomNumb });
                yeniSatir.Cells.Add(new DataGridViewTextBoxCell { Value = emlak.SquareMeter });
                yeniSatir.Cells.Add(new DataGridViewTextBoxCell { Value = emlak.Price });
                yeniSatir.Cells.Add(new DataGridViewTextBoxCell { Value = durum });
                yeniSatir.Cells.Add(new DataGridViewTextBoxCell { Value = $"{satici.Name} {satici.Surname}" });
                yeniSatir.Cells.Add(new DataGridViewTextBoxCell { Value = satici.Phone});
                filtrelenmisEmlakListesiUi.Rows.Add(yeniSatir);
                

            }
           
            
        }

        public void SayýMi(int degisken)
        {
            string degiskenString = degisken.ToString();
            bool sayiMi = int.TryParse(degiskenString, out _);
            if(!sayiMi)
            {
                MessageBox.Show("Lütfen sayý deðeri giriniz.");
            }
        }

        private void emlakGuncelle_Click(object sender, EventArgs e)
        {
            if (int.TryParse(emlakIdDegistirmelik.Text, out _))
            {
                bool durum = (degistirmelikDurumlar.Text == "Satýldý") ? true : false;
                RealEstate degistirilecekEmlak = db.RealEstate.FirstOrDefault(e => e.RealEstateId == int.Parse(emlakIdDegistirmelik.Text));
                if (degistirilecekEmlak != null)
                {
                    degistirilecekEmlak.IsSaled = durum;
                    db.SaveChanges();
                    MessageBox.Show($"({degistirilecekEmlak.Address}) adresli emlaðýn durumu ({degistirmelikDurumlar.Text}) olarak deðiþtirildi.");

                    filtrelenmisEmlakListesiUi.Rows.Clear();
                    filtrelenmisEmlakListesiUi.Columns.Clear();
                    EmlaklariListele(db.RealEstate.ToList());
                }
                else
                {
                    MessageBox.Show($"{emlakIdDegistirmelik.Text} sayýlý id ile ilgili bir emlak bulunmamaktadýr.");
                }
            }
            else
            {
                MessageBox.Show("ID alanýna doðru formatta giriþ yapýnýz.");
            }

        }

        private void emlakSilButon_Click(object sender, EventArgs e)
        {
            if(int.TryParse(emlakIdDegistirmelik.Text, out _))
            {
                RealEstate silinecekEmlak = db.RealEstate.FirstOrDefault(e => e.RealEstateId == int.Parse(emlakIdDegistirmelik.Text));
                if (silinecekEmlak != null)
                {
                    db.RealEstate.Remove(silinecekEmlak);
                    db.SaveChanges();
                    MessageBox.Show($"({silinecekEmlak.Address}) adresli emlak silindi.");

                    filtrelenmisEmlakListesiUi.Rows.Clear();
                    filtrelenmisEmlakListesiUi.Columns.Clear();
                    EmlaklariListele(db.RealEstate.ToList());
                }
                else
                {
                    MessageBox.Show($"{emlakIdDegistirmelik.Text} sayýlý id ile ilgili bir emlak bulunmamaktadýr.");
                }
            }
            else
            {
                MessageBox.Show("ID alanýna doðru formatta giriþ yapýnýz.");
            }
            
            
        }
    }
}