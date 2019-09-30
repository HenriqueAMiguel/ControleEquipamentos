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
            if(administrador.IsChecked == true)
            {
                p.Admin = true;
            }
            //TODO: Validar CPF, validar usuario

            if (PessoaDAO.CadastrarPessoa(p))
            {
                MessageBox.Show("Usuário salvo com sucesso!");
            }
            else
            {
                MessageBox.Show("Usuário não salvo");
            }
        }
    }
}
