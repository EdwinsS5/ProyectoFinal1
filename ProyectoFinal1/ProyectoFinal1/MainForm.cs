using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal1
{
    public partial class MainForm : Form
    {
        private readonly AIService aiService;
        private readonly DatabaseService dbService;
        private readonly WordService wordService;
        private readonly PowerPointService pptService;
        private string resultadoFinal = "";

        public MainForm()
        {
            InitializeComponent();

            aiService = new AIService("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");
            dbService = new DatabaseService("Server=DESKTOP-P5L5BPG\\SQLEXPRESS01;Database=PRFINAL1;Trusted_Connection=True;");
            wordService = new WordService();
            pptService = new PowerPointService();
        }

        private async void btnInvestigar_Click(object sender, EventArgs e)
        {

            btnInvestigar.Enabled = false;
            txtResultado.Text = "Consultando IA...";
            string prompt = txtPrompt.Text.Trim();
            string resultado = await aiService.ConsultarIAAsync(prompt);
            txtResultado.Text = resultado;
            resultadoFinal = resultado;
            btnGenerar.Enabled = true;
            btnInvestigar.Enabled = true;
        }

        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            btnGenerar.Enabled = false;
            string prompt = txtPrompt.Text.Trim();
            string resultado = txtResultado.Text.Trim();
            await dbService.GuardarInvestigacionAsync(prompt, resultado);

            // Guardar Word
            string wordPath = null;
            using (SaveFileDialog saveWordDialog = new SaveFileDialog())
            {
                saveWordDialog.Title = "Guardar documento Word";
                saveWordDialog.Filter = "Documento de Word (*.docx)|*.docx";
                saveWordDialog.FileName = "Investigacion.docx";
                if (saveWordDialog.ShowDialog() == DialogResult.OK)
                {
                    wordPath = saveWordDialog.FileName;
                    wordService.GenerarDoc(wordPath, prompt, resultado);
                }
            }

            // Guardar PowerPoint
            string pptPath = null;
            using (SaveFileDialog savePptDialog = new SaveFileDialog())
            {
                savePptDialog.Title = "Guardar presentación PowerPoint";
                savePptDialog.Filter = "Presentación de PowerPoint (*.pptx)|*.pptx";
                savePptDialog.FileName = "Investigacion.pptx";
                if (savePptDialog.ShowDialog() == DialogResult.OK)
                {
                    pptPath = savePptDialog.FileName;
                    pptService.GenerarPpt(pptPath, prompt, resultado);
                }
            }

            string mensaje = "Documentos generados:\n";
            if (wordPath != null) mensaje += wordPath + "\n";
            if (pptPath != null) mensaje += pptPath + "\n";
            if (wordPath == null && pptPath == null) mensaje = "No se generó ningún documento.";
            MessageBox.Show(mensaje);

            btnGenerar.Enabled = true;
        }
    }
}