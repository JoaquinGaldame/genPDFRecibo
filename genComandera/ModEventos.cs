using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genComandera
{
    public class ModEventos: PdfPageEventHelper
    {
        protected Font footer
        {
            get
            {
                BaseColor color = new BaseColor(128, 128, 128);
                return FontFactory.GetFont("Arial", 8f, 0, color);
            }
        }

        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            PdfPTable pdfPTable = new PdfPTable(2);
            pdfPTable.TotalWidth = doc.PageSize.Width;
            pdfPTable.HorizontalAlignment = 1;
            Paragraph paragraph = new Paragraph(" ", footer);
            paragraph.Add(Environment.NewLine);
            paragraph.Add(" ");
            PdfPCell pdfPCell = new PdfPCell(paragraph);
            pdfPCell.Border = 0;
            pdfPCell.PaddingLeft = 10f;
            pdfPTable.AddCell(pdfPCell);
            paragraph = new Paragraph("Recibo de Cobro - Softsystems", footer);
            pdfPCell = new PdfPCell(paragraph);
            pdfPCell.HorizontalAlignment = 2;
            pdfPCell.Border = 0;
            pdfPCell.PaddingRight = 10f;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.WriteSelectedRows(0, -1, 0f, doc.BottomMargin + 10f, writer.DirectContent);
        }
    }
}
