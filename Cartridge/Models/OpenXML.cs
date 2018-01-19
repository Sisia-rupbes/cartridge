using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using M = DocumentFormat.OpenXml.Math;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using V = DocumentFormat.OpenXml.Vml;
using W14 = DocumentFormat.OpenXml.Office2010.Word;
using A = DocumentFormat.OpenXml.Drawing;
using System.IO;

namespace Cartridge.Models
{
    public class OpenXML
    {
        b1cakEntities db = new b1cakEntities();
        // Creates a WordprocessingDocument.
        public void CreatePackage(string filePath, int departmentID, int deviceID, int cartridgeID)
        {
            using (WordprocessingDocument package = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                CreateParts(package, departmentID, deviceID, cartridgeID);
            }
        }
        public byte[] CreatePackageAsBytes(int departmentID, int deviceID, int cartridgeID)
        {
            
            using (var mstm = new MemoryStream())
            {
                using (WordprocessingDocument package = WordprocessingDocument.Create(mstm, WordprocessingDocumentType.Document))
                {
                    CreateParts(package,departmentID,deviceID,cartridgeID);
                }
                mstm.Flush();
                mstm.Close();
                return mstm.ToArray();
            }
        }

        // Adds child parts and generates content of the specified part.
        private void CreateParts(WordprocessingDocument document, int departmentID, int deviceID, int cartridgeID)
        {
            ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId3");
            GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

            MainDocumentPart mainDocumentPart1 = document.AddMainDocumentPart();
            GenerateMainDocumentPart1Content(mainDocumentPart1,deviceID, cartridgeID, departmentID);

            WebSettingsPart webSettingsPart1 = mainDocumentPart1.AddNewPart<WebSettingsPart>("rId3");
            GenerateWebSettingsPart1Content(webSettingsPart1);

            DocumentSettingsPart documentSettingsPart1 = mainDocumentPart1.AddNewPart<DocumentSettingsPart>("rId2");
            GenerateDocumentSettingsPart1Content(documentSettingsPart1);

            StyleDefinitionsPart styleDefinitionsPart1 = mainDocumentPart1.AddNewPart<StyleDefinitionsPart>("rId1");
            GenerateStyleDefinitionsPart1Content(styleDefinitionsPart1);

            ThemePart themePart1 = mainDocumentPart1.AddNewPart<ThemePart>("rId5");
            GenerateThemePart1Content(themePart1);

            FontTablePart fontTablePart1 = mainDocumentPart1.AddNewPart<FontTablePart>("rId4");
            GenerateFontTablePart1Content(fontTablePart1);

            SetPackageProperties(document);
        }

        // Generates content of extendedFilePropertiesPart1.
        private void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
        {
            Ap.Properties properties1 = new Ap.Properties();
            properties1.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            Ap.Template template1 = new Ap.Template();
            template1.Text = "Normal.dotm";
            Ap.TotalTime totalTime1 = new Ap.TotalTime();
            totalTime1.Text = "18";
            Ap.Pages pages1 = new Ap.Pages();
            pages1.Text = "1";
            Ap.Words words1 = new Ap.Words();
            words1.Text = "74";
            Ap.Characters characters1 = new Ap.Characters();
            characters1.Text = "423";
            Ap.Application application1 = new Ap.Application();
            application1.Text = "Microsoft Office Word";
            Ap.DocumentSecurity documentSecurity1 = new Ap.DocumentSecurity();
            documentSecurity1.Text = "0";
            Ap.Lines lines1 = new Ap.Lines();
            lines1.Text = "3";
            Ap.Paragraphs paragraphs1 = new Ap.Paragraphs();
            paragraphs1.Text = "1";
            Ap.ScaleCrop scaleCrop1 = new Ap.ScaleCrop();
            scaleCrop1.Text = "false";

            Ap.HeadingPairs headingPairs1 = new Ap.HeadingPairs();

            Vt.VTVector vTVector1 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Variant, Size = (UInt32Value)2U };

            Vt.Variant variant1 = new Vt.Variant();
            Vt.VTLPSTR vTLPSTR1 = new Vt.VTLPSTR();
            vTLPSTR1.Text = "Название";

            variant1.Append(vTLPSTR1);

            Vt.Variant variant2 = new Vt.Variant();
            Vt.VTInt32 vTInt321 = new Vt.VTInt32();
            vTInt321.Text = "1";

            variant2.Append(vTInt321);

            vTVector1.Append(variant1);
            vTVector1.Append(variant2);

            headingPairs1.Append(vTVector1);

            Ap.TitlesOfParts titlesOfParts1 = new Ap.TitlesOfParts();

            Vt.VTVector vTVector2 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Lpstr, Size = (UInt32Value)1U };
            Vt.VTLPSTR vTLPSTR2 = new Vt.VTLPSTR();
            vTLPSTR2.Text = "";

            vTVector2.Append(vTLPSTR2);

            titlesOfParts1.Append(vTVector2);
            Ap.Company company1 = new Ap.Company();
            company1.Text = "";
            Ap.LinksUpToDate linksUpToDate1 = new Ap.LinksUpToDate();
            linksUpToDate1.Text = "false";
            Ap.CharactersWithSpaces charactersWithSpaces1 = new Ap.CharactersWithSpaces();
            charactersWithSpaces1.Text = "496";
            Ap.SharedDocument sharedDocument1 = new Ap.SharedDocument();
            sharedDocument1.Text = "false";
            Ap.HyperlinksChanged hyperlinksChanged1 = new Ap.HyperlinksChanged();
            hyperlinksChanged1.Text = "false";
            Ap.ApplicationVersion applicationVersion1 = new Ap.ApplicationVersion();
            applicationVersion1.Text = "16.0000";

            properties1.Append(template1);
            properties1.Append(totalTime1);
            properties1.Append(pages1);
            properties1.Append(words1);
            properties1.Append(characters1);
            properties1.Append(application1);
            properties1.Append(documentSecurity1);
            properties1.Append(lines1);
            properties1.Append(paragraphs1);
            properties1.Append(scaleCrop1);
            properties1.Append(headingPairs1);
            properties1.Append(titlesOfParts1);
            properties1.Append(company1);
            properties1.Append(linksUpToDate1);
            properties1.Append(charactersWithSpaces1);
            properties1.Append(sharedDocument1);
            properties1.Append(hyperlinksChanged1);
            properties1.Append(applicationVersion1);

            extendedFilePropertiesPart1.Properties = properties1;
        }

        // Generates content of mainDocumentPart1.
        private void GenerateMainDocumentPart1Content(MainDocumentPart mainDocumentPart1, int deviceID, int cartridgeID, int departmentID)
        {
            p000047 device = db.p000047.Find(deviceID);
            p000052 cartridge = db.p000052.Find(cartridgeID);
            p000044 department = db.p000044.Find(departmentID);

            Document document1 = new Document() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se wp14" } };
            document1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            document1.AddNamespaceDeclaration("cx", "http://schemas.microsoft.com/office/drawing/2014/chartex");
            document1.AddNamespaceDeclaration("cx1", "http://schemas.microsoft.com/office/drawing/2015/9/8/chartex");
            document1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            document1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            document1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            document1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            document1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            document1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            document1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            document1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            document1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            document1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
            document1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            document1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            document1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            document1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            Body body1 = new Body();

            Table table1 = new Table();

            TableProperties tableProperties1 = new TableProperties();
            TableStyle tableStyle1 = new TableStyle() { Val = "a3" };
            TableWidth tableWidth1 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };

            TableBorders tableBorders1 = new TableBorders();
            InsideHorizontalBorder insideHorizontalBorder1 = new InsideHorizontalBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder1 = new InsideVerticalBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };

            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);
            TableLook tableLook1 = new TableLook() { Val = "04A0", FirstRow = true, LastRow = false, FirstColumn = true, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = true };

            tableProperties1.Append(tableStyle1);
            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableBorders1);
            tableProperties1.Append(tableLook1);

            TableGrid tableGrid1 = new TableGrid();
            GridColumn gridColumn1 = new GridColumn() { Width = "279" };
            GridColumn gridColumn2 = new GridColumn() { Width = "2551" };
            GridColumn gridColumn3 = new GridColumn() { Width = "285" };
            GridColumn gridColumn4 = new GridColumn() { Width = "282" };
            GridColumn gridColumn5 = new GridColumn() { Width = "2552" };
            GridColumn gridColumn6 = new GridColumn() { Width = "281" };
            GridColumn gridColumn7 = new GridColumn() { Width = "286" };
            GridColumn gridColumn8 = new GridColumn() { Width = "2551" };
            GridColumn gridColumn9 = new GridColumn() { Width = "567" };

            tableGrid1.Append(gridColumn1);
            tableGrid1.Append(gridColumn2);
            tableGrid1.Append(gridColumn3);
            tableGrid1.Append(gridColumn4);
            tableGrid1.Append(gridColumn5);
            tableGrid1.Append(gridColumn6);
            tableGrid1.Append(gridColumn7);
            tableGrid1.Append(gridColumn8);
            tableGrid1.Append(gridColumn9);

            TableRow tableRow1 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00195F14", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell1 = new TableCell();

            TableCellProperties tableCellProperties1 = new TableCellProperties();
            TableCellWidth tableCellWidth1 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan1 = new GridSpan() { Val = 3 };

            tableCellProperties1.Append(tableCellWidth1);
            tableCellProperties1.Append(gridSpan1);

            Paragraph paragraph1 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00195F14" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            Justification justification1 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold1 = new Bold();
            FontSize fontSize1 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(bold1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties1.Append(justification1);
            paragraphProperties1.Append(paragraphMarkRunProperties1);

            paragraph1.Append(paragraphProperties1);

            tableCell1.Append(tableCellProperties1);
            tableCell1.Append(paragraph1);

            TableCell tableCell2 = new TableCell();

            TableCellProperties tableCellProperties2 = new TableCellProperties();
            TableCellWidth tableCellWidth2 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan2 = new GridSpan() { Val = 3 };

            tableCellProperties2.Append(tableCellWidth2);
            tableCellProperties2.Append(gridSpan2);

            Paragraph paragraph2 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            Justification justification2 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold2 = new Bold();
            FontSize fontSize2 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties2.Append(runFonts2);
            paragraphMarkRunProperties2.Append(bold2);
            paragraphMarkRunProperties2.Append(fontSize2);
            paragraphMarkRunProperties2.Append(fontSizeComplexScript2);

            paragraphProperties2.Append(justification2);
            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run1 = new Run() { RsidRunProperties = "00396EB4" };

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts3 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold3 = new Bold();
            FontSize fontSize3 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "28" };

            runProperties1.Append(runFonts3);
            runProperties1.Append(bold3);
            runProperties1.Append(fontSize3);
            runProperties1.Append(fontSizeComplexScript3);
            Text text1 = new Text();
            text1.Text = "ЗАЯВКА";

            run1.Append(runProperties1);
            run1.Append(text1);

            paragraph2.Append(paragraphProperties2);
            paragraph2.Append(run1);

            tableCell2.Append(tableCellProperties2);
            tableCell2.Append(paragraph2);

            TableCell tableCell3 = new TableCell();

            TableCellProperties tableCellProperties3 = new TableCellProperties();
            TableCellWidth tableCellWidth3 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan3 = new GridSpan() { Val = 3 };

            tableCellProperties3.Append(tableCellWidth3);
            tableCellProperties3.Append(gridSpan3);

            Paragraph paragraph3 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidRunAdditionDefault = "00195F14" };

            ParagraphProperties paragraphProperties3 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties3 = new ParagraphMarkRunProperties();
            RunFonts runFonts4 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize4 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript4 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties3.Append(runFonts4);
            paragraphMarkRunProperties3.Append(fontSize4);
            paragraphMarkRunProperties3.Append(fontSizeComplexScript4);

            paragraphProperties3.Append(paragraphMarkRunProperties3);

            paragraph3.Append(paragraphProperties3);

            tableCell3.Append(tableCellProperties3);
            tableCell3.Append(paragraph3);

            tableRow1.Append(tableCell1);
            tableRow1.Append(tableCell2);
            tableRow1.Append(tableCell3);

            TableRow tableRow2 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00195F14", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell4 = new TableCell();

            TableCellProperties tableCellProperties4 = new TableCellProperties();
            TableCellWidth tableCellWidth4 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan4 = new GridSpan() { Val = 3 };

            tableCellProperties4.Append(tableCellWidth4);
            tableCellProperties4.Append(gridSpan4);

            Paragraph paragraph4 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidRunAdditionDefault = "00195F14" };

            ParagraphProperties paragraphProperties4 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties4 = new ParagraphMarkRunProperties();
            RunFonts runFonts5 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize5 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript5 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties4.Append(runFonts5);
            paragraphMarkRunProperties4.Append(fontSize5);
            paragraphMarkRunProperties4.Append(fontSizeComplexScript5);

            paragraphProperties4.Append(paragraphMarkRunProperties4);

            paragraph4.Append(paragraphProperties4);

            tableCell4.Append(tableCellProperties4);
            tableCell4.Append(paragraph4);

            TableCell tableCell5 = new TableCell();

            TableCellProperties tableCellProperties5 = new TableCellProperties();
            TableCellWidth tableCellWidth5 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan5 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders1 = new TableCellBorders();
            BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.Nil };

            tableCellBorders1.Append(bottomBorder1);

            tableCellProperties5.Append(tableCellWidth5);
            tableCellProperties5.Append(gridSpan5);
            tableCellProperties5.Append(tableCellBorders1);

            Paragraph paragraph5 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidRunAdditionDefault = "00195F14" };

            ParagraphProperties paragraphProperties5 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties5 = new ParagraphMarkRunProperties();
            RunFonts runFonts6 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize6 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript6 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties5.Append(runFonts6);
            paragraphMarkRunProperties5.Append(fontSize6);
            paragraphMarkRunProperties5.Append(fontSizeComplexScript6);

            paragraphProperties5.Append(paragraphMarkRunProperties5);

            paragraph5.Append(paragraphProperties5);

            tableCell5.Append(tableCellProperties5);
            tableCell5.Append(paragraph5);

            TableCell tableCell6 = new TableCell();

            TableCellProperties tableCellProperties6 = new TableCellProperties();
            TableCellWidth tableCellWidth6 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan6 = new GridSpan() { Val = 3 };

            tableCellProperties6.Append(tableCellWidth6);
            tableCellProperties6.Append(gridSpan6);

            Paragraph paragraph6 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidRunAdditionDefault = "00195F14" };

            ParagraphProperties paragraphProperties6 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties6 = new ParagraphMarkRunProperties();
            RunFonts runFonts7 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize7 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript7 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties6.Append(runFonts7);
            paragraphMarkRunProperties6.Append(fontSize7);
            paragraphMarkRunProperties6.Append(fontSizeComplexScript7);

            paragraphProperties6.Append(paragraphMarkRunProperties6);

            paragraph6.Append(paragraphProperties6);

            tableCell6.Append(tableCellProperties6);
            tableCell6.Append(paragraph6);

            tableRow2.Append(tableCell4);
            tableRow2.Append(tableCell5);
            tableRow2.Append(tableCell6);

            TableRow tableRow3 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00195F14", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell7 = new TableCell();

            TableCellProperties tableCellProperties7 = new TableCellProperties();
            TableCellWidth tableCellWidth7 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan7 = new GridSpan() { Val = 3 };

            tableCellProperties7.Append(tableCellWidth7);
            tableCellProperties7.Append(gridSpan7);

            Paragraph paragraph7 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties7 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties7 = new ParagraphMarkRunProperties();
            RunFonts runFonts8 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize8 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript8 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties7.Append(runFonts8);
            paragraphMarkRunProperties7.Append(fontSize8);
            paragraphMarkRunProperties7.Append(fontSizeComplexScript8);

            paragraphProperties7.Append(paragraphMarkRunProperties7);

            Run run2 = new Run();

            RunProperties runProperties2 = new RunProperties();
            RunFonts runFonts9 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize9 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript9 = new FontSizeComplexScript() { Val = "28" };

            runProperties2.Append(runFonts9);
            runProperties2.Append(fontSize9);
            runProperties2.Append(fontSizeComplexScript9);
            Text text2 = new Text();
            text2.Text = "На замену картриджа";

            run2.Append(runProperties2);
            run2.Append(text2);

            paragraph7.Append(paragraphProperties7);
            paragraph7.Append(run2);

            tableCell7.Append(tableCellProperties7);
            tableCell7.Append(paragraph7);

            TableCell tableCell8 = new TableCell();

            TableCellProperties tableCellProperties8 = new TableCellProperties();
            TableCellWidth tableCellWidth8 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan8 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders2 = new TableCellBorders();
            TopBorder topBorder1 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder2 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders2.Append(topBorder1);
            tableCellBorders2.Append(bottomBorder2);

            tableCellProperties8.Append(tableCellWidth8);
            tableCellProperties8.Append(gridSpan8);
            tableCellProperties8.Append(tableCellBorders2);

            Paragraph paragraph8 = new Paragraph() { RsidParagraphMarkRevision = "00B67540", RsidParagraphAddition = "00195F14", RsidParagraphProperties = "00484F2D", RsidRunAdditionDefault = "00320B06" };

            ParagraphProperties paragraphProperties8 = new ParagraphProperties();
            Justification justification3 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties8 = new ParagraphMarkRunProperties();
            RunFonts runFonts10 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize10 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript10 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties8.Append(runFonts10);
            paragraphMarkRunProperties8.Append(fontSize10);
            paragraphMarkRunProperties8.Append(fontSizeComplexScript10);

            paragraphProperties8.Append(justification3);
            paragraphProperties8.Append(paragraphMarkRunProperties8);

            Run run3 = new Run();

            RunProperties runProperties3 = new RunProperties();
            RunFonts runFonts11 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            NoProof noProof1 = new NoProof();
            FontSize fontSize11 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript11 = new FontSizeComplexScript() { Val = "28" };

            runProperties3.Append(runFonts11);
            runProperties3.Append(noProof1);
            runProperties3.Append(fontSize11);
            runProperties3.Append(fontSizeComplexScript11);
            Text text3 = new Text();
            text3.Text = cartridge.p000049.cartridge_brand.ToString() + " " + cartridge.p000049.cartridge_model.ToString();

            run3.Append(runProperties3);
            run3.Append(text3);

            paragraph8.Append(paragraphProperties8);
            paragraph8.Append(run3);

            tableCell8.Append(tableCellProperties8);
            tableCell8.Append(paragraph8);

            TableCell tableCell9 = new TableCell();

            TableCellProperties tableCellProperties9 = new TableCellProperties();
            TableCellWidth tableCellWidth9 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan9 = new GridSpan() { Val = 3 };

            tableCellProperties9.Append(tableCellWidth9);
            tableCellProperties9.Append(gridSpan9);

            Paragraph paragraph9 = new Paragraph() { RsidParagraphMarkRevision = "004F4AA4", RsidParagraphAddition = "00195F14", RsidParagraphProperties = "00320B06", RsidRunAdditionDefault = "004F4AA4" };

            ParagraphProperties paragraphProperties9 = new ParagraphProperties();
            Justification justification4 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties9 = new ParagraphMarkRunProperties();
            RunFonts runFonts12 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize12 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript12 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties9.Append(runFonts12);
            paragraphMarkRunProperties9.Append(fontSize12);
            paragraphMarkRunProperties9.Append(fontSizeComplexScript12);

            paragraphProperties9.Append(justification4);
            paragraphProperties9.Append(paragraphMarkRunProperties9);

            Run run4 = new Run();

            RunProperties runProperties4 = new RunProperties();
            RunFonts runFonts13 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize13 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript13 = new FontSizeComplexScript() { Val = "28" };

            runProperties4.Append(runFonts13);
            runProperties4.Append(fontSize13);
            runProperties4.Append(fontSizeComplexScript13);
            Text text4 = new Text();
            text4.Text = "№";

            run4.Append(runProperties4);
            run4.Append(text4);

            Run run5 = new Run() { RsidRunAddition = "00320B06" };

            RunProperties runProperties5 = new RunProperties();
            RunFonts runFonts14 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            NoProof noProof2 = new NoProof();
            FontSize fontSize14 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript14 = new FontSizeComplexScript() { Val = "28" };
            Languages languages1 = new Languages() { Val = "en-US" };

            runProperties5.Append(runFonts14);
            runProperties5.Append(noProof2);
            runProperties5.Append(fontSize14);
            runProperties5.Append(fontSizeComplexScript14);
            runProperties5.Append(languages1);
            Text text5 = new Text();
            text5.Text = cartridge.kod.ToString();

            run5.Append(runProperties5);
            run5.Append(text5);

            paragraph9.Append(paragraphProperties9);
            paragraph9.Append(run4);
            paragraph9.Append(run5);

            tableCell9.Append(tableCellProperties9);
            tableCell9.Append(paragraph9);

            tableRow3.Append(tableCell7);
            tableRow3.Append(tableCell8);
            tableRow3.Append(tableCell9);

            TableRow tableRow4 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00195F14", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell10 = new TableCell();

            TableCellProperties tableCellProperties10 = new TableCellProperties();
            TableCellWidth tableCellWidth10 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan10 = new GridSpan() { Val = 3 };

            tableCellProperties10.Append(tableCellWidth10);
            tableCellProperties10.Append(gridSpan10);

            Paragraph paragraph10 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidRunAdditionDefault = "00195F14" };

            ParagraphProperties paragraphProperties10 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties10 = new ParagraphMarkRunProperties();
            RunFonts runFonts15 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize15 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript15 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties10.Append(runFonts15);
            paragraphMarkRunProperties10.Append(fontSize15);
            paragraphMarkRunProperties10.Append(fontSizeComplexScript15);

            paragraphProperties10.Append(paragraphMarkRunProperties10);

            paragraph10.Append(paragraphProperties10);

            tableCell10.Append(tableCellProperties10);
            tableCell10.Append(paragraph10);

            TableCell tableCell11 = new TableCell();

            TableCellProperties tableCellProperties11 = new TableCellProperties();
            TableCellWidth tableCellWidth11 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan11 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders3 = new TableCellBorders();
            TopBorder topBorder2 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder3 = new BottomBorder() { Val = BorderValues.Nil };

            tableCellBorders3.Append(topBorder2);
            tableCellBorders3.Append(bottomBorder3);

            tableCellProperties11.Append(tableCellWidth11);
            tableCellProperties11.Append(gridSpan11);
            tableCellProperties11.Append(tableCellBorders3);

            Paragraph paragraph11 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidParagraphProperties = "00FB6E38", RsidRunAdditionDefault = "00195F14" };

            ParagraphProperties paragraphProperties11 = new ParagraphProperties();
            Justification justification5 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties11 = new ParagraphMarkRunProperties();
            RunFonts runFonts16 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize16 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript16 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties11.Append(runFonts16);
            paragraphMarkRunProperties11.Append(fontSize16);
            paragraphMarkRunProperties11.Append(fontSizeComplexScript16);

            paragraphProperties11.Append(justification5);
            paragraphProperties11.Append(paragraphMarkRunProperties11);

            paragraph11.Append(paragraphProperties11);

            tableCell11.Append(tableCellProperties11);
            tableCell11.Append(paragraph11);

            TableCell tableCell12 = new TableCell();

            TableCellProperties tableCellProperties12 = new TableCellProperties();
            TableCellWidth tableCellWidth12 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan12 = new GridSpan() { Val = 3 };

            tableCellProperties12.Append(tableCellWidth12);
            tableCellProperties12.Append(gridSpan12);

            Paragraph paragraph12 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidRunAdditionDefault = "00195F14" };

            ParagraphProperties paragraphProperties12 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties12 = new ParagraphMarkRunProperties();
            RunFonts runFonts17 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize17 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript17 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties12.Append(runFonts17);
            paragraphMarkRunProperties12.Append(fontSize17);
            paragraphMarkRunProperties12.Append(fontSizeComplexScript17);

            paragraphProperties12.Append(paragraphMarkRunProperties12);

            paragraph12.Append(paragraphProperties12);

            tableCell12.Append(tableCellProperties12);
            tableCell12.Append(paragraph12);

            tableRow4.Append(tableCell10);
            tableRow4.Append(tableCell11);
            tableRow4.Append(tableCell12);

            TableRow tableRow5 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00195F14", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell13 = new TableCell();

            TableCellProperties tableCellProperties13 = new TableCellProperties();
            TableCellWidth tableCellWidth13 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan13 = new GridSpan() { Val = 3 };

            tableCellProperties13.Append(tableCellWidth13);
            tableCellProperties13.Append(gridSpan13);

            Paragraph paragraph13 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties13 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties13 = new ParagraphMarkRunProperties();
            RunFonts runFonts18 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize18 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript18 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties13.Append(runFonts18);
            paragraphMarkRunProperties13.Append(fontSize18);
            paragraphMarkRunProperties13.Append(fontSizeComplexScript18);

            paragraphProperties13.Append(paragraphMarkRunProperties13);

            Run run6 = new Run();

            RunProperties runProperties6 = new RunProperties();
            RunFonts runFonts19 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize19 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript19 = new FontSizeComplexScript() { Val = "28" };

            runProperties6.Append(runFonts19);
            runProperties6.Append(fontSize19);
            runProperties6.Append(fontSizeComplexScript19);
            Text text6 = new Text();
            text6.Text = "Принтера(МФУ)";

            run6.Append(runProperties6);
            run6.Append(text6);

            paragraph13.Append(paragraphProperties13);
            paragraph13.Append(run6);

            tableCell13.Append(tableCellProperties13);
            tableCell13.Append(paragraph13);

            TableCell tableCell14 = new TableCell();

            TableCellProperties tableCellProperties14 = new TableCellProperties();
            TableCellWidth tableCellWidth14 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan14 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders4 = new TableCellBorders();
            TopBorder topBorder3 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder4 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders4.Append(topBorder3);
            tableCellBorders4.Append(bottomBorder4);

            tableCellProperties14.Append(tableCellWidth14);
            tableCellProperties14.Append(gridSpan14);
            tableCellProperties14.Append(tableCellBorders4);

            Paragraph paragraph14 = new Paragraph() { RsidParagraphMarkRevision = "00B67540", RsidParagraphAddition = "00195F14", RsidParagraphProperties = "00FB6E38", RsidRunAdditionDefault = "00320B06" };

            ParagraphProperties paragraphProperties14 = new ParagraphProperties();
            Justification justification6 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties14 = new ParagraphMarkRunProperties();
            RunFonts runFonts20 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize20 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript20 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties14.Append(runFonts20);
            paragraphMarkRunProperties14.Append(fontSize20);
            paragraphMarkRunProperties14.Append(fontSizeComplexScript20);

            paragraphProperties14.Append(justification6);
            paragraphProperties14.Append(paragraphMarkRunProperties14);

            Run run7 = new Run();

            RunProperties runProperties7 = new RunProperties();
            RunFonts runFonts21 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            NoProof noProof3 = new NoProof();
            FontSize fontSize21 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript21 = new FontSizeComplexScript() { Val = "28" };

            runProperties7.Append(runFonts21);
            runProperties7.Append(noProof3);
            runProperties7.Append(fontSize21);
            runProperties7.Append(fontSizeComplexScript21);
            Text text7 = new Text();
            text7.Text = device.p000045.device_brand.ToString() + " " + device.p000045.device_model.ToString();

            run7.Append(runProperties7);
            run7.Append(text7);

            paragraph14.Append(paragraphProperties14);
            paragraph14.Append(run7);

            tableCell14.Append(tableCellProperties14);
            tableCell14.Append(paragraph14);

            TableCell tableCell15 = new TableCell();

            TableCellProperties tableCellProperties15 = new TableCellProperties();
            TableCellWidth tableCellWidth15 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan15 = new GridSpan() { Val = 3 };

            tableCellProperties15.Append(tableCellWidth15);
            tableCellProperties15.Append(gridSpan15);

            Paragraph paragraph15 = new Paragraph() { RsidParagraphMarkRevision = "00705AF3", RsidParagraphAddition = "00195F14", RsidParagraphProperties = "00320B06", RsidRunAdditionDefault = "00705AF3" };

            ParagraphProperties paragraphProperties15 = new ParagraphProperties();
            Justification justification7 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties15 = new ParagraphMarkRunProperties();
            RunFonts runFonts22 = new RunFonts() { Ascii = "Symbol", HighAnsi = "Symbol", ComplexScript = "Times New Roman" };
            FontSize fontSize22 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript22 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties15.Append(runFonts22);
            paragraphMarkRunProperties15.Append(fontSize22);
            paragraphMarkRunProperties15.Append(fontSizeComplexScript22);

            paragraphProperties15.Append(justification7);
            paragraphProperties15.Append(paragraphMarkRunProperties15);

            Run run8 = new Run();

            RunProperties runProperties8 = new RunProperties();
            RunFonts runFonts23 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize23 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript23 = new FontSizeComplexScript() { Val = "28" };

            runProperties8.Append(runFonts23);
            runProperties8.Append(fontSize23);
            runProperties8.Append(fontSizeComplexScript23);
            Text text8 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text8.Text = "№ ";

            run8.Append(runProperties8);
            run8.Append(text8);

            Run run9 = new Run() { RsidRunAddition = "00320B06" };

            RunProperties runProperties9 = new RunProperties();
            RunFonts runFonts24 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            NoProof noProof4 = new NoProof();
            FontSize fontSize24 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript24 = new FontSizeComplexScript() { Val = "28" };

            runProperties9.Append(runFonts24);
            runProperties9.Append(noProof4);
            runProperties9.Append(fontSize24);
            runProperties9.Append(fontSizeComplexScript24);
            Text text9 = new Text();
            text9.Text = device.number.ToString();

            run9.Append(runProperties9);
            run9.Append(text9);

            paragraph15.Append(paragraphProperties15);
            paragraph15.Append(run8);
            paragraph15.Append(run9);

            tableCell15.Append(tableCellProperties15);
            tableCell15.Append(paragraph15);

            tableRow5.Append(tableCell13);
            tableRow5.Append(tableCell14);
            tableRow5.Append(tableCell15);

            TableRow tableRow6 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00195F14", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell16 = new TableCell();

            TableCellProperties tableCellProperties16 = new TableCellProperties();
            TableCellWidth tableCellWidth16 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan16 = new GridSpan() { Val = 3 };

            tableCellProperties16.Append(tableCellWidth16);
            tableCellProperties16.Append(gridSpan16);

            Paragraph paragraph16 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidRunAdditionDefault = "00195F14" };

            ParagraphProperties paragraphProperties16 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties16 = new ParagraphMarkRunProperties();
            RunFonts runFonts25 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize25 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript25 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties16.Append(runFonts25);
            paragraphMarkRunProperties16.Append(fontSize25);
            paragraphMarkRunProperties16.Append(fontSizeComplexScript25);

            paragraphProperties16.Append(paragraphMarkRunProperties16);

            paragraph16.Append(paragraphProperties16);

            tableCell16.Append(tableCellProperties16);
            tableCell16.Append(paragraph16);

            TableCell tableCell17 = new TableCell();

            TableCellProperties tableCellProperties17 = new TableCellProperties();
            TableCellWidth tableCellWidth17 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan17 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders5 = new TableCellBorders();
            TopBorder topBorder4 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder5 = new BottomBorder() { Val = BorderValues.Nil };

            tableCellBorders5.Append(topBorder4);
            tableCellBorders5.Append(bottomBorder5);

            tableCellProperties17.Append(tableCellWidth17);
            tableCellProperties17.Append(gridSpan17);
            tableCellProperties17.Append(tableCellBorders5);

            Paragraph paragraph17 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidParagraphProperties = "00FB6E38", RsidRunAdditionDefault = "00195F14" };

            ParagraphProperties paragraphProperties17 = new ParagraphProperties();
            Justification justification8 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties17 = new ParagraphMarkRunProperties();
            RunFonts runFonts26 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize26 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript26 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties17.Append(runFonts26);
            paragraphMarkRunProperties17.Append(fontSize26);
            paragraphMarkRunProperties17.Append(fontSizeComplexScript26);

            paragraphProperties17.Append(justification8);
            paragraphProperties17.Append(paragraphMarkRunProperties17);

            paragraph17.Append(paragraphProperties17);

            tableCell17.Append(tableCellProperties17);
            tableCell17.Append(paragraph17);

            TableCell tableCell18 = new TableCell();

            TableCellProperties tableCellProperties18 = new TableCellProperties();
            TableCellWidth tableCellWidth18 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan18 = new GridSpan() { Val = 3 };

            tableCellProperties18.Append(tableCellWidth18);
            tableCellProperties18.Append(gridSpan18);

            Paragraph paragraph18 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidRunAdditionDefault = "00195F14" };

            ParagraphProperties paragraphProperties18 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties18 = new ParagraphMarkRunProperties();
            RunFonts runFonts27 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize27 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript27 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties18.Append(runFonts27);
            paragraphMarkRunProperties18.Append(fontSize27);
            paragraphMarkRunProperties18.Append(fontSizeComplexScript27);

            paragraphProperties18.Append(paragraphMarkRunProperties18);

            paragraph18.Append(paragraphProperties18);

            tableCell18.Append(tableCellProperties18);
            tableCell18.Append(paragraph18);

            tableRow6.Append(tableCell16);
            tableRow6.Append(tableCell17);
            tableRow6.Append(tableCell18);

            TableRow tableRow7 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00195F14", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell19 = new TableCell();

            TableCellProperties tableCellProperties19 = new TableCellProperties();
            TableCellWidth tableCellWidth19 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan19 = new GridSpan() { Val = 3 };

            tableCellProperties19.Append(tableCellWidth19);
            tableCellProperties19.Append(gridSpan19);

            Paragraph paragraph19 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties19 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties19 = new ParagraphMarkRunProperties();
            RunFonts runFonts28 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize28 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript28 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties19.Append(runFonts28);
            paragraphMarkRunProperties19.Append(fontSize28);
            paragraphMarkRunProperties19.Append(fontSizeComplexScript28);

            paragraphProperties19.Append(paragraphMarkRunProperties19);

            Run run10 = new Run();

            RunProperties runProperties10 = new RunProperties();
            RunFonts runFonts29 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize29 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript29 = new FontSizeComplexScript() { Val = "28" };

            runProperties10.Append(runFonts29);
            runProperties10.Append(fontSize29);
            runProperties10.Append(fontSizeComplexScript29);
            Text text10 = new Text();
            text10.Text = "В подразделение";

            run10.Append(runProperties10);
            run10.Append(text10);

            paragraph19.Append(paragraphProperties19);
            paragraph19.Append(run10);

            tableCell19.Append(tableCellProperties19);
            tableCell19.Append(paragraph19);

            TableCell tableCell20 = new TableCell();

            TableCellProperties tableCellProperties20 = new TableCellProperties();
            TableCellWidth tableCellWidth20 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan20 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders6 = new TableCellBorders();
            TopBorder topBorder5 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder6 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders6.Append(topBorder5);
            tableCellBorders6.Append(bottomBorder6);

            tableCellProperties20.Append(tableCellWidth20);
            tableCellProperties20.Append(gridSpan20);
            tableCellProperties20.Append(tableCellBorders6);

            Paragraph paragraph20 = new Paragraph() { RsidParagraphMarkRevision = "00B67540", RsidParagraphAddition = "00195F14", RsidParagraphProperties = "00FB6E38", RsidRunAdditionDefault = "00320B06" };

            ParagraphProperties paragraphProperties20 = new ParagraphProperties();
            Justification justification9 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties20 = new ParagraphMarkRunProperties();
            RunFonts runFonts30 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize30 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript30 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties20.Append(runFonts30);
            paragraphMarkRunProperties20.Append(fontSize30);
            paragraphMarkRunProperties20.Append(fontSizeComplexScript30);

            paragraphProperties20.Append(justification9);
            paragraphProperties20.Append(paragraphMarkRunProperties20);

            Run run11 = new Run();

            RunProperties runProperties11 = new RunProperties();
            RunFonts runFonts31 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            NoProof noProof5 = new NoProof();
            FontSize fontSize31 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript31 = new FontSizeComplexScript() { Val = "28" };

            runProperties11.Append(runFonts31);
            runProperties11.Append(noProof5);
            runProperties11.Append(fontSize31);
            runProperties11.Append(fontSizeComplexScript31);
            Text text11 = new Text();
            text11.Text = department.department.ToString();

            run11.Append(runProperties11);
            run11.Append(text11);

            paragraph20.Append(paragraphProperties20);
            paragraph20.Append(run11);

            tableCell20.Append(tableCellProperties20);
            tableCell20.Append(paragraph20);

            TableCell tableCell21 = new TableCell();

            TableCellProperties tableCellProperties21 = new TableCellProperties();
            TableCellWidth tableCellWidth21 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan21 = new GridSpan() { Val = 3 };

            tableCellProperties21.Append(tableCellWidth21);
            tableCellProperties21.Append(gridSpan21);

            Paragraph paragraph21 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00195F14", RsidRunAdditionDefault = "00195F14" };

            ParagraphProperties paragraphProperties21 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties21 = new ParagraphMarkRunProperties();
            RunFonts runFonts32 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize32 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript32 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties21.Append(runFonts32);
            paragraphMarkRunProperties21.Append(fontSize32);
            paragraphMarkRunProperties21.Append(fontSizeComplexScript32);

            paragraphProperties21.Append(paragraphMarkRunProperties21);

            paragraph21.Append(paragraphProperties21);

            tableCell21.Append(tableCellProperties21);
            tableCell21.Append(paragraph21);

            tableRow7.Append(tableCell19);
            tableRow7.Append(tableCell20);
            tableRow7.Append(tableCell21);

            TableRow tableRow8 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00396EB4", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell22 = new TableCell();

            TableCellProperties tableCellProperties22 = new TableCellProperties();
            TableCellWidth tableCellWidth22 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan22 = new GridSpan() { Val = 3 };

            tableCellProperties22.Append(tableCellWidth22);
            tableCellProperties22.Append(gridSpan22);

            Paragraph paragraph22 = new Paragraph() { RsidParagraphAddition = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties22 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties22 = new ParagraphMarkRunProperties();
            RunFonts runFonts33 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize33 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript33 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties22.Append(runFonts33);
            paragraphMarkRunProperties22.Append(fontSize33);
            paragraphMarkRunProperties22.Append(fontSizeComplexScript33);

            paragraphProperties22.Append(paragraphMarkRunProperties22);

            paragraph22.Append(paragraphProperties22);

            tableCell22.Append(tableCellProperties22);
            tableCell22.Append(paragraph22);

            TableCell tableCell23 = new TableCell();

            TableCellProperties tableCellProperties23 = new TableCellProperties();
            TableCellWidth tableCellWidth23 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan23 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders7 = new TableCellBorders();
            TopBorder topBorder6 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders7.Append(topBorder6);

            tableCellProperties23.Append(tableCellWidth23);
            tableCellProperties23.Append(gridSpan23);
            tableCellProperties23.Append(tableCellBorders7);

            Paragraph paragraph23 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties23 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties23 = new ParagraphMarkRunProperties();
            RunFonts runFonts34 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize34 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript34 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties23.Append(runFonts34);
            paragraphMarkRunProperties23.Append(fontSize34);
            paragraphMarkRunProperties23.Append(fontSizeComplexScript34);

            paragraphProperties23.Append(paragraphMarkRunProperties23);

            paragraph23.Append(paragraphProperties23);

            tableCell23.Append(tableCellProperties23);
            tableCell23.Append(paragraph23);

            TableCell tableCell24 = new TableCell();

            TableCellProperties tableCellProperties24 = new TableCellProperties();
            TableCellWidth tableCellWidth24 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan24 = new GridSpan() { Val = 3 };

            tableCellProperties24.Append(tableCellWidth24);
            tableCellProperties24.Append(gridSpan24);

            Paragraph paragraph24 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties24 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties24 = new ParagraphMarkRunProperties();
            RunFonts runFonts35 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize35 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript35 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties24.Append(runFonts35);
            paragraphMarkRunProperties24.Append(fontSize35);
            paragraphMarkRunProperties24.Append(fontSizeComplexScript35);

            paragraphProperties24.Append(paragraphMarkRunProperties24);

            paragraph24.Append(paragraphProperties24);

            tableCell24.Append(tableCellProperties24);
            tableCell24.Append(paragraph24);

            tableRow8.Append(tableCell22);
            tableRow8.Append(tableCell23);
            tableRow8.Append(tableCell24);

            TableRow tableRow9 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00396EB4", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell25 = new TableCell();

            TableCellProperties tableCellProperties25 = new TableCellProperties();
            TableCellWidth tableCellWidth25 = new TableCellWidth() { Width = "279", Type = TableWidthUnitValues.Dxa };

            tableCellProperties25.Append(tableCellWidth25);

            Paragraph paragraph25 = new Paragraph() { RsidParagraphAddition = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties25 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties25 = new ParagraphMarkRunProperties();
            RunFonts runFonts36 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize36 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript36 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties25.Append(runFonts36);
            paragraphMarkRunProperties25.Append(fontSize36);
            paragraphMarkRunProperties25.Append(fontSizeComplexScript36);

            paragraphProperties25.Append(paragraphMarkRunProperties25);

            paragraph25.Append(paragraphProperties25);

            tableCell25.Append(tableCellProperties25);
            tableCell25.Append(paragraph25);

            TableCell tableCell26 = new TableCell();

            TableCellProperties tableCellProperties26 = new TableCellProperties();
            TableCellWidth tableCellWidth26 = new TableCellWidth() { Width = "2551", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders8 = new TableCellBorders();
            TopBorder topBorder7 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder7 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders8.Append(topBorder7);
            tableCellBorders8.Append(bottomBorder7);

            tableCellProperties26.Append(tableCellWidth26);
            tableCellProperties26.Append(tableCellBorders8);

            Paragraph paragraph26 = new Paragraph() { RsidParagraphMarkRevision = "00B67540", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00FB6E38", RsidRunAdditionDefault = "00320B06" };

            ParagraphProperties paragraphProperties26 = new ParagraphProperties();
            Justification justification10 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties26 = new ParagraphMarkRunProperties();
            RunFonts runFonts37 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize37 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript37 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties26.Append(runFonts37);
            paragraphMarkRunProperties26.Append(fontSize37);
            paragraphMarkRunProperties26.Append(fontSizeComplexScript37);

            paragraphProperties26.Append(justification10);
            paragraphProperties26.Append(paragraphMarkRunProperties26);

            Run run12 = new Run();

            RunProperties runProperties12 = new RunProperties();
            RunFonts runFonts38 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            NoProof noProof6 = new NoProof();
            FontSize fontSize38 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript38 = new FontSizeComplexScript() { Val = "28" };

            runProperties12.Append(runFonts38);
            runProperties12.Append(noProof6);
            runProperties12.Append(fontSize38);
            runProperties12.Append(fontSizeComplexScript38);
            Text text12 = new Text();
            text12.Text = System.DateTime.Now.ToShortDateString();

            run12.Append(runProperties12);
            run12.Append(text12);

            paragraph26.Append(paragraphProperties26);
            paragraph26.Append(run12);

            tableCell26.Append(tableCellProperties26);
            tableCell26.Append(paragraph26);

            TableCell tableCell27 = new TableCell();

            TableCellProperties tableCellProperties27 = new TableCellProperties();
            TableCellWidth tableCellWidth27 = new TableCellWidth() { Width = "285", Type = TableWidthUnitValues.Dxa };

            tableCellProperties27.Append(tableCellWidth27);

            Paragraph paragraph27 = new Paragraph() { RsidParagraphAddition = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties27 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties27 = new ParagraphMarkRunProperties();
            RunFonts runFonts39 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize39 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript39 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties27.Append(runFonts39);
            paragraphMarkRunProperties27.Append(fontSize39);
            paragraphMarkRunProperties27.Append(fontSizeComplexScript39);

            paragraphProperties27.Append(paragraphMarkRunProperties27);

            paragraph27.Append(paragraphProperties27);

            tableCell27.Append(tableCellProperties27);
            tableCell27.Append(paragraph27);

            TableCell tableCell28 = new TableCell();

            TableCellProperties tableCellProperties28 = new TableCellProperties();
            TableCellWidth tableCellWidth28 = new TableCellWidth() { Width = "282", Type = TableWidthUnitValues.Dxa };

            tableCellProperties28.Append(tableCellWidth28);

            Paragraph paragraph28 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties28 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties28 = new ParagraphMarkRunProperties();
            RunFonts runFonts40 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize40 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript40 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties28.Append(runFonts40);
            paragraphMarkRunProperties28.Append(fontSize40);
            paragraphMarkRunProperties28.Append(fontSizeComplexScript40);

            paragraphProperties28.Append(paragraphMarkRunProperties28);

            paragraph28.Append(paragraphProperties28);

            tableCell28.Append(tableCellProperties28);
            tableCell28.Append(paragraph28);

            TableCell tableCell29 = new TableCell();

            TableCellProperties tableCellProperties29 = new TableCellProperties();
            TableCellWidth tableCellWidth29 = new TableCellWidth() { Width = "2552", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders9 = new TableCellBorders();
            TopBorder topBorder8 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder8 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders9.Append(topBorder8);
            tableCellBorders9.Append(bottomBorder8);

            tableCellProperties29.Append(tableCellWidth29);
            tableCellProperties29.Append(tableCellBorders9);

            Paragraph paragraph29 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties29 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties29 = new ParagraphMarkRunProperties();
            RunFonts runFonts41 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize41 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript41 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties29.Append(runFonts41);
            paragraphMarkRunProperties29.Append(fontSize41);
            paragraphMarkRunProperties29.Append(fontSizeComplexScript41);

            paragraphProperties29.Append(paragraphMarkRunProperties29);

            paragraph29.Append(paragraphProperties29);

            tableCell29.Append(tableCellProperties29);
            tableCell29.Append(paragraph29);

            TableCell tableCell30 = new TableCell();

            TableCellProperties tableCellProperties30 = new TableCellProperties();
            TableCellWidth tableCellWidth30 = new TableCellWidth() { Width = "281", Type = TableWidthUnitValues.Dxa };

            tableCellProperties30.Append(tableCellWidth30);

            Paragraph paragraph30 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties30 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties30 = new ParagraphMarkRunProperties();
            RunFonts runFonts42 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize42 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript42 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties30.Append(runFonts42);
            paragraphMarkRunProperties30.Append(fontSize42);
            paragraphMarkRunProperties30.Append(fontSizeComplexScript42);

            paragraphProperties30.Append(paragraphMarkRunProperties30);

            paragraph30.Append(paragraphProperties30);

            tableCell30.Append(tableCellProperties30);
            tableCell30.Append(paragraph30);

            TableCell tableCell31 = new TableCell();

            TableCellProperties tableCellProperties31 = new TableCellProperties();
            TableCellWidth tableCellWidth31 = new TableCellWidth() { Width = "286", Type = TableWidthUnitValues.Dxa };

            tableCellProperties31.Append(tableCellWidth31);

            Paragraph paragraph31 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties31 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties31 = new ParagraphMarkRunProperties();
            RunFonts runFonts43 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize43 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript43 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties31.Append(runFonts43);
            paragraphMarkRunProperties31.Append(fontSize43);
            paragraphMarkRunProperties31.Append(fontSizeComplexScript43);

            paragraphProperties31.Append(paragraphMarkRunProperties31);

            paragraph31.Append(paragraphProperties31);

            tableCell31.Append(tableCellProperties31);
            tableCell31.Append(paragraph31);

            TableCell tableCell32 = new TableCell();

            TableCellProperties tableCellProperties32 = new TableCellProperties();
            TableCellWidth tableCellWidth32 = new TableCellWidth() { Width = "2551", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders10 = new TableCellBorders();
            TopBorder topBorder9 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder9 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders10.Append(topBorder9);
            tableCellBorders10.Append(bottomBorder9);

            tableCellProperties32.Append(tableCellWidth32);
            tableCellProperties32.Append(tableCellBorders10);

            Paragraph paragraph32 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties32 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties32 = new ParagraphMarkRunProperties();
            RunFonts runFonts44 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize44 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript44 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties32.Append(runFonts44);
            paragraphMarkRunProperties32.Append(fontSize44);
            paragraphMarkRunProperties32.Append(fontSizeComplexScript44);

            paragraphProperties32.Append(paragraphMarkRunProperties32);

            paragraph32.Append(paragraphProperties32);

            tableCell32.Append(tableCellProperties32);
            tableCell32.Append(paragraph32);

            TableCell tableCell33 = new TableCell();

            TableCellProperties tableCellProperties33 = new TableCellProperties();
            TableCellWidth tableCellWidth33 = new TableCellWidth() { Width = "567", Type = TableWidthUnitValues.Dxa };

            tableCellProperties33.Append(tableCellWidth33);

            Paragraph paragraph33 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties33 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties33 = new ParagraphMarkRunProperties();
            RunFonts runFonts45 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize45 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript45 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties33.Append(runFonts45);
            paragraphMarkRunProperties33.Append(fontSize45);
            paragraphMarkRunProperties33.Append(fontSizeComplexScript45);

            paragraphProperties33.Append(paragraphMarkRunProperties33);

            paragraph33.Append(paragraphProperties33);

            tableCell33.Append(tableCellProperties33);
            tableCell33.Append(paragraph33);

            tableRow9.Append(tableCell25);
            tableRow9.Append(tableCell26);
            tableRow9.Append(tableCell27);
            tableRow9.Append(tableCell28);
            tableRow9.Append(tableCell29);
            tableRow9.Append(tableCell30);
            tableRow9.Append(tableCell31);
            tableRow9.Append(tableCell32);
            tableRow9.Append(tableCell33);

            TableRow tableRow10 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00396EB4", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell34 = new TableCell();

            TableCellProperties tableCellProperties34 = new TableCellProperties();
            TableCellWidth tableCellWidth34 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan25 = new GridSpan() { Val = 3 };

            tableCellProperties34.Append(tableCellWidth34);
            tableCellProperties34.Append(gridSpan25);

            Paragraph paragraph34 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties34 = new ParagraphProperties();
            Justification justification11 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties34 = new ParagraphMarkRunProperties();
            RunFonts runFonts46 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize46 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript46 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties34.Append(runFonts46);
            paragraphMarkRunProperties34.Append(fontSize46);
            paragraphMarkRunProperties34.Append(fontSizeComplexScript46);

            paragraphProperties34.Append(justification11);
            paragraphProperties34.Append(paragraphMarkRunProperties34);

            Run run13 = new Run();

            RunProperties runProperties13 = new RunProperties();
            RunFonts runFonts47 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize47 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript47 = new FontSizeComplexScript() { Val = "28" };

            runProperties13.Append(runFonts47);
            runProperties13.Append(fontSize47);
            runProperties13.Append(fontSizeComplexScript47);
            Text text13 = new Text();
            text13.Text = "дата";

            run13.Append(runProperties13);
            run13.Append(text13);

            paragraph34.Append(paragraphProperties34);
            paragraph34.Append(run13);

            tableCell34.Append(tableCellProperties34);
            tableCell34.Append(paragraph34);

            TableCell tableCell35 = new TableCell();

            TableCellProperties tableCellProperties35 = new TableCellProperties();
            TableCellWidth tableCellWidth35 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan26 = new GridSpan() { Val = 3 };

            tableCellProperties35.Append(tableCellWidth35);
            tableCellProperties35.Append(gridSpan26);

            Paragraph paragraph35 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties35 = new ParagraphProperties();
            Justification justification12 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties35 = new ParagraphMarkRunProperties();
            RunFonts runFonts48 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize48 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript48 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties35.Append(runFonts48);
            paragraphMarkRunProperties35.Append(fontSize48);
            paragraphMarkRunProperties35.Append(fontSizeComplexScript48);

            paragraphProperties35.Append(justification12);
            paragraphProperties35.Append(paragraphMarkRunProperties35);

            Run run14 = new Run();

            RunProperties runProperties14 = new RunProperties();
            RunFonts runFonts49 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize49 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript49 = new FontSizeComplexScript() { Val = "28" };

            runProperties14.Append(runFonts49);
            runProperties14.Append(fontSize49);
            runProperties14.Append(fontSizeComplexScript49);
            Text text14 = new Text();
            text14.Text = "подпись";

            run14.Append(runProperties14);
            run14.Append(text14);

            paragraph35.Append(paragraphProperties35);
            paragraph35.Append(run14);

            tableCell35.Append(tableCellProperties35);
            tableCell35.Append(paragraph35);

            TableCell tableCell36 = new TableCell();

            TableCellProperties tableCellProperties36 = new TableCellProperties();
            TableCellWidth tableCellWidth36 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan27 = new GridSpan() { Val = 3 };

            tableCellProperties36.Append(tableCellWidth36);
            tableCellProperties36.Append(gridSpan27);

            Paragraph paragraph36 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties36 = new ParagraphProperties();
            Justification justification13 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties36 = new ParagraphMarkRunProperties();
            RunFonts runFonts50 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize50 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript50 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties36.Append(runFonts50);
            paragraphMarkRunProperties36.Append(fontSize50);
            paragraphMarkRunProperties36.Append(fontSizeComplexScript50);

            paragraphProperties36.Append(justification13);
            paragraphProperties36.Append(paragraphMarkRunProperties36);

            Run run15 = new Run();

            RunProperties runProperties15 = new RunProperties();
            RunFonts runFonts51 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize51 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript51 = new FontSizeComplexScript() { Val = "28" };

            runProperties15.Append(runFonts51);
            runProperties15.Append(fontSize51);
            runProperties15.Append(fontSizeComplexScript51);
            Text text15 = new Text();
            text15.Text = "ФИО";

            run15.Append(runProperties15);
            run15.Append(text15);

            paragraph36.Append(paragraphProperties36);
            paragraph36.Append(run15);

            tableCell36.Append(tableCellProperties36);
            tableCell36.Append(paragraph36);

            tableRow10.Append(tableCell34);
            tableRow10.Append(tableCell35);
            tableRow10.Append(tableCell36);

            TableRow tableRow11 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00396EB4", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell37 = new TableCell();

            TableCellProperties tableCellProperties37 = new TableCellProperties();
            TableCellWidth tableCellWidth37 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan28 = new GridSpan() { Val = 3 };

            tableCellProperties37.Append(tableCellWidth37);
            tableCellProperties37.Append(gridSpan28);

            Paragraph paragraph37 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties37 = new ParagraphProperties();
            Justification justification14 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties37 = new ParagraphMarkRunProperties();
            RunFonts runFonts52 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize52 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript52 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties37.Append(runFonts52);
            paragraphMarkRunProperties37.Append(fontSize52);
            paragraphMarkRunProperties37.Append(fontSizeComplexScript52);

            paragraphProperties37.Append(justification14);
            paragraphProperties37.Append(paragraphMarkRunProperties37);

            paragraph37.Append(paragraphProperties37);

            tableCell37.Append(tableCellProperties37);
            tableCell37.Append(paragraph37);

            TableCell tableCell38 = new TableCell();

            TableCellProperties tableCellProperties38 = new TableCellProperties();
            TableCellWidth tableCellWidth38 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan29 = new GridSpan() { Val = 3 };

            tableCellProperties38.Append(tableCellWidth38);
            tableCellProperties38.Append(gridSpan29);

            Paragraph paragraph38 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties38 = new ParagraphProperties();
            Justification justification15 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties38 = new ParagraphMarkRunProperties();
            RunFonts runFonts53 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize53 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript53 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties38.Append(runFonts53);
            paragraphMarkRunProperties38.Append(fontSize53);
            paragraphMarkRunProperties38.Append(fontSizeComplexScript53);

            paragraphProperties38.Append(justification15);
            paragraphProperties38.Append(paragraphMarkRunProperties38);

            paragraph38.Append(paragraphProperties38);

            tableCell38.Append(tableCellProperties38);
            tableCell38.Append(paragraph38);

            TableCell tableCell39 = new TableCell();

            TableCellProperties tableCellProperties39 = new TableCellProperties();
            TableCellWidth tableCellWidth39 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan30 = new GridSpan() { Val = 3 };

            tableCellProperties39.Append(tableCellWidth39);
            tableCellProperties39.Append(gridSpan30);

            Paragraph paragraph39 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties39 = new ParagraphProperties();
            Justification justification16 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties39 = new ParagraphMarkRunProperties();
            RunFonts runFonts54 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize54 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript54 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties39.Append(runFonts54);
            paragraphMarkRunProperties39.Append(fontSize54);
            paragraphMarkRunProperties39.Append(fontSizeComplexScript54);

            paragraphProperties39.Append(justification16);
            paragraphProperties39.Append(paragraphMarkRunProperties39);

            paragraph39.Append(paragraphProperties39);

            tableCell39.Append(tableCellProperties39);
            tableCell39.Append(paragraph39);

            tableRow11.Append(tableCell37);
            tableRow11.Append(tableCell38);
            tableRow11.Append(tableCell39);

            TableRow tableRow12 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00396EB4", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell40 = new TableCell();

            TableCellProperties tableCellProperties40 = new TableCellProperties();
            TableCellWidth tableCellWidth40 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan31 = new GridSpan() { Val = 3 };

            tableCellProperties40.Append(tableCellWidth40);
            tableCellProperties40.Append(gridSpan31);

            Paragraph paragraph40 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties40 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties40 = new ParagraphMarkRunProperties();
            RunFonts runFonts55 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize55 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript55 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties40.Append(runFonts55);
            paragraphMarkRunProperties40.Append(fontSize55);
            paragraphMarkRunProperties40.Append(fontSizeComplexScript55);

            paragraphProperties40.Append(paragraphMarkRunProperties40);

            Run run16 = new Run();

            RunProperties runProperties16 = new RunProperties();
            RunFonts runFonts56 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize56 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript56 = new FontSizeComplexScript() { Val = "28" };

            runProperties16.Append(runFonts56);
            runProperties16.Append(fontSize56);
            runProperties16.Append(fontSizeComplexScript56);
            Text text16 = new Text();
            text16.Text = "Замену произвел:";

            run16.Append(runProperties16);
            run16.Append(text16);

            paragraph40.Append(paragraphProperties40);
            paragraph40.Append(run16);

            tableCell40.Append(tableCellProperties40);
            tableCell40.Append(paragraph40);

            TableCell tableCell41 = new TableCell();

            TableCellProperties tableCellProperties41 = new TableCellProperties();
            TableCellWidth tableCellWidth41 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan32 = new GridSpan() { Val = 3 };

            tableCellProperties41.Append(tableCellWidth41);
            tableCellProperties41.Append(gridSpan32);

            Paragraph paragraph41 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties41 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties41 = new ParagraphMarkRunProperties();
            RunFonts runFonts57 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize57 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript57 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties41.Append(runFonts57);
            paragraphMarkRunProperties41.Append(fontSize57);
            paragraphMarkRunProperties41.Append(fontSizeComplexScript57);

            paragraphProperties41.Append(paragraphMarkRunProperties41);

            paragraph41.Append(paragraphProperties41);

            tableCell41.Append(tableCellProperties41);
            tableCell41.Append(paragraph41);

            TableCell tableCell42 = new TableCell();

            TableCellProperties tableCellProperties42 = new TableCellProperties();
            TableCellWidth tableCellWidth42 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan33 = new GridSpan() { Val = 3 };

            tableCellProperties42.Append(tableCellWidth42);
            tableCellProperties42.Append(gridSpan33);

            Paragraph paragraph42 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties42 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties42 = new ParagraphMarkRunProperties();
            RunFonts runFonts58 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize58 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript58 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties42.Append(runFonts58);
            paragraphMarkRunProperties42.Append(fontSize58);
            paragraphMarkRunProperties42.Append(fontSizeComplexScript58);

            paragraphProperties42.Append(paragraphMarkRunProperties42);

            paragraph42.Append(paragraphProperties42);

            tableCell42.Append(tableCellProperties42);
            tableCell42.Append(paragraph42);

            tableRow12.Append(tableCell40);
            tableRow12.Append(tableCell41);
            tableRow12.Append(tableCell42);

            TableRow tableRow13 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00396EB4", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell43 = new TableCell();

            TableCellProperties tableCellProperties43 = new TableCellProperties();
            TableCellWidth tableCellWidth43 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan34 = new GridSpan() { Val = 3 };

            tableCellProperties43.Append(tableCellWidth43);
            tableCellProperties43.Append(gridSpan34);

            Paragraph paragraph43 = new Paragraph() { RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties43 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties43 = new ParagraphMarkRunProperties();
            RunFonts runFonts59 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize59 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript59 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties43.Append(runFonts59);
            paragraphMarkRunProperties43.Append(fontSize59);
            paragraphMarkRunProperties43.Append(fontSizeComplexScript59);

            paragraphProperties43.Append(paragraphMarkRunProperties43);

            paragraph43.Append(paragraphProperties43);

            tableCell43.Append(tableCellProperties43);
            tableCell43.Append(paragraph43);

            TableCell tableCell44 = new TableCell();

            TableCellProperties tableCellProperties44 = new TableCellProperties();
            TableCellWidth tableCellWidth44 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan35 = new GridSpan() { Val = 3 };

            tableCellProperties44.Append(tableCellWidth44);
            tableCellProperties44.Append(gridSpan35);

            Paragraph paragraph44 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties44 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties44 = new ParagraphMarkRunProperties();
            RunFonts runFonts60 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize60 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript60 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties44.Append(runFonts60);
            paragraphMarkRunProperties44.Append(fontSize60);
            paragraphMarkRunProperties44.Append(fontSizeComplexScript60);

            paragraphProperties44.Append(paragraphMarkRunProperties44);

            paragraph44.Append(paragraphProperties44);

            tableCell44.Append(tableCellProperties44);
            tableCell44.Append(paragraph44);

            TableCell tableCell45 = new TableCell();

            TableCellProperties tableCellProperties45 = new TableCellProperties();
            TableCellWidth tableCellWidth45 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan36 = new GridSpan() { Val = 3 };

            tableCellProperties45.Append(tableCellWidth45);
            tableCellProperties45.Append(gridSpan36);

            Paragraph paragraph45 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties45 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties45 = new ParagraphMarkRunProperties();
            RunFonts runFonts61 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize61 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript61 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties45.Append(runFonts61);
            paragraphMarkRunProperties45.Append(fontSize61);
            paragraphMarkRunProperties45.Append(fontSizeComplexScript61);

            paragraphProperties45.Append(paragraphMarkRunProperties45);

            paragraph45.Append(paragraphProperties45);

            tableCell45.Append(tableCellProperties45);
            tableCell45.Append(paragraph45);

            tableRow13.Append(tableCell43);
            tableRow13.Append(tableCell44);
            tableRow13.Append(tableCell45);

            TableRow tableRow14 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00396EB4", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell46 = new TableCell();

            TableCellProperties tableCellProperties46 = new TableCellProperties();
            TableCellWidth tableCellWidth46 = new TableCellWidth() { Width = "279", Type = TableWidthUnitValues.Dxa };

            tableCellProperties46.Append(tableCellWidth46);

            Paragraph paragraph46 = new Paragraph() { RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties46 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties46 = new ParagraphMarkRunProperties();
            RunFonts runFonts62 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize62 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript62 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties46.Append(runFonts62);
            paragraphMarkRunProperties46.Append(fontSize62);
            paragraphMarkRunProperties46.Append(fontSizeComplexScript62);

            paragraphProperties46.Append(paragraphMarkRunProperties46);

            paragraph46.Append(paragraphProperties46);

            tableCell46.Append(tableCellProperties46);
            tableCell46.Append(paragraph46);

            TableCell tableCell47 = new TableCell();

            TableCellProperties tableCellProperties47 = new TableCellProperties();
            TableCellWidth tableCellWidth47 = new TableCellWidth() { Width = "2551", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders11 = new TableCellBorders();
            TopBorder topBorder10 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder10 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders11.Append(topBorder10);
            tableCellBorders11.Append(bottomBorder10);

            tableCellProperties47.Append(tableCellWidth47);
            tableCellProperties47.Append(tableCellBorders11);

            Paragraph paragraph47 = new Paragraph() { RsidParagraphMarkRevision = "00B67540", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00FB6E38", RsidRunAdditionDefault = "00320B06" };

            ParagraphProperties paragraphProperties47 = new ParagraphProperties();
            Justification justification17 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties47 = new ParagraphMarkRunProperties();
            RunFonts runFonts63 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize63 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript63 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties47.Append(runFonts63);
            paragraphMarkRunProperties47.Append(fontSize63);
            paragraphMarkRunProperties47.Append(fontSizeComplexScript63);

            paragraphProperties47.Append(justification17);
            paragraphProperties47.Append(paragraphMarkRunProperties47);

            Run run17 = new Run();

            RunProperties runProperties17 = new RunProperties();
            RunFonts runFonts64 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            NoProof noProof7 = new NoProof();
            FontSize fontSize64 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript64 = new FontSizeComplexScript() { Val = "28" };

            runProperties17.Append(runFonts64);
            runProperties17.Append(noProof7);
            runProperties17.Append(fontSize64);
            runProperties17.Append(fontSizeComplexScript64);
            Text text17 = new Text();
            text17.Text = System.DateTime.Now.ToShortDateString();

            run17.Append(runProperties17);
            run17.Append(text17);

            paragraph47.Append(paragraphProperties47);
            paragraph47.Append(run17);

            tableCell47.Append(tableCellProperties47);
            tableCell47.Append(paragraph47);

            TableCell tableCell48 = new TableCell();

            TableCellProperties tableCellProperties48 = new TableCellProperties();
            TableCellWidth tableCellWidth48 = new TableCellWidth() { Width = "285", Type = TableWidthUnitValues.Dxa };

            tableCellProperties48.Append(tableCellWidth48);

            Paragraph paragraph48 = new Paragraph() { RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties48 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties48 = new ParagraphMarkRunProperties();
            RunFonts runFonts65 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize65 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript65 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties48.Append(runFonts65);
            paragraphMarkRunProperties48.Append(fontSize65);
            paragraphMarkRunProperties48.Append(fontSizeComplexScript65);

            paragraphProperties48.Append(paragraphMarkRunProperties48);

            paragraph48.Append(paragraphProperties48);

            tableCell48.Append(tableCellProperties48);
            tableCell48.Append(paragraph48);

            TableCell tableCell49 = new TableCell();

            TableCellProperties tableCellProperties49 = new TableCellProperties();
            TableCellWidth tableCellWidth49 = new TableCellWidth() { Width = "282", Type = TableWidthUnitValues.Dxa };

            tableCellProperties49.Append(tableCellWidth49);

            Paragraph paragraph49 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties49 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties49 = new ParagraphMarkRunProperties();
            RunFonts runFonts66 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize66 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript66 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties49.Append(runFonts66);
            paragraphMarkRunProperties49.Append(fontSize66);
            paragraphMarkRunProperties49.Append(fontSizeComplexScript66);

            paragraphProperties49.Append(paragraphMarkRunProperties49);

            paragraph49.Append(paragraphProperties49);

            tableCell49.Append(tableCellProperties49);
            tableCell49.Append(paragraph49);

            TableCell tableCell50 = new TableCell();

            TableCellProperties tableCellProperties50 = new TableCellProperties();
            TableCellWidth tableCellWidth50 = new TableCellWidth() { Width = "2552", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders12 = new TableCellBorders();
            TopBorder topBorder11 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder11 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders12.Append(topBorder11);
            tableCellBorders12.Append(bottomBorder11);

            tableCellProperties50.Append(tableCellWidth50);
            tableCellProperties50.Append(tableCellBorders12);

            Paragraph paragraph50 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties50 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties50 = new ParagraphMarkRunProperties();
            RunFonts runFonts67 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize67 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript67 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties50.Append(runFonts67);
            paragraphMarkRunProperties50.Append(fontSize67);
            paragraphMarkRunProperties50.Append(fontSizeComplexScript67);

            paragraphProperties50.Append(paragraphMarkRunProperties50);

            paragraph50.Append(paragraphProperties50);

            tableCell50.Append(tableCellProperties50);
            tableCell50.Append(paragraph50);

            TableCell tableCell51 = new TableCell();

            TableCellProperties tableCellProperties51 = new TableCellProperties();
            TableCellWidth tableCellWidth51 = new TableCellWidth() { Width = "281", Type = TableWidthUnitValues.Dxa };

            tableCellProperties51.Append(tableCellWidth51);

            Paragraph paragraph51 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties51 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties51 = new ParagraphMarkRunProperties();
            RunFonts runFonts68 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize68 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript68 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties51.Append(runFonts68);
            paragraphMarkRunProperties51.Append(fontSize68);
            paragraphMarkRunProperties51.Append(fontSizeComplexScript68);

            paragraphProperties51.Append(paragraphMarkRunProperties51);

            paragraph51.Append(paragraphProperties51);

            tableCell51.Append(tableCellProperties51);
            tableCell51.Append(paragraph51);

            TableCell tableCell52 = new TableCell();

            TableCellProperties tableCellProperties52 = new TableCellProperties();
            TableCellWidth tableCellWidth52 = new TableCellWidth() { Width = "286", Type = TableWidthUnitValues.Dxa };

            tableCellProperties52.Append(tableCellWidth52);

            Paragraph paragraph52 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties52 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties52 = new ParagraphMarkRunProperties();
            RunFonts runFonts69 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize69 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript69 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties52.Append(runFonts69);
            paragraphMarkRunProperties52.Append(fontSize69);
            paragraphMarkRunProperties52.Append(fontSizeComplexScript69);

            paragraphProperties52.Append(paragraphMarkRunProperties52);

            paragraph52.Append(paragraphProperties52);

            tableCell52.Append(tableCellProperties52);
            tableCell52.Append(paragraph52);

            TableCell tableCell53 = new TableCell();

            TableCellProperties tableCellProperties53 = new TableCellProperties();
            TableCellWidth tableCellWidth53 = new TableCellWidth() { Width = "2551", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders13 = new TableCellBorders();
            TopBorder topBorder12 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder12 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders13.Append(topBorder12);
            tableCellBorders13.Append(bottomBorder12);

            tableCellProperties53.Append(tableCellWidth53);
            tableCellProperties53.Append(tableCellBorders13);

            Paragraph paragraph53 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties53 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties53 = new ParagraphMarkRunProperties();
            RunFonts runFonts70 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize70 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript70 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties53.Append(runFonts70);
            paragraphMarkRunProperties53.Append(fontSize70);
            paragraphMarkRunProperties53.Append(fontSizeComplexScript70);

            paragraphProperties53.Append(paragraphMarkRunProperties53);

            paragraph53.Append(paragraphProperties53);

            tableCell53.Append(tableCellProperties53);
            tableCell53.Append(paragraph53);

            TableCell tableCell54 = new TableCell();

            TableCellProperties tableCellProperties54 = new TableCellProperties();
            TableCellWidth tableCellWidth54 = new TableCellWidth() { Width = "567", Type = TableWidthUnitValues.Dxa };

            tableCellProperties54.Append(tableCellWidth54);

            Paragraph paragraph54 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties54 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties54 = new ParagraphMarkRunProperties();
            RunFonts runFonts71 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize71 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript71 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties54.Append(runFonts71);
            paragraphMarkRunProperties54.Append(fontSize71);
            paragraphMarkRunProperties54.Append(fontSizeComplexScript71);

            paragraphProperties54.Append(paragraphMarkRunProperties54);

            paragraph54.Append(paragraphProperties54);

            tableCell54.Append(tableCellProperties54);
            tableCell54.Append(paragraph54);

            tableRow14.Append(tableCell46);
            tableRow14.Append(tableCell47);
            tableRow14.Append(tableCell48);
            tableRow14.Append(tableCell49);
            tableRow14.Append(tableCell50);
            tableRow14.Append(tableCell51);
            tableRow14.Append(tableCell52);
            tableRow14.Append(tableCell53);
            tableRow14.Append(tableCell54);

            TableRow tableRow15 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00396EB4", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell55 = new TableCell();

            TableCellProperties tableCellProperties55 = new TableCellProperties();
            TableCellWidth tableCellWidth55 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan37 = new GridSpan() { Val = 3 };

            tableCellProperties55.Append(tableCellWidth55);
            tableCellProperties55.Append(gridSpan37);

            Paragraph paragraph55 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties55 = new ParagraphProperties();
            Justification justification18 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties55 = new ParagraphMarkRunProperties();
            RunFonts runFonts72 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize72 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript72 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties55.Append(runFonts72);
            paragraphMarkRunProperties55.Append(fontSize72);
            paragraphMarkRunProperties55.Append(fontSizeComplexScript72);

            paragraphProperties55.Append(justification18);
            paragraphProperties55.Append(paragraphMarkRunProperties55);

            Run run18 = new Run();

            RunProperties runProperties18 = new RunProperties();
            RunFonts runFonts73 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize73 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript73 = new FontSizeComplexScript() { Val = "28" };

            runProperties18.Append(runFonts73);
            runProperties18.Append(fontSize73);
            runProperties18.Append(fontSizeComplexScript73);
            Text text18 = new Text();
            text18.Text = "дата";

            run18.Append(runProperties18);
            run18.Append(text18);

            paragraph55.Append(paragraphProperties55);
            paragraph55.Append(run18);

            tableCell55.Append(tableCellProperties55);
            tableCell55.Append(paragraph55);

            TableCell tableCell56 = new TableCell();

            TableCellProperties tableCellProperties56 = new TableCellProperties();
            TableCellWidth tableCellWidth56 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan38 = new GridSpan() { Val = 3 };

            tableCellProperties56.Append(tableCellWidth56);
            tableCellProperties56.Append(gridSpan38);

            Paragraph paragraph56 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties56 = new ParagraphProperties();
            Justification justification19 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties56 = new ParagraphMarkRunProperties();
            RunFonts runFonts74 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize74 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript74 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties56.Append(runFonts74);
            paragraphMarkRunProperties56.Append(fontSize74);
            paragraphMarkRunProperties56.Append(fontSizeComplexScript74);

            paragraphProperties56.Append(justification19);
            paragraphProperties56.Append(paragraphMarkRunProperties56);

            Run run19 = new Run();

            RunProperties runProperties19 = new RunProperties();
            RunFonts runFonts75 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize75 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript75 = new FontSizeComplexScript() { Val = "28" };

            runProperties19.Append(runFonts75);
            runProperties19.Append(fontSize75);
            runProperties19.Append(fontSizeComplexScript75);
            Text text19 = new Text();
            text19.Text = "подпись";

            run19.Append(runProperties19);
            run19.Append(text19);

            paragraph56.Append(paragraphProperties56);
            paragraph56.Append(run19);

            tableCell56.Append(tableCellProperties56);
            tableCell56.Append(paragraph56);

            TableCell tableCell57 = new TableCell();

            TableCellProperties tableCellProperties57 = new TableCellProperties();
            TableCellWidth tableCellWidth57 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan39 = new GridSpan() { Val = 3 };

            tableCellProperties57.Append(tableCellWidth57);
            tableCellProperties57.Append(gridSpan39);

            Paragraph paragraph57 = new Paragraph() { RsidParagraphMarkRevision = "00396EB4", RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties57 = new ParagraphProperties();
            Justification justification20 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties57 = new ParagraphMarkRunProperties();
            RunFonts runFonts76 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize76 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript76 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties57.Append(runFonts76);
            paragraphMarkRunProperties57.Append(fontSize76);
            paragraphMarkRunProperties57.Append(fontSizeComplexScript76);

            paragraphProperties57.Append(justification20);
            paragraphProperties57.Append(paragraphMarkRunProperties57);

            Run run20 = new Run();

            RunProperties runProperties20 = new RunProperties();
            RunFonts runFonts77 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize77 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript77 = new FontSizeComplexScript() { Val = "28" };

            runProperties20.Append(runFonts77);
            runProperties20.Append(fontSize77);
            runProperties20.Append(fontSizeComplexScript77);
            Text text20 = new Text();
            text20.Text = "ФИО";

            run20.Append(runProperties20);
            run20.Append(text20);

            paragraph57.Append(paragraphProperties57);
            paragraph57.Append(run20);

            tableCell57.Append(tableCellProperties57);
            tableCell57.Append(paragraph57);

            tableRow15.Append(tableCell55);
            tableRow15.Append(tableCell56);
            tableRow15.Append(tableCell57);

            TableRow tableRow16 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00396EB4", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell58 = new TableCell();

            TableCellProperties tableCellProperties58 = new TableCellProperties();
            TableCellWidth tableCellWidth58 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan40 = new GridSpan() { Val = 3 };

            tableCellProperties58.Append(tableCellWidth58);
            tableCellProperties58.Append(gridSpan40);

            Paragraph paragraph58 = new Paragraph() { RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties58 = new ParagraphProperties();
            Justification justification21 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties58 = new ParagraphMarkRunProperties();
            RunFonts runFonts78 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize78 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript78 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties58.Append(runFonts78);
            paragraphMarkRunProperties58.Append(fontSize78);
            paragraphMarkRunProperties58.Append(fontSizeComplexScript78);

            paragraphProperties58.Append(justification21);
            paragraphProperties58.Append(paragraphMarkRunProperties58);

            paragraph58.Append(paragraphProperties58);

            tableCell58.Append(tableCellProperties58);
            tableCell58.Append(paragraph58);

            TableCell tableCell59 = new TableCell();

            TableCellProperties tableCellProperties59 = new TableCellProperties();
            TableCellWidth tableCellWidth59 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan41 = new GridSpan() { Val = 3 };

            tableCellProperties59.Append(tableCellWidth59);
            tableCellProperties59.Append(gridSpan41);

            Paragraph paragraph59 = new Paragraph() { RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties59 = new ParagraphProperties();
            Justification justification22 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties59 = new ParagraphMarkRunProperties();
            RunFonts runFonts79 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize79 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript79 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties59.Append(runFonts79);
            paragraphMarkRunProperties59.Append(fontSize79);
            paragraphMarkRunProperties59.Append(fontSizeComplexScript79);

            paragraphProperties59.Append(justification22);
            paragraphProperties59.Append(paragraphMarkRunProperties59);

            paragraph59.Append(paragraphProperties59);

            tableCell59.Append(tableCellProperties59);
            tableCell59.Append(paragraph59);

            TableCell tableCell60 = new TableCell();

            TableCellProperties tableCellProperties60 = new TableCellProperties();
            TableCellWidth tableCellWidth60 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan42 = new GridSpan() { Val = 3 };

            tableCellProperties60.Append(tableCellWidth60);
            tableCellProperties60.Append(gridSpan42);

            Paragraph paragraph60 = new Paragraph() { RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties60 = new ParagraphProperties();
            Justification justification23 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties60 = new ParagraphMarkRunProperties();
            RunFonts runFonts80 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize80 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript80 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties60.Append(runFonts80);
            paragraphMarkRunProperties60.Append(fontSize80);
            paragraphMarkRunProperties60.Append(fontSizeComplexScript80);

            paragraphProperties60.Append(justification23);
            paragraphProperties60.Append(paragraphMarkRunProperties60);

            paragraph60.Append(paragraphProperties60);

            tableCell60.Append(tableCellProperties60);
            tableCell60.Append(paragraph60);

            tableRow16.Append(tableCell58);
            tableRow16.Append(tableCell59);
            tableRow16.Append(tableCell60);

            TableRow tableRow17 = new TableRow() { RsidTableRowMarkRevision = "00396EB4", RsidTableRowAddition = "00396EB4", RsidTableRowProperties = "00FC58FD" };

            TableCell tableCell61 = new TableCell();

            TableCellProperties tableCellProperties61 = new TableCellProperties();
            TableCellWidth tableCellWidth61 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan43 = new GridSpan() { Val = 3 };

            tableCellProperties61.Append(tableCellWidth61);
            tableCellProperties61.Append(gridSpan43);

            Paragraph paragraph61 = new Paragraph() { RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties61 = new ParagraphProperties();
            Justification justification24 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties61 = new ParagraphMarkRunProperties();
            RunFonts runFonts81 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize81 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript81 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties61.Append(runFonts81);
            paragraphMarkRunProperties61.Append(fontSize81);
            paragraphMarkRunProperties61.Append(fontSizeComplexScript81);

            paragraphProperties61.Append(justification24);
            paragraphProperties61.Append(paragraphMarkRunProperties61);

            paragraph61.Append(paragraphProperties61);

            tableCell61.Append(tableCellProperties61);
            tableCell61.Append(paragraph61);

            TableCell tableCell62 = new TableCell();

            TableCellProperties tableCellProperties62 = new TableCellProperties();
            TableCellWidth tableCellWidth62 = new TableCellWidth() { Width = "3115", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan44 = new GridSpan() { Val = 3 };

            tableCellProperties62.Append(tableCellWidth62);
            tableCellProperties62.Append(gridSpan44);

            Paragraph paragraph62 = new Paragraph() { RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties62 = new ParagraphProperties();
            Justification justification25 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties62 = new ParagraphMarkRunProperties();
            RunFonts runFonts82 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize82 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript82 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties62.Append(runFonts82);
            paragraphMarkRunProperties62.Append(fontSize82);
            paragraphMarkRunProperties62.Append(fontSizeComplexScript82);

            paragraphProperties62.Append(justification25);
            paragraphProperties62.Append(paragraphMarkRunProperties62);
            BookmarkStart bookmarkStart1 = new BookmarkStart() { Name = "_GoBack", Id = "0" };
            BookmarkEnd bookmarkEnd1 = new BookmarkEnd() { Id = "0" };

            paragraph62.Append(paragraphProperties62);
            paragraph62.Append(bookmarkStart1);
            paragraph62.Append(bookmarkEnd1);

            tableCell62.Append(tableCellProperties62);
            tableCell62.Append(paragraph62);

            TableCell tableCell63 = new TableCell();

            TableCellProperties tableCellProperties63 = new TableCellProperties();
            TableCellWidth tableCellWidth63 = new TableCellWidth() { Width = "3404", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan45 = new GridSpan() { Val = 3 };

            tableCellProperties63.Append(tableCellWidth63);
            tableCellProperties63.Append(gridSpan45);

            Paragraph paragraph63 = new Paragraph() { RsidParagraphAddition = "00396EB4", RsidParagraphProperties = "00396EB4", RsidRunAdditionDefault = "00396EB4" };

            ParagraphProperties paragraphProperties63 = new ParagraphProperties();
            Justification justification26 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties63 = new ParagraphMarkRunProperties();
            RunFonts runFonts83 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize83 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript83 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties63.Append(runFonts83);
            paragraphMarkRunProperties63.Append(fontSize83);
            paragraphMarkRunProperties63.Append(fontSizeComplexScript83);

            paragraphProperties63.Append(justification26);
            paragraphProperties63.Append(paragraphMarkRunProperties63);

            paragraph63.Append(paragraphProperties63);

            tableCell63.Append(tableCellProperties63);
            tableCell63.Append(paragraph63);

            tableRow17.Append(tableCell61);
            tableRow17.Append(tableCell62);
            tableRow17.Append(tableCell63);

            table1.Append(tableProperties1);
            table1.Append(tableGrid1);
            table1.Append(tableRow1);
            table1.Append(tableRow2);
            table1.Append(tableRow3);
            table1.Append(tableRow4);
            table1.Append(tableRow5);
            table1.Append(tableRow6);
            table1.Append(tableRow7);
            table1.Append(tableRow8);
            table1.Append(tableRow9);
            table1.Append(tableRow10);
            table1.Append(tableRow11);
            table1.Append(tableRow12);
            table1.Append(tableRow13);
            table1.Append(tableRow14);
            table1.Append(tableRow15);
            table1.Append(tableRow16);
            table1.Append(tableRow17);

            Paragraph paragraph64 = new Paragraph() { RsidParagraphAddition = "00EE5B02", RsidParagraphProperties = "00484F2D", RsidRunAdditionDefault = "00EE5B02" };

            ParagraphProperties paragraphProperties64 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties64 = new ParagraphMarkRunProperties();
            RunFonts runFonts84 = new RunFonts() { Ascii = "Consolas", HighAnsi = "Consolas", ComplexScript = "Consolas" };
            Color color1 = new Color() { Val = "A31515" };
            FontSize fontSize84 = new FontSize() { Val = "19" };
            FontSizeComplexScript fontSizeComplexScript84 = new FontSizeComplexScript() { Val = "19" };

            paragraphMarkRunProperties64.Append(runFonts84);
            paragraphMarkRunProperties64.Append(color1);
            paragraphMarkRunProperties64.Append(fontSize84);
            paragraphMarkRunProperties64.Append(fontSizeComplexScript84);

            paragraphProperties64.Append(paragraphMarkRunProperties64);

            paragraph64.Append(paragraphProperties64);

            SectionProperties sectionProperties1 = new SectionProperties() { RsidR = "00EE5B02", RsidSect = "00396EB4" };
            PageSize pageSize1 = new PageSize() { Width = (UInt32Value)11906U, Height = (UInt32Value)16838U };
            PageMargin pageMargin1 = new PageMargin() { Top = 1134, Right = (UInt32Value)707U, Bottom = 1134, Left = (UInt32Value)1276U, Header = (UInt32Value)708U, Footer = (UInt32Value)708U, Gutter = (UInt32Value)0U };
            Columns columns1 = new Columns() { Space = "708" };
            DocGrid docGrid1 = new DocGrid() { LinePitch = 360 };

            sectionProperties1.Append(pageSize1);
            sectionProperties1.Append(pageMargin1);
            sectionProperties1.Append(columns1);
            sectionProperties1.Append(docGrid1);

            body1.Append(table1);
            body1.Append(paragraph64);
            body1.Append(sectionProperties1);

            document1.Append(body1);

            mainDocumentPart1.Document = document1;
        }

        // Generates content of webSettingsPart1.
        private void GenerateWebSettingsPart1Content(WebSettingsPart webSettingsPart1)
        {
            WebSettings webSettings1 = new WebSettings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se" } };
            webSettings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            webSettings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            webSettings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            webSettings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            webSettings1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            webSettings1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
            OptimizeForBrowser optimizeForBrowser1 = new OptimizeForBrowser();
            RelyOnVML relyOnVML1 = new RelyOnVML();
            AllowPNG allowPNG1 = new AllowPNG();

            webSettings1.Append(optimizeForBrowser1);
            webSettings1.Append(relyOnVML1);
            webSettings1.Append(allowPNG1);

            webSettingsPart1.WebSettings = webSettings1;
        }

        // Generates content of documentSettingsPart1.
        private void GenerateDocumentSettingsPart1Content(DocumentSettingsPart documentSettingsPart1)
        {
            Settings settings1 = new Settings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se" } };
            settings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            settings1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            settings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            settings1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            settings1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            settings1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            settings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            settings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            settings1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            settings1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
            settings1.AddNamespaceDeclaration("sl", "http://schemas.openxmlformats.org/schemaLibrary/2006/main");
            Zoom zoom1 = new Zoom() { Percent = "100" };
            ProofState proofState1 = new ProofState() { Spelling = ProofingStateValues.Clean, Grammar = ProofingStateValues.Clean };
            DefaultTabStop defaultTabStop1 = new DefaultTabStop() { Val = 708 };
            CharacterSpacingControl characterSpacingControl1 = new CharacterSpacingControl() { Val = CharacterSpacingValues.DoNotCompress };

            Compatibility compatibility1 = new Compatibility();
            CompatibilitySetting compatibilitySetting1 = new CompatibilitySetting() { Name = CompatSettingNameValues.CompatibilityMode, Uri = "http://schemas.microsoft.com/office/word", Val = "15" };
            CompatibilitySetting compatibilitySetting2 = new CompatibilitySetting() { Name = CompatSettingNameValues.OverrideTableStyleFontSizeAndJustification, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
            CompatibilitySetting compatibilitySetting3 = new CompatibilitySetting() { Name = CompatSettingNameValues.EnableOpenTypeFeatures, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
            CompatibilitySetting compatibilitySetting4 = new CompatibilitySetting() { Name = CompatSettingNameValues.DoNotFlipMirrorIndents, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };
            CompatibilitySetting compatibilitySetting5 = new CompatibilitySetting() { Name = new EnumValue<CompatSettingNameValues>() { InnerText = "differentiateMultirowTableHeaders" }, Uri = "http://schemas.microsoft.com/office/word", Val = "1" };

            compatibility1.Append(compatibilitySetting1);
            compatibility1.Append(compatibilitySetting2);
            compatibility1.Append(compatibilitySetting3);
            compatibility1.Append(compatibilitySetting4);
            compatibility1.Append(compatibilitySetting5);

            Rsids rsids1 = new Rsids();
            RsidRoot rsidRoot1 = new RsidRoot() { Val = "007205D7" };
            Rsid rsid1 = new Rsid() { Val = "00195F14" };
            Rsid rsid2 = new Rsid() { Val = "00320B06" };
            Rsid rsid3 = new Rsid() { Val = "00396EB4" };
            Rsid rsid4 = new Rsid() { Val = "004358AD" };
            Rsid rsid5 = new Rsid() { Val = "00484F2D" };
            Rsid rsid6 = new Rsid() { Val = "004F4AA4" };
            Rsid rsid7 = new Rsid() { Val = "00650FA0" };
            Rsid rsid8 = new Rsid() { Val = "0069704B" };
            Rsid rsid9 = new Rsid() { Val = "00705AF3" };
            Rsid rsid10 = new Rsid() { Val = "007205D7" };
            Rsid rsid11 = new Rsid() { Val = "00762314" };
            Rsid rsid12 = new Rsid() { Val = "0086407E" };
            Rsid rsid13 = new Rsid() { Val = "008C5184" };
            Rsid rsid14 = new Rsid() { Val = "00935FB2" };
            Rsid rsid15 = new Rsid() { Val = "00B67540" };
            Rsid rsid16 = new Rsid() { Val = "00EC587C" };
            Rsid rsid17 = new Rsid() { Val = "00EE5B02" };
            Rsid rsid18 = new Rsid() { Val = "00FB0112" };
            Rsid rsid19 = new Rsid() { Val = "00FB6E38" };
            Rsid rsid20 = new Rsid() { Val = "00FC58FD" };

            rsids1.Append(rsidRoot1);
            rsids1.Append(rsid1);
            rsids1.Append(rsid2);
            rsids1.Append(rsid3);
            rsids1.Append(rsid4);
            rsids1.Append(rsid5);
            rsids1.Append(rsid6);
            rsids1.Append(rsid7);
            rsids1.Append(rsid8);
            rsids1.Append(rsid9);
            rsids1.Append(rsid10);
            rsids1.Append(rsid11);
            rsids1.Append(rsid12);
            rsids1.Append(rsid13);
            rsids1.Append(rsid14);
            rsids1.Append(rsid15);
            rsids1.Append(rsid16);
            rsids1.Append(rsid17);
            rsids1.Append(rsid18);
            rsids1.Append(rsid19);
            rsids1.Append(rsid20);

            M.MathProperties mathProperties1 = new M.MathProperties();
            M.MathFont mathFont1 = new M.MathFont() { Val = "Cambria Math" };
            M.BreakBinary breakBinary1 = new M.BreakBinary() { Val = M.BreakBinaryOperatorValues.Before };
            M.BreakBinarySubtraction breakBinarySubtraction1 = new M.BreakBinarySubtraction() { Val = M.BreakBinarySubtractionValues.MinusMinus };
            M.SmallFraction smallFraction1 = new M.SmallFraction() { Val = M.BooleanValues.Zero };
            M.DisplayDefaults displayDefaults1 = new M.DisplayDefaults();
            M.LeftMargin leftMargin1 = new M.LeftMargin() { Val = (UInt32Value)0U };
            M.RightMargin rightMargin1 = new M.RightMargin() { Val = (UInt32Value)0U };
            M.DefaultJustification defaultJustification1 = new M.DefaultJustification() { Val = M.JustificationValues.CenterGroup };
            M.WrapIndent wrapIndent1 = new M.WrapIndent() { Val = (UInt32Value)1440U };
            M.IntegralLimitLocation integralLimitLocation1 = new M.IntegralLimitLocation() { Val = M.LimitLocationValues.SubscriptSuperscript };
            M.NaryLimitLocation naryLimitLocation1 = new M.NaryLimitLocation() { Val = M.LimitLocationValues.UnderOver };

            mathProperties1.Append(mathFont1);
            mathProperties1.Append(breakBinary1);
            mathProperties1.Append(breakBinarySubtraction1);
            mathProperties1.Append(smallFraction1);
            mathProperties1.Append(displayDefaults1);
            mathProperties1.Append(leftMargin1);
            mathProperties1.Append(rightMargin1);
            mathProperties1.Append(defaultJustification1);
            mathProperties1.Append(wrapIndent1);
            mathProperties1.Append(integralLimitLocation1);
            mathProperties1.Append(naryLimitLocation1);
            ThemeFontLanguages themeFontLanguages1 = new ThemeFontLanguages() { Val = "ru-RU" };
            ColorSchemeMapping colorSchemeMapping1 = new ColorSchemeMapping() { Background1 = ColorSchemeIndexValues.Light1, Text1 = ColorSchemeIndexValues.Dark1, Background2 = ColorSchemeIndexValues.Light2, Text2 = ColorSchemeIndexValues.Dark2, Accent1 = ColorSchemeIndexValues.Accent1, Accent2 = ColorSchemeIndexValues.Accent2, Accent3 = ColorSchemeIndexValues.Accent3, Accent4 = ColorSchemeIndexValues.Accent4, Accent5 = ColorSchemeIndexValues.Accent5, Accent6 = ColorSchemeIndexValues.Accent6, Hyperlink = ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = ColorSchemeIndexValues.FollowedHyperlink };

            ShapeDefaults shapeDefaults1 = new ShapeDefaults();
            Ovml.ShapeDefaults shapeDefaults2 = new Ovml.ShapeDefaults() { Extension = V.ExtensionHandlingBehaviorValues.Edit, MaxShapeId = 1026 };

            Ovml.ShapeLayout shapeLayout1 = new Ovml.ShapeLayout() { Extension = V.ExtensionHandlingBehaviorValues.Edit };
            Ovml.ShapeIdMap shapeIdMap1 = new Ovml.ShapeIdMap() { Extension = V.ExtensionHandlingBehaviorValues.Edit, Data = "1" };

            shapeLayout1.Append(shapeIdMap1);

            shapeDefaults1.Append(shapeDefaults2);
            shapeDefaults1.Append(shapeLayout1);
            DecimalSymbol decimalSymbol1 = new DecimalSymbol() { Val = "," };
            ListSeparator listSeparator1 = new ListSeparator() { Val = ";" };
            OpenXmlUnknownElement openXmlUnknownElement1 = OpenXmlUnknownElement.CreateOpenXmlUnknownElement("<w15:chartTrackingRefBased xmlns:w15=\"http://schemas.microsoft.com/office/word/2012/wordml\" />");

            OpenXmlUnknownElement openXmlUnknownElement2 = OpenXmlUnknownElement.CreateOpenXmlUnknownElement("<w15:docId w15:val=\"{7EB55555-294B-4470-BF39-EDBDA1B262A2}\" xmlns:w15=\"http://schemas.microsoft.com/office/word/2012/wordml\" />");

            settings1.Append(zoom1);
            settings1.Append(proofState1);
            settings1.Append(defaultTabStop1);
            settings1.Append(characterSpacingControl1);
            settings1.Append(compatibility1);
            settings1.Append(rsids1);
            settings1.Append(mathProperties1);
            settings1.Append(themeFontLanguages1);
            settings1.Append(colorSchemeMapping1);
            settings1.Append(shapeDefaults1);
            settings1.Append(decimalSymbol1);
            settings1.Append(listSeparator1);
            settings1.Append(openXmlUnknownElement1);
            settings1.Append(openXmlUnknownElement2);

            documentSettingsPart1.Settings = settings1;
        }

        // Generates content of styleDefinitionsPart1.
        private void GenerateStyleDefinitionsPart1Content(StyleDefinitionsPart styleDefinitionsPart1)
        {
            Styles styles1 = new Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se" } };
            styles1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            styles1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            styles1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            styles1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            styles1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            styles1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");

            DocDefaults docDefaults1 = new DocDefaults();

            RunPropertiesDefault runPropertiesDefault1 = new RunPropertiesDefault();

            RunPropertiesBaseStyle runPropertiesBaseStyle1 = new RunPropertiesBaseStyle();
            RunFonts runFonts85 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi, EastAsiaTheme = ThemeFontValues.MinorHighAnsi, ComplexScriptTheme = ThemeFontValues.MinorBidi };
            FontSize fontSize85 = new FontSize() { Val = "22" };
            FontSizeComplexScript fontSizeComplexScript85 = new FontSizeComplexScript() { Val = "22" };
            Languages languages2 = new Languages() { Val = "ru-RU", EastAsia = "en-US", Bidi = "ar-SA" };

            runPropertiesBaseStyle1.Append(runFonts85);
            runPropertiesBaseStyle1.Append(fontSize85);
            runPropertiesBaseStyle1.Append(fontSizeComplexScript85);
            runPropertiesBaseStyle1.Append(languages2);

            runPropertiesDefault1.Append(runPropertiesBaseStyle1);

            ParagraphPropertiesDefault paragraphPropertiesDefault1 = new ParagraphPropertiesDefault();

            ParagraphPropertiesBaseStyle paragraphPropertiesBaseStyle1 = new ParagraphPropertiesBaseStyle();
            SpacingBetweenLines spacingBetweenLines1 = new SpacingBetweenLines() { After = "160", Line = "259", LineRule = LineSpacingRuleValues.Auto };

            paragraphPropertiesBaseStyle1.Append(spacingBetweenLines1);

            paragraphPropertiesDefault1.Append(paragraphPropertiesBaseStyle1);

            docDefaults1.Append(runPropertiesDefault1);
            docDefaults1.Append(paragraphPropertiesDefault1);

            LatentStyles latentStyles1 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 99, DefaultSemiHidden = false, DefaultUnhideWhenUsed = false, DefaultPrimaryStyle = false, Count = 371 };
            LatentStyleExceptionInfo latentStyleExceptionInfo1 = new LatentStyleExceptionInfo() { Name = "Normal", UiPriority = 0, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo2 = new LatentStyleExceptionInfo() { Name = "heading 1", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo3 = new LatentStyleExceptionInfo() { Name = "heading 2", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo4 = new LatentStyleExceptionInfo() { Name = "heading 3", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo5 = new LatentStyleExceptionInfo() { Name = "heading 4", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo6 = new LatentStyleExceptionInfo() { Name = "heading 5", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo7 = new LatentStyleExceptionInfo() { Name = "heading 6", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo8 = new LatentStyleExceptionInfo() { Name = "heading 7", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo9 = new LatentStyleExceptionInfo() { Name = "heading 8", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo10 = new LatentStyleExceptionInfo() { Name = "heading 9", UiPriority = 9, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo11 = new LatentStyleExceptionInfo() { Name = "index 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo12 = new LatentStyleExceptionInfo() { Name = "index 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo13 = new LatentStyleExceptionInfo() { Name = "index 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo14 = new LatentStyleExceptionInfo() { Name = "index 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo15 = new LatentStyleExceptionInfo() { Name = "index 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo16 = new LatentStyleExceptionInfo() { Name = "index 6", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo17 = new LatentStyleExceptionInfo() { Name = "index 7", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo18 = new LatentStyleExceptionInfo() { Name = "index 8", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo19 = new LatentStyleExceptionInfo() { Name = "index 9", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo20 = new LatentStyleExceptionInfo() { Name = "toc 1", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo21 = new LatentStyleExceptionInfo() { Name = "toc 2", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo22 = new LatentStyleExceptionInfo() { Name = "toc 3", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo23 = new LatentStyleExceptionInfo() { Name = "toc 4", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo24 = new LatentStyleExceptionInfo() { Name = "toc 5", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo25 = new LatentStyleExceptionInfo() { Name = "toc 6", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo26 = new LatentStyleExceptionInfo() { Name = "toc 7", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo27 = new LatentStyleExceptionInfo() { Name = "toc 8", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo28 = new LatentStyleExceptionInfo() { Name = "toc 9", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo29 = new LatentStyleExceptionInfo() { Name = "Normal Indent", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo30 = new LatentStyleExceptionInfo() { Name = "footnote text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo31 = new LatentStyleExceptionInfo() { Name = "annotation text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo32 = new LatentStyleExceptionInfo() { Name = "header", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo33 = new LatentStyleExceptionInfo() { Name = "footer", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo34 = new LatentStyleExceptionInfo() { Name = "index heading", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo35 = new LatentStyleExceptionInfo() { Name = "caption", UiPriority = 35, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo36 = new LatentStyleExceptionInfo() { Name = "table of figures", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo37 = new LatentStyleExceptionInfo() { Name = "envelope address", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo38 = new LatentStyleExceptionInfo() { Name = "envelope return", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo39 = new LatentStyleExceptionInfo() { Name = "footnote reference", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo40 = new LatentStyleExceptionInfo() { Name = "annotation reference", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo41 = new LatentStyleExceptionInfo() { Name = "line number", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo42 = new LatentStyleExceptionInfo() { Name = "page number", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo43 = new LatentStyleExceptionInfo() { Name = "endnote reference", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo44 = new LatentStyleExceptionInfo() { Name = "endnote text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo45 = new LatentStyleExceptionInfo() { Name = "table of authorities", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo46 = new LatentStyleExceptionInfo() { Name = "macro", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo47 = new LatentStyleExceptionInfo() { Name = "toa heading", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo48 = new LatentStyleExceptionInfo() { Name = "List", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo49 = new LatentStyleExceptionInfo() { Name = "List Bullet", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo50 = new LatentStyleExceptionInfo() { Name = "List Number", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo51 = new LatentStyleExceptionInfo() { Name = "List 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo52 = new LatentStyleExceptionInfo() { Name = "List 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo53 = new LatentStyleExceptionInfo() { Name = "List 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo54 = new LatentStyleExceptionInfo() { Name = "List 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo55 = new LatentStyleExceptionInfo() { Name = "List Bullet 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo56 = new LatentStyleExceptionInfo() { Name = "List Bullet 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo57 = new LatentStyleExceptionInfo() { Name = "List Bullet 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo58 = new LatentStyleExceptionInfo() { Name = "List Bullet 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo59 = new LatentStyleExceptionInfo() { Name = "List Number 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo60 = new LatentStyleExceptionInfo() { Name = "List Number 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo61 = new LatentStyleExceptionInfo() { Name = "List Number 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo62 = new LatentStyleExceptionInfo() { Name = "List Number 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo63 = new LatentStyleExceptionInfo() { Name = "Title", UiPriority = 10, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo64 = new LatentStyleExceptionInfo() { Name = "Closing", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo65 = new LatentStyleExceptionInfo() { Name = "Signature", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo66 = new LatentStyleExceptionInfo() { Name = "Default Paragraph Font", UiPriority = 1, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo67 = new LatentStyleExceptionInfo() { Name = "Body Text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo68 = new LatentStyleExceptionInfo() { Name = "Body Text Indent", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo69 = new LatentStyleExceptionInfo() { Name = "List Continue", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo70 = new LatentStyleExceptionInfo() { Name = "List Continue 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo71 = new LatentStyleExceptionInfo() { Name = "List Continue 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo72 = new LatentStyleExceptionInfo() { Name = "List Continue 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo73 = new LatentStyleExceptionInfo() { Name = "List Continue 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo74 = new LatentStyleExceptionInfo() { Name = "Message Header", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo75 = new LatentStyleExceptionInfo() { Name = "Subtitle", UiPriority = 11, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo76 = new LatentStyleExceptionInfo() { Name = "Salutation", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo77 = new LatentStyleExceptionInfo() { Name = "Date", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo78 = new LatentStyleExceptionInfo() { Name = "Body Text First Indent", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo79 = new LatentStyleExceptionInfo() { Name = "Body Text First Indent 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo80 = new LatentStyleExceptionInfo() { Name = "Note Heading", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo81 = new LatentStyleExceptionInfo() { Name = "Body Text 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo82 = new LatentStyleExceptionInfo() { Name = "Body Text 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo83 = new LatentStyleExceptionInfo() { Name = "Body Text Indent 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo84 = new LatentStyleExceptionInfo() { Name = "Body Text Indent 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo85 = new LatentStyleExceptionInfo() { Name = "Block Text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo86 = new LatentStyleExceptionInfo() { Name = "Hyperlink", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo87 = new LatentStyleExceptionInfo() { Name = "FollowedHyperlink", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo88 = new LatentStyleExceptionInfo() { Name = "Strong", UiPriority = 22, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo89 = new LatentStyleExceptionInfo() { Name = "Emphasis", UiPriority = 20, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo90 = new LatentStyleExceptionInfo() { Name = "Document Map", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo91 = new LatentStyleExceptionInfo() { Name = "Plain Text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo92 = new LatentStyleExceptionInfo() { Name = "E-mail Signature", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo93 = new LatentStyleExceptionInfo() { Name = "HTML Top of Form", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo94 = new LatentStyleExceptionInfo() { Name = "HTML Bottom of Form", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo95 = new LatentStyleExceptionInfo() { Name = "Normal (Web)", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo96 = new LatentStyleExceptionInfo() { Name = "HTML Acronym", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo97 = new LatentStyleExceptionInfo() { Name = "HTML Address", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo98 = new LatentStyleExceptionInfo() { Name = "HTML Cite", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo99 = new LatentStyleExceptionInfo() { Name = "HTML Code", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo100 = new LatentStyleExceptionInfo() { Name = "HTML Definition", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo101 = new LatentStyleExceptionInfo() { Name = "HTML Keyboard", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo102 = new LatentStyleExceptionInfo() { Name = "HTML Preformatted", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo103 = new LatentStyleExceptionInfo() { Name = "HTML Sample", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo104 = new LatentStyleExceptionInfo() { Name = "HTML Typewriter", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo105 = new LatentStyleExceptionInfo() { Name = "HTML Variable", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo106 = new LatentStyleExceptionInfo() { Name = "Normal Table", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo107 = new LatentStyleExceptionInfo() { Name = "annotation subject", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo108 = new LatentStyleExceptionInfo() { Name = "No List", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo109 = new LatentStyleExceptionInfo() { Name = "Outline List 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo110 = new LatentStyleExceptionInfo() { Name = "Outline List 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo111 = new LatentStyleExceptionInfo() { Name = "Outline List 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo112 = new LatentStyleExceptionInfo() { Name = "Table Simple 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo113 = new LatentStyleExceptionInfo() { Name = "Table Simple 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo114 = new LatentStyleExceptionInfo() { Name = "Table Simple 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo115 = new LatentStyleExceptionInfo() { Name = "Table Classic 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo116 = new LatentStyleExceptionInfo() { Name = "Table Classic 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo117 = new LatentStyleExceptionInfo() { Name = "Table Classic 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo118 = new LatentStyleExceptionInfo() { Name = "Table Classic 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo119 = new LatentStyleExceptionInfo() { Name = "Table Colorful 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo120 = new LatentStyleExceptionInfo() { Name = "Table Colorful 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo121 = new LatentStyleExceptionInfo() { Name = "Table Colorful 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo122 = new LatentStyleExceptionInfo() { Name = "Table Columns 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo123 = new LatentStyleExceptionInfo() { Name = "Table Columns 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo124 = new LatentStyleExceptionInfo() { Name = "Table Columns 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo125 = new LatentStyleExceptionInfo() { Name = "Table Columns 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo126 = new LatentStyleExceptionInfo() { Name = "Table Columns 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo127 = new LatentStyleExceptionInfo() { Name = "Table Grid 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo128 = new LatentStyleExceptionInfo() { Name = "Table Grid 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo129 = new LatentStyleExceptionInfo() { Name = "Table Grid 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo130 = new LatentStyleExceptionInfo() { Name = "Table Grid 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo131 = new LatentStyleExceptionInfo() { Name = "Table Grid 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo132 = new LatentStyleExceptionInfo() { Name = "Table Grid 6", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo133 = new LatentStyleExceptionInfo() { Name = "Table Grid 7", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo134 = new LatentStyleExceptionInfo() { Name = "Table Grid 8", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo135 = new LatentStyleExceptionInfo() { Name = "Table List 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo136 = new LatentStyleExceptionInfo() { Name = "Table List 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo137 = new LatentStyleExceptionInfo() { Name = "Table List 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo138 = new LatentStyleExceptionInfo() { Name = "Table List 4", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo139 = new LatentStyleExceptionInfo() { Name = "Table List 5", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo140 = new LatentStyleExceptionInfo() { Name = "Table List 6", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo141 = new LatentStyleExceptionInfo() { Name = "Table List 7", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo142 = new LatentStyleExceptionInfo() { Name = "Table List 8", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo143 = new LatentStyleExceptionInfo() { Name = "Table 3D effects 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo144 = new LatentStyleExceptionInfo() { Name = "Table 3D effects 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo145 = new LatentStyleExceptionInfo() { Name = "Table 3D effects 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo146 = new LatentStyleExceptionInfo() { Name = "Table Contemporary", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo147 = new LatentStyleExceptionInfo() { Name = "Table Elegant", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo148 = new LatentStyleExceptionInfo() { Name = "Table Professional", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo149 = new LatentStyleExceptionInfo() { Name = "Table Subtle 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo150 = new LatentStyleExceptionInfo() { Name = "Table Subtle 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo151 = new LatentStyleExceptionInfo() { Name = "Table Web 1", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo152 = new LatentStyleExceptionInfo() { Name = "Table Web 2", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo153 = new LatentStyleExceptionInfo() { Name = "Table Web 3", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo154 = new LatentStyleExceptionInfo() { Name = "Balloon Text", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo155 = new LatentStyleExceptionInfo() { Name = "Table Grid", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo156 = new LatentStyleExceptionInfo() { Name = "Table Theme", SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo157 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", SemiHidden = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo158 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo159 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo160 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo161 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo162 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo163 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo164 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo165 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo166 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo167 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo168 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo169 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo170 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo171 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo172 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo173 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo174 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo175 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo176 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo177 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo178 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo179 = new LatentStyleExceptionInfo() { Name = "Revision", SemiHidden = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo180 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo181 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo182 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo183 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo184 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo185 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo186 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo187 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo188 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo189 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo190 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo191 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo192 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo193 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo194 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo195 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo196 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo197 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo198 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo199 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo200 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo201 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo202 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo203 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo204 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo205 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo206 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo207 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo208 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo209 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo210 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo211 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo212 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo213 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo214 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo215 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo216 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo217 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo218 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo219 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo220 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo221 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo222 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo223 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo224 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo225 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo226 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo227 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo228 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo229 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo230 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo231 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo232 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo233 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo234 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo235 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo236 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo237 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo238 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo239 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo240 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo241 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo242 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo243 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo244 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo245 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo246 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo247 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo248 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo249 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo250 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo251 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo252 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo253 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo254 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo255 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo256 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo257 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo258 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo259 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo260 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo261 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo262 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo263 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo264 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo265 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo266 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo267 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo268 = new LatentStyleExceptionInfo() { Name = "Plain Table 1", UiPriority = 41 };
            LatentStyleExceptionInfo latentStyleExceptionInfo269 = new LatentStyleExceptionInfo() { Name = "Plain Table 2", UiPriority = 42 };
            LatentStyleExceptionInfo latentStyleExceptionInfo270 = new LatentStyleExceptionInfo() { Name = "Plain Table 3", UiPriority = 43 };
            LatentStyleExceptionInfo latentStyleExceptionInfo271 = new LatentStyleExceptionInfo() { Name = "Plain Table 4", UiPriority = 44 };
            LatentStyleExceptionInfo latentStyleExceptionInfo272 = new LatentStyleExceptionInfo() { Name = "Plain Table 5", UiPriority = 45 };
            LatentStyleExceptionInfo latentStyleExceptionInfo273 = new LatentStyleExceptionInfo() { Name = "Grid Table Light", UiPriority = 40 };
            LatentStyleExceptionInfo latentStyleExceptionInfo274 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo275 = new LatentStyleExceptionInfo() { Name = "Grid Table 2", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo276 = new LatentStyleExceptionInfo() { Name = "Grid Table 3", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo277 = new LatentStyleExceptionInfo() { Name = "Grid Table 4", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo278 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo279 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo280 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo281 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 1", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo282 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 1", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo283 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 1", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo284 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 1", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo285 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 1", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo286 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 1", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo287 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 1", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo288 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 2", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo289 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 2", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo290 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 2", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo291 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 2", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo292 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 2", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo293 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 2", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo294 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 2", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo295 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 3", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo296 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 3", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo297 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 3", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo298 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 3", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo299 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 3", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo300 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 3", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo301 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 3", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo302 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 4", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo303 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 4", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo304 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 4", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo305 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 4", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo306 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 4", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo307 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 4", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo308 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 4", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo309 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 5", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo310 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 5", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo311 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 5", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo312 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 5", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo313 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 5", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo314 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 5", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo315 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 5", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo316 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 6", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo317 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 6", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo318 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 6", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo319 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 6", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo320 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 6", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo321 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 6", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo322 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 6", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo323 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo324 = new LatentStyleExceptionInfo() { Name = "List Table 2", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo325 = new LatentStyleExceptionInfo() { Name = "List Table 3", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo326 = new LatentStyleExceptionInfo() { Name = "List Table 4", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo327 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo328 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo329 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo330 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 1", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo331 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 1", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo332 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 1", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo333 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 1", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo334 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 1", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo335 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 1", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo336 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 1", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo337 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 2", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo338 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 2", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo339 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 2", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo340 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 2", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo341 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 2", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo342 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 2", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo343 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 2", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo344 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 3", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo345 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 3", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo346 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 3", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo347 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 3", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo348 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 3", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo349 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 3", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo350 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 3", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo351 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 4", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo352 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 4", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo353 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 4", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo354 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 4", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo355 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 4", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo356 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 4", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo357 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 4", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo358 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 5", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo359 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 5", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo360 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 5", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo361 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 5", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo362 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 5", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo363 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 5", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo364 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 5", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo365 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 6", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo366 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 6", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo367 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 6", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo368 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 6", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo369 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 6", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo370 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 6", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo371 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 6", UiPriority = 52 };

            latentStyles1.Append(latentStyleExceptionInfo1);
            latentStyles1.Append(latentStyleExceptionInfo2);
            latentStyles1.Append(latentStyleExceptionInfo3);
            latentStyles1.Append(latentStyleExceptionInfo4);
            latentStyles1.Append(latentStyleExceptionInfo5);
            latentStyles1.Append(latentStyleExceptionInfo6);
            latentStyles1.Append(latentStyleExceptionInfo7);
            latentStyles1.Append(latentStyleExceptionInfo8);
            latentStyles1.Append(latentStyleExceptionInfo9);
            latentStyles1.Append(latentStyleExceptionInfo10);
            latentStyles1.Append(latentStyleExceptionInfo11);
            latentStyles1.Append(latentStyleExceptionInfo12);
            latentStyles1.Append(latentStyleExceptionInfo13);
            latentStyles1.Append(latentStyleExceptionInfo14);
            latentStyles1.Append(latentStyleExceptionInfo15);
            latentStyles1.Append(latentStyleExceptionInfo16);
            latentStyles1.Append(latentStyleExceptionInfo17);
            latentStyles1.Append(latentStyleExceptionInfo18);
            latentStyles1.Append(latentStyleExceptionInfo19);
            latentStyles1.Append(latentStyleExceptionInfo20);
            latentStyles1.Append(latentStyleExceptionInfo21);
            latentStyles1.Append(latentStyleExceptionInfo22);
            latentStyles1.Append(latentStyleExceptionInfo23);
            latentStyles1.Append(latentStyleExceptionInfo24);
            latentStyles1.Append(latentStyleExceptionInfo25);
            latentStyles1.Append(latentStyleExceptionInfo26);
            latentStyles1.Append(latentStyleExceptionInfo27);
            latentStyles1.Append(latentStyleExceptionInfo28);
            latentStyles1.Append(latentStyleExceptionInfo29);
            latentStyles1.Append(latentStyleExceptionInfo30);
            latentStyles1.Append(latentStyleExceptionInfo31);
            latentStyles1.Append(latentStyleExceptionInfo32);
            latentStyles1.Append(latentStyleExceptionInfo33);
            latentStyles1.Append(latentStyleExceptionInfo34);
            latentStyles1.Append(latentStyleExceptionInfo35);
            latentStyles1.Append(latentStyleExceptionInfo36);
            latentStyles1.Append(latentStyleExceptionInfo37);
            latentStyles1.Append(latentStyleExceptionInfo38);
            latentStyles1.Append(latentStyleExceptionInfo39);
            latentStyles1.Append(latentStyleExceptionInfo40);
            latentStyles1.Append(latentStyleExceptionInfo41);
            latentStyles1.Append(latentStyleExceptionInfo42);
            latentStyles1.Append(latentStyleExceptionInfo43);
            latentStyles1.Append(latentStyleExceptionInfo44);
            latentStyles1.Append(latentStyleExceptionInfo45);
            latentStyles1.Append(latentStyleExceptionInfo46);
            latentStyles1.Append(latentStyleExceptionInfo47);
            latentStyles1.Append(latentStyleExceptionInfo48);
            latentStyles1.Append(latentStyleExceptionInfo49);
            latentStyles1.Append(latentStyleExceptionInfo50);
            latentStyles1.Append(latentStyleExceptionInfo51);
            latentStyles1.Append(latentStyleExceptionInfo52);
            latentStyles1.Append(latentStyleExceptionInfo53);
            latentStyles1.Append(latentStyleExceptionInfo54);
            latentStyles1.Append(latentStyleExceptionInfo55);
            latentStyles1.Append(latentStyleExceptionInfo56);
            latentStyles1.Append(latentStyleExceptionInfo57);
            latentStyles1.Append(latentStyleExceptionInfo58);
            latentStyles1.Append(latentStyleExceptionInfo59);
            latentStyles1.Append(latentStyleExceptionInfo60);
            latentStyles1.Append(latentStyleExceptionInfo61);
            latentStyles1.Append(latentStyleExceptionInfo62);
            latentStyles1.Append(latentStyleExceptionInfo63);
            latentStyles1.Append(latentStyleExceptionInfo64);
            latentStyles1.Append(latentStyleExceptionInfo65);
            latentStyles1.Append(latentStyleExceptionInfo66);
            latentStyles1.Append(latentStyleExceptionInfo67);
            latentStyles1.Append(latentStyleExceptionInfo68);
            latentStyles1.Append(latentStyleExceptionInfo69);
            latentStyles1.Append(latentStyleExceptionInfo70);
            latentStyles1.Append(latentStyleExceptionInfo71);
            latentStyles1.Append(latentStyleExceptionInfo72);
            latentStyles1.Append(latentStyleExceptionInfo73);
            latentStyles1.Append(latentStyleExceptionInfo74);
            latentStyles1.Append(latentStyleExceptionInfo75);
            latentStyles1.Append(latentStyleExceptionInfo76);
            latentStyles1.Append(latentStyleExceptionInfo77);
            latentStyles1.Append(latentStyleExceptionInfo78);
            latentStyles1.Append(latentStyleExceptionInfo79);
            latentStyles1.Append(latentStyleExceptionInfo80);
            latentStyles1.Append(latentStyleExceptionInfo81);
            latentStyles1.Append(latentStyleExceptionInfo82);
            latentStyles1.Append(latentStyleExceptionInfo83);
            latentStyles1.Append(latentStyleExceptionInfo84);
            latentStyles1.Append(latentStyleExceptionInfo85);
            latentStyles1.Append(latentStyleExceptionInfo86);
            latentStyles1.Append(latentStyleExceptionInfo87);
            latentStyles1.Append(latentStyleExceptionInfo88);
            latentStyles1.Append(latentStyleExceptionInfo89);
            latentStyles1.Append(latentStyleExceptionInfo90);
            latentStyles1.Append(latentStyleExceptionInfo91);
            latentStyles1.Append(latentStyleExceptionInfo92);
            latentStyles1.Append(latentStyleExceptionInfo93);
            latentStyles1.Append(latentStyleExceptionInfo94);
            latentStyles1.Append(latentStyleExceptionInfo95);
            latentStyles1.Append(latentStyleExceptionInfo96);
            latentStyles1.Append(latentStyleExceptionInfo97);
            latentStyles1.Append(latentStyleExceptionInfo98);
            latentStyles1.Append(latentStyleExceptionInfo99);
            latentStyles1.Append(latentStyleExceptionInfo100);
            latentStyles1.Append(latentStyleExceptionInfo101);
            latentStyles1.Append(latentStyleExceptionInfo102);
            latentStyles1.Append(latentStyleExceptionInfo103);
            latentStyles1.Append(latentStyleExceptionInfo104);
            latentStyles1.Append(latentStyleExceptionInfo105);
            latentStyles1.Append(latentStyleExceptionInfo106);
            latentStyles1.Append(latentStyleExceptionInfo107);
            latentStyles1.Append(latentStyleExceptionInfo108);
            latentStyles1.Append(latentStyleExceptionInfo109);
            latentStyles1.Append(latentStyleExceptionInfo110);
            latentStyles1.Append(latentStyleExceptionInfo111);
            latentStyles1.Append(latentStyleExceptionInfo112);
            latentStyles1.Append(latentStyleExceptionInfo113);
            latentStyles1.Append(latentStyleExceptionInfo114);
            latentStyles1.Append(latentStyleExceptionInfo115);
            latentStyles1.Append(latentStyleExceptionInfo116);
            latentStyles1.Append(latentStyleExceptionInfo117);
            latentStyles1.Append(latentStyleExceptionInfo118);
            latentStyles1.Append(latentStyleExceptionInfo119);
            latentStyles1.Append(latentStyleExceptionInfo120);
            latentStyles1.Append(latentStyleExceptionInfo121);
            latentStyles1.Append(latentStyleExceptionInfo122);
            latentStyles1.Append(latentStyleExceptionInfo123);
            latentStyles1.Append(latentStyleExceptionInfo124);
            latentStyles1.Append(latentStyleExceptionInfo125);
            latentStyles1.Append(latentStyleExceptionInfo126);
            latentStyles1.Append(latentStyleExceptionInfo127);
            latentStyles1.Append(latentStyleExceptionInfo128);
            latentStyles1.Append(latentStyleExceptionInfo129);
            latentStyles1.Append(latentStyleExceptionInfo130);
            latentStyles1.Append(latentStyleExceptionInfo131);
            latentStyles1.Append(latentStyleExceptionInfo132);
            latentStyles1.Append(latentStyleExceptionInfo133);
            latentStyles1.Append(latentStyleExceptionInfo134);
            latentStyles1.Append(latentStyleExceptionInfo135);
            latentStyles1.Append(latentStyleExceptionInfo136);
            latentStyles1.Append(latentStyleExceptionInfo137);
            latentStyles1.Append(latentStyleExceptionInfo138);
            latentStyles1.Append(latentStyleExceptionInfo139);
            latentStyles1.Append(latentStyleExceptionInfo140);
            latentStyles1.Append(latentStyleExceptionInfo141);
            latentStyles1.Append(latentStyleExceptionInfo142);
            latentStyles1.Append(latentStyleExceptionInfo143);
            latentStyles1.Append(latentStyleExceptionInfo144);
            latentStyles1.Append(latentStyleExceptionInfo145);
            latentStyles1.Append(latentStyleExceptionInfo146);
            latentStyles1.Append(latentStyleExceptionInfo147);
            latentStyles1.Append(latentStyleExceptionInfo148);
            latentStyles1.Append(latentStyleExceptionInfo149);
            latentStyles1.Append(latentStyleExceptionInfo150);
            latentStyles1.Append(latentStyleExceptionInfo151);
            latentStyles1.Append(latentStyleExceptionInfo152);
            latentStyles1.Append(latentStyleExceptionInfo153);
            latentStyles1.Append(latentStyleExceptionInfo154);
            latentStyles1.Append(latentStyleExceptionInfo155);
            latentStyles1.Append(latentStyleExceptionInfo156);
            latentStyles1.Append(latentStyleExceptionInfo157);
            latentStyles1.Append(latentStyleExceptionInfo158);
            latentStyles1.Append(latentStyleExceptionInfo159);
            latentStyles1.Append(latentStyleExceptionInfo160);
            latentStyles1.Append(latentStyleExceptionInfo161);
            latentStyles1.Append(latentStyleExceptionInfo162);
            latentStyles1.Append(latentStyleExceptionInfo163);
            latentStyles1.Append(latentStyleExceptionInfo164);
            latentStyles1.Append(latentStyleExceptionInfo165);
            latentStyles1.Append(latentStyleExceptionInfo166);
            latentStyles1.Append(latentStyleExceptionInfo167);
            latentStyles1.Append(latentStyleExceptionInfo168);
            latentStyles1.Append(latentStyleExceptionInfo169);
            latentStyles1.Append(latentStyleExceptionInfo170);
            latentStyles1.Append(latentStyleExceptionInfo171);
            latentStyles1.Append(latentStyleExceptionInfo172);
            latentStyles1.Append(latentStyleExceptionInfo173);
            latentStyles1.Append(latentStyleExceptionInfo174);
            latentStyles1.Append(latentStyleExceptionInfo175);
            latentStyles1.Append(latentStyleExceptionInfo176);
            latentStyles1.Append(latentStyleExceptionInfo177);
            latentStyles1.Append(latentStyleExceptionInfo178);
            latentStyles1.Append(latentStyleExceptionInfo179);
            latentStyles1.Append(latentStyleExceptionInfo180);
            latentStyles1.Append(latentStyleExceptionInfo181);
            latentStyles1.Append(latentStyleExceptionInfo182);
            latentStyles1.Append(latentStyleExceptionInfo183);
            latentStyles1.Append(latentStyleExceptionInfo184);
            latentStyles1.Append(latentStyleExceptionInfo185);
            latentStyles1.Append(latentStyleExceptionInfo186);
            latentStyles1.Append(latentStyleExceptionInfo187);
            latentStyles1.Append(latentStyleExceptionInfo188);
            latentStyles1.Append(latentStyleExceptionInfo189);
            latentStyles1.Append(latentStyleExceptionInfo190);
            latentStyles1.Append(latentStyleExceptionInfo191);
            latentStyles1.Append(latentStyleExceptionInfo192);
            latentStyles1.Append(latentStyleExceptionInfo193);
            latentStyles1.Append(latentStyleExceptionInfo194);
            latentStyles1.Append(latentStyleExceptionInfo195);
            latentStyles1.Append(latentStyleExceptionInfo196);
            latentStyles1.Append(latentStyleExceptionInfo197);
            latentStyles1.Append(latentStyleExceptionInfo198);
            latentStyles1.Append(latentStyleExceptionInfo199);
            latentStyles1.Append(latentStyleExceptionInfo200);
            latentStyles1.Append(latentStyleExceptionInfo201);
            latentStyles1.Append(latentStyleExceptionInfo202);
            latentStyles1.Append(latentStyleExceptionInfo203);
            latentStyles1.Append(latentStyleExceptionInfo204);
            latentStyles1.Append(latentStyleExceptionInfo205);
            latentStyles1.Append(latentStyleExceptionInfo206);
            latentStyles1.Append(latentStyleExceptionInfo207);
            latentStyles1.Append(latentStyleExceptionInfo208);
            latentStyles1.Append(latentStyleExceptionInfo209);
            latentStyles1.Append(latentStyleExceptionInfo210);
            latentStyles1.Append(latentStyleExceptionInfo211);
            latentStyles1.Append(latentStyleExceptionInfo212);
            latentStyles1.Append(latentStyleExceptionInfo213);
            latentStyles1.Append(latentStyleExceptionInfo214);
            latentStyles1.Append(latentStyleExceptionInfo215);
            latentStyles1.Append(latentStyleExceptionInfo216);
            latentStyles1.Append(latentStyleExceptionInfo217);
            latentStyles1.Append(latentStyleExceptionInfo218);
            latentStyles1.Append(latentStyleExceptionInfo219);
            latentStyles1.Append(latentStyleExceptionInfo220);
            latentStyles1.Append(latentStyleExceptionInfo221);
            latentStyles1.Append(latentStyleExceptionInfo222);
            latentStyles1.Append(latentStyleExceptionInfo223);
            latentStyles1.Append(latentStyleExceptionInfo224);
            latentStyles1.Append(latentStyleExceptionInfo225);
            latentStyles1.Append(latentStyleExceptionInfo226);
            latentStyles1.Append(latentStyleExceptionInfo227);
            latentStyles1.Append(latentStyleExceptionInfo228);
            latentStyles1.Append(latentStyleExceptionInfo229);
            latentStyles1.Append(latentStyleExceptionInfo230);
            latentStyles1.Append(latentStyleExceptionInfo231);
            latentStyles1.Append(latentStyleExceptionInfo232);
            latentStyles1.Append(latentStyleExceptionInfo233);
            latentStyles1.Append(latentStyleExceptionInfo234);
            latentStyles1.Append(latentStyleExceptionInfo235);
            latentStyles1.Append(latentStyleExceptionInfo236);
            latentStyles1.Append(latentStyleExceptionInfo237);
            latentStyles1.Append(latentStyleExceptionInfo238);
            latentStyles1.Append(latentStyleExceptionInfo239);
            latentStyles1.Append(latentStyleExceptionInfo240);
            latentStyles1.Append(latentStyleExceptionInfo241);
            latentStyles1.Append(latentStyleExceptionInfo242);
            latentStyles1.Append(latentStyleExceptionInfo243);
            latentStyles1.Append(latentStyleExceptionInfo244);
            latentStyles1.Append(latentStyleExceptionInfo245);
            latentStyles1.Append(latentStyleExceptionInfo246);
            latentStyles1.Append(latentStyleExceptionInfo247);
            latentStyles1.Append(latentStyleExceptionInfo248);
            latentStyles1.Append(latentStyleExceptionInfo249);
            latentStyles1.Append(latentStyleExceptionInfo250);
            latentStyles1.Append(latentStyleExceptionInfo251);
            latentStyles1.Append(latentStyleExceptionInfo252);
            latentStyles1.Append(latentStyleExceptionInfo253);
            latentStyles1.Append(latentStyleExceptionInfo254);
            latentStyles1.Append(latentStyleExceptionInfo255);
            latentStyles1.Append(latentStyleExceptionInfo256);
            latentStyles1.Append(latentStyleExceptionInfo257);
            latentStyles1.Append(latentStyleExceptionInfo258);
            latentStyles1.Append(latentStyleExceptionInfo259);
            latentStyles1.Append(latentStyleExceptionInfo260);
            latentStyles1.Append(latentStyleExceptionInfo261);
            latentStyles1.Append(latentStyleExceptionInfo262);
            latentStyles1.Append(latentStyleExceptionInfo263);
            latentStyles1.Append(latentStyleExceptionInfo264);
            latentStyles1.Append(latentStyleExceptionInfo265);
            latentStyles1.Append(latentStyleExceptionInfo266);
            latentStyles1.Append(latentStyleExceptionInfo267);
            latentStyles1.Append(latentStyleExceptionInfo268);
            latentStyles1.Append(latentStyleExceptionInfo269);
            latentStyles1.Append(latentStyleExceptionInfo270);
            latentStyles1.Append(latentStyleExceptionInfo271);
            latentStyles1.Append(latentStyleExceptionInfo272);
            latentStyles1.Append(latentStyleExceptionInfo273);
            latentStyles1.Append(latentStyleExceptionInfo274);
            latentStyles1.Append(latentStyleExceptionInfo275);
            latentStyles1.Append(latentStyleExceptionInfo276);
            latentStyles1.Append(latentStyleExceptionInfo277);
            latentStyles1.Append(latentStyleExceptionInfo278);
            latentStyles1.Append(latentStyleExceptionInfo279);
            latentStyles1.Append(latentStyleExceptionInfo280);
            latentStyles1.Append(latentStyleExceptionInfo281);
            latentStyles1.Append(latentStyleExceptionInfo282);
            latentStyles1.Append(latentStyleExceptionInfo283);
            latentStyles1.Append(latentStyleExceptionInfo284);
            latentStyles1.Append(latentStyleExceptionInfo285);
            latentStyles1.Append(latentStyleExceptionInfo286);
            latentStyles1.Append(latentStyleExceptionInfo287);
            latentStyles1.Append(latentStyleExceptionInfo288);
            latentStyles1.Append(latentStyleExceptionInfo289);
            latentStyles1.Append(latentStyleExceptionInfo290);
            latentStyles1.Append(latentStyleExceptionInfo291);
            latentStyles1.Append(latentStyleExceptionInfo292);
            latentStyles1.Append(latentStyleExceptionInfo293);
            latentStyles1.Append(latentStyleExceptionInfo294);
            latentStyles1.Append(latentStyleExceptionInfo295);
            latentStyles1.Append(latentStyleExceptionInfo296);
            latentStyles1.Append(latentStyleExceptionInfo297);
            latentStyles1.Append(latentStyleExceptionInfo298);
            latentStyles1.Append(latentStyleExceptionInfo299);
            latentStyles1.Append(latentStyleExceptionInfo300);
            latentStyles1.Append(latentStyleExceptionInfo301);
            latentStyles1.Append(latentStyleExceptionInfo302);
            latentStyles1.Append(latentStyleExceptionInfo303);
            latentStyles1.Append(latentStyleExceptionInfo304);
            latentStyles1.Append(latentStyleExceptionInfo305);
            latentStyles1.Append(latentStyleExceptionInfo306);
            latentStyles1.Append(latentStyleExceptionInfo307);
            latentStyles1.Append(latentStyleExceptionInfo308);
            latentStyles1.Append(latentStyleExceptionInfo309);
            latentStyles1.Append(latentStyleExceptionInfo310);
            latentStyles1.Append(latentStyleExceptionInfo311);
            latentStyles1.Append(latentStyleExceptionInfo312);
            latentStyles1.Append(latentStyleExceptionInfo313);
            latentStyles1.Append(latentStyleExceptionInfo314);
            latentStyles1.Append(latentStyleExceptionInfo315);
            latentStyles1.Append(latentStyleExceptionInfo316);
            latentStyles1.Append(latentStyleExceptionInfo317);
            latentStyles1.Append(latentStyleExceptionInfo318);
            latentStyles1.Append(latentStyleExceptionInfo319);
            latentStyles1.Append(latentStyleExceptionInfo320);
            latentStyles1.Append(latentStyleExceptionInfo321);
            latentStyles1.Append(latentStyleExceptionInfo322);
            latentStyles1.Append(latentStyleExceptionInfo323);
            latentStyles1.Append(latentStyleExceptionInfo324);
            latentStyles1.Append(latentStyleExceptionInfo325);
            latentStyles1.Append(latentStyleExceptionInfo326);
            latentStyles1.Append(latentStyleExceptionInfo327);
            latentStyles1.Append(latentStyleExceptionInfo328);
            latentStyles1.Append(latentStyleExceptionInfo329);
            latentStyles1.Append(latentStyleExceptionInfo330);
            latentStyles1.Append(latentStyleExceptionInfo331);
            latentStyles1.Append(latentStyleExceptionInfo332);
            latentStyles1.Append(latentStyleExceptionInfo333);
            latentStyles1.Append(latentStyleExceptionInfo334);
            latentStyles1.Append(latentStyleExceptionInfo335);
            latentStyles1.Append(latentStyleExceptionInfo336);
            latentStyles1.Append(latentStyleExceptionInfo337);
            latentStyles1.Append(latentStyleExceptionInfo338);
            latentStyles1.Append(latentStyleExceptionInfo339);
            latentStyles1.Append(latentStyleExceptionInfo340);
            latentStyles1.Append(latentStyleExceptionInfo341);
            latentStyles1.Append(latentStyleExceptionInfo342);
            latentStyles1.Append(latentStyleExceptionInfo343);
            latentStyles1.Append(latentStyleExceptionInfo344);
            latentStyles1.Append(latentStyleExceptionInfo345);
            latentStyles1.Append(latentStyleExceptionInfo346);
            latentStyles1.Append(latentStyleExceptionInfo347);
            latentStyles1.Append(latentStyleExceptionInfo348);
            latentStyles1.Append(latentStyleExceptionInfo349);
            latentStyles1.Append(latentStyleExceptionInfo350);
            latentStyles1.Append(latentStyleExceptionInfo351);
            latentStyles1.Append(latentStyleExceptionInfo352);
            latentStyles1.Append(latentStyleExceptionInfo353);
            latentStyles1.Append(latentStyleExceptionInfo354);
            latentStyles1.Append(latentStyleExceptionInfo355);
            latentStyles1.Append(latentStyleExceptionInfo356);
            latentStyles1.Append(latentStyleExceptionInfo357);
            latentStyles1.Append(latentStyleExceptionInfo358);
            latentStyles1.Append(latentStyleExceptionInfo359);
            latentStyles1.Append(latentStyleExceptionInfo360);
            latentStyles1.Append(latentStyleExceptionInfo361);
            latentStyles1.Append(latentStyleExceptionInfo362);
            latentStyles1.Append(latentStyleExceptionInfo363);
            latentStyles1.Append(latentStyleExceptionInfo364);
            latentStyles1.Append(latentStyleExceptionInfo365);
            latentStyles1.Append(latentStyleExceptionInfo366);
            latentStyles1.Append(latentStyleExceptionInfo367);
            latentStyles1.Append(latentStyleExceptionInfo368);
            latentStyles1.Append(latentStyleExceptionInfo369);
            latentStyles1.Append(latentStyleExceptionInfo370);
            latentStyles1.Append(latentStyleExceptionInfo371);

            Style style1 = new Style() { Type = StyleValues.Paragraph, StyleId = "a", Default = true };
            StyleName styleName1 = new StyleName() { Val = "Normal" };
            PrimaryStyle primaryStyle1 = new PrimaryStyle();

            style1.Append(styleName1);
            style1.Append(primaryStyle1);

            Style style2 = new Style() { Type = StyleValues.Character, StyleId = "a0", Default = true };
            StyleName styleName2 = new StyleName() { Val = "Default Paragraph Font" };
            UIPriority uIPriority1 = new UIPriority() { Val = 1 };
            SemiHidden semiHidden1 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed1 = new UnhideWhenUsed();

            style2.Append(styleName2);
            style2.Append(uIPriority1);
            style2.Append(semiHidden1);
            style2.Append(unhideWhenUsed1);

            Style style3 = new Style() { Type = StyleValues.Table, StyleId = "a1", Default = true };
            StyleName styleName3 = new StyleName() { Val = "Normal Table" };
            UIPriority uIPriority2 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden2 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed2 = new UnhideWhenUsed();

            StyleTableProperties styleTableProperties1 = new StyleTableProperties();
            TableIndentation tableIndentation1 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

            TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
            TopMargin topMargin1 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin1 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

            tableCellMarginDefault1.Append(topMargin1);
            tableCellMarginDefault1.Append(tableCellLeftMargin1);
            tableCellMarginDefault1.Append(bottomMargin1);
            tableCellMarginDefault1.Append(tableCellRightMargin1);

            styleTableProperties1.Append(tableIndentation1);
            styleTableProperties1.Append(tableCellMarginDefault1);

            style3.Append(styleName3);
            style3.Append(uIPriority2);
            style3.Append(semiHidden2);
            style3.Append(unhideWhenUsed2);
            style3.Append(styleTableProperties1);

            Style style4 = new Style() { Type = StyleValues.Numbering, StyleId = "a2", Default = true };
            StyleName styleName4 = new StyleName() { Val = "No List" };
            UIPriority uIPriority3 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden3 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed3 = new UnhideWhenUsed();

            style4.Append(styleName4);
            style4.Append(uIPriority3);
            style4.Append(semiHidden3);
            style4.Append(unhideWhenUsed3);

            Style style5 = new Style() { Type = StyleValues.Table, StyleId = "a3" };
            StyleName styleName5 = new StyleName() { Val = "Table Grid" };
            BasedOn basedOn1 = new BasedOn() { Val = "a1" };
            UIPriority uIPriority4 = new UIPriority() { Val = 39 };
            Rsid rsid21 = new Rsid() { Val = "00195F14" };

            StyleParagraphProperties styleParagraphProperties1 = new StyleParagraphProperties();
            SpacingBetweenLines spacingBetweenLines2 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties1.Append(spacingBetweenLines2);

            StyleTableProperties styleTableProperties2 = new StyleTableProperties();

            TableBorders tableBorders2 = new TableBorders();
            TopBorder topBorder13 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder1 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder13 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder1 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder2 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder2 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders2.Append(topBorder13);
            tableBorders2.Append(leftBorder1);
            tableBorders2.Append(bottomBorder13);
            tableBorders2.Append(rightBorder1);
            tableBorders2.Append(insideHorizontalBorder2);
            tableBorders2.Append(insideVerticalBorder2);

            styleTableProperties2.Append(tableBorders2);

            style5.Append(styleName5);
            style5.Append(basedOn1);
            style5.Append(uIPriority4);
            style5.Append(rsid21);
            style5.Append(styleParagraphProperties1);
            style5.Append(styleTableProperties2);

            styles1.Append(docDefaults1);
            styles1.Append(latentStyles1);
            styles1.Append(style1);
            styles1.Append(style2);
            styles1.Append(style3);
            styles1.Append(style4);
            styles1.Append(style5);

            styleDefinitionsPart1.Styles = styles1;
        }

        // Generates content of themePart1.
        private void GenerateThemePart1Content(ThemePart themePart1)
        {
            A.Theme theme1 = new A.Theme() { Name = "Тема Office" };
            theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.ThemeElements themeElements1 = new A.ThemeElements();

            A.ColorScheme colorScheme1 = new A.ColorScheme() { Name = "Стандартная" };

            A.Dark1Color dark1Color1 = new A.Dark1Color();
            A.SystemColor systemColor1 = new A.SystemColor() { Val = A.SystemColorValues.WindowText, LastColor = "000000" };

            dark1Color1.Append(systemColor1);

            A.Light1Color light1Color1 = new A.Light1Color();
            A.SystemColor systemColor2 = new A.SystemColor() { Val = A.SystemColorValues.Window, LastColor = "FFFFFF" };

            light1Color1.Append(systemColor2);

            A.Dark2Color dark2Color1 = new A.Dark2Color();
            A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "44546A" };

            dark2Color1.Append(rgbColorModelHex1);

            A.Light2Color light2Color1 = new A.Light2Color();
            A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "E7E6E6" };

            light2Color1.Append(rgbColorModelHex2);

            A.Accent1Color accent1Color1 = new A.Accent1Color();
            A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "5B9BD5" };

            accent1Color1.Append(rgbColorModelHex3);

            A.Accent2Color accent2Color1 = new A.Accent2Color();
            A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "ED7D31" };

            accent2Color1.Append(rgbColorModelHex4);

            A.Accent3Color accent3Color1 = new A.Accent3Color();
            A.RgbColorModelHex rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "A5A5A5" };

            accent3Color1.Append(rgbColorModelHex5);

            A.Accent4Color accent4Color1 = new A.Accent4Color();
            A.RgbColorModelHex rgbColorModelHex6 = new A.RgbColorModelHex() { Val = "FFC000" };

            accent4Color1.Append(rgbColorModelHex6);

            A.Accent5Color accent5Color1 = new A.Accent5Color();
            A.RgbColorModelHex rgbColorModelHex7 = new A.RgbColorModelHex() { Val = "4472C4" };

            accent5Color1.Append(rgbColorModelHex7);

            A.Accent6Color accent6Color1 = new A.Accent6Color();
            A.RgbColorModelHex rgbColorModelHex8 = new A.RgbColorModelHex() { Val = "70AD47" };

            accent6Color1.Append(rgbColorModelHex8);

            A.Hyperlink hyperlink1 = new A.Hyperlink();
            A.RgbColorModelHex rgbColorModelHex9 = new A.RgbColorModelHex() { Val = "0563C1" };

            hyperlink1.Append(rgbColorModelHex9);

            A.FollowedHyperlinkColor followedHyperlinkColor1 = new A.FollowedHyperlinkColor();
            A.RgbColorModelHex rgbColorModelHex10 = new A.RgbColorModelHex() { Val = "954F72" };

            followedHyperlinkColor1.Append(rgbColorModelHex10);

            colorScheme1.Append(dark1Color1);
            colorScheme1.Append(light1Color1);
            colorScheme1.Append(dark2Color1);
            colorScheme1.Append(light2Color1);
            colorScheme1.Append(accent1Color1);
            colorScheme1.Append(accent2Color1);
            colorScheme1.Append(accent3Color1);
            colorScheme1.Append(accent4Color1);
            colorScheme1.Append(accent5Color1);
            colorScheme1.Append(accent6Color1);
            colorScheme1.Append(hyperlink1);
            colorScheme1.Append(followedHyperlinkColor1);

            A.FontScheme fontScheme1 = new A.FontScheme() { Name = "Стандартная" };

            A.MajorFont majorFont1 = new A.MajorFont();
            A.LatinFont latinFont1 = new A.LatinFont() { Typeface = "Calibri Light", Panose = "020F0302020204030204" };
            A.EastAsianFont eastAsianFont1 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont1 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont1 = new A.SupplementalFont() { Script = "Jpan", Typeface = "游ゴシック Light" };
            A.SupplementalFont supplementalFont2 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont3 = new A.SupplementalFont() { Script = "Hans", Typeface = "等线 Light" };
            A.SupplementalFont supplementalFont4 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont5 = new A.SupplementalFont() { Script = "Arab", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont6 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont7 = new A.SupplementalFont() { Script = "Thai", Typeface = "Angsana New" };
            A.SupplementalFont supplementalFont8 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont9 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont10 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont11 = new A.SupplementalFont() { Script = "Khmr", Typeface = "MoolBoran" };
            A.SupplementalFont supplementalFont12 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont13 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont14 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont15 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont16 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont17 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont18 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont19 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont20 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont21 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont22 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont23 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont24 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont25 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont26 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont27 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont28 = new A.SupplementalFont() { Script = "Viet", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont29 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont30 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            majorFont1.Append(latinFont1);
            majorFont1.Append(eastAsianFont1);
            majorFont1.Append(complexScriptFont1);
            majorFont1.Append(supplementalFont1);
            majorFont1.Append(supplementalFont2);
            majorFont1.Append(supplementalFont3);
            majorFont1.Append(supplementalFont4);
            majorFont1.Append(supplementalFont5);
            majorFont1.Append(supplementalFont6);
            majorFont1.Append(supplementalFont7);
            majorFont1.Append(supplementalFont8);
            majorFont1.Append(supplementalFont9);
            majorFont1.Append(supplementalFont10);
            majorFont1.Append(supplementalFont11);
            majorFont1.Append(supplementalFont12);
            majorFont1.Append(supplementalFont13);
            majorFont1.Append(supplementalFont14);
            majorFont1.Append(supplementalFont15);
            majorFont1.Append(supplementalFont16);
            majorFont1.Append(supplementalFont17);
            majorFont1.Append(supplementalFont18);
            majorFont1.Append(supplementalFont19);
            majorFont1.Append(supplementalFont20);
            majorFont1.Append(supplementalFont21);
            majorFont1.Append(supplementalFont22);
            majorFont1.Append(supplementalFont23);
            majorFont1.Append(supplementalFont24);
            majorFont1.Append(supplementalFont25);
            majorFont1.Append(supplementalFont26);
            majorFont1.Append(supplementalFont27);
            majorFont1.Append(supplementalFont28);
            majorFont1.Append(supplementalFont29);
            majorFont1.Append(supplementalFont30);

            A.MinorFont minorFont1 = new A.MinorFont();
            A.LatinFont latinFont2 = new A.LatinFont() { Typeface = "Calibri", Panose = "020F0502020204030204" };
            A.EastAsianFont eastAsianFont2 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont2 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont31 = new A.SupplementalFont() { Script = "Jpan", Typeface = "游明朝" };
            A.SupplementalFont supplementalFont32 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont33 = new A.SupplementalFont() { Script = "Hans", Typeface = "等线" };
            A.SupplementalFont supplementalFont34 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont35 = new A.SupplementalFont() { Script = "Arab", Typeface = "Arial" };
            A.SupplementalFont supplementalFont36 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Arial" };
            A.SupplementalFont supplementalFont37 = new A.SupplementalFont() { Script = "Thai", Typeface = "Cordia New" };
            A.SupplementalFont supplementalFont38 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont39 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont40 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont41 = new A.SupplementalFont() { Script = "Khmr", Typeface = "DaunPenh" };
            A.SupplementalFont supplementalFont42 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont43 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont44 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont45 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont46 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont47 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont48 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont49 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont50 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont51 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont52 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont53 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont54 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont55 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont56 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont57 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont58 = new A.SupplementalFont() { Script = "Viet", Typeface = "Arial" };
            A.SupplementalFont supplementalFont59 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont60 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            minorFont1.Append(latinFont2);
            minorFont1.Append(eastAsianFont2);
            minorFont1.Append(complexScriptFont2);
            minorFont1.Append(supplementalFont31);
            minorFont1.Append(supplementalFont32);
            minorFont1.Append(supplementalFont33);
            minorFont1.Append(supplementalFont34);
            minorFont1.Append(supplementalFont35);
            minorFont1.Append(supplementalFont36);
            minorFont1.Append(supplementalFont37);
            minorFont1.Append(supplementalFont38);
            minorFont1.Append(supplementalFont39);
            minorFont1.Append(supplementalFont40);
            minorFont1.Append(supplementalFont41);
            minorFont1.Append(supplementalFont42);
            minorFont1.Append(supplementalFont43);
            minorFont1.Append(supplementalFont44);
            minorFont1.Append(supplementalFont45);
            minorFont1.Append(supplementalFont46);
            minorFont1.Append(supplementalFont47);
            minorFont1.Append(supplementalFont48);
            minorFont1.Append(supplementalFont49);
            minorFont1.Append(supplementalFont50);
            minorFont1.Append(supplementalFont51);
            minorFont1.Append(supplementalFont52);
            minorFont1.Append(supplementalFont53);
            minorFont1.Append(supplementalFont54);
            minorFont1.Append(supplementalFont55);
            minorFont1.Append(supplementalFont56);
            minorFont1.Append(supplementalFont57);
            minorFont1.Append(supplementalFont58);
            minorFont1.Append(supplementalFont59);
            minorFont1.Append(supplementalFont60);

            fontScheme1.Append(majorFont1);
            fontScheme1.Append(minorFont1);

            A.FormatScheme formatScheme1 = new A.FormatScheme() { Name = "Стандартная" };

            A.FillStyleList fillStyleList1 = new A.FillStyleList();

            A.SolidFill solidFill1 = new A.SolidFill();
            A.SchemeColor schemeColor1 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill1.Append(schemeColor1);

            A.GradientFill gradientFill1 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList1 = new A.GradientStopList();

            A.GradientStop gradientStop1 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor2 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation1 = new A.LuminanceModulation() { Val = 110000 };
            A.SaturationModulation saturationModulation1 = new A.SaturationModulation() { Val = 105000 };
            A.Tint tint1 = new A.Tint() { Val = 67000 };

            schemeColor2.Append(luminanceModulation1);
            schemeColor2.Append(saturationModulation1);
            schemeColor2.Append(tint1);

            gradientStop1.Append(schemeColor2);

            A.GradientStop gradientStop2 = new A.GradientStop() { Position = 50000 };

            A.SchemeColor schemeColor3 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation2 = new A.LuminanceModulation() { Val = 105000 };
            A.SaturationModulation saturationModulation2 = new A.SaturationModulation() { Val = 103000 };
            A.Tint tint2 = new A.Tint() { Val = 73000 };

            schemeColor3.Append(luminanceModulation2);
            schemeColor3.Append(saturationModulation2);
            schemeColor3.Append(tint2);

            gradientStop2.Append(schemeColor3);

            A.GradientStop gradientStop3 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor4 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation3 = new A.LuminanceModulation() { Val = 105000 };
            A.SaturationModulation saturationModulation3 = new A.SaturationModulation() { Val = 109000 };
            A.Tint tint3 = new A.Tint() { Val = 81000 };

            schemeColor4.Append(luminanceModulation3);
            schemeColor4.Append(saturationModulation3);
            schemeColor4.Append(tint3);

            gradientStop3.Append(schemeColor4);

            gradientStopList1.Append(gradientStop1);
            gradientStopList1.Append(gradientStop2);
            gradientStopList1.Append(gradientStop3);
            A.LinearGradientFill linearGradientFill1 = new A.LinearGradientFill() { Angle = 5400000, Scaled = false };

            gradientFill1.Append(gradientStopList1);
            gradientFill1.Append(linearGradientFill1);

            A.GradientFill gradientFill2 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList2 = new A.GradientStopList();

            A.GradientStop gradientStop4 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor5 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.SaturationModulation saturationModulation4 = new A.SaturationModulation() { Val = 103000 };
            A.LuminanceModulation luminanceModulation4 = new A.LuminanceModulation() { Val = 102000 };
            A.Tint tint4 = new A.Tint() { Val = 94000 };

            schemeColor5.Append(saturationModulation4);
            schemeColor5.Append(luminanceModulation4);
            schemeColor5.Append(tint4);

            gradientStop4.Append(schemeColor5);

            A.GradientStop gradientStop5 = new A.GradientStop() { Position = 50000 };

            A.SchemeColor schemeColor6 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.SaturationModulation saturationModulation5 = new A.SaturationModulation() { Val = 110000 };
            A.LuminanceModulation luminanceModulation5 = new A.LuminanceModulation() { Val = 100000 };
            A.Shade shade1 = new A.Shade() { Val = 100000 };

            schemeColor6.Append(saturationModulation5);
            schemeColor6.Append(luminanceModulation5);
            schemeColor6.Append(shade1);

            gradientStop5.Append(schemeColor6);

            A.GradientStop gradientStop6 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor7 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation6 = new A.LuminanceModulation() { Val = 99000 };
            A.SaturationModulation saturationModulation6 = new A.SaturationModulation() { Val = 120000 };
            A.Shade shade2 = new A.Shade() { Val = 78000 };

            schemeColor7.Append(luminanceModulation6);
            schemeColor7.Append(saturationModulation6);
            schemeColor7.Append(shade2);

            gradientStop6.Append(schemeColor7);

            gradientStopList2.Append(gradientStop4);
            gradientStopList2.Append(gradientStop5);
            gradientStopList2.Append(gradientStop6);
            A.LinearGradientFill linearGradientFill2 = new A.LinearGradientFill() { Angle = 5400000, Scaled = false };

            gradientFill2.Append(gradientStopList2);
            gradientFill2.Append(linearGradientFill2);

            fillStyleList1.Append(solidFill1);
            fillStyleList1.Append(gradientFill1);
            fillStyleList1.Append(gradientFill2);

            A.LineStyleList lineStyleList1 = new A.LineStyleList();

            A.Outline outline1 = new A.Outline() { Width = 6350, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill2 = new A.SolidFill();
            A.SchemeColor schemeColor8 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill2.Append(schemeColor8);
            A.PresetDash presetDash1 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter1 = new A.Miter() { Limit = 800000 };

            outline1.Append(solidFill2);
            outline1.Append(presetDash1);
            outline1.Append(miter1);

            A.Outline outline2 = new A.Outline() { Width = 12700, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill3 = new A.SolidFill();
            A.SchemeColor schemeColor9 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill3.Append(schemeColor9);
            A.PresetDash presetDash2 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter2 = new A.Miter() { Limit = 800000 };

            outline2.Append(solidFill3);
            outline2.Append(presetDash2);
            outline2.Append(miter2);

            A.Outline outline3 = new A.Outline() { Width = 19050, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill4 = new A.SolidFill();
            A.SchemeColor schemeColor10 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill4.Append(schemeColor10);
            A.PresetDash presetDash3 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter3 = new A.Miter() { Limit = 800000 };

            outline3.Append(solidFill4);
            outline3.Append(presetDash3);
            outline3.Append(miter3);

            lineStyleList1.Append(outline1);
            lineStyleList1.Append(outline2);
            lineStyleList1.Append(outline3);

            A.EffectStyleList effectStyleList1 = new A.EffectStyleList();

            A.EffectStyle effectStyle1 = new A.EffectStyle();
            A.EffectList effectList1 = new A.EffectList();

            effectStyle1.Append(effectList1);

            A.EffectStyle effectStyle2 = new A.EffectStyle();
            A.EffectList effectList2 = new A.EffectList();

            effectStyle2.Append(effectList2);

            A.EffectStyle effectStyle3 = new A.EffectStyle();

            A.EffectList effectList3 = new A.EffectList();

            A.OuterShadow outerShadow1 = new A.OuterShadow() { BlurRadius = 57150L, Distance = 19050L, Direction = 5400000, Alignment = A.RectangleAlignmentValues.Center, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex11 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha1 = new A.Alpha() { Val = 63000 };

            rgbColorModelHex11.Append(alpha1);

            outerShadow1.Append(rgbColorModelHex11);

            effectList3.Append(outerShadow1);

            effectStyle3.Append(effectList3);

            effectStyleList1.Append(effectStyle1);
            effectStyleList1.Append(effectStyle2);
            effectStyleList1.Append(effectStyle3);

            A.BackgroundFillStyleList backgroundFillStyleList1 = new A.BackgroundFillStyleList();

            A.SolidFill solidFill5 = new A.SolidFill();
            A.SchemeColor schemeColor11 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill5.Append(schemeColor11);

            A.SolidFill solidFill6 = new A.SolidFill();

            A.SchemeColor schemeColor12 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint5 = new A.Tint() { Val = 95000 };
            A.SaturationModulation saturationModulation7 = new A.SaturationModulation() { Val = 170000 };

            schemeColor12.Append(tint5);
            schemeColor12.Append(saturationModulation7);

            solidFill6.Append(schemeColor12);

            A.GradientFill gradientFill3 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList3 = new A.GradientStopList();

            A.GradientStop gradientStop7 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor13 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint6 = new A.Tint() { Val = 93000 };
            A.SaturationModulation saturationModulation8 = new A.SaturationModulation() { Val = 150000 };
            A.Shade shade3 = new A.Shade() { Val = 98000 };
            A.LuminanceModulation luminanceModulation7 = new A.LuminanceModulation() { Val = 102000 };

            schemeColor13.Append(tint6);
            schemeColor13.Append(saturationModulation8);
            schemeColor13.Append(shade3);
            schemeColor13.Append(luminanceModulation7);

            gradientStop7.Append(schemeColor13);

            A.GradientStop gradientStop8 = new A.GradientStop() { Position = 50000 };

            A.SchemeColor schemeColor14 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint7 = new A.Tint() { Val = 98000 };
            A.SaturationModulation saturationModulation9 = new A.SaturationModulation() { Val = 130000 };
            A.Shade shade4 = new A.Shade() { Val = 90000 };
            A.LuminanceModulation luminanceModulation8 = new A.LuminanceModulation() { Val = 103000 };

            schemeColor14.Append(tint7);
            schemeColor14.Append(saturationModulation9);
            schemeColor14.Append(shade4);
            schemeColor14.Append(luminanceModulation8);

            gradientStop8.Append(schemeColor14);

            A.GradientStop gradientStop9 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor15 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade5 = new A.Shade() { Val = 63000 };
            A.SaturationModulation saturationModulation10 = new A.SaturationModulation() { Val = 120000 };

            schemeColor15.Append(shade5);
            schemeColor15.Append(saturationModulation10);

            gradientStop9.Append(schemeColor15);

            gradientStopList3.Append(gradientStop7);
            gradientStopList3.Append(gradientStop8);
            gradientStopList3.Append(gradientStop9);
            A.LinearGradientFill linearGradientFill3 = new A.LinearGradientFill() { Angle = 5400000, Scaled = false };

            gradientFill3.Append(gradientStopList3);
            gradientFill3.Append(linearGradientFill3);

            backgroundFillStyleList1.Append(solidFill5);
            backgroundFillStyleList1.Append(solidFill6);
            backgroundFillStyleList1.Append(gradientFill3);

            formatScheme1.Append(fillStyleList1);
            formatScheme1.Append(lineStyleList1);
            formatScheme1.Append(effectStyleList1);
            formatScheme1.Append(backgroundFillStyleList1);

            themeElements1.Append(colorScheme1);
            themeElements1.Append(fontScheme1);
            themeElements1.Append(formatScheme1);
            A.ObjectDefaults objectDefaults1 = new A.ObjectDefaults();
            A.ExtraColorSchemeList extraColorSchemeList1 = new A.ExtraColorSchemeList();

            A.ExtensionList extensionList1 = new A.ExtensionList();

            A.Extension extension1 = new A.Extension() { Uri = "{05A4C25C-085E-4340-85A3-A5531E510DB2}" };

            OpenXmlUnknownElement openXmlUnknownElement3 = OpenXmlUnknownElement.CreateOpenXmlUnknownElement("<thm15:themeFamily xmlns:thm15=\"http://schemas.microsoft.com/office/thememl/2012/main\" name=\"Office Theme\" id=\"{62F939B6-93AF-4DB8-9C6B-D6C7DFDC589F}\" vid=\"{4A3C46E8-61CC-4603-A589-7422A47A8E4A}\" />");

            extension1.Append(openXmlUnknownElement3);

            extensionList1.Append(extension1);

            theme1.Append(themeElements1);
            theme1.Append(objectDefaults1);
            theme1.Append(extraColorSchemeList1);
            theme1.Append(extensionList1);

            themePart1.Theme = theme1;
        }

        // Generates content of fontTablePart1.
        private void GenerateFontTablePart1Content(FontTablePart fontTablePart1)
        {
            Fonts fonts1 = new Fonts() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se" } };
            fonts1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            fonts1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            fonts1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            fonts1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            fonts1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            fonts1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");

            Font font1 = new Font() { Name = "Calibri" };
            Panose1Number panose1Number1 = new Panose1Number() { Val = "020F0502020204030204" };
            FontCharSet fontCharSet1 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily1 = new FontFamily() { Val = FontFamilyValues.Swiss };
            Pitch pitch1 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature1 = new FontSignature() { UnicodeSignature0 = "E0002AFF", UnicodeSignature1 = "C000247B", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

            font1.Append(panose1Number1);
            font1.Append(fontCharSet1);
            font1.Append(fontFamily1);
            font1.Append(pitch1);
            font1.Append(fontSignature1);

            Font font2 = new Font() { Name = "Times New Roman" };
            Panose1Number panose1Number2 = new Panose1Number() { Val = "02020603050405020304" };
            FontCharSet fontCharSet2 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily2 = new FontFamily() { Val = FontFamilyValues.Roman };
            Pitch pitch2 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature2 = new FontSignature() { UnicodeSignature0 = "E0002EFF", UnicodeSignature1 = "C000785B", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

            font2.Append(panose1Number2);
            font2.Append(fontCharSet2);
            font2.Append(fontFamily2);
            font2.Append(pitch2);
            font2.Append(fontSignature2);

            Font font3 = new Font() { Name = "Symbol" };
            Panose1Number panose1Number3 = new Panose1Number() { Val = "05050102010706020507" };
            FontCharSet fontCharSet3 = new FontCharSet() { Val = "02" };
            FontFamily fontFamily3 = new FontFamily() { Val = FontFamilyValues.Roman };
            Pitch pitch3 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature3 = new FontSignature() { UnicodeSignature0 = "00000000", UnicodeSignature1 = "10000000", UnicodeSignature2 = "00000000", UnicodeSignature3 = "00000000", CodePageSignature0 = "80000000", CodePageSignature1 = "00000000" };

            font3.Append(panose1Number3);
            font3.Append(fontCharSet3);
            font3.Append(fontFamily3);
            font3.Append(pitch3);
            font3.Append(fontSignature3);

            Font font4 = new Font() { Name = "Consolas" };
            Panose1Number panose1Number4 = new Panose1Number() { Val = "020B0609020204030204" };
            FontCharSet fontCharSet4 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily4 = new FontFamily() { Val = FontFamilyValues.Modern };
            Pitch pitch4 = new Pitch() { Val = FontPitchValues.Fixed };
            FontSignature fontSignature4 = new FontSignature() { UnicodeSignature0 = "E00006FF", UnicodeSignature1 = "0000FCFF", UnicodeSignature2 = "00000001", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

            font4.Append(panose1Number4);
            font4.Append(fontCharSet4);
            font4.Append(fontFamily4);
            font4.Append(pitch4);
            font4.Append(fontSignature4);

            Font font5 = new Font() { Name = "Calibri Light" };
            Panose1Number panose1Number5 = new Panose1Number() { Val = "020F0302020204030204" };
            FontCharSet fontCharSet5 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily5 = new FontFamily() { Val = FontFamilyValues.Swiss };
            Pitch pitch5 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature5 = new FontSignature() { UnicodeSignature0 = "E0002AFF", UnicodeSignature1 = "C000247B", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

            font5.Append(panose1Number5);
            font5.Append(fontCharSet5);
            font5.Append(fontFamily5);
            font5.Append(pitch5);
            font5.Append(fontSignature5);

            fonts1.Append(font1);
            fonts1.Append(font2);
            fonts1.Append(font3);
            fonts1.Append(font4);
            fonts1.Append(font5);

            fontTablePart1.Fonts = fonts1;
        }

        private void SetPackageProperties(OpenXmlPackage document)
        {
            document.PackageProperties.Creator = "Пользователь Windows";
            document.PackageProperties.Title = "";
            document.PackageProperties.Subject = "";
            document.PackageProperties.Keywords = "";
            document.PackageProperties.Description = "";
            document.PackageProperties.Revision = "22";
            document.PackageProperties.Created = System.Xml.XmlConvert.ToDateTime("2018-01-04T06:35:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.Modified = System.Xml.XmlConvert.ToDateTime("2018-01-19T07:12:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.LastModifiedBy = "Пользователь Windows";
        }


    }
}
