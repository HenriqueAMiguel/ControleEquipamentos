using ControleEquipamentos.DAL;
using ControleEquipamentos.Models;
using ControleEquipamentos.Models.Enums;
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
    /// Interaction logic for CadastroUsuario.xaml
    /// </summary>
    public partial class CadastroUsuario : Window
    {
        public CadastroUsuario()
        {
            InitializeComponent();
            CarregarUsuarios();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    tipopessoa.ItemsSource = Enum.GetValues(typeof(TipoPessoa)).Cast<TipoPessoa>();
        //}

        private void Cadastrar(object sender, RoutedEventArgs e)
        {
            Pessoa p = new Pessoa();
            p.Nome = nome.Text;
            p.Nascimento = nascimento.SelectedDate;
            p.Usuario = usuario.Text;
            p.Cpf = cpf.Text;
            p.RG = rg1.Text;
            if (administrador.IsChecked == true)
            {
                p.Admin = true;
            }

            if (!Validacao.ValidarCpf(cpf.Text))
            {
                MessageBox.Show("CPF inválido tente novamente");
                return;
            }
            //TODO: validar usuario

            if (PessoaDAO.CadastrarPessoa(p))
            {
                MessageBox.Show("Usuário salvo com sucesso!");
                LimparFormulario();
                CarregarUsuarios();
            }
            else
            {
                MessageBox.Show("Usuário não salvo");
            }

        }

        /// <summary>
        /// Método que limpa a lista de usuarios cadastrados e carrega uma nova do banco
        /// </summary>
        private void CarregarUsuarios()
        {
            List<Pessoa> usuarios = PessoaDAO.ListarPessoas();
            tabelaUsuarios.ItemsSource = usuarios;
        }

        /// <summary>
        /// Metodo que limpa o formulário de cadastro de usuarios
        /// </summary>
        private void LimparFormulario()
        {
            nome.Text = "";
            nascimento.SelectedDate = DateTime.Now;
            usuario.Text = "";
            cpf.Text = "";
            administrador.IsChecked = false;
        }

        /// <summary>
        /// Metodo que seleciona um usuario da tabela para editar o mesmo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelecionarUsuario(object sender, SelectionChangedEventArgs e)
        {
            Pessoa u = (Pessoa)tabelaUsuarios.SelectedItem;
            id.Text = u.Id.ToString();
            nome.Text = u.Nome;
            nascimento.SelectedDate = u.Nascimento;
            usuario.Text = u.Usuario;
            cpf.Text = u.Cpf;
            administrador.IsChecked = u.Admin;

            cadastrar.Visibility = Visibility.Hidden;
            atualizar.Visibility = Visibility.Visible;
            cancelarAtulizar.Visibility = Visibility.Visible;
        }

        private void Atualizar(object sender, RoutedEventArgs e)
        {
            Pessoa p = PessoaDAO.ObterPessoa(Convert.ToInt32(id.Text));
            p.Nome = nome.Text;
            p.Nascimento = nascimento.SelectedDate;
            p.Usuario = usuario.Text;
            p.Cpf = cpf.Text;
            if (administrador.IsChecked == true)
            {
                p.Admin = true;
            }

            if (!Validacao.ValidarCpf(cpf.Text))
            {
                MessageBox.Show("CPF inválido tente novamente");
                return;
            }
            //TODO: Validar CPF, validar usuario

            if (PessoaDAO.AtualizarPessoa(p))
            {
                MessageBox.Show("Usuário atualizado com sucesso!");
                LimparFormulario();
                CarregarUsuarios();
                cancelarAtulizar.Visibility = Visibility.Hidden;
                cadastrar.Visibility = Visibility.Visible;
                atualizar.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Usuário não atualizado");
            }

        }

        private void CancelarAtualizar(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
            CarregarUsuarios();
            cancelarAtulizar.Visibility = Visibility.Hidden;
            cadastrar.Visibility = Visibility.Visible;
            atualizar.Visibility = Visibility.Hidden;
        }

        private void ValidarCpf(object sender, RoutedEventArgs e)
        {
            if (!Validacao.ValidarCpf(cpf.Text))
            {
                MessageBox.Show("CPF inválido tente novamente");
            }
        }

        private void Rg1_Text(object sender, TextChangedEventArgs e)
        {

        }

        //TODO: Metodo para editar e excluir
    }
}
