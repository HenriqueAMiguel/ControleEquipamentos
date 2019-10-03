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
            Equipamento eq = EquipamentoDAO.ObterEquipamento(Convert.ToInt32(id.Text));
            eq.Descricao = descricao.Text;
            eq.Marca = marca.Text;
            eq.Modelo = modelo.Text;
            eq.NumeroRegistro = Convert.ToInt32(numeroregistro.Text);
            if (Inativo.IsChecked == true)
                eq.Inativo = true;

            if (EquipamentoDAO.AtualizarEquipamento(eq))
            {
                MessageBox.Show("Atualizado com sucesso!");
                LimparFormulario();
                CarregarEquipamentos();
            }
            else
            {
                MessageBox.Show("Equipamento não atualizado!");
            }
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
            LimparFormulario();
            cancelarAtualizar.Visibility = Visibility.Hidden;
            atualizar.Visibility = Visibility.Hidden;
            cadastrar.Visibility = Visibility.Visible;
            Inativo.Visibility = Visibility.Hidden;
        }

        private void tabelaEquipamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Equipamento eq = (Equipamento)tabelaEquipamento.SelectedItem;
            id.Text = eq.Id.ToString();
            descricao.Text = eq.Descricao;
            marca.Text = eq.Marca;
            modelo.Text = eq.Modelo;
            numeroregistro.Text = eq.NumeroRegistro.ToString();

            cadastrar.Visibility = Visibility.Hidden;
            atualizar.Visibility = Visibility.Visible;
            cancelarAtualizar.Visibility = Visibility.Visible;
            Inativo.Visibility = Visibility.Visible;
        }
    }
}
