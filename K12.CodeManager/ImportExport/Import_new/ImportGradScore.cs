using System;
using System.Collections.Generic;
using System.Text;
using SmartSchool.API.PlugIn;
using System.Xml;
using System.Threading;
using K12.Data;

namespace K12Code.Management.Module
{
    class ImportGradScore : SmartSchool.API.PlugIn.Import.Importer
    {
        private List<string> Domains;

        public ImportGradScore()
        {
            this.Image = null;
            this.Text = "匯入學生家長代碼(NEW)";

            Domains = new List<string>();
            Domains.AddRange(new string[] { "學生代碼", "家長代碼" });
        }

        public override void InitializeImport(SmartSchool.API.PlugIn.Import.ImportWizard wizard)
        {
            Dictionary<string, int> _ID_SchoolYear_Semester_GradeYear = new Dictionary<string, int>();
            Dictionary<string, List<string>> _ID_SchoolYear_Semester_Subject = new Dictionary<string, List<string>>();
            Dictionary<string, StudentRecord> _StudentCollection = new Dictionary<string, StudentRecord>();
            Dictionary<StudentRecord, Dictionary<int, decimal>> _StudentPassScore = new Dictionary<StudentRecord, Dictionary<int, decimal>>();

            wizard.PackageLimit = 500;
            wizard.ImportableFields.AddRange("學生代碼", "家長代碼");

            //沒有必要欄位
            //wizard.RequiredFields.AddRange("學生代碼", "家長代碼");

            wizard.ValidateStart += delegate(object sender, SmartSchool.API.PlugIn.Import.ValidateStartEventArgs e)
            {
                #region ValidateStart
                _ID_SchoolYear_Semester_GradeYear.Clear();
                _ID_SchoolYear_Semester_Subject.Clear();
                _StudentCollection.Clear();

                List<StudentRecord> list = Student.SelectByIDs(e.List);
                //建立學生ID清單
                foreach (StudentRecord stu in list)
                {
                    if (!_StudentCollection.ContainsKey(stu.ID))
                        _StudentCollection.Add(stu.ID, stu);
                }

                MultiThreadWorker<StudentRecord> loader = new MultiThreadWorker<StudentRecord>();
                loader.MaxThreads = 3;
                loader.PackageSize = 250;
                loader.PackageWorker += delegate(object sender1, PackageWorkEventArgs<StudentRecord> e1)
                {
                    //執行此資料 e.List

                };
                loader.Run(list);


                #endregion
            };
            wizard.ValidateRow += delegate(object sender, SmartSchool.API.PlugIn.Import.ValidateRowEventArgs e)
            {
                #region ValidateRow
                decimal d;
                StudentRecord student;
                if (_StudentCollection.ContainsKey(e.Data.ID))
                {
                    student = _StudentCollection[e.Data.ID];
                }
                else
                {
                    e.ErrorMessage = "沒有這個學生" + e.Data.ID;
                    return;
                }
                bool inputFormatPass = true;

                #region 驗各欄位填寫格式
                foreach (string field in e.SelectFields)
                {
                    string value = e.Data[field];
                    switch (field)
                    {
                        default:
                            break;
                        case "學生代碼":
                            if (value == "")
                            {
                                //檢查是否重覆資料
                                inputFormatPass &= false;
                                e.ErrorFields.Add(field, "學生代碼不可重覆!!");
                            }

                            break;
                        case "家長代碼":
                            if (value == "")
                            {
                                //檢查是否重覆資料
                                inputFormatPass &= false;
                                e.ErrorFields.Add(field, "家長代碼不可重覆!!");
                            }
                            break;
                    }
                }
                #endregion
                //輸入格式正確才會針對情節做檢驗
                if (inputFormatPass)
                {
                    string errorMessage = "";

                    string key = e.Data.ID;
                    string skey = e.Data["學生代碼"];

                    if (!_ID_SchoolYear_Semester_Subject.ContainsKey(key))
                        _ID_SchoolYear_Semester_Subject.Add(key, new List<string>());
                    if (_ID_SchoolYear_Semester_Subject[key].Contains(skey))
                    {
                        errorMessage += (errorMessage == "" ? "" : "\n") + "同一學生不允許多筆相同畢業領域的資料";
                    }
                    else
                        _ID_SchoolYear_Semester_Subject[key].Add(skey);

                    e.ErrorMessage = errorMessage;
                }
                #endregion
            };

            wizard.ImportPackage += delegate(object sender, SmartSchool.API.PlugIn.Import.ImportPackageEventArgs e)
            {
                //    #region ImportPackage
                //    Dictionary<string, List<RowData>> id_Rows = new Dictionary<string, List<RowData>>();
                //    #region 分包裝
                //    foreach (RowData data in e.Items)
                //    {
                //        if (!id_Rows.ContainsKey(data.ID))
                //            id_Rows.Add(data.ID, new List<RowData>());
                //        id_Rows[data.ID].Add(data);
                //    }
                //    #endregion

                //    Dictionary<string, GradScoreRecordEditor> gradDict = new Dictionary<string, GradScoreRecordEditor>();

                //    //交叉比對各學生資料
                //    #region 交叉比對各學生資料
                //    foreach (string id in id_Rows.Keys)
                //    {
                //        StudentRecord studentRec = _StudentCollection[id];

                //        GradScoreRecord record = GradScore.Instance.Items[studentRec.ID];
                //        GradScoreRecordEditor editor = null;
                //        if (record != null)
                //            editor = record.GetEditor();
                //        else
                //            editor = new GradScoreRecordEditor(Student.Instance.Items[studentRec.ID]);

                //        if (!gradDict.ContainsKey(studentRec.ID))
                //            gradDict.Add(studentRec.ID, editor);

                //        //要匯入的學期科目成績
                //        Dictionary<string, RowData> importScoreDictionary = new Dictionary<string, RowData>();

                //        #region 整理要匯入的資料
                //        foreach (RowData row in id_Rows[id])
                //        {
                //            string domain = row["領域"];

                //            if (!importScoreDictionary.ContainsKey(domain))
                //                importScoreDictionary.Add(domain, row);
                //        }
                //        #endregion

                //        //開始處理ImportScore
                //        foreach (string domain in importScoreDictionary.Keys)
                //        {
                //            RowData data = importScoreDictionary[domain];
                //            if (domain == "學習領域")
                //            {
                //                decimal d;
                //                if (decimal.TryParse(data["分數評量"], out d))
                //                    editor.LearnDomainScore = d;
                //                else
                //                    editor.LearnDomainScore = null;
                //            }
                //            else if (domain == "課程學習")
                //            {
                //                decimal d;
                //                if (decimal.TryParse(data["分數評量"], out d))
                //                    editor.CourseLearnScore = d;
                //                else
                //                    editor.CourseLearnScore = null;
                //            }
                //            else
                //            {
                //                if (!editor.Domains.ContainsKey(domain))
                //                    editor.Domains.Add(domain, new GradDomainScore(domain));
                //                decimal d;
                //                if (decimal.TryParse(data["分數評量"], out d))
                //                    editor.Domains[domain].Score = d;
                //                else
                //                    editor.Domains[domain].Score = null;
                //            }
                //        }
                //    }
                //    #endregion

                //    if (gradDict.Values.Count > 0)
                //    {
                //        #region 分批次兩路上傳
                //        List<List<GradScoreRecordEditor>> updatePackages = new List<List<GradScoreRecordEditor>>();
                //        List<List<GradScoreRecordEditor>> updatePackages2 = new List<List<GradScoreRecordEditor>>();
                //        {
                //            List<GradScoreRecordEditor> package = null;
                //            int count = 0;
                //            foreach (GradScoreRecordEditor var in gradDict.Values)
                //            {
                //                if (count == 0)
                //                {
                //                    package = new List<GradScoreRecordEditor>(30);
                //                    count = 30;
                //                    if ((updatePackages.Count & 1) == 0)
                //                        updatePackages.Add(package);
                //                    else
                //                        updatePackages2.Add(package);
                //                }
                //                package.Add(var);
                //                count--;
                //            }
                //        }
                //        Thread threadUpdateSemesterSubjectScore = new Thread(new ParameterizedThreadStart(updateSemesterSubjectScore));
                //        threadUpdateSemesterSubjectScore.IsBackground = true;
                //        threadUpdateSemesterSubjectScore.Start(updatePackages);

                //        Thread threadUpdateSemesterSubjectScore2 = new Thread(new ParameterizedThreadStart(updateSemesterSubjectScore));
                //        threadUpdateSemesterSubjectScore2.IsBackground = true;
                //        threadUpdateSemesterSubjectScore2.Start(updatePackages2);

                //        threadUpdateSemesterSubjectScore.Join();
                //        threadUpdateSemesterSubjectScore2.Join();
                //        #endregion
                //    }

                //    FISCA.LogAgent.ApplicationLog.Log("匯入學生家長代碼", "匯入", "已匯入。");
                //    #endregion
                //};
                //wizard.ImportComplete += delegate
                //{
                //    //EventHub.Instance.InvokScoreChanged(new List<string>(_StudentCollection.Keys).ToArray());
            };
        }

        private void updateSemesterSubjectScore(object item)
        {
            //List<List<GradScoreRecordEditor>> updatePackages = (List<List<GradScoreRecordEditor>>)item;
            //foreach (List<GradScoreRecordEditor> package in updatePackages)
            //{
            //    package.SaveAllEditors();
            //}
        }
    }
}
