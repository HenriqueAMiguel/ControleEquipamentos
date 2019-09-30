using ControleEquipamentos.DAL;
using ControleEquipamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControleEquipamentos.Views
{
    /// <summary>
    /// Interaction logic for CadastroEquipamento.xaml
    /// </summary>
    public partial class CadastroEquipamento : Window
    {
        public CadastroEquipamento()
        {
            InitializeComponent();
            cboOperador.ItemsSource = PessoaDAO.ListarOperadores();
            cboOperador.DisplayMemberPath = "Nome";
            cboOperador.SelectedValuePath = "Id";
        }

        private void Cadastrar(object sender, RoutedEventArgs e)
        {
            Equipamento eq = new Equipamento();
            eq.Descricao = descricao.Text;
            eq.Marca = marca.Text;
            eq.Modelo = modelo.Text;
            eq.NumeroRegistro = Convert.ToInt32(numeroregistro.Text);
            Pessoa p = PessoaDAO.ObterPessoa(Convert.ToInt32(cboOperador.SelectedValue));
            eq.Operador = p;

            ///TODO: validar numero de registro

            if (EquipamentoDAO.CadastrarEquipamento(eq))
            {
                MessageBox.Show("Equipamento salvo com sucesso!");
            }
            else
            {
                MessageBox.Show("Equipamento não salvo");
            }
        }
    }
}
