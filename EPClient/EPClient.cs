﻿using OpenProtocolInterpreter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EPClient
{
    public partial class EPClient : Form
    {
        Regex validipregex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");

        public EPClient()
        {
            InitializeComponent();
        }

        private BindingList<Gun> BGuns;
        private BindingList<Action> BActions;

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadConfig();
            InitUI();
            string left;
            //var mid2 = MidInterpreter.Parse("00570002            010001020103Airbag1234567890123456789", out left);
            //var m0001 = new Mid0001().Pack();
            //var m0003 = new Mid0003().Pack();
            //var mid4 = MidInterpreter.Parse("00260004            001802", out left);
            //var mid5 = MidInterpreter.Parse("00240005            0018", out left);
            //var m9999 = new Mid9999().Pack();
            //var mid9999 = MidInterpreter.Parse("00209999001         ", out left);
            //var m0060 = new Mid0060().Pack();
            //var mid61 = MidInterpreter.Parse("023100610010        010001020103airbag7                 z04KPOL3456JKLO897         Z050006003070000080000090100111120008401300140014001200150007391600000170999918000001900000202001-06-02:09:54:09212001-05-29:12:34:33221233456750000", out left);
            //var m62 = new Mid0062().Pack();
            //var m63 = new Mid0063().Pack();
            //var mid11 = MidInterpreter.Parse("00290011            002001002", out left);
            //var m12 = new Mid0012() { PsetID = "002" }.Pack();
            //var mid0013 = MidInterpreter.Parse("01040013            0100102Airbag1                 z0310403050012000600150007001400080036009007201000480",out left);
            var m18 = new Mid0018() { PsetID = "002" }.Pack();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        private void SaveConfig()
        {
            List<Gun> okGuns = BGuns.Where(g => !string.IsNullOrWhiteSpace(g.ID) &&
                                                                 !string.IsNullOrWhiteSpace(g.Code) &&
                                                                 !string.IsNullOrWhiteSpace(g.IP) &&
                                                                 validipregex.IsMatch(g.IP) &&
                                                                 g.Port > 0
                                                                 ).ToList();
            List<Action> okActions = BActions.Where(a => !string.IsNullOrWhiteSpace(a.ID) &&
                                                                !string.IsNullOrWhiteSpace(a.Name) &&
                                                                !string.IsNullOrWhiteSpace(a.GunID) &&
                                                                a.Pset > 0
                                                                 )
                                             .Where(a => okGuns.Select(g => g.ID).Contains(a.GunID)).ToList();
            var encoding = Encoding.UTF8;
            using (var fileStream = new FileStream("Guns.xml", FileMode.Create))
            {
                using (System.IO.StreamWriter streamWriter = new StreamWriter(fileStream, encoding))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Gun>));
                    xmlSerializer.Serialize(streamWriter, okGuns);
                }
            }
            using (var fileStream = new FileStream("Actions.xml", FileMode.Create))
            {
                using (System.IO.StreamWriter streamWriter = new StreamWriter(fileStream, encoding))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Action>));
                    xmlSerializer.Serialize(streamWriter, okActions);
                }
            }
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        private void ReadConfig()
        {
            var encoding = Encoding.UTF8;
            if (File.Exists("Guns.xml"))
            {
                using (var fileStream = new FileStream("Guns.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (System.IO.StreamReader streamReader = new StreamReader(fileStream, encoding))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Gun>));
                        List<Gun> guns = xmlSerializer.Deserialize(streamReader) as List<Gun>;
                        BGuns = new BindingList<Gun>(guns);
                    }
                }
            }
            else
            {
                BGuns = new BindingList<Gun>();
            }
            if (File.Exists("Actions.xml"))
            {
                using (var fileStream = new FileStream("Actions.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (System.IO.StreamReader streamReader = new StreamReader(fileStream, encoding))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Action>));
                        List<Action> actions = xmlSerializer.Deserialize(streamReader) as List<Action>;
                        List<Action> okActions = actions.Where(a => BGuns.Select(g => g.ID).Contains(a.GunID)).ToList();
                        BActions = new BindingList<Action>(okActions);
                    }
                }
            }
            else
            {
                BActions = new BindingList<Action>();
            }
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void InitUI()
        {
            dGVGuns.DataSource = BGuns;
            dGVActions.DataSource = BActions;

            DataGridViewComboBoxColumn gunColum = dGVActions.Columns["ActionGun"] as DataGridViewComboBoxColumn;
            gunColum.DataSource = BGuns;
            gunColum.DisplayMember = "Code";
            gunColum.ValueMember = "ID";
        }

        /// <summary>
        /// 验证用户的输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (dGVGuns == sender)
                {
                    dGVGuns.Rows[e.RowIndex].ErrorText = "";
                    if (dGVGuns.Columns[e.ColumnIndex].Name == "GunPort")
                    {
                        dGVGuns.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                        Int32 newInteger = 0;
                        if (!int.TryParse(e.FormattedValue.ToString(), out newInteger))
                        {
                            e.Cancel = true;
                            dGVGuns.CancelEdit();
                            //dGVGuns.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "端口只能输入数字";
                            //MessageBox.Show("端口只能输入数字");
                        }
                        else if (newInteger <= 0)
                        {
                            dGVGuns.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "端口只能是大于0数字";
                        }
                    }
                    if (dGVGuns.Columns[e.ColumnIndex].Name == "GunIp")
                    {
                        dGVGuns.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                        if (!validipregex.IsMatch(e.FormattedValue.ToString()))
                        {
                            //e.Cancel = true;
                            dGVGuns.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "ip格式不对";
                            //MessageBox.Show("ip格式不对");
                        }
                    }
                    if (dGVGuns.Columns[e.ColumnIndex].Name == "GunCode")
                    {
                        dGVGuns.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
                        {
                            //e.Cancel = true;
                            dGVGuns.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "编号不能为空";
                            //MessageBox.Show("编号不能为空");
                        }
                    }
                }
                if (dGVActions == sender)
                {
                    dGVActions.Rows[e.RowIndex].ErrorText = "";
                    if (dGVActions.Columns[e.ColumnIndex].Name == "ActionBatchCount")
                    {
                        dGVActions.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                        Int32 newInteger = 0;
                        if (!int.TryParse(e.FormattedValue.ToString(), out newInteger))
                        {
                            e.Cancel = true;
                            dGVActions.CancelEdit();
                            //dGVActions.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "需求个数只能是大于0数字";
                            //MessageBox.Show("需求个数只能是数字");
                        }
                        else if (newInteger<=0)
                        {
                            dGVActions.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "需求个数只能是大于0数字";
                        }
                    }
                    if (dGVActions.Columns[e.ColumnIndex].Name == "ActionName")
                    {
                        dGVActions.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
                        {
                            //e.Cancel = true;
                            dGVActions.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "名称不能为空";
                            //MessageBox.Show("各称不能为空");
                        }
                    }
                    if (dGVActions.Columns[e.ColumnIndex].Name == "ActionGun")
                    {
                        dGVActions.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
                        {
                            //e.Cancel = true;
                            dGVActions.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "拧紧枪不能为空";
                            //MessageBox.Show("拧紧枪不能为空");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 删除枪时判断这把枪是否关联了工序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dGVGuns_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Gun gun = e.Row.DataBoundItem as Gun;
            List<Action> actionUseGun = BActions.Where(a => a.GunID == gun.ID).ToList();
            if (actionUseGun.Any())
            {
                string actionNames = string.Join("、",actionUseGun.Select(a => a.Name).ToList());
                DialogResult rsl = MessageBox.Show("你要删除的这把枪（" + gun.Code + "）已经被工序（" + actionNames+ "）使用。\n\t点“是”则连工序一起删除\n\t点“否”则取消删除操作", "你要删除的这把枪已绑定到工序上了", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rsl == DialogResult.Yes)
                {
                    foreach (var action in actionUseGun)
                    {
                        BActions.Remove(action);
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}