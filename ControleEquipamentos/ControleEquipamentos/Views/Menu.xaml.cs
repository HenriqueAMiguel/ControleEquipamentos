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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            List<Emprestimo> emprestimos = EmprestimoDAO.ListarEmprestimos();
            tabelaEmprestimos.ItemsSource = emprestimos;
        }

        private void Sair(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja fechar a janela?", "Controle de Equipamentos", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void Cadastrar_Usuario(object sender, RoutedEventArgs e)
        {
            CadastroUsuario cadastroUsuario = new CadastroUsuario();
            cadastroUsuario.ShowDialog();
        }

        private void Cadastrar_Equipamento(object sender, RoutedEventArgs e)
        {
            CadastroEquipamento cadastroEquipamento = new CadastroEquipamento();
            cadastroEquipamento.ShowDialog();
        }

        private void Cadastrar_Ocorrencia(object sender, RoutedEventArgs e)
        {
            CadastroOcorrencia cadastroOcorrencia = new CadastroOcorrencia();
            cadastroOcorrencia.ShowDialog();
        }

        private void Cadastrar_Emprestimo(object sender, RoutedEventArgs e)
        {
            CadastroEmprestimo cadastroEmprestimo = new CadastroEmprestimo();
            cadastroEmprestimo.ShowDialog();
        }

        
    }
}
