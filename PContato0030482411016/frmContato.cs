using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PContato0030482411016
{
    public partial class frmContato : Form
    {
        private BindingSource bnContato = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsContato = new DataSet();
        private DataSet dsCidade = new DataSet();

        public frmContato()
        {
            InitializeComponent();
        }

        private void frmContato_Load(object sender, EventArgs e)
        {
            try
            {
                Contato Con = new Contato();
                dsContato.Tables.Add(Con.Listar());
                bnContato.DataSource = dsContato.Tables["Contato"];
                dgvContato.DataSource = bnContato;
                bnvContato.BindingSource = bnContato;
                txtIdContato.DataBindings.Add("TEXT", bnContato, "id_contato");
                txtNomeContato.DataBindings.Add("TEXT", bnContato, "nome_contato");
                txtEndContato.DataBindings.Add("TEXT", bnContato, "end_contato");
                txtCelContato.DataBindings.Add("TEXT", bnContato, "cel_contato");
                txtEmailContato.DataBindings.Add("TEXT", bnContato, "email_contato");
                dtpDtCadastroContato.DataBindings.Add("TEXT", bnContato, "dtcadastro_contato");
                //Carrega dados da cidade
                Cidade Cid = new Cidade();
                dsCidade.Tables.Add(Cid.Listar());
                cbxCidadeContato.DataSource = dsCidade.Tables["Cidade"];
                //CAMPO QUE SERÁ MOSTRADO PARA O USUÁRIO
                cbxCidadeContato.DisplayMember = "nome_cidade";
                //CAMPO QUE É A CHAVE DA TABELA CIDADE E QUE LIGA COM A TABELA DE ALUNO
                cbxCidadeContato.ValueMember = "id_cidade";
                //No momento de linkar os componentes com o Binding Source linkar também o combox da cidade
                cbxCidadeContato.DataBindings.Add("SelectedValue", bnContato, "cidade_id_cidade"); //AJUSTAR DROPDOWNSTYLE PARA DropDownList PARA NAO DEIXAR
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
    }
}
