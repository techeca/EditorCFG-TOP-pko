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

namespace EditorCFG
{
    public partial class frmCFGEditor : Form
    {
        List<string> lstPalabProh = new List<string>();
        public frmCFGEditor()
        {
            InitializeComponent();
        }

        private void frmCFGEditor_Load(object sender, EventArgs e)
        {
            txtAccountPort.Text = "1978";
            txtGateServerPort.Text = "1973";
            txtGroupServerPort.Text = "1975";
            txtGameServerPort.Text = "1971";

            txtAccountServerName.Text = "AccountServer";
            txtGameDBName.Text = "GameDB";

            lstPalabProh.Add("[net]");
            lstPalabProh.Add("[db]");
            lstPalabProh.Add("[bill]");
            lstPalabProh.Add("[tom]");
            lstPalabProh.Add("[gs]");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(checkEmptyFields())
            {
                confAccountServer();
                confGateServer();
                confGroupServer();
                confGameServer();
                //MessageBox.Show("Done");
            }
        }

        public void confAccountServer()
        {
            string text = File.ReadAllText("AccountServer.cfg");
            File.WriteAllText("AccountServer.cfg", text);
            text = text.Replace("[ACCOUNTSERVERIP]", txtAccountServerIP.Text);
            File.WriteAllText("AccountServer.cfg", text);
            text = text.Replace("[PORTACCOUNTSERVER]", txtAccountPort.Text);
            File.WriteAllText("AccountServer.cfg", text);
        }

        public void confGateServer()
        {
            string text = File.ReadAllText("GateServer.cfg");
            File.WriteAllText("GateServer.cfg", text);
            text = text.Replace("[IPGROUPSERVER]", txtGroupServerIP.Text);
            File.WriteAllText("GateServer.cfg", text);
            text = text.Replace("[PORTGROUPSERVER]", txtGroupServerPort.Text);
            File.WriteAllText("GateServer.cfg", text);
            text = text.Replace("[IPGATESERVER]", txtGateServerIP.Text);
            File.WriteAllText("GateServer.cfg", text);
            text = text.Replace("[PORTGATESERVER]", txtGateServerPort.Text);
            File.WriteAllText("GateServer.cfg", text);
            text = text.Replace("[IPGAMESERVER]", txtGameServerIP.Text);
            File.WriteAllText("GateServer.cfg", text);
            text = text.Replace("[PORTGAMESERVER]", txtGameServerPort.Text);
            File.WriteAllText("GateServer.cfg", text);

        }

        public void confGroupServer()
        {
            string text = File.ReadAllText("GroupServer.cfg");
            File.WriteAllText("GroupServer.cfg", text);
            text = text.Replace("[IPGROUPSERVER]", txtGroupServerIP.Text);
            File.WriteAllText("GroupServer.cfg", text);
            text = text.Replace("[PORTGROUPSERVER]", txtGroupServerPort.Text);
            File.WriteAllText("GroupServer.cfg", text);
            text = text.Replace("[IPACCOUNTSERVER]", txtAccountServerIP.Text);
            File.WriteAllText("GroupServer.cfg", text);
            text = text.Replace("[PORTACCOUNTSERVER]", txtAccountPort.Text);
            File.WriteAllText("GroupServer.cfg", text);

            
        }

        public void confGameServer()
        {
            string text = File.ReadAllText("GameServer.cfg");
            text = text.Replace("[IPGAMESERVER]", txtGameServerIP.Text);
            File.WriteAllText("GameServer.cfg", text);
            text = text.Replace("[PORTGAMESERVER]", txtGameServerPort.Text);
            File.WriteAllText("GameServer.cfg", text);
        }

        public bool checkEmptyFields()
        {
            string accSvrIp = txtAccountServerIP.Text;
            string accSvrPort = txtAccountPort.Text;
            string gateSvrIP = txtGameServerIP.Text;
            string gateSvrPort = txtGateServerPort.Text;
            string groupSvrIP = txtGroupServerIP.Text;
            string groupSvrPort = txtGroupServerPort.Text;
            

            if(!string.IsNullOrEmpty(accSvrIp) && (!string.IsNullOrEmpty(accSvrPort)) && (!string.IsNullOrEmpty(gateSvrIP)) && (!string.IsNullOrEmpty(gateSvrPort)) &&
              (!string.IsNullOrEmpty(groupSvrIP)) && (!string.IsNullOrEmpty(groupSvrPort)))
            {
                return true;
            }
            tssInfo.Text = "Empty fields";
            //MessageBox.Show("Empty fields");
            return false;
        }

        public bool checkEmptyFieldsDB()
        {
            string dbInstance = txtDBServerGDB.Text;
            string dbAccountServer = txtAccountServerName.Text;
            string dbGameDB = txtGameDBName.Text;
            string dbUserAS = txtUserDBAS.Text;
            string dbPassAS = txtPassDbAS.Text;
            string dbUserGDB = txtUserDBGDB.Text;
            string dbPassGDB = txtPassDBGDB.Text;
            TextBox txtSrch = new TextBox();

            

            if((!string.IsNullOrEmpty(dbGameDB)) && (!string.IsNullOrEmpty(dbInstance)) && (!string.IsNullOrEmpty(dbUserAS)) && (!string.IsNullOrEmpty(dbPassAS)) &&
              (!string.IsNullOrEmpty(dbAccountServer)) && (!string.IsNullOrEmpty(dbUserGDB)) && (!string.IsNullOrEmpty(dbPassGDB)))
            {
                return true;
            }
            tssInfo.Text = "Empty fields";
            return false;
        }

        private void btnAgregarMapa_Click(object sender, EventArgs e)
        {
            if (lstBMapas.Items.Contains(txtMapName.Text))
            {
                tssInfo.Text = "MAP ALREADY EXIST";
            }
            else
            {
                lstBMapas.Items.Add(txtMapName.Text);
            }
        }

        private void btnQuitarMapa_Click(object sender, EventArgs e)
        {
            lstBMapas.Items.RemoveAt(lstBMapas.SelectedIndex);
        }

        private void chBoxUserDb_CheckedChanged(object sender, EventArgs e)
        {
            if(chBoxUserDb.Checked)
            {
                txtUserDBGDB.Enabled = false;
                txtUserDBGDB.Text = txtUserDBAS.Text;
            }
            else
            {
                txtUserDBGDB.Enabled = true;
                txtUserDBGDB.Text = "";
            }

        }

        private void txtUserDBAS_TextChanged(object sender, EventArgs e)
        {
            if(chBoxUserDb.Checked)
            {
                txtUserDBGDB.Text = txtUserDBAS.Text;
            }

            if (palabrasProhibidas(txtUserDBAS.Text))
            {
                tssInfo.Text = "You can`t use that word: "+txtUserDBAS.Text;
                txtUserDBAS.Text = "";
            }

        }

        private void chBoxPassDb_CheckedChanged(object sender, EventArgs e)
        {
            if(chBoxPassDb.Checked)
            {
                txtPassDBGDB.Enabled = false;
                txtPassDBGDB.Text = txtPassDbAS.Text;
            }
            else
            {
                txtPassDBGDB.Enabled = true;
                txtPassDBGDB.Text = "";
            }
        }

        private void txtPassDbAS_TextChanged(object sender, EventArgs e)
        {
            if(chBoxPassDb.Checked)
            {
                txtPassDBGDB.Text = txtPassDbAS.Text;
            }

            if (palabrasProhibidas(txtPassDbAS.Text))
            {
                tssInfo.Text = "You can`t use that word: "+txtPassDbAS.Text;
                txtPassDbAS.Text = "";
            }
        }

        private void chBoxInstance_CheckedChanged(object sender, EventArgs e)
        {
            if(chBoxInstance.Checked)
            {
                txtDBServerGDB.Enabled = false;
                txtDBServerGDB.Text = txtDBServerAS.Text;
            }
            else
            {
                txtDBServerGDB.Enabled = true;
                txtDBServerGDB.Text = "";
            }
        }

        private void txtDBServerAS_TextChanged(object sender, EventArgs e)
        {
            if (chBoxInstance.Checked)
            {
                txtDBServerGDB.Text = txtDBServerAS.Text;
            }
            if (palabrasProhibidas(txtDBServerAS.Text))
            {
                tssInfo.Text = "You can`t use that word: " + txtDBServerAS.Text;
                txtDBServerAS.Text = "";
            }
        }

        private void txtAccountServerName_TextChanged(object sender, EventArgs e)
        {
            if (palabrasProhibidas(txtAccountServerName.Text))
            {
                tssInfo.Text = "You can`t use that word: "+txtAccountServerName.Text;
                txtAccountServerName.Text = "";
            }
        }

        public void confAccountServerDB()
        {
            string text = File.ReadAllText("AccountServer.cfg");
            text = text.Replace("[NAMEDBACCOUNTSERVER]", txtAccountServerName.Text);
            File.WriteAllText("AccountServer.cfg", text);
            text = text.Replace("[DBSERVER]", txtDBServerGDB.Text);    //intance
            File.WriteAllText("AccountServer.cfg", text);
            text = text.Replace("[USERDB]", txtUserDBAS.Text);
            File.WriteAllText("AccountServer.cfg", text);
            text = text.Replace("[PASSWORDDB]", txtPassDbAS.Text);
            File.WriteAllText("AccountServer.cfg", text);
        }

        public void confGameDBDB()
        {
            string text = File.ReadAllText("GroupServer.cfg");
            text = text.Replace("[DBSERVER]", txtDBServerGDB.Text);
            File.WriteAllText("GroupServer.cfg", text);
            text = text.Replace("[NAMEGAMEDB]", txtGameDBName.Text);
            File.WriteAllText("GroupServer.cfg", text);
            text = text.Replace("[USERDB]", txtUserDBGDB.Text);
            File.WriteAllText("GroupServer.cfg", text);
            text = text.Replace("[PASSWORDDB]", txtPassDBGDB.Text);
            File.WriteAllText("GroupServer.cfg", text);

            string text2 = File.ReadAllText("GameServer.cfg");
            text2 = text2.Replace("[DBSERVER]", txtDBServerGDB.Text);
            File.WriteAllText("GameServer.cfg", text2);
            text2 = text2.Replace("[USERDB]", txtUserDBGDB.Text);
            File.WriteAllText("GameServer.cfg", text2);
            text2 = text2.Replace("[PASSWORDDB]", txtPassDBGDB.Text);
            File.WriteAllText("GameServer.cfg", text2);
        }

        private void btnGuardarDB_Click(object sender, EventArgs e)
        {
            if (checkEmptyFieldsDB())
            {
                confAccountServerDB();
                confGameDBDB();
            }
        }

        public bool palabrasProhibidas(string palabraCompar)
        {
            if(lstPalabProh.Contains(palabraCompar))
            {
                return true;
            }
            return false;
        }

        private void txtGameDBName_TextChanged(object sender, EventArgs e)
        {
            if (palabrasProhibidas(txtGameDBName.Text))
            {
                tssInfo.Text = "You can`t use that word: " + txtGameDBName.Text;
                txtGameDBName.Text = "";
            }
        }

        private void txtUserDBGDB_TextChanged(object sender, EventArgs e)
        {
            if (palabrasProhibidas(txtUserDBGDB.Text))
            {
                tssInfo.Text = "You can`t use that word: " + txtUserDBGDB.Text;
                txtUserDBGDB.Text = "";
            }
        }

        private void txtPassDBGDB_TextChanged(object sender, EventArgs e)
        {
            if (palabrasProhibidas(txtPassDBGDB.Text))
            {
                tssInfo.Text = "You can`t use that word: " + txtPassDBGDB.Text;
                txtPassDBGDB.Text = "";
            }
        }

        private void txtDBServerGDB_TextChanged(object sender, EventArgs e)
        {
            if (palabrasProhibidas(txtDBServerGDB.Text))
            {
                tssInfo.Text = "You can`t use that word: " + txtDBServerGDB.Text;
                txtDBServerGDB.Text = "";
            }
        }
    }
}
