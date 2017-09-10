using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Correios.Net;

namespace BuscaCEP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.txtCep.Clear();
        }

        private void buscaCep()
        {
            if (!string.IsNullOrWhiteSpace(this.txtCep.Text))
            {
                Address address = SearchZip.GetAddress(this.txtCep.Text);
                if (address.Zip != null)
                {
                    this.txtEstado.Text = address.State;
                    this.txtCidade.Text = address.City;
                    this.txtRua.Text = address.Street;
                    this.txtBairro.Text = address.District;
                }
                else
                {
                    MessageBox.Show("Nao foi possivel localizar logradouro","Informacao",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else {
                MessageBox.Show("Por favor preencha campo cep", "Erro",MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCep.Focus();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.buscaCep();
        }

    }
}
