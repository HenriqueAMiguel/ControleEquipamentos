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
            CarregarOcorrencias();
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
                CarregarOcorrencias();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Ocorrência não Cadastrada");
            }
        }

        private void CarregarOcorrencias()
        {
            List<Ocorrencia> ocorrencias = OcorrenciaDAO.ListarOcorrencias();
            tabelaOcorrencias.ItemsSource = ocorrencias;
        }

        private void LimparFormulario()
        {
            descricao.Clear();
            dataocorrencia.SelectedDate = null;
            cboEquipamento.SelectedValue = null;
            ordemservico.Clear();
            dataDevolvido.SelectedDate = null;
            previsaoRetorno = null;
        }

        private void Atualizar(object sender, RoutedEventArgs e)
        {
            Ocorrencia oc = OcorrenciaDAO.BuscarOcorrencia(Convert.ToInt32(id.Text));
            oc.DataDevolucao = dataDevolvido.SelectedDate;
            oc.Finalizado = true;

            if (OcorrenciaDAO.AtualizarOcorrencia(oc))
            {
                MessageBox.Show("Ocorrência atualizada.");
                LimparFormulario();
                CarregarOcorrencias();
                btnCadastrar.Visibility = Visibility.Visible;

                lbDataDevolvido.Visibility = Visibility.Hidden;
                dataDevolvido.Visibility = Visibility.Hidden;
                btnAtualizar.Visibility = Visibility.Hidden;
                btnCancelarAtualizar.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Ocorrência não atualizada.");
            }

        }

        private void CancelarAtualizar(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
            btnCadastrar.Visibility = Visibility.Visible;
            
            lbDataDevolvido.Visibility = Visibility.Hidden;
            dataDevolvido.Visibility = Visibility.Hidden;
            btnAtualizar.Visibility = Visibility.Hidden;
            btnCancelarAtualizar.Visibility = Visibility.Hidden;
        }

        private void tabelaOcorrencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCadastrar.Visibility = Visibility.Hidden;

            lbDataDevolvido.Visibility = Visibility.Visible;
            dataDevolvido.Visibility = Visibility.Visible;
            btnAtualizar.Visibility = Visibility.Visible;
            btnCancelarAtualizar.Visibility = Visibility.Visible;

            Ocorrencia oc = (Ocorrencia)tabelaOcorrencias.SelectedItem;
            id.Text = oc.Id.ToString();
            descricao.Text = oc.Descricao;
            dataocorrencia.SelectedDate = oc.DataOcorrencia;
            cboEquipamento.SelectedValue = oc.Equipamento.Id;
            ordemservico.Text = oc.OrdemDeServico.ToString();
            previsaoRetorno.SelectedDate = oc.PrevisaoRetorno;
        }

        //TODO: Metodo para editar e excluir
        //TODO: Campo status para saber se finalizou a ocorrencia
    }
}
