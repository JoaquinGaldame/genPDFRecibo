using genComandera;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace GenCOBPDF
{
    public class GenPDFRecibo
    {
        private string Formato_numero(decimal numero)
        {
            string text = "N2";
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("es-ES");
            return numero.ToString(text, cultureInfo).Replace(".", " ");
        }
        public int GenerandoPDF(string pathArchivo, DataSet datos, string rutalogo, ref HttpResponse ResponseP, int opcion)
        {
            byte[] array = new byte[1];
            byte[] datosbyte = array;
            return GenerandoPDF_Final(pathArchivo, datos, rutalogo, ref ResponseP, opcion, ref datosbyte);
        }

        public int GenerandoPDF(string pathArchivo, DataSet datos, string rutalogo, ref HttpResponse ResponseP, int opcion, ref byte[] datosbyte)
        {
            return GenerandoPDF_Final(pathArchivo, datos, rutalogo, ref ResponseP, opcion, ref datosbyte);
        }

        private int GenerandoPDF_Final(string pathArchivo, DataSet datos, string rutalogo, ref HttpResponse ResponseP, int opcion, ref byte[] datosbyte)
        {
            int index = 0;
            if (Convert.ToInt32(datos.Tables[0].Rows[index]["tipoImpresion"]) == 0)
            {
                Document document = new Document(PageSize.A4, 50f, 50f, 30f, 30f);
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter instance = PdfWriter.GetInstance(document, memoryStream);
                ModEventos modEventos = (ModEventos)(instance.PageEvent = new ModEventos());
                if (opcion == 1)
                {
                    instance = PdfWriter.GetInstance(document, new FileStream(pathArchivo, FileMode.Create));
                }

                document.Open();
                try
                {
                    _ = instance.DirectContent;
                    string content = datos.Tables[0].Rows[index]["Fecha"].ToString();
                    string text = datos.Tables[0].Rows[index]["Numero"].ToString();
                    string text2 = datos.Tables[0].Rows[index]["inicioact"].ToString();
                    string text3 = datos.Tables[0].Rows[index]["cuitempresa"].ToString();
                    string text4 = datos.Tables[0].Rows[index]["nroingresosb"].ToString();
                    datos.Tables[0].Rows[index]["CUIT"].ToString();
                    string content2 = "X";
                    string content3 = datos.Tables[0].Rows[index]["codcliente"].ToString();
                    string content4 = datos.Tables[0].Rows[index]["Domicilio"].ToString();
                    string text5 = datos.Tables[0].Rows[index]["Nombre"].ToString();
                    string content5 = datos.Tables[0].Rows[index]["observaciones"].ToString();
                    string content6 = datos.Tables[0].Rows[index]["nom_moneda"].ToString();
                    string content7 = datos.Tables[0].Rows[index]["txt_cotiz"].ToString();
                    string content8 = "Recibo";
                    document.NewPage();
                    Font font = FontFactory.GetFont("ARIAL", 10f, 1);
                    Font font2 = FontFactory.GetFont("ARIAL", 10f);
                    Font font3 = FontFactory.GetFont("ARIAL", 11f, 1);
                    Font font4 = FontFactory.GetFont("ARIAL", 8f);
                    FontFactory.GetFont("ARIAL", 8f, 1);
                    Font font5 = FontFactory.GetFont("ARIAL", 7f);
                    Font font6 = FontFactory.GetFont("ARIAL", 45f, 1);
                    Font font7 = FontFactory.GetFont("ARIAL", 10f, 1, BaseColor.WHITE);
                    float[] widths = new float[3] { 70f, 15f, 70f };
                    PdfPTable pdfPTable = new PdfPTable(3);
                    pdfPTable.WidthPercentage = 100f;
                    pdfPTable.SetWidths(widths);
                    pdfPTable.DefaultCell.VerticalAlignment = 4;
                    pdfPTable.DefaultCell.FixedHeight = 100f;
                    pdfPTable.DefaultCell.BorderWidth = 1f;
                    pdfPTable.DefaultCell.Border = 0;
                    PdfPCell pdfPCell = new PdfPCell();
                    pdfPCell.Image = Image.GetInstance(rutalogo);
                    pdfPCell.Border = 0;
                    pdfPCell.BorderWidth = 1f;
                    Chunk element = new Chunk(content2, font6);
                    Chunk element2 = new Chunk(" ", font5);
                    Phrase phrase = new Phrase();
                    phrase.Add(element);
                    phrase.Add(Environment.NewLine);
                    phrase.Add(element2);
                    PdfPCell pdfPCell2 = new PdfPCell(phrase);
                    pdfPCell2.HorizontalAlignment = 5;
                    pdfPCell2.PaddingLeft = 7f;
                    pdfPCell2.PaddingTop = 7f;
                    pdfPCell2.PaddingBottom = 1f;
                    pdfPCell2.Border = 15;
                    pdfPCell2.BorderWidth = 1f;
                    pdfPCell2.Colspan = 2;
                    PdfPTable pdfPTable2 = new PdfPTable(2);
                    pdfPTable2.WidthPercentage = 100f;
                    pdfPTable2.DefaultCell.VerticalAlignment = 4;
                    pdfPTable2.DefaultCell.FixedHeight = 100f;
                    pdfPTable2.DefaultCell.BorderWidth = 1f;
                    pdfPTable2.DefaultCell.Border = 0;
                    PdfPCell pdfPCell3 = new PdfPCell();
                    pdfPCell3.Border = 0;
                    pdfPCell3.BorderWidth = 1f;
                    PdfPCell pdfPCell4 = new PdfPCell();
                    pdfPCell4.Border = 0;
                    pdfPCell4.BorderWidth = 1f;
                    pdfPTable2.AddCell(pdfPCell2);
                    pdfPTable2.AddCell(pdfPCell3);
                    pdfPTable2.AddCell(pdfPCell4);
                    Chunk element3 = new Chunk(content8, font3);
                    Chunk element4 = new Chunk("Documento no valido como Factura", font4);
                    Chunk element5 = new Chunk(text, font);
                    Chunk element6 = new Chunk("Fecha: ", font);
                    Chunk element7 = new Chunk(content, font2);
                    Chunk element8 = new Chunk("CUIT: " + text3, font5);
                    Chunk element9 = new Chunk("Ing. Brutos: " + text4, font5);
                    Chunk element10 = new Chunk("Inic. Act.: " + text2, font5);
                    Phrase phrase2 = new Phrase();
                    phrase2.Add(element4);
                    phrase2.Add(Environment.NewLine);
                    phrase2.Add(element3);
                    phrase2.Add(Environment.NewLine);
                    phrase2.Add(element5);
                    phrase2.Add(Environment.NewLine);
                    phrase2.Add(Environment.NewLine);
                    phrase2.Add(Environment.NewLine);
                    phrase2.Add(element6);
                    phrase2.Add(element7);
                    phrase2.Add(Environment.NewLine);
                    phrase2.Add(Environment.NewLine);
                    phrase2.Add(Environment.NewLine);
                    phrase2.Add(element8);
                    phrase2.Add(Environment.NewLine);
                    phrase2.Add(element9);
                    phrase2.Add(Environment.NewLine);
                    phrase2.Add(element10);
                    PdfPCell pdfPCell5 = new PdfPCell(phrase2);
                    pdfPCell5.HorizontalAlignment = 0;
                    pdfPCell5.PaddingTop = 20f;
                    pdfPCell5.PaddingLeft = 20f;
                    pdfPCell5.Border = 0;
                    pdfPCell5.BorderWidth = 1f;
                    pdfPTable.AddCell(pdfPCell);
                    pdfPTable.AddCell(pdfPTable2);
                    pdfPTable.AddCell(pdfPCell5);
                    PdfPTable pdfPTable3 = new PdfPTable(1);
                    pdfPTable3.WidthPercentage = 100f;
                    pdfPTable3.DefaultCell.VerticalAlignment = 5;
                    pdfPTable3.DefaultCell.HorizontalAlignment = 0;
                    Chunk element11 = new Chunk("Nombre y Apellido o Razón Social: ", font);
                    Chunk element12 = new Chunk(text5, font2);
                    Chunk element13 = new Chunk("Codigo de Cliente: ", font);
                    Chunk element14 = new Chunk(content3, font2);
                    Chunk element15 = new Chunk("Domicilio: ", font);
                    Chunk element16 = new Chunk(content4, font2);
                    Paragraph paragraph = new Paragraph();
                    paragraph.Add(element11);
                    paragraph.Add(element12);
                    Paragraph paragraph2 = new Paragraph();
                    paragraph2.Add(element13);
                    paragraph2.Add(element14);
                    Paragraph paragraph3 = new Paragraph();
                    paragraph3.Add(element15);
                    paragraph3.Add(element16);
                    PdfPCell pdfPCell6 = new PdfPCell(paragraph);
                    pdfPCell6.PaddingTop = 5f;
                    pdfPCell6.BorderWidth = 1f;
                    pdfPCell6.Border = 1;
                    PdfPCell pdfPCell7 = new PdfPCell(paragraph2);
                    pdfPCell7.BorderWidth = 1f;
                    pdfPCell7.Border = 0;
                    PdfPCell pdfPCell8 = new PdfPCell(paragraph3);
                    pdfPCell8.BorderWidth = 1f;
                    pdfPCell8.Border = 2;
                    pdfPTable3.AddCell(pdfPCell6);
                    pdfPTable3.AddCell(pdfPCell7);
                    pdfPTable3.AddCell(pdfPCell8);
                    PdfPTable pdfPTable4 = new PdfPTable(1);
                    pdfPTable4.WidthPercentage = 100f;
                    pdfPTable4.DefaultCell.VerticalAlignment = 5;
                    pdfPTable4.DefaultCell.HorizontalAlignment = 0;
                    pdfPTable4.DefaultCell.Border = 0;
                    pdfPTable4.DefaultCell.BorderWidth = 1f;
                    PdfPCell pdfPCell9 = new PdfPCell(new Phrase(new Chunk("Moneda Original del Comprobante:", font)));
                    pdfPCell9.PaddingTop = 10f;
                    pdfPCell9.BorderWidth = 1f;
                    pdfPCell9.Border = 0;
                    pdfPTable4.AddCell(pdfPCell9);
                    PdfPTable pdfPTable5 = new PdfPTable(2);
                    pdfPTable5.WidthPercentage = 100f;
                    pdfPTable5.DefaultCell.Border = 0;
                    PdfPCell pdfPCell10 = new PdfPCell(new Phrase(new Chunk("Moneda", font7)));
                    pdfPCell10.HorizontalAlignment = 0;
                    pdfPCell10.BorderWidth = 1f;
                    pdfPCell10.Border = 15;
                    pdfPCell10.BackgroundColor = BaseColor.GRAY;
                    pdfPTable5.AddCell(pdfPCell10);
                    PdfPCell pdfPCell11 = new PdfPCell(new Phrase(new Chunk("Cotización", font7)));
                    pdfPCell11.HorizontalAlignment = 0;
                    pdfPCell11.BorderWidth = 1f;
                    pdfPCell11.Border = 15;
                    pdfPCell11.BackgroundColor = BaseColor.GRAY;
                    pdfPTable5.AddCell(pdfPCell11);
                    PdfPCell pdfPCell12 = new PdfPCell(new Phrase(new Chunk(content6, font4)));
                    pdfPCell12.PaddingTop = 4f;
                    pdfPCell12.BorderWidth = 1f;
                    pdfPCell12.HorizontalAlignment = 5;
                    pdfPCell12.VerticalAlignment = 6;
                    pdfPCell12.Border = 15;
                    pdfPTable5.AddCell(pdfPCell12);
                    PdfPCell pdfPCell13 = new PdfPCell(new Phrase(new Chunk(content7, font4)));
                    pdfPCell13.PaddingTop = 4f;
                    pdfPCell13.HorizontalAlignment = 2;
                    pdfPCell13.VerticalAlignment = 6;
                    pdfPCell13.BorderWidth = 1f;
                    pdfPCell13.Border = 15;
                    pdfPTable5.AddCell(pdfPCell13);
                    pdfPTable4.AddCell(pdfPTable5);
                    PdfPTable pdfPTable6 = new PdfPTable(1);
                    pdfPTable6.WidthPercentage = 100f;
                    pdfPTable6.DefaultCell.VerticalAlignment = 5;
                    pdfPTable6.DefaultCell.HorizontalAlignment = 0;
                    pdfPTable6.DefaultCell.Border = 0;
                    pdfPTable6.DefaultCell.BorderWidth = 1f;
                    PdfPCell pdfPCell14 = new PdfPCell(new Phrase(new Chunk("Corresponde a la Documentación que se detalla:", font)));
                    pdfPCell14.PaddingTop = 10f;
                    pdfPCell14.BorderWidth = 1f;
                    pdfPCell14.Border = 0;
                    pdfPTable6.AddCell(pdfPCell14);
                    float[] widths2 = new float[5] { 41f, 12f, 21f, 21f, 21f };
                    PdfPTable pdfPTable7 = new PdfPTable(5);
                    pdfPTable7.WidthPercentage = 100f;
                    pdfPTable7.SetWidths(widths2);
                    pdfPTable7.DefaultCell.Border = 0;
                    PdfPCell pdfPCell15 = new PdfPCell(new Phrase(new Chunk("Concepto", font7)));
                    pdfPCell15.HorizontalAlignment = 0;
                    pdfPCell15.BorderWidth = 1f;
                    pdfPCell15.Border = 15;
                    pdfPCell15.BackgroundColor = BaseColor.GRAY;
                    pdfPTable7.AddCell(pdfPCell15);
                    PdfPCell pdfPCell16 = new PdfPCell(new Phrase(new Chunk("Fecha", font7)));
                    pdfPCell16.HorizontalAlignment = 0;
                    pdfPCell16.BorderWidth = 1f;
                    pdfPCell16.Border = 15;
                    pdfPCell16.BackgroundColor = BaseColor.GRAY;
                    pdfPTable7.AddCell(pdfPCell16);
                    PdfPCell pdfPCell17 = new PdfPCell(new Phrase(new Chunk("Importe", font7)));
                    pdfPCell17.HorizontalAlignment = 2;
                    pdfPCell17.BorderWidth = 1f;
                    pdfPCell17.Border = 15;
                    pdfPCell17.BackgroundColor = BaseColor.GRAY;
                    pdfPTable7.AddCell(pdfPCell17);
                    PdfPCell pdfPCell18 = new PdfPCell(new Phrase(new Chunk("Neto", font7)));
                    pdfPCell18.HorizontalAlignment = 2;
                    pdfPCell18.BorderWidth = 1f;
                    pdfPCell18.Border = 15;
                    pdfPCell18.BackgroundColor = BaseColor.GRAY;
                    pdfPTable7.AddCell(pdfPCell18);
                    PdfPCell pdfPCell19 = new PdfPCell(new Phrase(new Chunk("Cobrado", font7)));
                    pdfPCell19.HorizontalAlignment = 2;
                    pdfPCell19.BorderWidth = 1f;
                    pdfPCell19.Border = 15;
                    pdfPCell19.BackgroundColor = BaseColor.GRAY;
                    pdfPTable7.AddCell(pdfPCell19);
                    decimal numero = 0m;
                    decimal numero2 = 0m;
                    if (datos.Tables[2].Rows.Count > 0)
                    {
                        for (int i = 0; i < datos.Tables[2].Rows.Count; i++)
                        {
                            PdfPCell pdfPCell20 = new PdfPCell(new Phrase(new Chunk(datos.Tables[2].Rows[i]["txtDescripCom"].ToString(), font4)));
                            pdfPCell20.PaddingTop = 4f;
                            pdfPCell20.BorderWidth = 1f;
                            pdfPCell20.HorizontalAlignment = 5;
                            pdfPCell20.VerticalAlignment = 6;
                            pdfPCell20.Border = 15;
                            pdfPTable7.AddCell(pdfPCell20);
                            PdfPCell pdfPCell21 = new PdfPCell(new Phrase(new Chunk(datos.Tables[2].Rows[i]["txtFecCom"].ToString(), font4)));
                            pdfPCell21.PaddingTop = 4f;
                            pdfPCell21.BorderWidth = 1f;
                            pdfPCell21.VerticalAlignment = 6;
                            pdfPCell21.HorizontalAlignment = 0;
                            pdfPCell21.Border = 15;
                            pdfPTable7.AddCell(pdfPCell21);
                            PdfPCell pdfPCell22 = new PdfPCell(new Phrase(new Chunk(Formato_numero(decimal.Round(decimal.Parse(datos.Tables[2].Rows[i]["txtImporte"].ToString()), 2)), font4)));
                            pdfPCell22.PaddingTop = 4f;
                            pdfPCell22.BorderWidth = 1f;
                            pdfPCell22.VerticalAlignment = 6;
                            pdfPCell22.HorizontalAlignment = 2;
                            pdfPCell22.Border = 15;
                            pdfPTable7.AddCell(pdfPCell22);
                            PdfPCell pdfPCell23 = new PdfPCell(new Phrase(new Chunk(Formato_numero(decimal.Round(decimal.Parse(datos.Tables[2].Rows[i]["txtNeto"].ToString()), 2)), font4)));
                            pdfPCell23.PaddingTop = 4f;
                            pdfPCell23.HorizontalAlignment = 2;
                            pdfPCell23.VerticalAlignment = 6;
                            pdfPCell23.BorderWidth = 1f;
                            pdfPCell23.Border = 15;
                            pdfPTable7.AddCell(pdfPCell23);
                            PdfPCell pdfPCell24 = new PdfPCell(new Phrase(new Chunk(Formato_numero(decimal.Round(decimal.Parse(datos.Tables[2].Rows[i]["ImporteRel"].ToString()), 2)), font4)));
                            pdfPCell24.PaddingTop = 4f;
                            pdfPCell24.HorizontalAlignment = 2;
                            pdfPCell24.VerticalAlignment = 6;
                            pdfPCell24.BorderWidth = 1f;
                            pdfPCell24.Border = 15;
                            pdfPTable7.AddCell(pdfPCell24);
                            numero2 += decimal.Round(decimal.Parse(datos.Tables[2].Rows[i]["txtNeto"].ToString()), 2);
                            numero += decimal.Round(decimal.Parse(datos.Tables[2].Rows[i]["ImporteRel"].ToString()), 2);
                        }
                    }

                    if (datos.Tables[1].Rows.Count > 0)
                    {
                        PdfPCell pdfPCell25 = new PdfPCell(new Phrase(new Chunk("Cobro Adelantado", font4)));
                        pdfPCell25.HorizontalAlignment = 0;
                        pdfPCell25.BorderWidth = 1f;
                        pdfPCell25.Border = 15;
                        pdfPCell25.Colspan = 3;
                        pdfPCell25.PaddingTop = 2f;
                        pdfPTable7.AddCell(pdfPCell25);
                        PdfPCell pdfPCell26 = new PdfPCell(new Phrase(new Chunk(Formato_numero(decimal.Round(decimal.Parse(datos.Tables[1].Rows[0]["txtNetoAd"].ToString()), 2)), font4)));
                        pdfPCell26.HorizontalAlignment = 2;
                        pdfPCell26.BorderWidth = 1f;
                        pdfPCell26.PaddingTop = 2f;
                        pdfPCell26.Border = 15;
                        pdfPTable7.AddCell(pdfPCell26);
                        PdfPCell pdfPCell27 = new PdfPCell(new Phrase(new Chunk(Formato_numero(decimal.Round(decimal.Parse(datos.Tables[1].Rows[0]["ImpPagAdel"].ToString()), 2)), font4)));
                        pdfPCell27.HorizontalAlignment = 2;
                        pdfPCell27.BorderWidth = 1f;
                        pdfPCell27.PaddingTop = 2f;
                        pdfPCell27.Border = 15;
                        pdfPTable7.AddCell(pdfPCell27);
                        numero2 += decimal.Round(decimal.Parse(datos.Tables[1].Rows[0]["txtNetoAd"].ToString()), 2);
                        numero += decimal.Round(decimal.Parse(datos.Tables[1].Rows[0]["ImpPagAdel"].ToString()), 2);
                    }

                    PdfPCell pdfPCell28 = new PdfPCell(new Phrase(new Chunk("Total", font7)));
                    pdfPCell28.HorizontalAlignment = 2;
                    pdfPCell28.BorderWidth = 1f;
                    pdfPCell28.Colspan = 3;
                    pdfPCell28.Border = 15;
                    pdfPCell28.BackgroundColor = BaseColor.GRAY;
                    pdfPTable7.AddCell(pdfPCell28);
                    PdfPCell pdfPCell29 = new PdfPCell(new Phrase(new Chunk(Formato_numero(numero2), font7)));
                    pdfPCell29.HorizontalAlignment = 2;
                    pdfPCell29.BorderWidth = 1f;
                    pdfPCell29.Border = 15;
                    pdfPCell29.BackgroundColor = BaseColor.GRAY;
                    pdfPTable7.AddCell(pdfPCell29);
                    PdfPCell pdfPCell30 = new PdfPCell(new Phrase(new Chunk(Formato_numero(numero), font7)));
                    pdfPCell30.HorizontalAlignment = 2;
                    pdfPCell30.BorderWidth = 1f;
                    pdfPCell30.Border = 15;
                    pdfPCell30.BackgroundColor = BaseColor.GRAY;
                    pdfPTable7.AddCell(pdfPCell30);
                    pdfPTable6.AddCell(pdfPTable7);
                    PdfPTable pdfPTable8 = new PdfPTable(1);
                    pdfPTable8.WidthPercentage = 100f;
                    pdfPTable8.DefaultCell.VerticalAlignment = 5;
                    pdfPTable8.DefaultCell.HorizontalAlignment = 0;
                    pdfPTable8.DefaultCell.Border = 0;
                    pdfPTable8.DefaultCell.BorderWidth = 1f;
                    PdfPCell pdfPCell31 = new PdfPCell(new Phrase(new Chunk("Cobros:", font)));
                    pdfPCell31.PaddingTop = 10f;
                    pdfPCell31.BorderWidth = 1f;
                    pdfPCell31.Border = 0;
                    pdfPTable8.AddCell(pdfPCell31);
                    float[] widths3 = new float[5] { 14f, 53f, 14f, 14f, 21f };
                    PdfPTable pdfPTable9 = new PdfPTable(5);
                    pdfPTable9.WidthPercentage = 100f;
                    pdfPTable9.SetWidths(widths3);
                    pdfPTable9.DefaultCell.Border = 0;
                    PdfPCell pdfPCell32 = new PdfPCell(new Phrase(new Chunk("Cuenta", font7)));
                    pdfPCell32.HorizontalAlignment = 0;
                    pdfPCell32.BorderWidth = 1f;
                    pdfPCell32.Border = 15;
                    pdfPCell32.BackgroundColor = BaseColor.GRAY;
                    pdfPTable9.AddCell(pdfPCell32);
                    PdfPCell pdfPCell33 = new PdfPCell(new Phrase(new Chunk("Descripción", font7)));
                    pdfPCell33.HorizontalAlignment = 0;
                    pdfPCell33.BorderWidth = 1f;
                    pdfPCell33.Border = 15;
                    pdfPCell33.BackgroundColor = BaseColor.GRAY;
                    pdfPTable9.AddCell(pdfPCell33);
                    PdfPCell pdfPCell34 = new PdfPCell(new Phrase(new Chunk("Número", font7)));
                    pdfPCell34.HorizontalAlignment = 2;
                    pdfPCell34.BorderWidth = 1f;
                    pdfPCell34.Border = 15;
                    pdfPCell34.BackgroundColor = BaseColor.GRAY;
                    pdfPTable9.AddCell(pdfPCell34);
                    PdfPCell pdfPCell35 = new PdfPCell(new Phrase(new Chunk("Fecha", font7)));
                    pdfPCell35.HorizontalAlignment = 2;
                    pdfPCell35.BorderWidth = 1f;
                    pdfPCell35.Border = 15;
                    pdfPCell35.BackgroundColor = BaseColor.GRAY;
                    pdfPTable9.AddCell(pdfPCell35);
                    PdfPCell pdfPCell36 = new PdfPCell(new Phrase(new Chunk("Importe", font7)));
                    pdfPCell36.HorizontalAlignment = 2;
                    pdfPCell36.BorderWidth = 1f;
                    pdfPCell36.Border = 15;
                    pdfPCell36.BackgroundColor = BaseColor.GRAY;
                    pdfPTable9.AddCell(pdfPCell36);
                    decimal numero3 = 0m;
                    if (datos.Tables[3].Rows.Count > 0)
                    {
                        for (int j = 0; j < datos.Tables[3].Rows.Count; j++)
                        {
                            PdfPCell pdfPCell37 = new PdfPCell(new Phrase(new Chunk(datos.Tables[3].Rows[j]["Cuenta"].ToString(), font4)));
                            pdfPCell37.PaddingTop = 4f;
                            pdfPCell37.BorderWidth = 1f;
                            pdfPCell37.HorizontalAlignment = 5;
                            pdfPCell37.VerticalAlignment = 6;
                            pdfPCell37.Border = 15;
                            pdfPTable9.AddCell(pdfPCell37);
                            PdfPCell pdfPCell38 = new PdfPCell(new Phrase(new Chunk(datos.Tables[3].Rows[j]["ddlDescripcionC"].ToString(), font4)));
                            pdfPCell38.PaddingTop = 4f;
                            pdfPCell38.BorderWidth = 1f;
                            pdfPCell38.VerticalAlignment = 6;
                            pdfPCell38.HorizontalAlignment = 0;
                            pdfPCell38.Border = 15;
                            pdfPTable9.AddCell(pdfPCell38);
                            if (datos.Tables[3].Rows[j]["TipoCta"].ToString() == "CR" || datos.Tables[3].Rows[j]["TipoCta"].ToString() == "BA" || datos.Tables[3].Rows[j]["TipoCta"].ToString() == "CH")
                            {
                                PdfPCell pdfPCell39 = new PdfPCell(new Phrase(new Chunk(datos.Tables[3].Rows[j]["BcoNum"].ToString(), font4)));
                                pdfPCell39.PaddingTop = 4f;
                                pdfPCell39.BorderWidth = 1f;
                                pdfPCell39.VerticalAlignment = 6;
                                pdfPCell39.HorizontalAlignment = 2;
                                pdfPCell39.Border = 15;
                                pdfPTable9.AddCell(pdfPCell39);
                                PdfPCell pdfPCell40 = new PdfPCell(new Phrase(new Chunk(datos.Tables[3].Rows[j]["BcoVen"].ToString(), font4)));
                                pdfPCell40.PaddingTop = 4f;
                                pdfPCell40.HorizontalAlignment = 2;
                                pdfPCell40.VerticalAlignment = 6;
                                pdfPCell40.BorderWidth = 1f;
                                pdfPCell40.Border = 15;
                                pdfPTable9.AddCell(pdfPCell40);
                            }
                            else
                            {
                                PdfPCell pdfPCell41 = new PdfPCell(new Phrase(new Chunk(" ", font4)));
                                pdfPCell41.PaddingTop = 4f;
                                pdfPCell41.BorderWidth = 1f;
                                pdfPCell41.VerticalAlignment = 6;
                                pdfPCell41.HorizontalAlignment = 2;
                                pdfPCell41.Border = 15;
                                pdfPTable9.AddCell(pdfPCell41);
                                PdfPCell pdfPCell42 = new PdfPCell(new Phrase(new Chunk(" ", font4)));
                                pdfPCell42.PaddingTop = 4f;
                                pdfPCell42.HorizontalAlignment = 2;
                                pdfPCell42.VerticalAlignment = 6;
                                pdfPCell42.BorderWidth = 1f;
                                pdfPCell42.Border = 15;
                                pdfPTable9.AddCell(pdfPCell42);
                            }

                            PdfPCell pdfPCell43 = new PdfPCell(new Phrase(new Chunk(Formato_numero(decimal.Round(decimal.Parse(datos.Tables[3].Rows[j]["ImporteCta"].ToString()), 2)), font4)));
                            pdfPCell43.PaddingTop = 4f;
                            pdfPCell43.HorizontalAlignment = 2;
                            pdfPCell43.VerticalAlignment = 6;
                            pdfPCell43.BorderWidth = 1f;
                            pdfPCell43.Border = 15;
                            pdfPTable9.AddCell(pdfPCell43);
                            numero3 += decimal.Round(decimal.Parse(datos.Tables[3].Rows[j]["ImporteCta"].ToString()), 2);
                        }
                    }

                    PdfPCell pdfPCell44 = new PdfPCell(new Phrase(new Chunk(" ", font7)));
                    pdfPCell44.HorizontalAlignment = 0;
                    pdfPCell44.BorderWidth = 1f;
                    pdfPCell44.Border = 15;
                    pdfPCell44.Colspan = 4;
                    pdfPCell44.BackgroundColor = BaseColor.GRAY;
                    pdfPTable9.AddCell(pdfPCell44);
                    PdfPCell pdfPCell45 = new PdfPCell(new Phrase(new Chunk(Formato_numero(numero3), font7)));
                    pdfPCell45.HorizontalAlignment = 2;
                    pdfPCell45.BorderWidth = 1f;
                    pdfPCell45.Border = 15;
                    pdfPCell45.BackgroundColor = BaseColor.GRAY;
                    pdfPTable9.AddCell(pdfPCell45);
                    pdfPTable8.AddCell(pdfPTable9);
                    PdfPTable pdfPTable10 = new PdfPTable(1);
                    pdfPTable10.WidthPercentage = 100f;
                    pdfPTable10.DefaultCell.VerticalAlignment = 5;
                    pdfPTable10.DefaultCell.HorizontalAlignment = 0;
                    pdfPTable10.DefaultCell.Border = 0;
                    PdfPCell pdfPCell46 = new PdfPCell(new Phrase(new Chunk("Observaciones :", font)));
                    pdfPCell46.PaddingTop = 10f;
                    pdfPCell46.BorderWidth = 1f;
                    pdfPCell46.Border = 0;
                    pdfPTable10.AddCell(pdfPCell46);
                    PdfPCell pdfPCell47 = new PdfPCell(new Phrase(new Chunk(content5, font4)));
                    pdfPCell47.PaddingTop = 4f;
                    pdfPCell47.BorderWidth = 1f;
                    pdfPCell47.Border = 15;
                    pdfPTable10.AddCell(pdfPCell47);
                    float[] widths4 = new float[3] { 60f, 40f, 40f };
                    PdfPTable pdfPTable11 = new PdfPTable(3);
                    pdfPTable11.WidthPercentage = 100f;
                    pdfPTable11.SetWidths(widths4);
                    pdfPTable11.DefaultCell.Border = 0;
                    PdfPCell pdfPCell48 = new PdfPCell(new Phrase(new Chunk(" ", font)));
                    pdfPCell48.PaddingTop = 25f;
                    pdfPCell48.BorderWidth = 1f;
                    pdfPCell48.Colspan = 3;
                    pdfPCell48.Rowspan = 3;
                    pdfPCell48.Border = 0;
                    pdfPTable11.AddCell(pdfPCell48);
                    PdfPCell pdfPCell49 = new PdfPCell(new Phrase(new Chunk("RECIBÍ CONFORME :", font)));
                    pdfPCell49.BorderWidth = 1f;
                    pdfPCell49.Border = 0;
                    pdfPTable11.AddCell(pdfPCell49);
                    PdfPCell pdfPCell50 = new PdfPCell(new Phrase(new Chunk("________________", font)));
                    pdfPCell50.BorderWidth = 1f;
                    pdfPCell50.HorizontalAlignment = 1;
                    pdfPCell50.Border = 0;
                    pdfPTable11.AddCell(pdfPCell50);
                    PdfPCell pdfPCell51 = new PdfPCell(new Phrase(new Chunk("________________", font)));
                    pdfPCell51.BorderWidth = 1f;
                    pdfPCell51.HorizontalAlignment = 1;
                    pdfPCell51.Border = 0;
                    pdfPTable11.AddCell(pdfPCell51);
                    PdfPCell pdfPCell52 = new PdfPCell(new Phrase(new Chunk(" ", font)));
                    pdfPCell52.BorderWidth = 1f;
                    pdfPCell52.Border = 0;
                    pdfPTable11.AddCell(pdfPCell52);
                    PdfPCell pdfPCell53 = new PdfPCell(new Phrase(new Chunk("FIRMA", font)));
                    pdfPCell53.BorderWidth = 1f;
                    pdfPCell53.HorizontalAlignment = 1;
                    pdfPCell53.Border = 0;
                    pdfPTable11.AddCell(pdfPCell53);
                    PdfPCell pdfPCell54 = new PdfPCell(new Phrase(new Chunk("ACLARACIÓN", font)));
                    pdfPCell54.BorderWidth = 1f;
                    pdfPCell54.HorizontalAlignment = 1;
                    pdfPCell54.Border = 0;
                    pdfPTable11.AddCell(pdfPCell54);
                    document.Add(pdfPTable);
                    document.Add(pdfPTable3);
                    document.Add(pdfPTable4);
                    document.Add(pdfPTable6);
                    document.Add(pdfPTable8);
                    document.Add(pdfPTable10);
                    document.Add(pdfPTable11);
                    document.Close();
                    if (opcion == 0)
                    {
                        ResponseP.ContentType = "application/pdf";
                        ResponseP.AddHeader("content-disposition", "attachment;filename=REC " + text.ToString().Replace("Nº", "").Trim() + " - " + text5.ToString().Trim() + ".pdf");
                        ResponseP.Buffer = true;
                        ResponseP.Clear();
                        ResponseP.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
                        ResponseP.OutputStream.Flush();
                        ResponseP.End();
                    }

                    if (opcion == 3)
                    {
                        datosbyte = new byte[memoryStream.GetBuffer().Length];
                        datosbyte = memoryStream.GetBuffer();
                    }

                    return 1;
                }
                catch (NullReferenceException)
                {
                    document.CloseDocument();
                    return 0;
                }
            }
            else
            {
                // Tamaño del papel de recibo: 80mm de ancho, longitud variable
                float receiptWidth = Utilities.MillimetersToPoints(80);
                float receiptHeight = PageSize.A4.Height; // Ajustar según la longitud deseada

                Document document = new Document(new Rectangle(receiptWidth, receiptHeight), 10f, 10f, 10f, 10f);
                MemoryStream memoryStream = new MemoryStream();
                PdfWriter instance = PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                try
                {
                    _ = instance.DirectContent;

                    Font fontMin1 = FontFactory.GetFont("ARIAL", 8f);
                    Font fontMin2 = FontFactory.GetFont("ARIAL", 8f, 1);
                    Font fontMin = FontFactory.GetFont("ARIAL", 8f);
                    Font fontTitle = FontFactory.GetFont("ARIAL", 11f, 1);
                    Font fontTitle2 = FontFactory.GetFont("ARIAL", 9f, 1);
                    string cuit = datos.Tables[0].Rows[index]["cuitempresa"].ToString();
                    string contentNro = datos.Tables[0].Rows[index]["Numero"].ToString();
                    string fecha = datos.Tables[0].Rows[index]["Fecha"].ToString();
                    string nameClient = datos.Tables[0].Rows[index]["Nombre"].ToString();
                    string codigo = datos.Tables[0].Rows[index]["codcliente"].ToString();
                    string domicilio = datos.Tables[0].Rows[index]["Domicilio"].ToString();
                    string moneda = datos.Tables[0].Rows[index]["nom_moneda"].ToString();
                    string observacion = datos.Tables[0].Rows[index]["observaciones"].ToString();
                    string cotizacion = datos.Tables[0].Rows[index]["txt_cotiz"].ToString();
                    document.Add(Chunk.NEWLINE);
                    Paragraph titleRecibo = new Paragraph("Recibo " + contentNro, fontTitle);
                    titleRecibo.SpacingAfter = 2f;
                    document.Add(titleRecibo);
                    Paragraph CUITdata = new Paragraph("CUIT: " + cuit, fontMin);
                    CUITdata.SpacingAfter = 0;
                    document.Add(CUITdata);
                    // Añadir una línea de separación
                    LineSeparator lineSeparator = new LineSeparator(0.5f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 0);
                    //document.Add(new Chunk(lineSeparator));
                    Chunk element1 = new Chunk("Fecha: ", fontMin);
                    Chunk element2 = new Chunk(fecha, fontMin);
                    Phrase phrase1 = new Phrase();
                    phrase1.Add(element1);
                    phrase1.Add(element2);
                    document.Add(new Paragraph(phrase1));
                    document.Add(new Paragraph("Cliente: " + nameClient, fontMin));
                    document.Add(new Paragraph("Código: " + codigo, fontMin));
                    document.Add(new Paragraph("Domicilio: " + domicilio, fontMin));
                    // Añadir una línea de separación
                    //document.Add(new Chunk(lineSeparator));
                    //document.Add(new Paragraph("Moneda: " + moneda, fontMin));
                    //document.Add(new Paragraph("Cotización: " + cotizacion, fontMin));
                    document.Add(new Chunk(lineSeparator));

                    // Crea una tabla con tres columnas
                    Paragraph titleCompCobros = new Paragraph("Comprobantes a Cobrar ", fontTitle2);
                    titleCompCobros.SpacingAfter = 5f;
                    document.Add(titleCompCobros);
                    PdfPTable table_Detalles = new PdfPTable(2);
                    table_Detalles.TotalWidth = 205f; // Ajusta el ancho total de la tabla
                    table_Detalles.LockedWidth = true;
                    float[] widths = new float[] { 180f, 150f };
                    table_Detalles.SetWidths(widths);
                    // Crea las celdas
                    PdfPCell cellF_1 = new PdfPCell(new Phrase("Concepto", fontMin2));
                    cellF_1.Border = Rectangle.NO_BORDER;
                    cellF_1.HorizontalAlignment = Element.ALIGN_LEFT;
                    table_Detalles.AddCell(cellF_1);
                    PdfPCell cellF_2 = new PdfPCell(new Phrase("Importe", fontMin2));
                    cellF_2.Border = Rectangle.NO_BORDER;
                    cellF_2.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table_Detalles.AddCell(cellF_2);
                    decimal numero = 0m;
                    if (datos.Tables[2].Rows.Count > 0)
                    {
                        for (int i = 0; i < datos.Tables[2].Rows.Count; i++)
                        {
                            PdfPCell cellF_3 = new PdfPCell(new Phrase(new Chunk(datos.Tables[2].Rows[i]["txtDescripCom"].ToString(), fontMin1)));
                            cellF_3.Border = Rectangle.NO_BORDER;
                            cellF_3.HorizontalAlignment = Element.ALIGN_LEFT;
                            table_Detalles.AddCell(cellF_3);

                            PdfPCell cellF_4 = new PdfPCell(new Phrase(new Chunk(Formato_numero(decimal.Round(decimal.Parse(datos.Tables[2].Rows[i]["ImporteRel"].ToString()), 2)), fontMin1)));
                            cellF_4.Border = Rectangle.NO_BORDER;
                            cellF_4.HorizontalAlignment = Element.ALIGN_RIGHT;
                            table_Detalles.AddCell(cellF_4);

                            numero += decimal.Round(decimal.Parse(datos.Tables[2].Rows[i]["ImporteRel"].ToString()), 2);
                        }
                    }

                    if (datos.Tables[1].Rows.Count > 0)
                    {
                        PdfPCell cellF_5 = new PdfPCell(new Phrase(new Chunk("Cobro Adelantado", fontMin1)));
                        cellF_5.Border = Rectangle.NO_BORDER;
                        cellF_5.HorizontalAlignment = Element.ALIGN_LEFT;
                        table_Detalles.AddCell(cellF_5);

                        PdfPCell cellF_6 = new PdfPCell(new Phrase(new Chunk(Formato_numero(decimal.Round(decimal.Parse(datos.Tables[1].Rows[0]["ImpPagAdel"].ToString()), 2)), fontMin1)));
                        cellF_6.Border = Rectangle.NO_BORDER;
                        cellF_6.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table_Detalles.AddCell(cellF_6);
                        numero += decimal.Round(decimal.Parse(datos.Tables[1].Rows[0]["ImpPagAdel"].ToString()), 2);
                    }

                    PdfPCell cellF_7 = new PdfPCell(new Phrase(new Chunk("Total", fontMin2)));
                    cellF_7.Border = Rectangle.NO_BORDER;
                    cellF_7.HorizontalAlignment = Element.ALIGN_LEFT;
                    table_Detalles.AddCell(cellF_7);

                    PdfPCell cellF_8 = new PdfPCell(new Phrase(new Chunk(Formato_numero(numero), fontMin2)));
                    cellF_8.Border = Rectangle.NO_BORDER;
                    cellF_8.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table_Detalles.AddCell(cellF_8);
                    // Agregar Tabla Detalles
                    document.Add(table_Detalles);
                    // Añadir una línea de separación
                    document.Add(new Chunk(lineSeparator));

                    Paragraph titleCobros = new Paragraph("Cobros ", fontTitle2);
                    titleCobros.SpacingAfter = 5f;
                    document.Add(titleCobros);
                    PdfPTable table_Cobros = new PdfPTable(3);
                    table_Cobros.TotalWidth = 200f; // Ajusta el ancho total de la tabla
                    table_Cobros.LockedWidth = true;
                    float[] widths2 = new float[] { 100f, 100f, 100f };
                    table_Cobros.SetWidths(widths2);
                    PdfPCell cellC_1 = new PdfPCell(new Phrase("Descripcion", fontMin2));
                    cellC_1.Border = Rectangle.NO_BORDER;
                    cellC_1.HorizontalAlignment = Element.ALIGN_LEFT;
                    table_Cobros.AddCell(cellC_1);
                    PdfPCell cellC_2 = new PdfPCell(new Phrase("Fecha", fontMin2));
                    cellC_2.Border = Rectangle.NO_BORDER;
                    cellC_2.HorizontalAlignment = Element.ALIGN_LEFT;
                    table_Cobros.AddCell(cellC_2);
                    PdfPCell cellC_3 = new PdfPCell(new Phrase("Importe", fontMin2));
                    cellC_3.Border = Rectangle.NO_BORDER;
                    cellC_3.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table_Cobros.AddCell(cellC_3);

                    //Ingreso de datos
                    decimal TotalCobros = 0m;
                    if (datos.Tables[3].Rows.Count > 0)
                    {
                        for (int j = 0; j < datos.Tables[3].Rows.Count; j++)
                        {
                            PdfPCell cellC_4 = new PdfPCell(new Phrase(new Chunk(datos.Tables[3].Rows[j]["ddlDescripcionC"].ToString(), fontMin1)));
                            cellC_4.Border = Rectangle.NO_BORDER;
                            cellC_4.HorizontalAlignment = Element.ALIGN_LEFT;
                            table_Cobros.AddCell(cellC_4);

                            if (datos.Tables[3].Rows[j]["TipoCta"].ToString() == "CR" || datos.Tables[3].Rows[j]["TipoCta"].ToString() == "BA" || datos.Tables[3].Rows[j]["TipoCta"].ToString() == "CH")
                            {
                                PdfPCell cellC_5 = new PdfPCell(new Phrase(new Chunk(datos.Tables[3].Rows[j]["BcoVen"].ToString(), fontMin1)));
                                cellC_5.Border = Rectangle.NO_BORDER;
                                cellC_5.HorizontalAlignment = Element.ALIGN_LEFT;
                                table_Cobros.AddCell(cellC_5);
                            }
                            else
                            {
                                PdfPCell cellC_6 = new PdfPCell(new Phrase(new Chunk(" ", fontMin1)));
                                cellC_6.Border = Rectangle.NO_BORDER;
                                cellC_6.HorizontalAlignment = Element.ALIGN_LEFT;
                                table_Cobros.AddCell(cellC_6);
                            }

                            PdfPCell cellC_7 = new PdfPCell(new Phrase(new Chunk(Formato_numero(decimal.Round(decimal.Parse(datos.Tables[3].Rows[j]["ImporteCta"].ToString()), 2)), fontMin1)));
                            cellC_7.Border = Rectangle.NO_BORDER;
                            cellC_7.HorizontalAlignment = Element.ALIGN_RIGHT;
                            table_Cobros.AddCell(cellC_7);
                            TotalCobros += decimal.Round(decimal.Parse(datos.Tables[3].Rows[j]["ImporteCta"].ToString()), 2);

                        }
                    }

                    PdfPCell cellC_8 = new PdfPCell(new Phrase(new Chunk("Total", fontMin2)));
                    cellC_8.Border = Rectangle.NO_BORDER;
                    cellC_8.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellC_8.Colspan = 2;
                    table_Cobros.AddCell(cellC_8);
                    PdfPCell cellC_9 = new PdfPCell(new Phrase(new Chunk(Formato_numero(TotalCobros), fontMin2)));
                    cellC_9.Border = Rectangle.NO_BORDER;
                    cellC_9.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table_Cobros.AddCell(cellC_9);

                    // Agregar Tabla Cobros
                    document.Add(table_Cobros);

                    document.Add(Chunk.NEWLINE);
                    document.Add(new Paragraph("Observaciones: ", fontMin2));
                    document.Add(new Paragraph(observacion, fontMin1));

                    document.Close();

                    if (opcion == 0)
                    {
                        ResponseP.ContentType = "application/pdf";
                        ResponseP.AddHeader("content-disposition", "attachment;filename=REC " + contentNro.ToString().Replace("Nº", "").Trim() + " - " + nameClient.ToString().Trim() + ".pdf");
                        ResponseP.Buffer = true;
                        ResponseP.Clear();
                        ResponseP.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
                        ResponseP.OutputStream.Flush();
                        ResponseP.End();
                    }

                    if (opcion == 3)
                    {
                        datosbyte = new byte[memoryStream.GetBuffer().Length];
                        datosbyte = memoryStream.GetBuffer();
                    }

                    return 1; ;
                }
                catch (NullReferenceException)
                {
                    document.CloseDocument();
                    return 0;
                }
            }
        }
    }
}
