﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Siemens.Engineering.SW.Tags;
using Siemens.Engineering.VersionControl;
using PlcSoftAnalyzer.Model;

namespace PlcSoftAnalyzer.ViewModel
{
    public class TagRefReportViewModel : ViewModelBase
    {
        private FlowDocument _tagRefReport;
        //private Dictionary<int, int> _referenceTagsDict;
        private List<TagTableRefReport> reportSource;
        public FlowDocument TagRefReport
        {
            get { return _tagRefReport; }
            set
            {  _tagRefReport = value;
                OnPropertyChanged(nameof(TagRefReport));}
            }

        public TagRefReportViewModel() { }
        public TagRefReportViewModel(List<TagTableRefReport> report)
        {
            reportSource = report;
            GenerateReport();
        }
        public void GenerateReport()
        {
            FlowDocument doc = new FlowDocument();
            doc.Blocks.Add(new Paragraph(new Run("PLC soft analyzer report"))
            {
                FontSize = 20,
                FontWeight = System.Windows.FontWeights.Bold,
                TextAlignment = TextAlignment.Center
            });
            if (reportSource != null)
            {
                foreach (var source in reportSource)
                {
                    var outOfLimitTags = 0;
                    doc.Blocks.Add(new Paragraph(new Run($"{source.TableName}")) { FontWeight = FontWeights.Bold });
                    foreach (var type in source.RefOutOfLimitData)
                    {
                        outOfLimitTags += type.Value.Count;
                        doc.Blocks.Add(new Paragraph(new Run($"\t {type.Value.Count} {type.Key} tags references out of limit")));
                    }
                    if (source.TagsAmount > 0)
                    {
                        double invalidTagPercentage = ((double)outOfLimitTags / source.TagsAmount) * 100.0;
                        doc.Blocks.Add(new Paragraph(new Run($"\t Summury: {invalidTagPercentage:F2}% ({outOfLimitTags} from {source.TagsAmount})")));
                    }
                }
            }
            TagRefReport = doc;
        }
        public void CleanReport()
        { 
            TagRefReport.Blocks.Clear(); 
        }
    }
}
