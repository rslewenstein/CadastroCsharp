using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadastroSimples.BLL;
using CadastroSimples.DTO;

namespace SQLiteMetroUI
{
    public partial class frmPrincipal : MetroFramework.Forms.MetroForm
    {

        PessoaBLL bll = new PessoaBLL();
        PessoaDTO dto = new PessoaDTO();


        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void CarregarGrid()
        {
            dtGrid.DataSource = bll.carregarDados();

            //Define o tamanho dos campos no grid

            // dtgvLista.Columns[0].Width = 60;
            dtGrid.Columns[0].Width = 80;
            dtGrid.Columns[1].Width = 100;
            dtGrid.Columns[2].Width = 100;
            dtGrid.Columns[3].Width = 100;
            dtGrid.Columns[4].Width = 100;

        }

        private void Limpar()
        {
            txtNome.Clear();
            txtProf.Clear();
            txtCel.Clear();
            txtId.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            dto.Nome = txtNome.Text;
            dto.Nascimento = Convert.ToDateTime(dtNasc.Text);
            dto.Cel = txtCel.Text;
            dto.Profissao = txtProf.Text;
            bll.Incluir(dto);
            CarregarGrid();
            Limpar();
            MessageBox.Show("Cadastrado com sucesso");
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
