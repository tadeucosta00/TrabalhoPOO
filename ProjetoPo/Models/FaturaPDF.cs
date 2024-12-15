using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace ProjetoPo.Models
{
    public class FaturaPDF
    {
        public void GerarFatura(string caminhoArquivo, string clienteNome, string clienteEmail, List<ItemFatura> itens, double imposto, double total, string clienteDocumentoId)
        {
            using (var writer = new PdfWriter(caminhoArquivo))
            using (var pdf = new PdfDocument(writer))
            using (var documento = new iText.Layout.Document(pdf))
            {
                iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(@"C:\Users\tadeu\Documents\GitHub\TrabalhoPOO\logo.png"));
                logo.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);
                logo.ScaleToFit(100, 100);
                documento.Add(logo);

                documento.Add(new Paragraph("Fatura").SetFontSize(20).SetTextAlignment(TextAlignment.CENTER));
                documento.Add(new Paragraph($"Data: {DateTime.Now:d}"));

                documento.Add(new Paragraph($"Cliente: {clienteNome}"));
                documento.Add(new Paragraph($"Documento Identificação: {clienteDocumentoId}"));
                documento.Add(new Paragraph($"Email: {clienteEmail}"));


                documento.Add(new Paragraph("\n"));

                Table tabela = new Table(4);
                tabela.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                tabela.AddHeaderCell("Descrição");
                tabela.AddHeaderCell("Hospedes");
                tabela.AddHeaderCell("Preço sem IVA");
                tabela.AddHeaderCell("Total");

                foreach (var item in itens)
                {
                    tabela.AddCell(item.Descricao);
                    tabela.AddCell(item.Quantidade.ToString());
                    tabela.AddCell($"€{item.PrecoUnitario:F2}");
                    tabela.AddCell($"€{total:F2}");
                }

                documento.Add(tabela);
                documento.Add(new Paragraph("\n"));

                documento.Add(new Paragraph($"Imposto: €{imposto:F2}"));
                documento.Add(new Paragraph($"Total: €{total:F2}"));
            }
        }
    }

    public class ItemFatura
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public double Total { get; set; }
    }
}
