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
    /// Interaction logic for CadastroEmprestimo.xaml
    /// </summary>
    public partial class CadastroEmprestimo : Window
    {
        private List<Equipamento> list = new List<Equipamento>();
        public CadastroEmprestimo()
        {
            InitializeComponent();
            CarregarEmprestimos();

            cboOperador.ItemsSource = PessoaDAO.ListarOperadores();
            cboOperador.DisplayMemberPath = "Nome";
            cboOperador.SelectedValuePath = "Id";

            cboUsuario.ItemsSource = PessoaDAO.ListarUsuarios();
            cboUsuario.DisplayMemberPath = "Nome";
            cboUsuario.SelectedValuePath = "Id";

            cboEquipamento.ItemsSource = EquipamentoDAO.ListarEquipamento();
            cboEquipamento.DisplayMemberPath = "Descricao";
            cboEquipamento.SelectedValuePath = "Id";
        }

        private void Cadastrar(object sender, RoutedEventArgs e)
        {
            Emprestimo emp = new Emprestimo();

            emp.DataEmprestimo = dataEmprestimo.SelectedDate;
            emp.DataPrevistaDevolucao = dataPrevDevol.SelectedDate;
          
            Pessoa p = PessoaDAO.ObterPessoa(Convert.ToInt32(cboOperador.SelectedValue));
            emp.Operador = p;

            Pessoa pe = PessoaDAO.ObterPessoa(Convert.ToInt32(cboUsuario.SelectedValue));
            emp.Usuario = pe;
            emp.Equipamentos = list;

            if (EmprestimoDAO.CadastrarEmprestimo(emp))
            {
                MessageBox.Show("Empréstimo realizado com sucesso!");
                CarregarEmprestimos();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Empréstimo não realizado");
            }
        }

        private void Atualizar(object sender, RoutedEventArgs e)
        {
            if (!dataDevolucao.SelectedDate.HasValue)
            {
                MessageBox.Show("Necessário preencher uma data de devolução");
                return;
            }

            Emprestimo emp = EmprestimoDAO.BuscarEmprestimo(Convert.ToInt32(id.Text));
            emp.DataDevolucao = dataDevolucao.SelectedDate;
            emp.StatusDoEmprestimo = true;
            var retorno = EmprestimoDAO.Atualizar(emp);

            if (retorno)
            {
                MessageBox.Show("Empréstimo atualizado");
                LimparFormulario();
                btnCadastrar.Visibility = Visibility.Visible;
                btnAtualizar.Visibility = Visibility.Hidden;
                dataDevolucao.Visibility = Visibility.Hidden;
                lbDtDevolucao.Visibility = Visibility.Hidden;

                CarregarEmprestimos();
            }
            else
            {
                MessageBox.Show("Empréstimo não atualizado");
            }
        }

        private void addEquipamento(object sender, RoutedEventArgs e)
        {
            if (EquipamentoDAO.ValidarEquipamento(Convert.ToInt32(cboEquipamento.SelectedValue)))
            {
                MessageBox.Show("Equipamento já emprestado");
                return;
            }            

            Equipamento eq = EquipamentoDAO.ObterEquipamento(Convert.ToInt32(cboEquipamento.SelectedValue));
            
            list.Add(eq);
            tabelaEquipamentos.ItemsSource = list;
            tabelaEquipamentos.Items.Refresh();
        }

        private void tabelaEmprestimos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Emprestimo emp = (Emprestimo)tabelaEmprestimos.SelectedValue;
            if (emp.StatusDoEmprestimo)
            {
                MessageBox.Show(" Emprestimo já devolvido");
                return;
            }
            dataEmprestimo.SelectedDate = emp.DataEmprestimo;
            dataPrevDevol.SelectedDate = emp.DataPrevistaDevolucao;

            cboOperador.SelectedItem = emp.Operador;
            cboUsuario.SelectedItem = emp.Usuario;
            tabelaEquipamentos.ItemsSource = emp.Equipamentos;

            id.Text = emp.Id.ToString();

            dataDevolucao.Visibility = Visibility.Visible;
            btnCadastrar.Visibility = Visibility.Hidden;
            btnAtualizar.Visibility = Visibility.Visible;
            lbDtDevolucao.Visibility = Visibility.Visible;
        }

        private void CarregarEmprestimos()
        {
            List<Emprestimo> emprestimos = EmprestimoDAO.ListarEmprestimosComEquipamento();
            tabelaEmprestimos.ItemsSource = emprestimos;
        }

       

        private void LimparFormulario()
        {
            dataEmprestimo.SelectedDate = null;
            dataDevolucao.SelectedDate = null;
            dataPrevDevol.SelectedDate = null;
            cboOperador.SelectedItem = null;
            cboUsuario.SelectedItem = null;
            tabelaEquipamentos.ItemsSource = new List<Equipamento>();
            devolvido.IsChecked = false;
        }
    }
}
