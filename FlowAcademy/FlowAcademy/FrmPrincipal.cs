using FlowAcademyClasses;
using FlowAcademyF;
using System;
using System.Windows.Forms;

namespace FlowAcademy
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        // ==========================
        // LOAD
        // ==========================
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AplicarPermissoes();
        }

        // ==========================
        // PERMISSÕES
        // ==========================
        private void AplicarPermissoes()
        {
            string perfil = Sessao.NivelAcesso?.ToLower();

            // ADMIN → acesso total
            if (perfil == "admin")
            {
                return;
            }

            // PROFESSOR
            if (perfil == "professor")
            {
                btnUsuarios.Visible = false;
            }

            // ALUNO
            if (perfil == "aluno")
            {
                btnUsuarios.Visible = false;
                btnProfessores.Visible = false;
                btnCursos.Visible = false;
                btnDisciplinas.Visible = false;
                btnTurmas.Visible = false;
                btnMatriculas.Visible = false;
            }
        }

        // ==========================
        // ABRIR FORM NO PAINEL
        // ==========================
        private void AbrirFormulario(Form form)
        {
            panel1.Controls.Clear();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;

            panel1.Controls.Add(form);
            form.Show();
        }

        // ==========================
        // BOTÕES
        // ==========================

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmUsuario());
        }

        private void btnAlunos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmAluno());
        }

        private void btnProfessores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmProfessor());
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmCurso());
        }

        private void btnDisciplinas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmDisciplina());
        }

        private void btnTurmas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmTurma());
        }

        private void btnMatriculas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmMatricula());
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmNota());
        }

        private void btnFrequencia_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmFrequencia());
        }

        private void btnPagamentos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmPagamento());
        }

        private void btnFeedbacks_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmFeedback());
        }
    }
}