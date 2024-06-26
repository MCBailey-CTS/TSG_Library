﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using NXOpen;
using NXOpen.Assemblies;
using NXOpen.UF;
using NXOpen.Utilities;
using TSG_Library.Attributes;
using TSG_Library.Geom;
using TSG_Library.Properties;
using TSG_Library.UFuncUtilities.BomUtilities;
using TSG_Library.Ui;
using TSG_Library.Utilities;
using static TSG_Library.Extensions.Extensions;
using static TSG_Library.UFuncs._UFunc;
using Selection = TSG_Library.Ui.Selection;

namespace TSG_Library.UFuncs
{
    [UFunc(ufunc_bill_of_material)]
    //[RevisionLog("Bill Of Material")]
    //[RevisionEntry("1.00", "2017", "06", "05")]
    //[Revision("1.00.1", "Created for NX 11")]
    //[RevisionEntry("1.10", "2017", "08", "22")]
    //[Revision("1.10.1", "Signed so it can run outside of CTS")]
    //[RevisionEntry("1.11", "2017", "10", "11")]
    //[Revision("1.11.1", "Adjusted filter for counting the quantity of components")]
    //[Revision("1.11.1.1",
    //    "Added a check where the component.Parent.ReferenceSet != \"Empty\" must be true in order for that particular instance to be counted.")]
    //[RevisionEntry("1.2", "2017", "11", "22")]
    //[Revision("1.2.1",
    //    "When creating a stocklist, the program will now copy the excel file off of the “U” drive and rename it to the appropriate title that AssemblyExportDesignData can pick up")]
    //[Revision("1.2.2",
    //    "In the rare occurrence that a stock list already named properly exists, a window will prompt the user to override the file.")]
    //[RevisionEntry("1.3", "2017", "11", "29")]
    //[Revision("1.3.1", "Moved all the resources and processes for closing the excel files.")]
    //[RevisionEntry("1.4", "2017", "12", "28")]
    //[Revision("1.4.1", "Automatically named the stocklist correctly so that Assembly exportDesignData can find it.")]
    //[Revision("1.4.2", "When a bomb is created it will now also create and populate a checker stocklist.")]
    //[Revision("1.4.3", "Casting stock lists will now be named “-casting-stocklist”.")]
    //[Revision("1.4.4", "Made it so that the vendor list will not pop up if there are no vendors to select from.")]
    //[RevisionEntry("1.5", "2018", "01", "08")]
    //[Revision("1.5.1", "The BOM will now open a session of the BOM excel file when the program has completed.")]
    //[Revision("1.5.2",
    //    "Also the form will pop open first and getting the actual details for the BOM will only occur after a shop button is pressed.")]
    //[RevisionEntry("1.6", "2018", "01", "10")]
    //[Revision("1.6.1", "Changed the location of the CheckTemplate to the UDrive.")]
    //[Revision("1.6.2", "U:\\nxFiles\\Excel\\cts\\CheckerTemplate.xls")]
    //[RevisionEntry("1.7", "2018", "01", "29")]
    //[Revision("1.7.1", "Pointed validation method to CTS_Library to fix issue with BOM not validating the RTS server.")]
    //[Revision("1.7.2", "Fixed issue where the colors were coming on the wrong cell in the checker list.")]
    //[RevisionEntry("1.8", "2018", "03", "20")]
    //[Revision("1.8.1", "Fixed issue where the vendor dialog was not opening.")]
    //[Revision("1.8.2", "Added pre check.")]
    //[Revision("1.8.2.1",
    //    "Now the program will go through all the parts that are to be added to the BOM and it checks to make sure that they all have “Material” attribute with a valid value.")]
    //[Revision("1.8.2.2",
    //    "A valid value does not mean it has to be an actual Material the is known, the value just can’t be null, empty, or whitespace.")]
    //[Revision("1.8.2.3", "If one part fails the check then the program terminates")]
    //[RevisionEntry("1.81", "2018", "09", "14")]
    //[Revision("1.81.1",
    //    "Fixed bug that caused program to error out when there was a part file in the current displayed assembly, that didn't have single number within the DisplayName of its components.")]
    //[RevisionEntry("2.0", "2018", "10", "24")]
    //[Revision("2.0.1", "Removed “Reload” button.")]
    //[Revision("2.0.2", "Added “UGS” button.")]
    //[Revision("2.0.3", "Removed “Exit” button.")]
    //[Revision("2.0.4", "Removed both minimum and maximum from control box.")]
    //[Revision("2.0.5", "Added prompt and status changes during the BOM process.")]
    //[Revision("2.0.6",
    //    "When the “UGS” button is clicked, it will look for components with the “ComponentDescriptionUGS” attribute and add the value to the H column in the BOM.")]
    //[Revision("2.0.7",
    //    "Fixed issue where the form would remain idle after the BOM is made, and the user can’t click anything.Gives the appearance that it is frozen.")]
    //[Revision("2.0.7.1",
    //    "This was actually frozen because the checker sheet was being made.Now the form doesn't show until all after the entire process is complete.")]
    //[Revision("2.0.8", "Fixed issue where the BOM seemed to get halfway through populating the actual excel sheet.")]
    //[Revision("2.0.8.1",
    //    "I believe this was caused because the user might accidentally click the sheet while it was being populated.")]
    //[Revision("2.0.8.2", "The excel sheet is now not visible while it is being populated.")]
    //[RevisionEntry("2.1", "2018", "11", "29")]
    //[Revision("2.1.1", "Added a try-catch around the method call to make the Bom Sheet.")]
    //[Revision("2.1.2", "Hopefully this will give us some insight into why the checker sheet is not made sometimes.")]
    //[RevisionEntry("2.2", "2019", "08", "14")]
    //[Revision("2.2.1", "Updated to use new GFolder.")]
    //[RevisionEntry("2.3", "2019", "08", "28")]
    //[Revision("2.3.1", "GFolder updated to allow old job number under non cts folder.")]
    //[RevisionEntry("2.4", "2020", "02", "10")]
    //[Revision("2.4.1", "Updated to use new GFolder which will now search for a valid stock list folder.")]
    //[RevisionEntry("2.5", "2020", "10", "14")]
    //[Revision("2.5.1", "Added a clear selections button to the form.")]
    //[Revision("2.5.2", "Fixed issue where the form sometimes did not remember it's location upon load up.")]
    //[Revision("2.5.3", "Template files for excel bom sheet are updated to use the new version of excel.")]
    //[Revision("2.5.4",
    //    "Template file paths as well as the checker sheet are now determined through the \"U:\\nxFiles\\UfuncFiles\\BillOfMaterial.ucf\".")]
    //[RevisionEntry("2.6", "2021", "02", "11")]
    //[Revision("2.6.1", "Added a size description check to process.")]
    //[Revision("2.6.2",
    //    "Like in Design Check, a size description will be performed on all details prior to building of the BOM.")]
    //[Revision("2.6.3",
    //    "If any detail fails, the user will be notified and the user will have to give the okay to run via a dialog.")]
    //[RevisionEntry("2.7", "2021", "05", "27")]
    //[Revision("2.7.1", "The ConceptControlFile now points to \"U:\\nxFiles\\UfuncFiles\\ConceptControlFile.ucf\"")]
    //[RevisionEntry("2.8", "2022", "03", "14")]
    //[Revision("2.7.1", "The ConceptControlFile now points to \"U:\\nxFiles\\UfuncFiles\\BillOfMaterial.ucf\"")]
    //[Revision("2.7.2",
    //    "For Size Validation, the method will now check to see if the AddX, AddY, and AddZ expressions are present and valid.")]
    //[RevisionEntry("2.8", "2022", "09", "09")]
    //[Revision("2.8.1", "The material column in the Bom will now remove '-ALTER'")]
    //[Revision("2.8.2", "The material column in the Checker Sheet will now remove '-ALTER'")]
    //[RevisionEntry("2.9", "2022", "10", "04")]
    //[Revision("2.9.1", "The Rts bom file has been updated with a new logo")]
    //[RevisionEntry("11.1", "2023", "01", "09")]
    //[Revision("11.1.1", "Removed validation")]
    public partial class BillOfMaterialForm : _UFuncForm
    {
        public const string FilePath_BillOfMaterialFileUcf = @"U:\nxFiles\UfuncFiles\BillOfMaterial.ucf";

        private static List<Component> _childComponents = new List<Component>();

        private static List<Component> _selectedComponents = new List<Component>();

        private static readonly List<Component> ErrorComponents = new List<Component>();

        private static readonly List<NXExcelData> ExcelData = new List<NXExcelData>();

        private readonly Ucf _ucf;

        private bool _isCasting;

        public BillOfMaterialForm()
        {
            InitializeComponent();
            _ucf = new Ucf(FilePath_BillOfMaterialFileUcf);
        }

        //public MainForm() : base(typeof(Program))
        //{
        //    InitializeComponent();
        //}

        //private void MainForm_Load(object sender, EventArgs e)
        //{
        //    Location = Settings.Default.BillOfMaterialWindowLocation;
        //}

        //private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    Settings.Default.BillOfMaterialWindowLocation = Location;
        //    Settings.Default.Save();
        //}

        private void ButtonCreateBom_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
                NXExcelData.RowColumnIndexes customerIndex;
                string customerPath;
                switch (sender)
                {
                    case var unused when sender == buttonCreateAts:
                        customerIndex = NXExcelData.RowColumnIndexes.AtsStartRow;
                        customerPath = _ucf["ATS_EXCEL"][0];
                        break;
                    case var unused when sender == buttonCreateCts:
                        customerIndex = NXExcelData.RowColumnIndexes.CtsStartRow;
                        customerPath = _ucf["CTS_EXCEL"][0];
                        break;
                    case var unused when sender == buttonCreateDts:
                        customerIndex = NXExcelData.RowColumnIndexes.DtsStartRow;
                        customerPath = _ucf["DTS_EXCEL"][0];
                        break;
                    case var unused when sender == buttonCreateEts:
                        customerIndex = NXExcelData.RowColumnIndexes.EtsStartRow;
                        customerPath = _ucf["ETS_EXCEL"][0];
                        break;
                    case var unused when sender == buttonCreateHTS:
                        customerIndex = NXExcelData.RowColumnIndexes.HtsStartRow;
                        customerPath = _ucf["HTS_EXCEL"][0];
                        break;
                    case var unused when sender == buttonCreateRTS:
                        customerIndex = NXExcelData.RowColumnIndexes.RtsStartRow;
                        customerPath = _ucf["RTS_EXCEL"][0];
                        break;
                    case var unused when sender == buttonCreateUGS:
                        customerIndex = NXExcelData.RowColumnIndexes.UgsStartRow;
                        customerPath = _ucf["UGS_EXCEL"][0];
                        break;
                    default:
                        print_("Error");
                        return;
                }

                GFolder folder = GFolder.Create(__work_part_.FullPath)
                                 ??
                                 throw new InvalidOperationException(
                                     "The current work part does not reside in a job folder.");

                if (_selectedComponents.Count == 0 && !_isCasting)
                    BuildComponentList();

                Part[] partsInBom = _selectedComponents
                    .Where(__c => __c.__IsLoaded())
                    .Select(component => component.__Prototype())
                    .Distinct()
                    .ToArray();

                if (partsInBom.Length == 0)
                {
                    print_("Didn't find any data");
                    return;
                }

                if (!CheckMaterials(partsInBom))
                    return;

                if (!CheckSizeDescriptions(partsInBom))
                {
                    DialogResult result =
                        MessageBox.Show(
                            @"At least one block did not match its' description. Would you like to continue?",
                            @"Warning", MessageBoxButtons.YesNo);

                    switch (result)
                    {
                        case DialogResult.Yes:
                            break;
                        default:
                            return;
                    }
                }

                List<Part> metric_english_fastener_owners = new List<Part>();

                foreach (Part part in partsInBom)
                {
                    if (!part.__IsPartDetail())
                        continue;

                    if (part.ComponentAssembly.RootComponent is null)
                        continue;

                    Component[] fasteners = part.ComponentAssembly.RootComponent.GetChildren()
                        .Where(__c => !__c.IsSuppressed)
                        .Where(__c => __c.__IsFastener())
                        .ToArray();

                    Component[] metric_fasteners =
                        fasteners.Where(__f => __f.DisplayName.ToLower().Contains("mm")).ToArray();
                    Component[] english_fasteners =
                        fasteners.Where(__f => !__f.DisplayName.ToLower().Contains("mm")).ToArray();

                    if (metric_fasteners.Length > 0 && english_fasteners.Length > 0)
                        metric_english_fastener_owners.Add(part);

                    //NXOpen.Assemblies.Component[] dwls_mm = fasteners.Where(__f => __f._IsDwl()).Where(__f => __f.DisplayName.ToLower().Contains("mm")).ToArray();
                    //NXOpen.Assemblies.Component[] dwls_in = fasteners.Where(__f => __f._IsDwl()).Where(__f => !__f.DisplayName.ToLower().Contains("mm")).ToArray();

                    //NXOpen.Assemblies.Component[] jigjacks_mm = fasteners.Where(__f => __f._IsJckScrewTsg()).Where(__f => __f.DisplayName.ToLower().Contains("mm")).ToArray();
                    //NXOpen.Assemblies.Component[] jigjacks_in = fasteners.Where(__f => __f._IsJckScrewTsg()).Where(__f => !__f.DisplayName.ToLower().Contains("mm")).ToArray();

                    //NXOpen.Assemblies.Component[] jack_screws_mm = fasteners.Where(__f => __f._is()).Where(__f => __f.DisplayName.ToLower().Contains("mm")).ToArray();
                    //NXOpen.Assemblies.Component[] jigjack_screws_in = fasteners.Where(__f => __f._IsJckScrewTsg()).Where(__f => !__f.DisplayName.ToLower().Contains("mm")).ToArray();
                }

                if (metric_english_fastener_owners.Count > 0)
                {
                    print_("/////////////////////////////");
                    print_("The following parts have both unsuppressed english and metric fasteners");
                    foreach (Part part in metric_english_fastener_owners)
                        print_(part.Leaf);

                    DialogResult result =
                        MessageBox.Show(
                            "The following parts have both unsuppressed english and metric fasteners do you want to continue",
                            @"Warning", MessageBoxButtons.YesNo);

                    switch (result)
                    {
                        case DialogResult.Yes:
                            break;
                        default:
                            return;
                    }

                    print_("/////////////////////////////");
                }


                IEnumerable<NXExcelData> bomData = WriteData(customerIndex, customerPath, folder);

                if (bomData == null || _isCasting)
                    return;

                WriteCheckSheet(bomData, folder);
            }
            catch (FormatException)
            {
                // Expected.
            }
            catch (Exception ex)
            {
                ex.__PrintException();
            }
            finally
            {
                Show();
            }
        }

        private static bool CheckMaterials(IEnumerable<Part> partsInBom)
        {
            bool allPassed = true;

            foreach (Part part in partsInBom)
                try
                {
                    string att = part.GetUserAttributes().Select(information => information.Title)
                        .FirstOrDefault(title => title.ToLower() == "material");

                    if (att is null)
                    {
                        allPassed = false;
                        print_($"{part.Leaf} doesn't have a MATERIAL attribute.");
                        continue;
                    }

                    string attValue = part.GetUserAttributeAsString(att, NXObject.AttributeType.String, -1);

                    switch (attValue)
                    {
                        case null:
                            allPassed = false;
                            print_($"{part.Leaf} MATERIAL attribute has value of NULL.");
                            continue;
                        case "":
                            allPassed = false;
                            print_($"{part.Leaf} MATERIAL attribute has value of EMPTY.");
                            continue;
                        default:
                            if (string.IsNullOrWhiteSpace(attValue))
                            {
                                allPassed = false;
                                print_($"{part.Leaf} MATERIAL attribute has value of WHITESPACE.");
                            }

                            break;
                    }
                }
                catch (Exception ex)
                {
                    ex.__PrintException(part.Leaf);
                }

            return allPassed;
        }

        private static bool CheckSizeDescriptions(IEnumerable<Part> partsInBom)
        {
            bool allPassed = true;

            foreach (Part part in partsInBom)
                if (!SizeDescription1.Validate(part, out string message))
                {
                    allPassed = false;
                    print_($"{part.Leaf}:\n{message}\n");
                }

            return allPassed;
        }

        private static void WriteCheckSheet(IEnumerable<NXExcelData> bomDatas, GFolder folder)
        {
            prompt_("Preparing to create checker sheet.");
            ExcelApplication excelApp = new ExcelApplication();

            using (excelApp)
            {
                string checkerStockListPath = folder.file_checker_stock_list();

                if (File.Exists(checkerStockListPath))
                    File.Delete(checkerStockListPath);
                File.Copy(CheckProperties.CheckerTemplateFilePath, checkerStockListPath);
                NXExcelData[] enumeratedDatas = bomDatas.ToArray();
                for (int index = 0; index < enumeratedDatas.Length; index++)
                {
                    NXExcelData data = enumeratedDatas[index];
                    prompt_($"Writing checker sheet. Cell {index + 1} of {enumeratedDatas.Length}.");
                    int colIndex;
                    switch (data.ColumnIndex)
                    {
                        case BomProperties.DetailColumn:
                            colIndex = CheckProperties.DetailColumn;
                            break;
                        case BomProperties.DescriptionColumn:
                            colIndex = CheckProperties.DescriptionColumn;
                            break;
                        case BomProperties.RequiredColumn:
                            colIndex = CheckProperties.RequiredColumn;
                            break;
                        case BomProperties.MaterialColumn:
                            colIndex = CheckProperties.MaterialColumn;
                            break;
                        default:
                            continue;
                    }

                    //Revision 1.7 - 2018-01-29
                    int rowIndex = data.RowIndex - (BomProperties.StartRow + CheckProperties.StartRow) + 12;

                    excelApp.SetCell(checkerStockListPath, 1, rowIndex, colIndex, data.Data);

                    excelApp.SetCell(checkerStockListPath, 1, rowIndex, colIndex,
                        data.Data.ToUpper().Replace("-ALTER", ""));

                    if (!data.ColorCell) continue;

                    excelApp.SetCell(checkerStockListPath, 1, rowIndex, colIndex, Color.FromArgb(0, 255, 0));
                }

                excelApp.SaveWorkBook(checkerStockListPath);
            }
        }

        private IEnumerable<NXExcelData> WriteData(NXExcelData.RowColumnIndexes index, string path, GFolder folder)
        {
            using (ExcelApplication excelApp = new ExcelApplication())
            {
                // Revision 1.2 2017/11/22
                string expectedStocklistPath = _isCasting
                    ? $"{folder.DirStocklist}\\{__display_part_.Leaf}-casting-stocklist.xlsx"
                    : $"{folder.DirStocklist}\\{__display_part_.Leaf}-stocklist.xlsx";

                if (File.Exists(expectedStocklistPath))
                    // ReSharper disable once SwitchStatementMissingSomeCases
                    switch (MessageBox.Show($@"{expectedStocklistPath} already exists, would you like to overwrite it.",
                                @"Warning", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            File.Delete(expectedStocklistPath);
                            break;
                        default:
                            return null;
                    }

                string dir = Path.GetDirectoryName(expectedStocklistPath);

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.Copy(path, expectedStocklistPath);
                excelApp.Visible = false;
                BuildNxExcelList(index);

                if (ExcelData is null || ExcelData.Count == 0)
                {
                    print_("Did not find any data to write.");
                    return null;
                }

                Dictionary<int, NXExcelData> dict_parts = new Dictionary<int, NXExcelData>();
                Dictionary<int, NXExcelData> dict_sizes = new Dictionary<int, NXExcelData>();

                foreach (NXExcelData data in ExcelData)
                {
                    if (data.ColumnIndex == 1)
                        dict_parts[data.RowIndex] = data;

                    if (data.ColumnIndex == 3)
                        dict_sizes[data.RowIndex] = data;
                }

                System.Diagnostics.Debugger.Launch();

                foreach (int key in dict_parts.Keys)
                    try
                    {
                        var temp = $"{folder.CustomerNumber}-{dict_parts[key].Data}";

                        Part part = session_.__FindOrOpen(temp);
                        string description = dict_sizes[key].Data;

                        if (!chkMM.Checked)
                            continue;

                        Body solidBody = part.__SolidBodyLayer1OrNull();

                        if (solidBody is null)
                            continue;

                        Unit[] massUnits1 = new Unit[5];
                        massUnits1[0] = _WorkPart.UnitCollection.FindObject("SquareInch");
                        massUnits1[1] = _WorkPart.UnitCollection.FindObject("CubicInch");
                        massUnits1[2] = _WorkPart.UnitCollection.FindObject("PoundMass");
                        massUnits1[3] = _WorkPart.UnitCollection.FindObject("Inch");
                        massUnits1[4] = _WorkPart.UnitCollection.FindObject("PoundForce");
                        IBody[] objects1 = new IBody[1];
                        objects1[0] = solidBody;
                        MeasureBodies measureBodies1 =
                            _WorkPart.MeasureManager.NewMassProperties(massUnits1, 0.99, objects1);

                        using (measureBodies1)
                        {
                            measureBodies1.InformationUnit = MeasureBodies.AnalysisUnit.KilogramMillimeter;
                            string weight = $"{measureBodies1.Mass / 2.2:f3}";

                            ExcelData.Add(new NXExcelData
                            {
                                ColorCell = false,
                                ColumnIndex = 6,
                                RowIndex = key,
                                Data = weight
                            });
                        }

                        Match match = Regex.Match(description,
                            "(?<num0>\\d+\\.\\d+) X (?<num1>\\d+\\.\\d+) X (?<num2>\\d+\\.\\d+)(?<append>.*)");

                        if (!match.Success)
                            continue;

                        Box3d box = solidBody.__Box3d();
                        double x = double.Parse(match.Groups["num0"].Value) *
                                   25.4; //  Math.Abs(box.MaxX - box.MinX) * 25.4;
                        double y = double.Parse(match.Groups["num1"].Value) *
                                   25.4; //Math.Abs(box.MaxY - box.MinY) * 25.4;
                        double z = double.Parse(match.Groups["num2"].Value) * 25.4;
                        double[] sizes = new[] { x, y, z }.OrderBy(t => t).ToArray();
                        dict_sizes[key].Data =
                            $"{sizes[0]:f3} X {sizes[1]:f3} X {sizes[2]:f3}{match.Groups["append"].Value}";
                    }
                    catch (Exception ex)
                    {
                        ex.__PrintException($"{key}");
                    }

                _Worksheet workSheet = excelApp.WorkBookActiveSheet(expectedStocklistPath);

                // Writes the actual data to the excel sheet.
                NXExcelData.WriteData(workSheet, ExcelData);

                excelApp.SaveWorkBook(expectedStocklistPath);

                int max = ExcelData.Select(d => d.RowIndex).Max();

                Dictionary<string, int> _dict = new Dictionary<string, int>();

                foreach (Component comp1 in __display_part_.ComponentAssembly.RootComponent.__Descendants())
                {
                    if (!comp1.__IsLoaded())
                        continue;

                    if (comp1.IsSuppressed)
                        continue;

                    if (!comp1.__Prototype().FullPath.ToLower().Contains("fastener"))
                        continue;

                    if (comp1.__Prototype().FullPath.ToLower().Contains("jck"))
                        continue;

                    Tag fast_inst = UFSession.GetUFSession().Assem.AskInstOfPartOcc(comp1.Tag);

                    Component root = comp1.Parent.__Prototype().ComponentAssembly.RootComponent;

                    Tag original_inst = UFSession.GetUFSession().Assem.AskPartOccOfInst(root.Tag, fast_inst);

                    Component fastener_instance = (Component)session_.__GetTaggedObject(original_inst);

                    if (fastener_instance.Layer == 97 || fastener_instance.Layer == 98)
                        continue;

                    if (!_dict.ContainsKey(comp1.DisplayName.Replace("-2x", "")))
                        _dict.Add(comp1.DisplayName.Replace("-2x", ""), 0);

                    _dict[comp1.DisplayName.Replace("-2x", "")]++;
                }

                _Worksheet workSheetFasteners = excelApp.WorkSheet(expectedStocklistPath, "fasteners");

                string[] keys = _dict.Keys.OrderBy(k => k).ToArray();

                for (int i = 0; i < keys.Length; i++)
                {
                    workSheetFasteners.Cells[index + i, 2] = _dict[keys[i]];
                    workSheetFasteners.Cells[index + i, 3] = keys[i].Replace("-2x", "");
                    workSheetFasteners.Cells[index + i, 4] = "PUR";
                }

                // Constructs the path to the {previous}.
                string previous = $"{folder.DirStocklist}\\previous.txt";
                List<string> flags = new List<string>();
                if (File.Exists(previous))
                    flags.AddRange(File.ReadAllLines(previous));
                string[] strings = ShowCheckBoxDialog(ExcelData, flags.ToArray());
                File.WriteAllLines(previous, strings);
                NXExcelData.Color(strings, workSheet, ExcelData);
                excelApp.SaveWorkBook(expectedStocklistPath);
                // Revision 1.5 2018/01/08
                Process.Start(expectedStocklistPath);
                return ExcelData;
            }
        }

        private string[] ShowCheckBoxDialog(IEnumerable<NXExcelData> data, string[] array)
        {
            List<string> purchasedList = new List<string>();
            string[] purMaterials = _ucf["PURCHASED_MATERIALS"].ToArray();
            purMaterials = purMaterials.Where(s => s.ToUpper() != "PUR" && s.ToUpper() != "STOCK").ToArray();
            foreach (NXExcelData dat in data)
            foreach (string str in purMaterials)
            {
                if (!string.Equals(dat.Data, str, StringComparison.CurrentCultureIgnoreCase)) continue;
                if (!purchasedList.Contains(dat.Data.ToUpper()))
                    purchasedList.Add(dat.Data.ToUpper());
            }

            if (purchasedList.Count == 0)
                return new string[0];

            string[] strings = CheckBoxDialog.ShowBoxes(purchasedList.ToArray(), array, Location);
            return strings;
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
                _childComponents.Clear();
                _selectedComponents.Clear();
                ErrorComponents.Clear();
                ExcelData.Clear();

                Component[] selectedComponents = Selection.SelectManyComponents();

                if (selectedComponents.Length > 0)
                {
                    _selectedComponents = selectedComponents.Distinct(new EqualityDisplayName()).ToList();

                    return;
                }

                print_("There are no valid components");
            }
            catch (Exception ex)
            {
                ex.__PrintException();
            }
            finally
            {
                Show();
            }
        }

        private void ButtonLoadCastings_Click(object sender, EventArgs e)
        {
            using (session_.__UsingFormShowHide(this))
            {
                try
                {
                    BuildComponentList();

                    if (_selectedComponents.Count == 0)
                        return;

                    _childComponents.Clear();

                    foreach (Component comp in _selectedComponents.Select(__c => __c))
                    foreach (NXObject.AttributeInformation attr in comp.GetUserAttributes())
                    {
                        if (attr.Title.ToUpper() != "DESCRIPTION")
                            continue;

                        string value = comp.GetStringUserAttribute(attr.Title, -1);

                        if (value.Contains("CAST") || value.Contains("cast"))
                            _childComponents.Add(comp);
                    }

                    _isCasting = true;
                    _selectedComponents.Clear();
                    _selectedComponents.AddRange(_childComponents);
                }
                catch (Exception ex)
                {
                    ex.__PrintException();
                }
            }
        }

        private void BuildComponentList()
        {
            prompt_("Building Component list.");
            _isCasting = false;
            _childComponents.Clear();
            _selectedComponents.Clear();
            ErrorComponents.Clear();
            ExcelData.Clear();

            if (__display_part_.ComponentAssembly.RootComponent is null)
                return;

            GetChildComponents(__display_part_.ComponentAssembly.RootComponent);

            if (_childComponents.Count == 0)
                return;

            Component[] selectDeselectComps = _childComponents.ToArray();
            _childComponents = Preselect.GetUserSelections(selectDeselectComps);

            if (_childComponents.Count != 0)
                _selectedComponents = _childComponents.Distinct(new EqualityDisplayName()).ToList();
        }

        private void GetChildComponents(Component assembly)
        {
            foreach (Component child in assembly.GetChildren())
            {
                if (child.IsSuppressed)
                {
                    if (IsAssemNameValid(child))
                        print_($"{child.DisplayName} is suppressed");

                    if (IsNameValid(child))
                        print_($"{child.DisplayName} is suppressed");

                    continue;
                }

                bool isValid = IsNameValid(child);

                if (isValid)
                {
                    Tag instance = child.__InstanceTag();

                    if (instance == NXOpen.Tag.Null)
                        continue;

                    UFSession.GetUFSession().Assem.AskPartNameOfChild(instance, out string partName);
                    int partLoad = UFSession.GetUFSession().Part.IsLoaded(partName);

                    if (partLoad != 1)
                    {
                        UFSession.GetUFSession().Cfi.AskFileExist(partName, out int status);

                        if (status != 0)
                            continue;

                        UFSession.GetUFSession().Part.OpenQuiet(partName, out Tag partOpen, out _);

                        if (partOpen == NXOpen.Tag.Null)
                            continue;
                    }

                    _childComponents.Add(child);
                }

                GetChildComponents(child);
            }
        }

        /// <summary>
        ///     Gets a value indicating that the {comp} is a detail and and the {comp} has a name with the length of 3.
        /// </summary>
        private bool IsNameValid(Component comp)
        {
            if (chk4Digits.Checked)
                return comp.DisplayName.__IsDetail() && int.TryParse(comp.Name, out _) && comp.Name.Length == 4;
            return comp.DisplayName.__IsDetail() && int.TryParse(comp.Name, out _) && comp.Name.Length == 3;
        }

        private static bool IsAssemNameValid(Component comp)
        {
            string disp = comp.DisplayName.ToLower();

            if (disp.Contains("000"))
                return true;

            if (disp.Contains("lsh"))
                return true;

            if (disp.Contains("ush"))
                return true;

            if (disp.Contains("lsp"))
                return true;

            if (disp.Contains("usp"))
                return true;

            if (disp.Contains("lwr"))
                return true;

            if (disp.Contains("upr"))
                return true;

            return false;
        }

        private void BuildNxExcelList(NXExcelData.RowColumnIndexes startRowIndex)
        {
            ExcelData.Clear();
            HashSet<Part> hashParts = new HashSet<Part>();

            Component[] components = _selectedComponents.Select(__c => __c).ToArray();

            for (int i = 0; i < components.Length; i++)
            {
                Component comp = components[i];

                //prompt_($"Building NX Excel List: {i + 1} of {components.Length}");

                if (chk4Digits.Checked)
                {
                    if (comp.Name.Length != 4)
                        continue;
                }
                else if (comp.Name.Length != 3)
                {
                    continue;
                }

                hashParts.Add((Part)comp.Prototype);


                if (chk4Digits.Checked)
                {
                    if (comp.DisplayName.Contains("mirror"))
                    {
                        string testName = comp.DisplayName.Substring(comp.DisplayName.Length - 10, 4);
                        if (comp.Name != testName)
                            ErrorComponents.Add(comp);
                    }
                    else
                    {
                        string testName = comp.DisplayName.Substring(comp.DisplayName.Length - 4, 4);
                        if (comp.Name != testName)
                            ErrorComponents.Add(comp);
                    }
                }
                else
                {
                    if (comp.DisplayName.Contains("mirror"))
                    {
                        string testName = comp.DisplayName.Substring(comp.DisplayName.Length - 10, 3);
                        if (comp.Name != testName)
                            ErrorComponents.Add(comp);
                    }
                    else
                    {
                        string testName = comp.DisplayName.Substring(comp.DisplayName.Length - 3, 3);
                        if (comp.Name != testName)
                            ErrorComponents.Add(comp);
                    }
                }
            }

            if (ErrorComponents.Count != 0)
            {
                foreach (Component comp in ErrorComponents.Select(__c => __c))
                {
                    print_("/////////////////////////////////////////////////");
                    print_(
                        $"Error : Parent Name = {comp.DirectOwner.RootComponent.DisplayName} : Descriptive Name = {comp.DisplayName} : Component Name = {comp.Name}");
                    print_($"Assembly Path: {comp._AssemblyPathString()}");
                    print_("/////////////////////////////////////////////////");
                }

                return;
            }

            // create list of UGExcel objects from list of assembly components
            _selectedComponents.Sort((c1, c2) => string.Compare(c1.Name, c2.Name, StringComparison.Ordinal));
            int rowIndexCount = (int)startRowIndex;

            for (int i = 0; i < _selectedComponents.Count; i++)
            {
                prompt_($"Building NX Excel List: {i + 1} of {components.Length}");

                Component excelComp = _selectedComponents[i];
                // get component name and create detail number attribute
                int compNumber;
                string compName;
                // Added OperationNumber - 2013-09-25 dvw
                string opNumberName = string.Empty;
                bool isConverted;
                if (chk4Digits.Checked)
                {
                    //if (excelComp.DisplayName.Contains("mirror"))
                    //{
                    //    compName = excelComp.DisplayName.Substring(excelComp.DisplayName.Length - 11, 4);
                    //    isConverted = int.TryParse(compName, out compNumber);
                    //}
                    //else
                    //{
                    compName = excelComp.DisplayName.Substring(excelComp.DisplayName.Length - 4, 4);
                    //print_(compName);
                    int.TryParse(compName, out compNumber);
                    opNumberName = excelComp.DisplayName.Substring(excelComp.DisplayName.Length - 8, 3);
                    //print_(opNumberName);
                    // Added OpNumber - 2013-09-25 dvw
                    isConverted = int.TryParse(opNumberName, out _);
                    //}
                }
                else
                {
                    //if (excelComp.DisplayName.Contains("mirror"))
                    //{
                    //    compName = excelComp.DisplayName.Substring(excelComp.DisplayName.Length - 10, 3);
                    //    isConverted = int.TryParse(compName, out compNumber);
                    //}
                    //else
                    //{
                    compName = excelComp.DisplayName.Substring(excelComp.DisplayName.Length - 3, 3);
                    int.TryParse(compName, out compNumber);
                    opNumberName = excelComp.DisplayName.Substring(excelComp.DisplayName.Length - 7, 3);
                    // Added OpNumber - 2013-09-25 dvw
                    isConverted = int.TryParse(opNumberName, out _);
                    //}
                }

                if (isConverted)
                    if (compNumber > 0 && compNumber < 10000)
                    {
                        NXExcelData excelDataName = new NXExcelData
                        {
                            Data = opNumberName + "-" + compName,
                            RowIndex = rowIndexCount,
                            ColumnIndex = (int)NXExcelData.RowColumnIndexes.NameColumn
                        };
                        //excelDataName.Data = compName; - 2013-09-25 dvw
                        ExcelData.Add(excelDataName);
                        // get all occurrences and create quantity attribute
                        Part excelPart = (Part)excelComp.Prototype;
                        UFSession.GetUFSession().Assem
                            .AskOccsOfPart(__display_part_.Tag, excelPart.Tag, out Tag[] partOccs);
                        int quantity = (from occTag in partOccs
                            select (Component)NXObjectManager.Get(occTag)
                            into component
                            where (component.Name.Length == 3 && !chk4Digits.Checked) ||
                                  (component.Name.Length == 4 && chk4Digits.Checked)
                            where !component.Parent.IsSuppressed
                            where !component.IsSuppressed
                            // Revision 1.11 2017/10/11 
                            select component).Count(component => component.Parent.ReferenceSet != "Empty");
                        NXExcelData excelDataQty = new NXExcelData
                        {
                            Data = quantity.ToString(),
                            RowIndex = rowIndexCount,
                            ColumnIndex = (int)NXExcelData.RowColumnIndexes.QtyColumn
                        };

                        ExcelData.Add(excelDataQty);
                        NXObject.AttributeInformation[] descriptionAttributes = excelPart.GetUserAttributes()
                            .Where(att => att.Title.ToUpper() == "DESCRIPTION").ToArray();
                        bool isCasting = descriptionAttributes.Length == 1 &&
                                         descriptionAttributes[0].StringValue != null && descriptionAttributes[0]
                                             .StringValue.ToUpper().Contains("CAST");
                        // Gets the attribute titles and columns for the cells that need to be populated.
                        var pairs = (from str in _ucf["ATTRIBUTE_TO_POPULATE_WITH"]
                            let match = Regex.Match(str, @"^{(?<title>.+)}:{(?<column>\d+)}$")
                            where match.Success
                            let title = match.Groups["title"].Value
                            let column = match.Groups["column"].Value
                            select new { title, column }).ToArray();
                        // Iterate through the attribute titles and columns.
                        foreach (var pair in pairs)
                        {
                            // Gets the attributes that the {excelPat} has whose title matches the title. Not case sensitive.
                            NXObject.AttributeInformation[] attributes = excelPart.GetUserAttributes().Where(att =>
                                string.Equals(att.Title, pair.title, StringComparison.OrdinalIgnoreCase)).ToArray();

                            // todo: do we want to throw in this case?
                            // If the length of {attributes} does not equal 1, then we can just continue for now.
                            if (attributes.Length != 1) continue;
                            ExcelData.Add(new NXExcelData
                            {
                                Data = string.IsNullOrEmpty(attributes[0].StringValue) ? "" : attributes[0].StringValue,
                                RowIndex = rowIndexCount,
                                ColumnIndex = int.Parse(pair.column)
                            });
                        }

                        if (isCasting)
                            foreach (Body body in excelPart.Bodies)
                            {
                                int count = 1;

                                if (body.Layer != 1)
                                    continue;

                                if (count != 1)
                                {
                                    print_(
                                        $"More than one solid body on layer one in casting : {excelComp.DisplayName}");
                                    continue;
                                }

                                count++;

                                string MeasureBody(IBody tempBody)
                                {
                                    Unit[] massUnits1 = new Unit[5];
                                    massUnits1[0] = __work_part_.UnitCollection.FindObject("SquareInch");
                                    massUnits1[1] = __work_part_.UnitCollection.FindObject("CubicInch");
                                    massUnits1[2] = __work_part_.UnitCollection.FindObject("PoundMass");
                                    massUnits1[3] = __work_part_.UnitCollection.FindObject("Inch");
                                    massUnits1[4] = __work_part_.UnitCollection.FindObject("PoundForce");
                                    IBody[] objects1 = new IBody[1];
                                    objects1[0] = tempBody;
                                    MeasureBodies measureBodies1 =
                                        __work_part_.MeasureManager.NewMassProperties(massUnits1, 0.99, objects1);
                                    using (measureBodies1)
                                    {
                                        measureBodies1.InformationUnit = MeasureBodies.AnalysisUnit.PoundInch;
                                        return measureBodies1.Weight.ToString(CultureInfo.CurrentCulture);
                                    }
                                }

                                NXExcelData excelDataWeight = new NXExcelData
                                {
                                    Data = MeasureBody(body),
                                    RowIndex = rowIndexCount,
                                    ColumnIndex = (int)NXExcelData.RowColumnIndexes.WeightColumn
                                };
                                ExcelData.Add(excelDataWeight);
                            }
                    }
                    else
                    {
                        print_($"{excelComp.DisplayName} is not a valid component name");
                    }

                rowIndexCount++;
            }
        }

        private void BtnClearSelection_Click(object sender, EventArgs e)
        {
            if (_selectedComponents.Count > 0)
                prompt_($"Cleared {_selectedComponents.Count} selected components");

            _selectedComponents.Clear();
            _childComponents.Clear();
            ErrorComponents.Clear();
            ExcelData.Clear();
        }

        private void BillOfMaterialForm_Load(object sender, EventArgs e)
        {
            Location = Settings.Default.bill_of_material_form_window_location;
            Text = AssemblyFileVersion;
        }

        private void BillOfMaterialForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.bill_of_material_form_window_location = Location;
            Settings.Default.Save();
        }

        public struct BomProperties
        {
            /// <summary>The column in the Bom template for the detail number.</summary>
            public const int DetailColumn = 1;

            /// <summary>The column in the Bom template for the required number.</summary>
            public const int RequiredColumn = 2;

            /// <summary>The column in the Bom template for the description.</summary>
            public const int DescriptionColumn = 3;

            /// <summary>The column in the Bom template for the material.</summary>
            public const int MaterialColumn = 4;

            /// <summary>The row in the Bom template to start the details.</summary>
            public const int StartRow = 16;
        }

        public struct CheckProperties
        {
            /// <summary>The path to the template file used by the check department.</summary>
            /// <remarks>Revision 1.6 – 2018 / 01 / 10</remarks>
            public static string CheckerTemplateFilePath => "U:\\nxFiles\\Excel\\CheckerTemplate.xlsx";

            /// <summary>The column in the check template for the detail number.</summary>
            public static int DetailColumn => 5;

            /// <summary>The column in the check template for the required number.</summary>
            public static int RequiredColumn => 6;

            /// <summary>The column in the check template for the description.</summary>
            public static int DescriptionColumn => 7;

            /// <summary>The column in the check template for the material.</summary>
            public static int MaterialColumn => 8;

            /// <summary>The row in the check template to start the details.</summary>
            public static int StartRow => 7;
        }

        public class ExcelApplication : IDisposable
        {
            private readonly Microsoft.Office.Interop.Excel.Application _application;

            private readonly List<Range> _ranges;

            private readonly IDictionary<string, Workbook> _workBooks;

            private readonly List<_Worksheet> _workSheets;

            public ExcelApplication()
            {
                _application = new Microsoft.Office.Interop.Excel.Application();
                _workBooks = new Dictionary<string, Workbook>();
                _workSheets = new List<_Worksheet>();
                _ranges = new List<Range>();
            }


            //NXOpen.NXObject


            public bool Visible
            {
                get => _application.Visible;
                set => _application.Visible = value;
            }

            public void Dispose()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                foreach (Range range in _ranges)
                    if (range != null)
                        Marshal.ReleaseComObject(range);

                foreach (_Worksheet range in _workSheets)
                    if (range != null)
                        Marshal.ReleaseComObject(range);

                foreach (KeyValuePair<string, Workbook> range in _workBooks)
                    if (range.Value != null)
                    {
                        range.Value.Close();
                        Marshal.ReleaseComObject(range.Value);
                    }

                _application.Quit();
                Marshal.ReleaseComObject(_application);
            }

            public void SetCell(string excelFilePath, int sheetIndex, object rowIndex, object columnIndex, object data)
            {
                if (!_workBooks.ContainsKey(excelFilePath))
                    _workBooks.Add(excelFilePath, _application.Workbooks.Open(excelFilePath));

                _Worksheet workSheet = (_Worksheet)_workBooks[excelFilePath].Sheets[sheetIndex];

                _workSheets.Add(workSheet);

                Range range = workSheet.UsedRange;

                _ranges.Add(range);

                if (!(range[rowIndex, columnIndex] is Range tempRange))
                    return;

                _ranges.Add(tempRange);

                tempRange.Value2 = data;
            }

            public void SetCell(string excelFilePath, int sheetIndex, object rowIndex, object columnIndex, Color color)
            {
                if (!_workBooks.ContainsKey(excelFilePath))
                    _workBooks.Add(excelFilePath, _application.Workbooks.Open(excelFilePath));

                _Worksheet workSheet = (_Worksheet)_workBooks[excelFilePath].Sheets[sheetIndex];

                _workSheets.Add(workSheet);

                Range range = workSheet.UsedRange;

                _ranges.Add(range);

                if (!(range[rowIndex, columnIndex] is Range tempRange))
                    return;

                _ranges.Add(tempRange);

                tempRange.Interior.Color = color;
            }

            //public _Worksheet WorkBookActiveSheet1(string excelFilePath)
            //{
            //    if (!_workBooks.ContainsKey(excelFilePath))
            //        _workBooks.Add(excelFilePath, _application.Workbooks.Open(excelFilePath));

            //    //_Worksheet workSheet = (_Worksheet)_workBooks[excelFilePath].Worksheets["Sheet1"];


            //    _workSheets.Add(workSheet);

            //    return workSheet;
            //}

            //public _Worksheet WorkBookActiveSheet(string excelFilePath)
            //{
            //    if (!_workBooks.ContainsKey(excelFilePath)) 
            //        _workBooks.Add(excelFilePath, _application.Workbooks.Open(excelFilePath));

            //    _Worksheet workSheet = (_Worksheet)_workBooks[excelFilePath].ActiveSheet;

            //    _workSheets.Add(workSheet);

            //    return workSheet;
            //}

            public _Worksheet WorkBookActiveSheet(string excelFilePath)
            {
                if (!_workBooks.ContainsKey(excelFilePath))
                    _workBooks.Add(excelFilePath, _application.Workbooks.Open(excelFilePath));

                _Worksheet workSheet = (_Worksheet)_workBooks[excelFilePath].ActiveSheet;

                _workSheets.Add(workSheet);

                return workSheet;
            }

            public void SaveWorkBook(string excelFilePath)
            {
                if (!_workBooks.ContainsKey(excelFilePath))
                    throw new FileNotFoundException(
                        $"You cannot save excel sheet \"{excelFilePath}\" when you haven't opened it.");
                _workBooks[excelFilePath].Save();
            }

            internal _Worksheet WorkSheet(string excelFilePath, string name)
            {
                //if (!_workBooks.ContainsKey(excelFilePath))
                //    _workBooks.Add(excelFilePath, _application.Workbooks.Open(excelFilePath));

                return (_Worksheet)_workBooks[excelFilePath].Worksheets[name];

                //_workSheets.Add(workSheet);

                //return workSheet;
            }
        }

        internal class NXExcelData
        {
            public enum RowColumnIndexes
            {
                AtsStartRow = 14,
                CtsStartRow = AtsStartRow,
                DtsStartRow = AtsStartRow,
                EtsStartRow = AtsStartRow,
                HtsStartRow = AtsStartRow,
                RtsStartRow = AtsStartRow,
                UgsStartRow = AtsStartRow,
                NameColumn = 1,
                QtyColumn = 2,
                DescriptionColumn = 3,
                MaterialColumn = 4,
                WeightColumn = 8
            }
            // Data

            // ReSharper disable once InconsistentNaming
            private const string REPORT_TEXT = "verdana";

            // ReSharper disable once InconsistentNaming
            private const int REPORT_TEXT_SIZE = 10;

            // Constructors

            public NXExcelData()
            {
            }

            public NXExcelData(int rowIndex, int columnIndex, string data)
            {
                RowIndex = rowIndex;
                ColumnIndex = columnIndex;
                Data = data;
                ColorCell = false;
            }

            public int RowIndex { get; set; }

            public int ColumnIndex { get; set; }

            public string Data { get; set; }

            public bool ColorCell { get; set; }

            // Methods

            public static void WriteData(_Worksheet worksheet, List<NXExcelData> data)
            {
                worksheet.Columns.HorizontalAlignment = Constants.xlCenter;
                worksheet.Columns.Font.Name = REPORT_TEXT;
                worksheet.Columns.Font.Size = REPORT_TEXT_SIZE;
                //excelApp.SetCell(checkerStockListPath, 1, rowIndex, colIndex, data.Data.ToUpper().Replace("-ALTER", ""));
                for (int index = 0; index < data.Count; index++)
                {
                    NXExcelData nxExcelData = data[index];
                    UFSession.GetUFSession().Ui.SetPrompt($"Writing BOM sheet. Cell {index + 1} of {data.Count}.");
                    worksheet.Cells[nxExcelData.RowIndex, nxExcelData.ColumnIndex] =
                        nxExcelData.Data.ToUpper().ToUpper().Replace("-ALTER", "");
                }
            }


            public static void Color(string[] strings, _Worksheet worksheet, IEnumerable<NXExcelData> data)
            {
                foreach (NXExcelData excelData in data)
                {
                    if (strings.All(str =>
                            !string.Equals(str, excelData.Data, StringComparison.CurrentCultureIgnoreCase))) continue;
                    excelData.ColorCell = true;
                    if (worksheet.Cells[excelData.RowIndex, excelData.ColumnIndex] is Range range)
                        range.Interior.Color = System.Drawing.Color.FromArgb(0, 255, 0);
                }
            }
        }
    }
}