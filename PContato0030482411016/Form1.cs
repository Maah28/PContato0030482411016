using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace PContato0030482411016
{
    public partial class frmPrincipal : Form
    {
        public static SqlConnection conexao;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("Data Source=Apolo;Initial Catalog=BD;User ID=BD2411016;Password=Damaris28006#");
                conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir o Banco de Dados!\n"+ex.Message);
            }
        }

        private void cadastroDeContatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["frmContato"];

            if(fc != null)
            {
                fc.Close();
            }

            frmContato FRMC = new frmContato();
            FRMC.MdiParent = this;
            FRMC.WindowState = FormWindowState.Maximized;
            FRMC.Show();
        }
    }
}
