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
    /// Interaction logic for RelatorioEmprestimos.xaml
    /// </summary>
    public partial class RelatorioEmprestimos : Window
    {
        public RelatorioEmprestimos()
        {
            InitializeComponent();
           List<Equipamento> eq = EquipamentoDAO.ListarEquipamento();
            cboEquipamento.ItemsSource = eq;
            cboEquipamento.DisplayMemberPath = "Descricao";
            cboEquipamento.SelectedValuePath = "Id";

            List<Pessoa> op = PessoaDAO.ListarOperadores();
            cboOperador.ItemsSource = op;
            cboOperador.DisplayMemberPath = "Nome";
            cboOperador.SelectedValuePath = "Id";

            List<Pessoa> u = PessoaDAO.ListarUsuarios();
            cboUsuario.ItemsSource = u;
            cboUsuario.DisplayMemberPath = "Nome";
            cboUsuario.SelectedValuePath = "Id";
        }

        private void Pesquisar(object sender, RoutedEventArgs e)
        {

        }
    }
}
