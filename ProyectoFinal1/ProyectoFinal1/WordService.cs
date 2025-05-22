using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

public class WordService
{
    public void GenerarDoc(string rutaDestino, string prompt, string resultado)
    {
        // Ruta absoluta a la plantilla dentro de la carpeta 'Plantillas' junto al ejecutable
        string rutaPlantilla = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Plantillas", "Plantilla.docx");

        // Copia la plantilla al destino
        File.Copy(rutaPlantilla, rutaDestino, true);

        // Abre el archivo de destino para edición
        using (WordprocessingDocument doc = WordprocessingDocument.Open(rutaDestino, true))
        {
            var body = doc.MainDocumentPart.Document.Body;

            foreach (var text in body.Descendants<Text>())
            {
                if (text.Text.Contains("{FECHA}"))
                    text.Text = text.Text.Replace("{FECHA}", System.DateTime.Now.ToString("dd/MM/yyyy"));
                if (text.Text.Contains("{PROMPT}"))
                    text.Text = text.Text.Replace("{PROMPT}", prompt ?? "");
                if (text.Text.Contains("{RESULTADO}"))
                    text.Text = text.Text.Replace("{RESULTADO}", resultado ?? "");
            }

            doc.MainDocumentPart.Document.Save();
        }
    }
}