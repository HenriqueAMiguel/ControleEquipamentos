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
    /// Interaction logic for CadastroOcorrencia.xaml
    /// </summary>
    public partial class CadastroOcorrencia : Window
    {
        public CadastroOcorrencia()
        {
            InitializeComponent();
            cboEquipamento.ItemsSource = EquipamentoDAO.ListarEquipamento();
            cboEquipamento.DisplayMemberPath = "Descricao";
            cboEquipamento.SelectedValuePath = "Id";
        }

        private void Cadastrar(object sender, RoutedEventArgs e)
        {
            Ocorrencia o = new Ocorrencia();
            o.Descricao = descricao.Text;
            o.DataOcorrencia = dataocorrencia.SelectedDate;
            Equipamento eq = EquipamentoDAO.ObterEquipamento(Convert.ToInt32(cboEquipamento.SelectedValue));
            o.Equipamento = eq;
            o.OrdemDeServico = Convert.ToInt32(ordemservico.Text);
            o.PrevisaoRetorno = previsaoRetorno.SelectedDate;
            

            if (OcorrenciaDAO.CadastrarOcorrencia(o))
            {
                MessageBox.Show("Ocorrência Cadastrada com sucesso!");
            }
            else
            {
                MessageBox.Show("Ocorrência não Cadastrada");
            }
        }
    }
}
