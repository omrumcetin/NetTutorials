using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Linq;

namespace MrParser
{
    public sealed class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = File.OpenText(@"d:\Works\P\Parse\PIx4FB5E7E8D5C01ACEECD2C9F471BDBxADKILLx20190305x111243x40xHWI4GxSCRIPTEXEC_20190305111507_USON_1668.rst");
            string line;
            var cpuUsage = new CpuUsage();
            var cellUeCntList = new List<CellUeCnt>();
            var columns = new List<string>();
            var UEsAccessStatisticalInfoTab = false;
            var CpuPowerInfoTab = false;
            while ((line = reader.ReadLine()) != null)
            {
                if (line == "")
                    continue;
                line = Regex.Replace(line,@"\ {2,300}",",");
                if(line.StartsWith("(Number of Result",StringComparison.OrdinalIgnoreCase))
                {
                    UEsAccessStatisticalInfoTab = false;
                    CpuPowerInfoTab = false;
                    columns.Clear();
                }
                if (CpuPowerInfoTab)
                {
                    var valueItems = line.Split(',');
                    var columnAndValueMap = columns.Zip(valueItems, (x, y) => new { column = x, value = y });
                    foreach (var pair in columnAndValueMap)
                    {
                        switch (pair.column)
                        {
                            case ("Cabinet No."):
                                cpuUsage.CN = pair.value;
                                break;
                            case ("Subrack No."):
                                cpuUsage.SRN = pair.value;
                                break;
                            case ("Slot No."):
                                cpuUsage.SN = pair.value;
                                break;
                            case ("Object Type"):
                                cpuUsage.ObjectType = pair.value;
                                break;
                            case ("Object Number"):
                                cpuUsage.ObjectNumber = pair.value;
                                break;
                            case ("CPU/DSP Usage(%)"):
                                cpuUsage.CPUUsage = pair.value;
                                break;
                        }
                    }
                }

                if (UEsAccessStatisticalInfoTab)
                {
                    var cellUeCnt = new CellUeCnt();
                    var valueItems = line.Split(',');
                    var columnAndValueMap = columns.Zip(valueItems, (x, y) => new { column = x, value = y });
                    foreach (var pair in columnAndValueMap)
                    {
                        switch (pair.column)
                        {
                            case ("Local Cell ID"):
                                cellUeCnt.LocalCellId = pair.value;
                                break;
                            case ("Cell Name"):
                                cellUeCnt.CellName = pair.value;
                                break;
                            case ("Cell MO-Signal Counter"):
                                cellUeCnt.MoSignalCounter = pair.value;
                                break;
                            case ("Cell MO-Data Counter"):
                                cellUeCnt.MoDataCounter = pair.value;
                                break;
                            case ("Cell MT-Access Counter"):
                                cellUeCnt.MTAccessCounter = pair.value;
                                break;
                            case ("Cell Other Counter"):
                                cellUeCnt.OtherCounter = pair.value;
                                break;
                            case ("Cell Total Counter"):
                                cellUeCnt.TotalCounter = pair.value;
                                break;
                            case ("Cell VoLTE Counter"):
                                cellUeCnt.VoLTECounter = pair.value;
                                break;
                            case ("Cell CA Counter"):
                                cellUeCnt.CACounter = pair.value;
                                break;
                        }                       
                    }
                    cellUeCntList.Add(cellUeCnt);
                    continue;
                }
                if(line.StartsWith("Local Cell Id", StringComparison.OrdinalIgnoreCase))
                {
                    var columnItems = line.Split(',');
                    foreach (var column in columnItems)
                    {
                        columns.Add(column);
                    }
                    UEsAccessStatisticalInfoTab = true;
                }
                if (line.StartsWith("Cabinet No.", StringComparison.OrdinalIgnoreCase))
                {
                    var columnItems = line.Split(',');
                    foreach (var column in columnItems)
                    {
                        columns.Add(column);
                    }
                    CpuPowerInfoTab = true;
                }
            }
            var response = new { cpuUsage = cpuUsage, cellUeCnt = cellUeCntList };

            var stop =1;
        }
    }
}
    