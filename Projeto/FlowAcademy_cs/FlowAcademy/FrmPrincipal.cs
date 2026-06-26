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
            ConfigurarEventos();
        }

        // ==========================
        // LOAD
        // ==========================
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AplicarPermissoes();
        }

        // ==========================
        // PERMISSOES
        // ==========================
        private void AplicarPermissoes()
        {
            OcultarTodosMenus();

            string perfil = NormalizarPerfil(Sessao.NivelAcesso);

            Text = "Flow Academy - " + (Sessao.Nome ?? "Usuario") + " (" + perfil + ")";

            if (perfil == "aluno")
            {
                MostrarMenus(btnNotas, btnFrequencia);
                return;
            }

            if (perfil == "professor")
            {
                MostrarMenus(btnNotas, btnFrequencia);
                return;
            }

            if (perfil == "coordenacao")
            {
                MostrarMenus(btnAlunos, btnCursos, btnDisciplinas, btnTurmas, btnMatriculas);
                return;
            }

            if (perfil == "administrativo")
            {
                MostrarMenus(btnAlunos, btnMatriculas, btnPagamentos);
                return;
            }

            if (perfil == "admin")
            {
                MostrarMenus(btnUsuarios, btnAlunos, btnProfessores, btnCursos,
                    btnDisciplinas, btnTurmas, btnMatriculas, btnPagamentos);
            }
        }

        private string NormalizarPerfil(string? perfil)
        {
            string perfilTratado = (perfil ?? "").Trim().ToLower();

            // Mesmo comportamento do PHP: financeiro antigo entra como administrativo.
            if (perfilTratado == "financeiro")
            {
                return "administrativo";
            }

            return perfilTratado;
        }

        private void OcultarTodosMenus()
        {
            btnUsuarios.Visible = false;
            btnAlunos.Visible = false;
            btnProfessores.Visible = false;
            btnCursos.Visible = false;
            btnDisciplinas.Visible = false;
            btnTurmas.Visible = false;
            btnMatriculas.Visible = false;
            btnNotas.Visible = false;
            btnFrequencia.Visible = false;
            btnPagamentos.Visible = false;
            bntFeedbacks.Visible = false;
        }

        private void MostrarMenus(params Button[] botoes)
        {
            foreach (Button botao in botoes)
            {
                botao.Visible = true;
            }
        }

        private bool PodeAcessar(Button botao)
        {
            return botao.Visible;
        }

        private void AvisarSemPermissao()
        {
            MessageBox.Show("Seu usuario nao tem permissao para acessar esta tela.",
                "Permissao",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void ConfigurarEventos()
        {
            btnUsuarios.Click += btnUsuarios_Click;
            btnAlunos.Click += btnAlunos_Click;
            btnProfessores.Click += btnProfessores_Click;
            btnCursos.Click += btnCursos_Click;
            btnDisciplinas.Click += btnDisciplinas_Click;
            btnTurmas.Click += btnTurmas_Click;
            btnMatriculas.Click += btnMatriculas_Click;
            btnNotas.Click += btnNotas_Click;
            btnFrequencia.Click += btnFrequencia_Click;
            btnPagamentos.Click += btnPagamentos_Click;
            bntFeedbacks.Click += btnFeedbacks_Click;
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
        // BOTOES
        // ==========================

        private void btnUsuarios_Click(object? sender, EventArgs e)
        {
            if (!PodeAcessar(btnUsuarios)) { AvisarSemPermissao(); return; }
            AbrirFormulario(new FrmUsuario());
        }

        private void btnAlunos_Click(object? sender, EventArgs e)
        {
            if (!PodeAcessar(btnAlunos)) { AvisarSemPermissao(); return; }
            AbrirFormulario(new FrmAluno());
        }

        private void btnProfessores_Click(object? sender, EventArgs e)
        {
            if (!PodeAcessar(btnProfessores)) { AvisarSemPermissao(); return; }
            AbrirFormulario(new FrmProfessor());
        }

        private void btnCursos_Click(object? sender, EventArgs e)
        {
            if (!PodeAcessar(btnCursos)) { AvisarSemPermissao(); return; }
            AbrirFormulario(new FrmCurso());
        }

        private void btnDisciplinas_Click(object? sender, EventArgs e)
        {
            if (!PodeAcessar(btnDisciplinas)) { AvisarSemPermissao(); return; }
            AbrirFormulario(new FrmDisciplina());
        }

        private void btnTurmas_Click(object? sender, EventArgs e)
        {
            if (!PodeAcessar(btnTurmas)) { AvisarSemPermissao(); return; }
            AbrirFormulario(new FrmTurma());
        }

        private void btnMatriculas_Click(object? sender, EventArgs e)
        {
            if (!PodeAcessar(btnMatriculas)) { AvisarSemPermissao(); return; }
            AbrirFormulario(new FrmMatricula());
        }

        private void btnNotas_Click(object? sender, EventArgs e)
        {
            if (!PodeAcessar(btnNotas)) { AvisarSemPermissao(); return; }
            AbrirFormulario(new FrmNota());
        }

        private void btnFrequencia_Click(object? sender, EventArgs e)
        {
            if (!PodeAcessar(btnFrequencia)) { AvisarSemPermissao(); return; }
            AbrirFormulario(new FrmFrequencia());
        }

        private void btnPagamentos_Click(object? sender, EventArgs e)
        {
            if (!PodeAcessar(btnPagamentos)) { AvisarSemPermissao(); return; }
            AbrirFormulario(new FrmPagamento());
        }

        private void btnFeedbacks_Click(object? sender, EventArgs e)
        {
            if (!PodeAcessar(bntFeedbacks)) { AvisarSemPermissao(); return; }
            AbrirFormulario(new FrmFeedback());
        }
    }
}
