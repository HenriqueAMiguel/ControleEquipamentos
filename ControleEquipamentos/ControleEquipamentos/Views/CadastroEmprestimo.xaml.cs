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
        private List<dynamic> equipamentos = new List<dynamic>();
        
        public CadastroEmprestimo()
        {
            InitializeComponent();
            cboOperador.ItemsSource = PessoaDAO.ListarOperadores();
            cboOperador.DisplayMemberPath = "Nome";
            cboOperador.SelectedValuePath = "Id";

            cboEquipamento.ItemsSource = EquipamentoDAO.ListarEquipamento();
            cboEquipamento.DisplayMemberPath = "Nome";
            cboEquipamento.SelectedValuePath = "Id";
        }

        private void Cadastrar(object sender, RoutedEventArgs e)
        {
            Emprestimo emp = new Emprestimo();

            emp.DataEmprestimo = dataEmprestimo.SelectedDate;
            emp.DataPrevistaDevolucao = dataPrevDevol.SelectedDate;
            emp.DataDevolucao = dataDevolucao.SelectedDate;

            Pessoa p = PessoaDAO.ObterPessoa(Convert.ToInt32(cboOperador.SelectedValue));
            emp.Operador = p;

            Pessoa pe = PessoaDAO.ObterPessoa(Convert.ToInt32(cboOperador.SelectedValue));
            emp.Usuario = pe;

            Equipamento eq = EquipamentoDAO.ObterEquipamento(Convert.ToInt32(cboEquipamento.SelectedValue));
            dynamic d = new
            {
                Equipamento = eq.Descricao                
            };
            equipamentos.Add(d);



            if (EmprestimoDAO.CadastrarEmprestimo(emp))
            {
                MessageBox.Show("Empréstimo realizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Empréstimo não realizado");
            }
        }
    }
}
