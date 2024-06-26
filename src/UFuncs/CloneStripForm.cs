﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NXOpen;
using NXOpen.Assemblies;
using NXOpen.Layer;
using NXOpen.Positioning;
using NXOpen.UF;
using TSG_Library.Attributes;
using TSG_Library.Properties;
using TSG_Library.Utilities;
using static TSG_Library.Extensions.Extensions;
using static TSG_Library.Utilities.GFolder;
using static TSG_Library.UFuncs._UFunc;
using static TSG_Library.UFuncs.CloneAssemblyForm;
using Selection = TSG_Library.Ui.Selection;

namespace TSG_Library.UFuncs
{
    [UFunc(ufunc_clone_strip)]
    public partial class CloneStripForm : _UFuncForm
    {
        public CloneStripForm()
        {
            InitializeComponent();
        }

        private void BtnAddStation_Click(object sender, EventArgs e)
        {
            try
            {
                add_station();
            }
            catch (Exception ex)
            {
                ex.__PrintException();
            }
        }

        private void BtnDeleteStation_Click(object sender, EventArgs e)
        {
            try
            {
                delete_station();
            }
            catch (Exception ex)
            {
                ex.__PrintException();
            }
        }

        private void btnCreateStationNew_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                //System.Diagnostics.Debugger.Launch();

                ListingWindow lw = Session.GetSession().ListingWindow;
                string jobDir = txtJobPath.Text;
                int transfer = (int)numUpDownTransfer.Value;
                int prog = (int)numUpDownProg.Value;
                int progPresses = (int)numUpDownProgPresses.Value;
                int tranPresses = (int)numUpDownTranPresses.Value;
                bool start005 = chk005.Checked;

                Match match = Regex.Match(jobDir, @"^([gcph]:)\\(cts|rts|hts|dts|ats|ets)\\(?<top_dir>\d{4,6})",
                    RegexOptions.IgnoreCase);

                if (!match.Success)
                {
                    print_("Could not determine Job Folder");
                    return;
                }

                string top_dir = match.Groups["top_dir"].Value.Trim();


                GFolder __folder = Create(jobDir);

                string leaf = Path.GetFileNameWithoutExtension(jobDir);

                //Match match = Regex.Match(leaf, "^(?<custNum>\\d{6}).*$");

                //if (!match.Success)
                //{
                //    lw.Open();
                //    lw.WriteLine("Bad job directory");
                //    return;
                //}

                create(__folder, transfer, tranPresses, prog, progPresses, start005, chkOfflineDie.Checked);

                //string custNum = match.Groups["custNum"].Value;

                //NXOpen.Session.GetSession().Execute(
                //   @"C:\Repos\NXJournals\Journals\create_strip.py",
                //   "",
                //    "create_strip",
                //   new object[] { jobDir, custNum, transfer, prog, start005, progPresses, tranPresses, chkOfflineDie.Checked });
            }
            catch (Exception ex)
            {
                ex.__PrintException();
                return;
            }
            finally
            {
                stopwatch.Stop();

                UFSession.GetUFSession().Ui.SetPrompt("Complete");
                UFSession.GetUFSession().Ui.SetStatus("Complete1");
                //print_(stopwatch.Elapsed);
            }

            print_("Clone Strip complete");
        }

        private void btnAddSimulation_Click(object sender, EventArgs e)
        {
            try
            {
                Component sim_comp = __display_part_.ComponentAssembly.RootComponent.GetChildren()
                    .Where(__c => __c.Layer == 8)
                    .SingleOrDefault(__c => __c.Name.ToLower().StartsWith("simulation"));

                if (sim_comp is null)
                {
                    print_("Did not detect a sim file on Layer 8");
                    return;
                }

                if (!sim_comp.__IsLoaded())
                {
                    print_("Please load the simulation file");
                    return;
                }

                foreach (Component child in __display_part_.ComponentAssembly.RootComponent.GetChildren())
                    if (child.Name.EndsWith("-WORK"))
                    {
                        child.__Prototype().__AddComponent(
                            sim_comp.__Prototype().FullPath,
                            "Empty",
                            origin: sim_comp.__Origin(),
                            orientation: sim_comp.__Orientation(),
                            componentName: child.Name.Replace("-WORK", "-SIMULATION"),
                            layer: 8
                        );

                        __display_part_.__AddComponent(
                            sim_comp.__Prototype().FullPath,
                            origin: new Point3d(
                                sim_comp.__Origin().X + child.__Origin().X,
                                sim_comp.__Origin().Y + child.__Origin().Y,
                                sim_comp.__Origin().Z + child.__Origin().Z),
                            orientation: sim_comp.__Orientation(),
                            componentName: child.Name.Replace("-WORK", "-SIMULATION"),
                            layer: 8);
                    }
            }
            catch (Exception ex)
            {
                ex.__PrintException();
            }
        }

        private void btnDeleteSimulation_Click(object sender, EventArgs e)
        {
            try
            {
                Session.UndoMarkId id = session_.SetUndoMark(Session.MarkVisibility.Visible, "");

                __display_part_.ComponentAssembly.RootComponent.GetChildren()
                    .Where(__c => __c.Layer != 8)
                    .SelectMany(__c => __c.GetChildren())
                    .Where(__c => __c.Name.ToUpper().Contains("SIMULATION"))
                    .ToList()
                    .ForEach(__c => session_.UpdateManager.AddObjectsToDeleteList(new[] { __c }));

                __display_part_.ComponentAssembly.RootComponent.GetChildren()
                    .Where(__c => __c.Layer == 8)
                    //.SelectMany(__c => __c.GetChildren())
                    .Where(__c => __c.Name.ToUpper().EndsWith("SIMULATION"))
                    .ToList()
                    .ForEach(__c => session_.UpdateManager.AddObjectsToDeleteList(new[] { __c }));

                session_.UpdateManager.DoUpdate(id);
            }
            catch (Exception ex)
            {
                ex.__PrintException();
            }
        }

        private void BtnAddTranPress_Click(object sender, EventArgs e)
        {
            add_press("T");
        }

        private void BtnAddProgPress_Click(object sender, EventArgs e)
        {
            add_press("P");
        }

        private void NumUpDownProg_ValueChanged(object sender, EventArgs e)
        {
            Reset();
        }

        private void NumUpDownTransfer_ValueChanged(object sender, EventArgs e)
        {
            Reset();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = AssemblyFileVersion;
            Location = Settings.Default.clone_strip_form_window_location;

            if (Environment.UserName == "mcbailey")
                txtJobPath.Text = "C:\\CTS\\003506 (lydall)";

            chkOfflineDie.Checked = true;
            Reset();
        }

        private void ChkOfflineDie_CheckedChanged(object sender, EventArgs e)
        {
            Reset();
        }

        private void Chk005_CheckedChanged(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            int transfer = (int)numUpDownTransfer.Value;

            if (transfer > 0 && !chkOfflineDie.Checked)
            {
                numUpDownProgPresses.Value = 0;
                numUpDownProgPresses.Enabled = false;
            }
            else
            {
                numUpDownProgPresses.Enabled = true;
            }

            if (transfer == 0)
            {
                numUpDownTranPresses.Value = 0;
                numUpDownTranPresses.Enabled = false;
                chkOfflineDie.Checked = false;
                chkOfflineDie.Enabled = false;
            }
            else
            {
                numUpDownTranPresses.Enabled = true;
                chkOfflineDie.Enabled = true;
            }
        }

        //public void add_press(string prefix)
        //{

        //    var has_prog = __display_part_.ComponentAssembly.RootComponent.GetChildren()
        //        .Select(__c => __c.Name.ToUpper())
        //        .Any(__c => Regex.IsMatch(__c, "^P\\d\\d\\d-"));

        //    var has_tran = __display_part_.ComponentAssembly.RootComponent.GetChildren()
        //        .Select(__c => __c.Name.ToUpper())
        //        .Any(__c => Regex.IsMatch(__c, "^T\\d\\d\\d-"));


        //    var __match0 = Regex.Match(__display_part_.Leaf, "^(?<cus_num>\\d{6})-.*$");

        //    if (!__match0.Success)
        //    {
        //        print_("Could not find customer number");
        //        return;
        //    }


        //    var cust_num = __match0.Groups["cus_num"].Value;

        //    var directory = session_.IO.dirname(__display_part_.FullPath);

        //    var job_folder = session_.IO.dirname(directory);
        //    var layout_folder = $"{job_folder}\\Layout";

        //    var op_int = 10;
        //    string press_path;
        //    while (true)
        //    {
        //        var op_str = op_10_010(op_int);
        //        press_path = $"{layout_folder}\\{cust_num}-{prefix}{op_str}-Press.prt";

        //        try
        //        {
        //            if (session_.IO.path_exists(press_path))
        //                continue;

        //            if (prefix == "P" && has_tran)
        //            {
        //                print_("You can't add a prog press");
        //                return;
        //            }

        //            if (prefix == "T" && !has_tran && has_prog)
        //            {
        //                print_("You can't add a tran press");
        //                return;
        //            }

        //            session_.IO.copyfile(GFolder.XXXXX_Press_XX_Assembly, press_path);

        //            var press_comp = __display_part_._AddComponent(
        //                press_path,
        //                "Entire Part",
        //                $"{prefix}{op_str}-PRESS",
        //                new Position_(0.0, 0.0, 0.0),
        //                Orientation_.identity_xy(),
        //                245
        //            );

        //            __display_part_.Layers.SetState(256, NXOpen.Layer.State.WorkLayer);

        //            var proto_press_csys = press_comp.__Prototype()
        //                .features
        //                .First()
        //                .to_datum_csys_feature_();

        //            var strip_csys0 = __display_part_.features.First().to_datum_csys_feature_();

        //            // # constrains the xy planes
        //            var constaint = __display_part_.constrain_occ_proto_distance(
        //                press_comp.find_occurrence(proto_press_csys.datum_plane_xy).to_datum_plane_(),
        //                strip_csys0.datum_plane_xy,
        //                "0.0"
        //                );

        //            constaint.Name = $"{prefix}{op_str}-PRESS-XY";
        //            constaint.get_displayed_constraint().Layer = 256;

        //            // # constrains the yz planes
        //            constaint = __display_part_.constrain_occ_proto_distance(
        //                press_comp.find_occurrence(proto_press_csys.datum_plane_yz).to_datum_plane_(),
        //                strip_csys0.datum_plane_yz,
        //                "0.0"
        //                );


        //            constaint.Name = $"{prefix}{op_str}-PRESS-YZ";
        //            constaint.get_displayed_constraint().Layer = 256;


        //            var __entity = __display_part_.features[1]
        //                .to_datum_plane_feature_()
        //                
        //                .GetEntities()[0];

        //            // # constrains the xz planes
        //            constaint = __display_part_.constrain_occ_proto_distance(
        //                    press_comp.find_occurrence(proto_press_csys.datum_plane_xz).to_datum_plane_(),
        //                    session_.c1reate__(__entity).to_datum_plane_(),
        //                    "0.0"
        //                );

        //            constaint.Name = $"{prefix}{op_str}-PRESS-XZ";
        //            constaint.get_displayed_constraint().Layer = 256;


        //            press_comp.reference_set = "BODY";
        //            break;
        //        }
        //        finally
        //        {
        //            op_int += 10;
        //        }
        //    }

        //}

        private void txtJobPath_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = "G:\\";

            dialog.ShowDialog();

            string k = dialog.SelectedPath;

            txtJobPath.Text = k;
        }

        private void txtJobPath_TextChanged(object sender, EventArgs e)
        {
        }


        private void CloneStripForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.clone_strip_form_window_location = Location;
            Settings.Default.Save();
        }

        public static List<int> ask_prog_station_10()
        {
            return __display_part_.ComponentAssembly.RootComponent.GetChildren()
                .Select(__child =>
                    Regex.Match(__child.DisplayName, "^(\\d{6})-(?<__prefix>[TP])(?<__op>\\d{3})-Layout$"))
                .Where(__match => __match.Success)
                .Where(__match => __match.Groups["__prefix"].Value == "P")
                .Select(__match => __match.Groups["__op"].Value)
                .Select(__op => int.Parse(__op))
                .Reverse()
                .ToList();
        }

        public static List<int> ask_tran_station_10()
        {
            return __display_part_.ComponentAssembly.RootComponent.GetChildren()
                .Select(__child =>
                    Regex.Match(__child.DisplayName, "^(\\d{6})-(?<__prefix>[TP])(?<__op>\\d{3})-Layout$"))
                .Where(__match => __match.Success)
                .Where(__match => __match.Groups["__prefix"].Value == "T")
                .Select(__match => __match.Groups["__op"].Value)
                .Select(__op => int.Parse(__op))
                .Reverse()
                .ToList();
        }

        public static void move_station(int op, int op_next, string cust_num, string selected_prefix)
        {
            string __old_op = __Op10To010(op);
            string __next_op = __Op10To010(op_next);
            string leaf = $"{cust_num}-{selected_prefix}{__old_op}-Layout";
            //    # new_leaf =
            Part old_part = session_.__FindOrOpen(leaf);
            string old_file_path = old_part.FullPath;
            string new_file_path = old_file_path.Replace(leaf, $"{cust_num}-{selected_prefix}{__next_op}-Layout");
            __work_part_ = old_part;
            old_part.SaveAs(new_file_path);
            __work_part_ = __display_part_;
            File.Delete(old_file_path);
            int length = uf_.Assem.AskOccsOfPart(__display_part_.Tag, old_part.Tag, out Tag[] __part_occs);
            for (int i = 0; i < length; i++)
            {
                Component comp = (Component)session_.__GetTaggedObject(__part_occs[i]);

                comp.SetName(comp.Name.Replace(__old_op, __next_op));

                foreach (ComponentConstraint __const in comp.GetConstraints())
                {
                    string new_formula = __const.Expression.RightHandSide.Replace(__old_op, __next_op);
                    __const.Expression.RightHandSide = new_formula;
                    string new_name = __const.Expression.Name.Replace(__old_op, __next_op);
                    __const.SetName(__const.Name.Replace(__old_op, __next_op));
                    try
                    {
                        __display_part_.Expressions.Rename(__const.Expression, new_name);
                    }
                    catch (Exception ex)
                    {
                        ex.__PrintException();
                    }
                }
            }
        }

        public static void add_station()
        {
            Component selected_comp = Selection.SelectSingleComponent();

            string selected_part_path = selected_comp.__Prototype().FullPath;

            Match __match0 = Regex.Match(selected_comp.DisplayName,
                "^(?<cust_num>\\d{6})-(?<prefix>[TP])(?<detail>\\d{3})-Layout$");

            List<int> progs = ask_prog_station_10();

            List<int> trans = ask_tran_station_10();

            if (!__match0.Success)
                throw new Exception("Please select a valid transfer or progressive station");

            string __prefix = __match0.Groups["prefix"].Value;

            List<int> ops;

            if (__prefix == "T")
                ops = ask_tran_station_10();
            else if (__prefix == "P")
                ops = ask_prog_station_10();
            else
                throw new Exception();
            ops = ops.Distinct().ToList();
            ops.Sort();
            ops.Reverse();

            string cust_num = __match0.Groups["cust_num"].Value;

            int selected_op = int.Parse(__match0.Groups["detail"].Value);

            foreach (int op in ops)
            {
                if (op < selected_op)
                    break;
                move_station(op, op + 10, cust_num, __prefix);
            }

            if (selected_op == 10)
            {
                File.Copy(XxxxxxOpXxxLayout, selected_part_path);
            }
            else
            {
                string new_part_file = selected_part_path.Replace(
                    $"-{__prefix}{__Op10To010(selected_op)}-Layout",
                    $"-{__prefix}{__Op10To010(selected_op - 10)}-Layout");
                File.Copy(new_part_file, selected_part_path);
            }


            string op_str = __Op10To010(selected_op);

            if (__prefix == "P")
            {
                prog_work(op_str, selected_part_path, __prefix);
                prog_lifted(op_str, selected_part_path, __prefix);


                int max_op = ops.Max();

                if (ask_prog_station_10().Count > 0 && ask_tran_station_10().Count > 0 && selected_op == max_op)
                {
                    prog_transfer(Create(op_str), selected_part_path, __prefix);

                    if (max_op > 0)
                    {
                        string max_op_str = __Op10To010(max_op);
                        Component __comp = __display_part_.ComponentAssembly.RootComponent.GetChildren()
                            .Single(__c => __c.Name == $"P{__Op10To010(max_op)}-TRANSFER");
                        __comp.__DeleteSelfAndConstraints();
                    }
                }
            }

            if (__prefix == "T")
            {
                tran_work(op_str, selected_part_path, __prefix);
                tran_lifted(op_str, selected_part_path, __prefix);
                tran_transfer(op_str, selected_part_path, __prefix);
            }

            uf_.Modl.Update();
            update_sim_components();
        }

        public static void delete_station()
        {
            Component result = Selection.SelectSingleComponent();
            delete_station(result);
        }

        public static void delete_station(Component selected_comp)
        {
            //    # import nx_open.tagged_object

            //    # __folder = GFolder.create(__display_part_.FullPath)
            //    #
            //    # _p_stations = __display_part_.ComponentAssembly.RootComponent\
            //    #     .GetChildren()\
            //    #     .where(lambda __child:__child.startswith(f"{__folder.customer_number}-P"))
            //    #
            //    # _t_stations = __display_part_.ComponentAssembly.RootComponent \
            //    #     .GetChildren() \
            //    #     .where(lambda __child: __child.startswith(f"{__folder.customer_number}-T"))


            Match __match0 = Regex.Match(selected_comp.DisplayName,
                "^(?<cust_num>\\d{6})-(?<prefix>[TP])(?<detail>\\d{3})-Layout$");

            if (!__match0.Success)
            {
                print_("Please select a valid transfer or progressive station");
                return;
            }

            string __prefix = __match0.Groups["prefix"].Value;

            List<int> ops;

            if (__prefix == "T")
                ops = ask_tran_station_10();
            else if (__prefix == "P")
                ops = ask_prog_station_10();
            else
                throw new Exception();

            ops = ops.Distinct().ToList();
            ops.Sort();
            //ops.Reverse();

            //foreach (var k in ops)
            //    print_(k);


            //    ops = list(sorted(set(ops)))
            string cust_num = __match0.Groups["cust_num"].Value;
            string selected_prefix = __match0.Groups["prefix"].Value;
            int selected_op = int.Parse(__match0.Groups["detail"].Value);
            string selected_display_name = selected_comp.DisplayName;
            string selected_full_path = selected_comp.__Prototype().FullPath;

            Part selected_part = selected_comp.__Prototype();
            File.Delete(selected_part.FullPath);

            uf_.Assem.AskOccsOfPart(__display_part_.Tag, selected_comp.__Prototype().Tag, out Tag[] part_occs);
            for (int i = 0; i < part_occs.Length; i++)
                ((Component)session_.__GetTaggedObject(part_occs[i])).__DeleteSelfAndConstraints();

            selected_part.__Close();

            foreach (int op in ops)
            {
                if (op <= selected_op)
                    continue;
                move_station(op, op - 10, cust_num, selected_prefix);
            }

            // check if contains both T and P layouts
            int[] prog_ops = __display_part_.ComponentAssembly.RootComponent.GetChildren()
                .Select(__c => Regex.Match(__c.Name, "^P(?<op>\\d\\d\\d)-"))
                .Where(__r => __r.Success)
                .Select(__r => int.Parse(__r.Groups["op"].Value))
                .ToArray();

            int[] tran_ops = __display_part_.ComponentAssembly.RootComponent.GetChildren()
                .Select(__c => Regex.Match(__c.Name, "^T(?<op>\\d\\d\\d)-"))
                .Where(__r => __r.Success)
                .Select(__r => int.Parse(__r.Groups["op"].Value))
                .ToArray();

            if (prog_ops.Length > 0 && tran_ops.Length > 0 && __prefix == "P")
            {
                GFolder folder = Create(__display_part_.FullPath);

                string[] paths = __display_part_.ComponentAssembly.RootComponent.GetChildren()
                    .Where(__c => __c.__IsLoaded())
                    .Where(__c => Regex.IsMatch(__c.Name, "^P(?<op>\\d\\d\\d)-"))
                    .Select(__c => __c.__Prototype().FullPath)
                    .ToArray();

                string[] children = __display_part_.ComponentAssembly.RootComponent.GetChildren()
                    .Select(__c => __c.Name)
                    .Where(__n => __n.StartsWith("P0"))
                    .ToArray();

                string max_op = __Op10To010(prog_ops.Max());

                string new_path = selected_full_path.Replace(selected_display_name, $"{cust_num}-P{max_op}-Layout");

                if (selected_op - 10 == int.Parse(max_op))
                    prog_P_TRANSFER(max_op, new_path, "P");
            }


            //if (__display_part_.ComponentAssembly.RootComponent)

            uf_.Modl.Update();
            update_sim_components();
        }

        public static void update_sim_components()
        {
            __display_part_.ComponentAssembly.RootComponent
                .GetChildren()
                .Where(child => child.Layer == 254)
                .Where(child => child.Name.ToUpper().Contains("SIMULATION"))
                .ToList()
                .ForEach(child => session_.__DeleteObjects(child));
        }

        public static void create(GFolder __folder, int __transfer_layouts, int __tran_presses, int __prog_layouts,
            int __prog_presses, bool __start_at_005, bool __offline_die)
        {
            if (!File.Exists(__folder.DirJob))
                Directory.CreateDirectory(__folder.DirJob);

            if (!File.Exists(__folder.DirLayout))
                Directory.CreateDirectory(__folder.DirLayout);

            if (!File.Exists(__folder.DirSimulation))
                Directory.CreateDirectory(__folder.DirSimulation);

            if (!File.Exists(__folder.PathSimulation))
            {
                print_("Couldn't find a simulation file");
                return;
            }

            if (!__offline_die)
                clone_non_offline_die(__folder, __transfer_layouts, __tran_presses, __prog_layouts, __prog_presses,
                    __transfer_layouts > 0 ? "900" : "010");
            else
                clone_offline_die(__folder, __prog_layouts, __transfer_layouts, __prog_presses, __tran_presses, "010");


            if (File.Exists(__folder.file_strip("010")))
                session_.__FindOrOpen(__folder.file_strip("010")).__AddComponent(
                    __folder.PathSimulation,
                    componentName: "SIMULATION-STRIP",
                    layer: 8);

            if (File.Exists(__folder.file_strip("900")))
                session_.__FindOrOpen(__folder.file_strip("900")).__AddComponent(
                    __folder.PathSimulation,
                    componentName: "SIMULATION-STRIP",
                    layer: 8);


            uf_.Modl.Update();
            __work_part_ = __display_part_;
            update_sim_components();

            __display_part_.__Save();

            foreach (Part __part in session_.Parts.ToArray())
                if (__part.IsModified && __part.Leaf.StartsWith(__folder.CustomerNumber))
                    __part.__Save();

            if (File.Exists(__folder.file_strip("010")))
                session_.Parts.SetActiveDisplay(session_.__FindOrOpen(__folder.file_strip("010")),
                    DisplayPartOption.AllowAdditional, PartDisplayPartWorkPartOption.SameAsDisplay, out _);

            if (File.Exists(__folder.file_strip("900")))
                session_.Parts.SetActiveDisplay(session_.__FindOrOpen(__folder.file_strip("900")),
                    DisplayPartOption.AllowAdditional, PartDisplayPartWorkPartOption.SameAsDisplay, out _);

            __display_part_.Layers.WorkLayer = 1;
            __display_part_.Layers.ChangeStates(new[] { new StateInfo { State = State.Selectable, Layer = 5 } });
            __display_part_.__Save();
        }

        public static void delete_prog_presses_from_display(GFolder __folder)
        {
            __display_part_.ComponentAssembly.RootComponent.GetChildren()
                .Where(__child => __child.DisplayName.StartsWith($"{__folder.CustomerNumber}-P"))
                .Where(__child => __child.DisplayName.EndsWith("-Press"))
                .ToList()
                .ForEach(__child => __child.__DeleteSelfAndConstraints());
        }

        public static void clone_non_offline_die(GFolder __folder, int __transfer_layouts, int __tran_presses,
            int __prog_layouts, int __prog_presses, string op)
        {
            string strip_tran_path = __folder.file_strip(op);
            ExecuteCloneStrip(__folder, strip_tran_path);
            Session.GetSession().__FindOrOpen(strip_tran_path);

            // add the prog layout-stations
            for (int i = 10; i < (__prog_layouts + 1) * 10; i += 10)
                try
                {
                    prog_work_lifted(__folder, __Op10To010(i), "P");
                }
                catch (Exception ex)
                {
                    ex.__PrintException();
                }

            // adds a P{last}-TRANSFER component if this is a transfer die and has prog stations
            if (__transfer_layouts > 0 && __prog_layouts > 0)
                try
                {
                    string op_str = __Op10To010(__prog_layouts * 10);
                    string layout_path = __folder.file_layout_p(op_str);
                    if (!File.Exists(layout_path))
                        File.Copy(XxxxxxOpXxxLayout, layout_path);
                    //prog_work(op_str, layout_path, "P");
                    //prog_lifted(op_str, layout_path, "P");
                    prog_P_TRANSFER(__Op10To010(__prog_layouts * 10), layout_path, "P");
                }
                catch (Exception ex)
                {
                    ex.__PrintException();
                }

            // add the transfer layout-stations
            for (int i = 10; i < (__transfer_layouts + 1) * 10; i += 10)
                try
                {
                    tran_work_lifted_transfer(__folder, __Op10To010(i), "T");
                }
                catch (Exception ex)
                {
                    ex.__PrintException();
                }

            // add the prog press-stations
            for (int i = 10; i < (__prog_presses + 1) * 10; i += 10)
                try
                {
                    add_press("P");
                }
                catch (Exception ex)
                {
                    ex.__PrintException();
                }

            // add the transfer press-stations
            for (int i = 10; i < (__tran_presses + 1) * 10; i += 10)
                try
                {
                    add_press("T");

                    __display_part_.__Save();
                }
                catch (Exception ex)
                {
                    ex.__PrintException();
                }
        }

        public static void tran_transfer(string op_str, string selected_part_path, string __prefix)
        {
            add_component_and_constrain(
                selected_part_path,
                op_str,
                102,
                $"{__prefix}{op_str}-TRANSFER",
                __prefix,
                "X",
                "Y",
                "ZTransfer"
            );
        }

        public static void tran_lifted(string op_str, string selected_part_path, string __prefix)
        {
            add_component_and_constrain(
                selected_part_path,
                op_str,
                101,
                $"{__prefix}{op_str}-LIFTED",
                __prefix,
                "X",
                "Y",
                "ZLifted"
            );
        }

        public static void tran_work(string op_str, string selected_part_path, string __prefix)
        {
            add_component_and_constrain(
                selected_part_path,
                op_str,
                100,
                $"{__prefix}{op_str}-WORK",
                __prefix,
                "X",
                "Y",
                "Z"
            );
        }

        public static void prog_lifted(string op_str, string selected_part_path, string __prefix)
        {
            add_component_and_constrain(
                selected_part_path,
                op_str,
                101,
                $"{__prefix}{op_str}-LIFTED",
                __prefix,
                "X",
                "Y",
                "ZLifted"
            );
        }

        public static void prog_work(string op_str, string selected_part_path, string __prefix)
        {
            add_component_and_constrain(
                selected_part_path,
                op_str,
                100,
                $"{__prefix}{op_str}-WORK",
                __prefix,
                "X",
                "Y",
                "Z"
            );
        }

        public static void prog_P_TRANSFER(string op_str, string selected_part_path, string __prefix)
        {
            add_component_and_constrain(
                selected_part_path,
                op_str,
                102,
                $"{__prefix}{op_str}-TRANSFER",
                __prefix,
                "X",
                "Y",
                "ZTransfer"
            );
        }

        public static void clone_offline_die(GFolder __folder, int __prog_layouts, int __transfer_layouts,
            int __prog_presses, int __tran_presses, string op)
        {
            string strip_tran_path = __folder.FileStrip900;
            string strip_prog_path = __folder.file_strip(op);
            ExecuteCloneStrip1(__folder, op, strip_prog_path);
            File.Copy(strip_prog_path, strip_tran_path);
            if (!File.Exists(strip_tran_path))
                File.Copy(XxxxxStrip, strip_tran_path);

            __display_part_ = session_.__FindOrOpen(strip_tran_path);

            // add the transfer layout-stations
            for (int i = 10; i < (__transfer_layouts + 1) * 10; i += 10)
                tran_work_lifted_transfer(__folder, __Op10To010(i), "T");

            // add the transfer press-stations
            for (int i = 10; i < (__tran_presses + 1) * 10; i += 10)
                add_press("T");

            try
            {
                session_.__FindOrOpen(__folder.PathStripFlange);

                Component obj = __display_part_.ComponentAssembly.RootComponent.__FindComponent(
                    $"COMPONENT {__folder.CustomerNumber}-Strip Flange Carrier_Tracking Tab 1");

                session_.__DeleteObjects(obj);
            }
            catch (Exception ex)
            {
                ex.__PrintException("Failed to delete strip flange");
            }

            __display_part_.__Save();

            if (!File.Exists(strip_prog_path))
                File.Copy(XxxxxStrip, strip_prog_path);
            __display_part_ = session_.__FindOrOpen(strip_prog_path);

            // add the prog layout-stations
            for (int i = 10; i < (__prog_layouts + 1) * 10; i += 10)
                prog_work_lifted(__folder, __Op10To010(i), "P");

            // add the prog press-stations
            for (int i = 10; i < (__prog_presses + 1) * 10; i += 10)
                add_press("P");
        }

        public static void tran_work_lifted_transfer(GFolder __folder, string op_str, string __prefix)
        {
            string layout_path = __folder.file_layout_t(op_str);
            if (!File.Exists(layout_path))
                File.Copy(XxxxxxOpXxxLayout, layout_path);
            tran_work(op_str, layout_path, __prefix);
            tran_lifted(op_str, layout_path, __prefix);
            tran_transfer(op_str, layout_path, __prefix);
        }

        public static void prog_work_lifted(GFolder __folder, string op_str, string __prefix)
        {
            string layout_path = __folder.file_layout_p(op_str);
            if (!File.Exists(layout_path))
                File.Copy(XxxxxxOpXxxLayout, layout_path);
            prog_work(op_str, layout_path, __prefix);
            prog_lifted(op_str, layout_path, __prefix);
        }

        public static void prog_transfer(GFolder __folder, string __op_str, string __prefix)
        {
            string layout_path = __folder.file_layout(__prefix, __op_str);
            if (!File.Exists(layout_path))
                File.Copy(XxxxxxOpXxxLayout, layout_path);
            prog_transfer(Create(__op_str), layout_path, __prefix);
        }


        public static void ExecuteCloneStrip1(GFolder __folder, string op, string strip_prog_path)
        {
            UFClone clone = uf_.Clone;
            clone.Terminate();
            clone.Initialise(UFClone.OperationClass.CloneOperation);
            clone.SetDefNaming(UFClone.NamingTechnique.UserName);
            clone.SetDryrun(false);
            clone.AddPart(XxxxxStrip);
            clone.SetNaming(XxxxxStrip, UFClone.NamingTechnique.UserName, strip_prog_path);
            if (op != "900")
            {
                clone.AddPart(StripFlangeCarrierTracking);
                clone.SetNaming(StripFlangeCarrierTracking, UFClone.NamingTechnique.UserName,
                    __folder.PathStripFlange);
            }

            clone.InitNamingFailures(out UFClone.NamingFailures failures);
            clone.PerformClone(ref failures);
            clone.Terminate();
        }


        public static void ExecuteCloneStrip(GFolder __folder, string strip_tran_path)
        {
            UFClone clone = uf_.Clone;
            clone.Terminate();
            clone.Initialise(UFClone.OperationClass.CloneOperation);
            clone.SetDefNaming(UFClone.NamingTechnique.UserName);
            clone.SetDryrun(false);
            clone.AddPart(XxxxxStrip);
            clone.SetNaming(XxxxxStrip, UFClone.NamingTechnique.UserName, strip_tran_path);

            if (!File.Exists(__folder.PathStripFlange))
            {
                clone.AddPart(StripFlangeCarrierTracking);
                clone.SetNaming(StripFlangeCarrierTracking, UFClone.NamingTechnique.UserName,
                    __folder.PathStripFlange);
            }

            clone.InitNamingFailures(out UFClone.NamingFailures failures);
            clone.PerformClone(ref failures);
            clone.Terminate();
        }
    }
}
// 980