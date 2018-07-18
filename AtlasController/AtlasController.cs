using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AtlasController
{
    public partial class AtlasController : Form
    {
        List<Pset> psets;

        public AtlasController()
        {
            InitializeComponent();
        }

        private void btnAddPset_Click(object sender, EventArgs e)
        {
            Pset pset = new Pset();
            pset.PsetID = psets.Count() + 1;
            pset.PsetName = "Pset" + pset.PsetID;
            psets.Add(pset);
            AddTabPageByPset(pset);
            tabControl1.SelectedIndex = psets.Count - 1;
        }

        private void AtlasController_Load(object sender, EventArgs e)
        {
            ReadConfig();
            InitUI();
        }

        private void ReadConfig()
        {
            var encoding = Encoding.UTF8;
            if (File.Exists("Psets.xml"))
            {
                using (var fileStream = new FileStream("Psets.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (System.IO.StreamReader streamReader = new StreamReader(fileStream, encoding))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pset>));
                        psets = xmlSerializer.Deserialize(streamReader) as List<Pset>;
                    }
                }
            }
            else
            {
                psets = new List<Pset>();
            }
        }

        private void InitUI()
        {
            psets.ForEach(p=>AddTabPageByPset(p));
        }

        private void AddTabPageByPset(Pset pset)
        {
            TabPage tp = new TabPage(pset.PsetName);
            tabControl1.TabPages.Add(tp);

            int x = 10, y = 10, i=0;
            foreach (var property in pset.GetType().GetProperties())
            {
                Label lbText = new Label();
                lbText.Location = new Point(x, y+(i/2)*40);
                lbText.Size = new Size(120, 30);
                lbText.Text = property.Name;
                lbText.TextAlign = ContentAlignment.TopRight;
                tp.Controls.Add(lbText);

                TextBox tbValue = new TextBox();
                tbValue.Location = new Point(x+130, y+(i/2)*40);
                tbValue.Size = new Size(100, 30);
                tbValue.Tag = property.Name;
                tbValue.Text = (property.GetValue(pset, null) == null ? "" : property.GetValue(pset, null)).ToString();
                tbValue.ReadOnly = i == 0 || i == 1;
                tbValue.LostFocus += TbValue_LostFocus;
                tp.Controls.Add(tbValue);

                if (i%2==0)
                {
                    x += 230 + 10 ;
                }
                else
                {
                    x = 10;
                }

                i++;
            }
            Button tightOk = new Button();
            tightOk.Text = "拧个OK的";
            tightOk.Location = new Point(10, y + (i/2)*40 + 30);
            tightOk.Size = new Size(80, 30);
            tightOk.Click += TightOk_Click;
            tp.Controls.Add(tightOk);

            Button tightNOk = new Button();
            tightNOk.Text = "拧个NOK的";
            tightNOk.Location = new Point(100, y + (i / 2) * 40 + 30);
            tightNOk.Size = new Size(80, 30);
            tightNOk.Click += TightNOk_Click;
            tp.Controls.Add(tightNOk);
        }

        private void TightNOk_Click(object sender, EventArgs e)
        {
            Pset pset = psets[tabControl1.SelectedIndex];
        }

        private void TightOk_Click(object sender, EventArgs e)
        {
            Pset pset = psets[tabControl1.SelectedIndex];
        }

        private void TbValue_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            string property = tb.Tag as string;
            string value = tb.Text;
            Pset pset = psets[tabControl1.SelectedIndex];
            try
            {
                object v = Convert.ChangeType(value, pset.GetType().GetProperty(property).PropertyType);
                pset.GetType().GetProperty(property).SetValue(pset, v, null);
            }
            catch { }
            tb.Text = pset.GetType().GetProperty(property).GetValue(pset).ToString();
        }

        private void btnDeletePset_Click(object sender, EventArgs e)
        {
            psets.RemoveAt(psets.Count-1);
            tabControl1.TabPages.RemoveAt(tabControl1.TabPages.Count-1);
        }

        private void AtlasController_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        private void SaveConfig()
        {
            var encoding = Encoding.UTF8;
            using (var fileStream = new FileStream("Psets.xml", FileMode.Create))
            {
                using (System.IO.StreamWriter streamWriter = new StreamWriter(fileStream, encoding))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pset>));
                    xmlSerializer.Serialize(streamWriter, psets);
                }
            }
        }
    }
}
