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
            CarregarEquipamentos();
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
                LimparFormulario();
                CarregarEquipamentos();
            }
            else
            {
                MessageBox.Show("Equipamento não salvo");
            }
        }

        private void Atualizar(object sender, RoutedEventArgs e)
        {

        }


        private void LimparFormulario()
        {
            id.Clear();
            descricao.Clear();
            marca.Clear();
            modelo.Clear();
            numeroregistro.Clear();
        }

        private void CarregarEquipamentos()
        {
            List<Equipamento> equipamentos = EquipamentoDAO.ListarEquipamento();
            tabelaEquipamento.ItemsSource = equipamentos;
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {

        }

        //TODO: Metodo para editar e excluir
    }
}
