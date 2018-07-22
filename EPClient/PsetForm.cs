using OpenProtocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPClient
{
    public partial class PsetForm : Form
    {
        private SocketConnect connect;
        public PsetForm(SocketConnect connect)
        {
            this.connect = connect;
            InitializeComponent();
        }

        private void PsetForm_Load(object sender, EventArgs e)
        {
            if (this.connect!=null)
            {
                connect.RequestPsetIds(mid=> {
                    this.Invoke(new System.Action(()=> {
                        var mid0011 = (mid as Mid0011);
                        foreach (var item in mid0011.Psets)
                        {
                            TabPage tp = new TabPage();
                            tp.Text = item;
                            this.tabControl1.TabPages.Add(tp);
                        }
                        getPsetData(this.tabControl1.TabPages[0]);
                    }));
                });
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPsetData((sender as TabControl).SelectedTab);
        }

        private void getPsetData(TabPage tp)
        {
            if (tp.Controls.Count==0)
            {
                if (this.connect != null)
                {
                    this.connect.RequestPsetData(tp.Text, mid => {
                        var mid0013 = mid as Mid0013;
                        TextBox tb = new TextBox();
                        tb.Text = mid0013.ToString();
                        tb.Multiline = true;
                        tb.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                        tb.Dock = DockStyle.Fill;
                        tb.ReadOnly = true;

                        Button btn = new Button();
                        btn.Dock = DockStyle.Bottom;
                        btn.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                        btn.Text = "选这个档位";
                        btn.Tag = tp.Text;
                        btn.AutoSize = true;
                        btn.Click += Btn_Click;

                        this.Invoke(new System.Action(() => {
                            tp.Controls.Add(btn);
                            tp.Controls.Add(tb);
                        }));
                    }, mid => {
                        var mid0004 = mid as Mid0004;
                        TextBox tb = new TextBox();
                        tb.Text = mid0004.ToString();
                        tb.Multiline = true;
                        tb.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                        tb.Dock = DockStyle.Fill;
                        this.Invoke(new System.Action(() => {
                            tp.Controls.Add(tb);
                        }));
                    });
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var psetid = btn.Tag as string;
            connect.SelectPset(psetid, () =>
            {
                MessageBox.Show("更改成功！");
            }, mid =>
            {
                MessageBox.Show("更改失败！" + mid);
            });
        }
    }
}
