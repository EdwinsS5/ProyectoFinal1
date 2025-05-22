using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using System.IO;
using System.Linq;

public class PowerPointService
{
    public void GenerarPpt(string rutaDestino, string textoTitulo, string textoContenido)
    {
        // Ruta absoluta a la plantilla dentro de la carpeta 'Plantillas' junto al ejecutable
        string rutaPlantilla = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Plantillas", "Plantilla.pptx");

        // Copia la plantilla a la nueva ubicación
        File.Copy(rutaPlantilla, rutaDestino, true);

        using (PresentationDocument ppt = PresentationDocument.Open(rutaDestino, true))
        {
            var slidePart = ppt.PresentationPart.SlideParts.First();

            // Reemplaza solo las llaves {TITULO} y {INVESTIGACION} en todos los cuadros de texto
            foreach (var textElement in slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>())
            {
                if (textElement.Text.Contains("{TITULO}"))
                    textElement.Text = textElement.Text.Replace("{TITULO}", textoTitulo);

                if (textElement.Text.Contains("{INVESTIGACION}"))
                    textElement.Text = textElement.Text.Replace("{INVESTIGACION}", textoContenido);
            }

            slidePart.Slide.Save();
        }
    }
}