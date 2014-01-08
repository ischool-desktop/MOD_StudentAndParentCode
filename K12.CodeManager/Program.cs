using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using FISCA.Permission;
using FISCA.Presentation;
using FISCA.Presentation.Controls;
using K12.Data;
using System.Data;
using System.Windows.Forms;

namespace K12Code.Management.Module
{
    public class Program
    {
        [MainMethod()]
        public static void Main()
        {
            Campus.DocumentValidator.FactoryProvider.FieldFactory.Add(new FieldValidatorFactory());

            FeatureAce UserPermission = FISCA.Permission.UserAcl.Current[Permissions.帳號與親子關係];
            if (UserPermission.Editable)
                K12.Presentation.NLDPanels.Student.AddDetailBulider(new FISCA.Presentation.DetailBulider<StudentItem>());

            UserPermission = FISCA.Permission.UserAcl.Current[Permissions.教師代碼];
            if (UserPermission.Editable)
                K12.Presentation.NLDPanels.Teacher.AddDetailBulider(new FISCA.Presentation.DetailBulider<TeacherItem>());

            #region 學生代碼管理

            UserPermission = FISCA.Permission.UserAcl.Current[Permissions.批次產生學生代碼];
            if (UserPermission.Executable)
            {
                RibbonBarItem bh = K12.Presentation.NLDPanels.Student.RibbonBarItems["代碼"];
                bh["代碼管理"].Size = RibbonBarButton.MenuButtonSize.Large;
                bh["代碼管理"].Image = Properties.Resources.vector_to_raster_64;
                bh["代碼管理"]["產生學生代碼"].Enable = Permissions.批次產生學生代碼權限;
                bh["代碼管理"]["產生學生代碼"].Click += delegate
                {

                    RunCode.Run_GenerateCode();
                };

                MenuButton menuButton = K12.Presentation.NLDPanels.Student.ListPaneContexMenu["代碼管理"];
                menuButton.Image = Properties.Resources.vector_to_raster_64;
                menuButton["產生學生代碼"].Enable = Permissions.批次產生學生代碼權限;
                menuButton["產生學生代碼"].Click += delegate
                {
                    RunCode.Run_GenerateCode();
                };
            }

            UserPermission = FISCA.Permission.UserAcl.Current[Permissions.批次清除學生代碼];
            if (UserPermission.Executable)
            {
                RibbonBarItem bh = K12.Presentation.NLDPanels.Student.RibbonBarItems["代碼"];
                bh["代碼管理"].Size = RibbonBarButton.MenuButtonSize.Large;
                bh["代碼管理"].Image = Properties.Resources.vector_to_raster_64;
                bh["代碼管理"]["清除學生代碼"].Enable = Permissions.批次清除學生代碼權限;
                bh["代碼管理"]["清除學生代碼"].Click += delegate
                {
                    RunCode.Run_ClearCode();
                };

                MenuButton menuButton = K12.Presentation.NLDPanels.Student.ListPaneContexMenu["代碼管理"];
                menuButton.Image = Properties.Resources.vector_to_raster_64;
                menuButton["清除學生代碼"].Enable = Permissions.批次清除學生代碼權限;
                menuButton["清除學生代碼"].Click += delegate
                {
                    RunCode.Run_ClearCode();
                };
            }

            #endregion

            #region 家長代碼管理
            UserPermission = FISCA.Permission.UserAcl.Current[Permissions.批次產生家長代碼];
            if (UserPermission.Executable)
            {
                RibbonBarItem bh = K12.Presentation.NLDPanels.Student.RibbonBarItems["代碼"];
                bh["代碼管理"].Size = RibbonBarButton.MenuButtonSize.Large;
                bh["代碼管理"].Image = Properties.Resources.vector_to_raster_64;
                bh["代碼管理"]["產生家長代碼"].Enable = Permissions.批次產生家長代碼權限;
                bh["代碼管理"]["產生家長代碼"].Click += delegate
                {
                    RunCode.Run_GenerateCode2();
                };

                MenuButton menuButton = K12.Presentation.NLDPanels.Student.ListPaneContexMenu["代碼管理"];
                menuButton.Image = Properties.Resources.vector_to_raster_64;
                menuButton["產生家長代碼"].Enable = Permissions.批次產生家長代碼權限;
                menuButton["產生家長代碼"].Click += delegate
                {
                    RunCode.Run_GenerateCode2();

                };
            }

            UserPermission = FISCA.Permission.UserAcl.Current[Permissions.批次清除家長代碼];
            if (UserPermission.Executable)
            {
                RibbonBarItem bh = K12.Presentation.NLDPanels.Student.RibbonBarItems["代碼"];
                bh["代碼管理"].Size = RibbonBarButton.MenuButtonSize.Large;
                bh["代碼管理"].Image = Properties.Resources.vector_to_raster_64;
                bh["代碼管理"]["清除家長代碼"].Enable = Permissions.批次清除家長代碼權限;
                bh["代碼管理"]["清除家長代碼"].Click += delegate
                {
                    RunCode.Run_ClearCode2();
                };

                MenuButton menuButton = K12.Presentation.NLDPanels.Student.ListPaneContexMenu["代碼管理"];
                menuButton.Image = Properties.Resources.vector_to_raster_64;
                menuButton["清除家長代碼"].Enable = Permissions.批次清除家長代碼權限;
                menuButton["清除家長代碼"].Click += delegate
                {
                    RunCode.Run_ClearCode2();
                };
            }

            UserPermission = FISCA.Permission.UserAcl.Current[Permissions.快速檢視代碼清單];
            if (UserPermission.Executable)
            {
                RibbonBarItem bh = K12.Presentation.NLDPanels.Student.RibbonBarItems["代碼"];
                bh["代碼管理"].Size = RibbonBarButton.MenuButtonSize.Large;
                bh["代碼管理"].Image = Properties.Resources.vector_to_raster_64;
                bh["代碼管理"]["檢視代碼"].Enable = Permissions.快速檢視代碼清單權限;
                bh["代碼管理"]["檢視代碼"].Click += delegate
                {
                    RunCode.Run_ViewCode();
                };

                MenuButton menuButton = K12.Presentation.NLDPanels.Student.ListPaneContexMenu["代碼管理"];
                menuButton.Image = Properties.Resources.vector_to_raster_64;
                menuButton["檢視代碼"].Enable = Permissions.快速檢視代碼清單權限;
                menuButton["檢視代碼"].Click += delegate
                {
                    RunCode.Run_ViewCode();
                };
            }
            #endregion

            #region 老師代碼管理

            UserPermission = FISCA.Permission.UserAcl.Current[Permissions.批次產生教師代碼];
            if (UserPermission.Executable)
            {
                RibbonBarItem bh = K12.Presentation.NLDPanels.Teacher.RibbonBarItems["代碼"];
                bh["代碼管理"].Size = RibbonBarButton.MenuButtonSize.Large;
                bh["代碼管理"].Image = Properties.Resources.vector_to_raster_64;
                bh["代碼管理"]["產生教師代碼"].Enable = Permissions.批次產生教師代碼權限;
                bh["代碼管理"]["產生教師代碼"].Click += delegate
                {
                    RunCode.Run_GenerateCode3();
                };

                MenuButton menuButton = K12.Presentation.NLDPanels.Teacher.ListPaneContexMenu["代碼管理"];
                menuButton.Image = Properties.Resources.vector_to_raster_64;
                menuButton["產生教師代碼"].Enable = Permissions.批次產生教師代碼權限;
                menuButton["產生教師代碼"].Click += delegate
                {
                    RunCode.Run_GenerateCode3();
                };
            }

            UserPermission = FISCA.Permission.UserAcl.Current[Permissions.批次清除教師代碼];
            if (UserPermission.Executable)
            {
                RibbonBarItem bh = K12.Presentation.NLDPanels.Teacher.RibbonBarItems["代碼"];
                bh["代碼管理"].Size = RibbonBarButton.MenuButtonSize.Large;
                bh["代碼管理"].Image = Properties.Resources.vector_to_raster_64;
                bh["代碼管理"]["清除教師代碼"].Enable = Permissions.批次清除教師代碼權限;
                bh["代碼管理"]["清除教師代碼"].Click += delegate
                {
                    RunCode.Run_ClearCode3();
                };

                MenuButton menuButton = K12.Presentation.NLDPanels.Teacher.ListPaneContexMenu["代碼管理"];
                menuButton.Image = Properties.Resources.vector_to_raster_64;
                menuButton["清除教師代碼"].Enable = Permissions.批次清除教師代碼權限;
                menuButton["清除教師代碼"].Click += delegate
                {
                    RunCode.Run_ClearCode3();
                };
            }

            UserPermission = FISCA.Permission.UserAcl.Current[Permissions.快速檢視教師代碼清單];
            if (UserPermission.Executable)
            {
                RibbonBarItem bh = K12.Presentation.NLDPanels.Teacher.RibbonBarItems["代碼"];
                bh["代碼管理"].Size = RibbonBarButton.MenuButtonSize.Large;
                bh["代碼管理"].Image = Properties.Resources.vector_to_raster_64;
                bh["代碼管理"]["檢視教師代碼"].Enable = Permissions.快速檢視教師代碼清單權限;
                bh["代碼管理"]["檢視教師代碼"].Click += delegate
                {
                    RunCode.Run_ViewCode3();
                };

                MenuButton menuButton = K12.Presentation.NLDPanels.Teacher.ListPaneContexMenu["代碼管理"];
                menuButton.Image = Properties.Resources.vector_to_raster_64;
                menuButton["檢視教師代碼"].Enable = Permissions.快速檢視教師代碼清單權限;
                menuButton["檢視教師代碼"].Click += delegate
                {
                    RunCode.Run_ViewCode3();
                };
            }

            #endregion

            #region 匯出匯入
            RibbonBarItem Report = K12.Presentation.NLDPanels.Student.RibbonBarItems["資料統計"];
            Report["匯出"]["代碼相關匯出"]["匯出學生家長代碼"].Enable = Permissions.匯出學生家長代碼權限;
            Report["匯出"]["代碼相關匯出"]["匯出學生家長代碼"].Click += delegate
            {
                SmartSchool.API.PlugIn.Export.Exporter exporter = new ExportStudentAndParent();
                ExportStudentV2 wizard = new ExportStudentV2(exporter.Text, exporter.Image);
                exporter.InitializeExport(wizard);
                wizard.ShowDialog();
            };

            Report["匯入"]["代碼相關匯入"]["匯入學生家長代碼"].Enable = Permissions.匯入學生家長代碼權限;
            Report["匯入"]["代碼相關匯入"]["匯入學生家長代碼"].Click += delegate
            {
                ImportStudentAndParent wizard = new ImportStudentAndParent();
                wizard.Execute();
            }; 
            #endregion

            #region 報表
            RibbonBarItem edit = K12.Presentation.NLDPanels.Class.RibbonBarItems["資料統計"];
            edit["報表"]["代碼相關報表"]["班級學生家長代碼表"].Enable = Permissions.班級學生家長代碼表權限;
            edit["報表"]["代碼相關報表"]["班級學生家長代碼表"].Click += delegate
            {
                ClassStudentParentCode insert = new ClassStudentParentCode();
                insert.ShowDialog();
            };

            edit = K12.Presentation.NLDPanels.Student.RibbonBarItems["資料統計"];
            edit["報表"]["代碼相關報表"]["學生家長代碼邀請函"].Enable = Permissions.學生家長代碼邀請函碼權限;
            edit["報表"]["代碼相關報表"]["學生家長代碼邀請函"].Click += delegate
            {
                ParentInvitations insert = new ParentInvitations();
                insert.ShowDialog();
            }; 
            #endregion

            #region 權限代碼

            Catalog detail = RoleAclSource.Instance["學生"]["資料項目"];
            detail.Add(new DetailItemFeature(Permissions.帳號與親子關係, "代碼與親屬關係"));

            detail = RoleAclSource.Instance["學生"]["功能按鈕"];
            detail.Add(new ReportFeature(Permissions.學生家長代碼邀請函, "學生家長代碼邀請函"));
            detail.Add(new ReportFeature(Permissions.批次產生學生代碼, "產生學生代碼"));
            detail.Add(new ReportFeature(Permissions.批次清除學生代碼, "清除學生代碼"));
            detail.Add(new ReportFeature(Permissions.批次產生家長代碼, "產生家長代碼"));
            detail.Add(new ReportFeature(Permissions.批次清除家長代碼, "清除家長代碼"));
            detail.Add(new ReportFeature(Permissions.快速檢視代碼清單, "檢視代碼"));

            detail = RoleAclSource.Instance["學生"]["匯出/匯入"];
            detail.Add(new ReportFeature(Permissions.匯出學生家長代碼, "匯出學生家長代碼"));
            detail.Add(new ReportFeature(Permissions.匯入學生家長代碼, "匯入學生家長代碼"));

            detail = RoleAclSource.Instance["班級"]["功能按鈕"];
            detail.Add(new ReportFeature(Permissions.班級學生家長代碼表, "班級學生家長代碼表"));

            detail = RoleAclSource.Instance["教師"]["功能按鈕"];
            detail.Add(new ReportFeature(Permissions.批次產生教師代碼, "產生教師代碼"));
            detail.Add(new ReportFeature(Permissions.批次清除教師代碼, "清除教師代碼"));
            detail.Add(new ReportFeature(Permissions.快速檢視教師代碼清單, "檢視教師代碼"));

            detail = RoleAclSource.Instance["教師"]["資料項目"];
            detail.Add(new DetailItemFeature(Permissions.教師代碼, "教師代碼"));

            #endregion
        }
    }
}
